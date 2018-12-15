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
            get => new DateTime(1970, 1, 1).AddSeconds(Convert.ToInt32(map.DocumentElement.GetAttribute("E")));
        }
        public DateTime WireLastModify
        {
            get => new DateTime(1970, 1, 1).AddSeconds(Convert.ToInt32(map.DocumentElement.GetAttribute("E")));
        }

        public XmlDocument map;

        public AsokupeConfig(XmlDocument map)
        {
            this.map = map;
        }


        public void SaveMap(Station station, string Path)
        {
            map.RemoveChild(map.DocumentElement);
            XmlElement stel = map.CreateElement("Station");
            stel.SetAttribute("Name", station.Properties.Name);
            stel.SetAttribute("E", station.Properties.ExpressCode.ToString());

            foreach(LineGroup lgp in station.getGroups())
            {

            }
            
        }


        /// <summary>
        /// Создает элементы управления
        /// </summary>
        /// <param name="station">Элемент управления Station, в котором будут расположена визуализация остановочного пункта</param>
        /// <param name="editable">Признак, определяющий, какие функции будут доступны на элементах управления</param>
        public void DrawMap(Station station, bool editable)
        {
            foreach (XmlElement lgEl in map.DocumentElement.SelectNodes("Group"))
            {
                LineGroup lg = station.LineGroupAdd(CreateLineGroupProperties(lgEl), editable);
                foreach (XmlElement lnEl in lgEl.SelectNodes("Line"))
                {
                    TurnLine ln = lg.addLine(CreateTurnLineProperties(lnEl), editable);
                    RackProperties prevRack = CreateRackProperty((XmlElement)lnEl.SelectSingleNode("Turn[@Order=\"0\"]"));
                    int max = lnEl.SelectNodes("Turn").Count - 1;
                    for (int i = 1; i <= max; i++)
                    {
                        XmlElement tEl = (XmlElement)lnEl.SelectSingleNode("Turn[@Order=\"" + i + "\"]");
                        PassProperies p = CreatePassProperty(tEl, prevRack, editable);
                        Turnstile t = ln.addTurnstile(p,editable);
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
