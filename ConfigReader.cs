using System;
using System.Collections.Generic;
using System.Xml;

namespace TurnCtrl
{
    public class AsokupeConfig
    {
        public string Name
        {
            get => map.DocumentElement.GetAttribute("Name");
            set => map.DocumentElement.SetAttribute("Name", value);
        }
        public int E
        {
            get => Convert.ToInt32(map.DocumentElement.GetAttribute("E"));
            set => map.DocumentElement.SetAttribute("E", value.ToString());
        }
        public DateTime MapLastModify
        {
            get => new DateTime(1970, 1, 1).AddSeconds(Convert.ToInt32(map.DocumentElement.GetAttribute("LastModify")));
            set => map.DocumentElement.SetAttribute("LastModify", ((int)value.Subtract(new DateTime(1970, 1, 1)).TotalSeconds).ToString());
        }

        public XmlDocument map;

        public AsokupeConfig(XmlDocument map)
        {
            this.map = map;
        }

        public string Validate()
        {
            string Output = string.Empty;
            #region Проверка на дубликаты проходов
            List<byte> passNums = new List<byte>();
            byte tmp;
            foreach (XmlAttribute a in map.DocumentElement.SelectNodes("Group/Line/Turn[@PassNum]/@PassNum"))
            {

                tmp = Convert.ToByte(a.Value);

                if (tmp == 0 || passNums.Contains(tmp))
                    continue;
                XmlNodeList nl = map.DocumentElement.SelectNodes("Group/Line/Turn[@PassNum=\"" + tmp + "\"]");
                if (nl.Count > 1)
                {
                    Output += "Несколько проходов с №" + tmp + ":\r\n";
                    foreach (XmlElement el in nl)
                        Output += "\t" + GetHumanPathOfPass(el) + "\r\n";
                }
                passNums.Add(tmp);
            }

            passNums.Clear();
            #endregion
            #region проверка на порт
            XmlNodeList tmpnl = map.DocumentElement.SelectNodes("Group/Line/Turn[@Port]");
            if (tmpnl.Count != 0)
            {
                Output += "Не указан порт для " + tmpnl.Count + " проходов:\r\n";

                foreach (XmlElement a in tmpnl)
                {
                    Output += "\t" + GetHumanPathOfPass(a) + "\r\n";
                }
            }
            #endregion

            Console.WriteLine();
            return Output;
        }

        public string GetHumanPathOfPass(XmlElement el)
        {
            return ((XmlElement)el.ParentNode.ParentNode).GetAttribute("Name") + " -> " + ((XmlElement)el.ParentNode).GetAttribute("Name") + " -> " + el.GetAttribute("PassNum");
        }

        public void SaveMap(Station station, string Path)
        {
            map.RemoveChild(map.DocumentElement);
            XmlElement stel = map.CreateElement("Station");
            stel.SetAttribute("Name", station.Properties.Name);
            stel.SetAttribute("E", station.Properties.ExpressCode.ToString());
            stel.SetAttribute("Ver", System.Reflection.Assembly.LoadFrom("TurnCtrl.dll").GetName().Version.ToString());
            map.AppendChild(stel);
            foreach (LineGroup lgp in station.getGroups())
            {

                XmlElement lgel = map.CreateElement("Group");
                lgel.SetAttribute("Order", lgp.Properties.Id.ToString());
                lgel.SetAttribute("Name", lgp.Properties.Name);
                stel.AppendChild(lgel);
                foreach (TurnLine ln in lgp.getTurnLines())
                {
                    XmlElement lnel = map.CreateElement("Line");
                    lnel.SetAttribute("Order", ln.Properties.Id.ToString());
                    lnel.SetAttribute("Name", ln.Properties.Name);
                    lnel.SetAttribute("Type", ln.Properties.TurnstileModel.ToString());
                    lgel.AppendChild(lnel);

                    Turnstile[] turns = ln.getTurnstiles();
                    XmlElement tEl = map.CreateElement("Turn");
                    tEl.SetAttribute("Order", "0");
                    tEl.SetAttribute("SN", turns[1].Properties.LeftRack.SerialNum.ToString());
                    tEl.SetAttribute("IN", turns[1].Properties.LeftRack.InventoryNum);
                    lnel.AppendChild(tEl);
                    foreach (Turnstile t in turns)
                    {
                        tEl = map.CreateElement("Turn");

                        tEl.SetAttribute("PassNum", t.Properties.Number.ToString());

                        tEl.SetAttribute("Order", t.Properties.Order.ToString());
                        tEl.SetAttribute("SN", t.Properties.RightRack.SerialNum.ToString());
                        tEl.SetAttribute("IN", t.Properties.RightRack.InventoryNum);


                        Bool2Attr(tEl, "Baggage", t.Properties.Baggage);
                        Bool2Attr(tEl, "Express", t.Properties.Express);
                        Bool2Attr(tEl, "InEnable", t.Properties.InEnable);
                        Bool2Attr(tEl, "OutEnable", t.Properties.OutEnable);


                        tEl.SetAttribute("Port", t.Properties.Wire.Port);
                        tEl.SetAttribute("Address", t.Properties.Wire.Address.ToString());



                        lnel.AppendChild(tEl);


                    }
                }

            }
            MapLastModify = DateTime.Now;
            map.Save(Path);
        }


        /// <summary>
        /// Создает элементы управления
        /// </summary>
        /// <param name="station">Элемент управления Station, в котором будут расположена визуализация остановочного пункта</param>
        /// <param name="editable">Признак, определяющий, какие функции будут доступны на элементах управления</param>
        public void DrawMap(Station station, bool editable)
        {
            station.Properties.Name = map.DocumentElement.GetAttribute("Name");
            station.Properties.ExpressCode = Convert.ToInt32(map.DocumentElement.GetAttribute("E"));
            foreach (XmlElement lgEl in map.DocumentElement.SelectNodes("Group"))
            {
                LineGroup lg = station.LineGroupAdd(CreateLineGroupProperties(lgEl));
                lg.HeaderClick += station.GroupHeaderClick;
                foreach (XmlElement lnEl in lgEl.SelectNodes("Line"))
                {
                    TurnLine ln = lg.addLine(CreateTurnLineProperties(lnEl));
                    ln.HeaderClick += station.LineHeaderClick;
                    RackProperties prevRack = CreateRackProperty((XmlElement)lnEl.SelectSingleNode("Turn[@Order=\"0\"]"));
                    for (int i = 1; i < lnEl.SelectNodes("Turn").Count; i++)
                    {
                        XmlElement tEl = (XmlElement)lnEl.SelectSingleNode("Turn[@Order=\"" + i + "\"]");
                        PassProperies p = CreatePassProperty(tEl, prevRack, editable);
                        Turnstile t = ln.addTurnstile(p);
                        t.PassNumClick += station.PassNumClick;
                        prevRack = p.RightRack;
                        t.Compose();
                    }
                    ln.Compose();
                }
                lg.Compose();
            }
            station.Compose();
        }

        /// <summary>
        /// Возвращает булево значение аттрибута указанного элемента
        /// </summary>
        /// <param name="el"></param>
        /// <param name="Name"></param>
        /// <returns></returns>
        private bool Attr2Bool(XmlElement el, string Name)
        {
            return el.GetAttribute(Name) == "0" ? false : true;
        }
        private void Bool2Attr(XmlElement el, string Name, bool Value)
        {
            el.SetAttribute(Name, Value ? "1" : "0");
        }
        public PassProperies CreatePassProperty(XmlElement el, RackProperties leftRack, bool WithWire = false)
        {
            return new PassProperies()
            {
                Number = Convert.ToByte(el.GetAttribute("PassNum")),
                Order = Convert.ToByte(el.GetAttribute("Order")),
                Baggage = Attr2Bool(el, "Baggage"),
                Express = Attr2Bool(el, "Express"),
                InEnable = Attr2Bool(el, "InEnable"),
                OutEnable = Attr2Bool(el, "OutEnable"),
                LeftRack = leftRack,
                RightRack = CreateRackProperty(el),
                Wire = WithWire ? CreateWireProperties(el) : null

            };
        }

        private WireProperties CreateWireProperties(XmlElement el)
        {
            WireProperties output = new WireProperties();
            output.Port = el.GetAttribute("Port");
            try
            {
                output.Address = Convert.ToByte(el.GetAttribute("Address"));
            }
            catch
            {
                output.Address = 1;
            }
            return output;
        }

        private RackProperties CreateRackProperty(XmlElement el)
        {
            return new RackProperties()
            {
                InventoryNum = el.GetAttribute("IN"),
                SerialNum = Convert.ToUInt64(el.GetAttribute("SN"))
            };
        }
        private LineGroupProperties CreateLineGroupProperties(XmlElement el)
        {
            return new LineGroupProperties()
            {
                Id = Convert.ToByte(el.GetAttribute("Order")),
                Name = el.GetAttribute("Name")
            };
        }
        private TurnLineProperties CreateTurnLineProperties(XmlElement el)
        {
            return new TurnLineProperties()
            {
                Id = Convert.ToByte(el.GetAttribute("Order")),
                Name = el.GetAttribute("Name"),
                TurnstileModel = (Turnstile.Model)Enum.Parse(typeof(Turnstile.Model), el.GetAttribute("Type"))
            };
        }
    }
}
