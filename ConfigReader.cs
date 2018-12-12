using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace TurnCtrl
{
    class AsokupeConfig
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
        public 


        public XmlDocument
            map,
            wire;

        public AsokupeConfig(XmlDocument map, XmlDocument wire)
        {
            this.map = map;
            this.wire = wire;
        }

        private readonly XmlSerializer LineGroupSerializer = new XmlSerializer(typeof(LineGroup), new XmlRootAttribute("Station"));
        public LineGroupProperties[] GetLineGroups()
        {
            List<LineGroupProperties> output = new List<LineGroupProperties>();
            foreach (XmlElement el in map.DocumentElement.SelectNodes("Group"))
            {
                output.Add(
                    new LineGroupProperties()
                    {
                        Id = Convert.ToByte(el.GetAttribute("Order")),
                        Name = el.GetAttribute("Name")
                    }
               );
            }
            return output.ToArray();
        }
        public TurnLineProperties[] GetLinesOfGroup(TurnLineProperties p)
        {
            List<TurnLineProperties> output = new List<TurnLineProperties>();
            foreach (XmlElement el in map.DocumentElement.SelectNodes("Group[@Id=\"" + p.Id + "\"]"))
                output.Add(_createLineFromXml(el));
            return output.ToArray();
        }
        public TurnLineProperties getTurnLineOfPass(VisualPassProperty prop)
        {
            return _createLineFromXml((XmlElement)map.DocumentElement.SelectSingleNode("Group/Line/Pass[@Num=\"" + prop.Number + "\"]").ParentNode);
        }

        internal TurnLineProperties _createLineFromXml(XmlElement el)
        {
            return new TurnLineProperties()
            {
                Id = Convert.ToByte(el.GetAttribute("Order")),
                Name = el.GetAttribute("Name"),
                TurnstileModel = (Turnstile.Model)Enum.Parse(typeof(Turnstile.Model), el.GetAttribute("Model"))
            };
        }


        public VisualPassProperty getPassProperty(byte PassNum)
        {
            XmlElement el2 = (XmlElement)map.DocumentElement.SelectSingleNode("Group/Line/Pass[@Num=\"" + PassNum + "\"]");
            return new VisualPassProperty()
            {
                Number = PassNum,
                OrderId = XmlAttr2byte(el2,"Order"),
                Baggage = XmlAttr2Bool(el2, "Baggage"),
                Express = XmlAttr2Bool(el2, "Express"),
                InEnable = XmlAttr2Bool(el2, "In"),
                OutEnable = XmlAttr2Bool(el2, "Out"),
                LeftRack = getRackProperty(get ,OrderId)
            };
        }
        public WireProperty getWirePassProperty(byte PassNum)
        {
            XmlElement el = (XmlElement)map.DocumentElement.SelectSingleNode("Pass[@Num=\"" + PassNum + "\"]");
            return new WireProperty()
            {
                Address = XmlAttr2byte(el, "Addr"),
                Port = el.GetAttribute("Port"),
                InEnable = XmlAttr2Bool(el, "In"),
                OutEnable = XmlAttr2Bool(el, "Out"),
                Model = (Turnstile.Model)Enum.Parse(typeof(Turnstile.Model), ((XmlElement)el.ParentNode).GetAttribute("Type"))
            };
        }
        public RackProperties getRackProperty(TurnLineProperties line, byte OrderId)
        {
            XmlElement el = (XmlElement)map.DocumentElement.SelectSingleNode("Group/Line[@Order=\"" + line.Id + "\"]/Rack[@Order=\"" + OrderId + "\"]");
            return new RackProperties()
            {
                SerialNum = Convert.ToUInt64(el.GetAttribute("SN")),
                InventoryNum = el.GetAttribute("IN")
            };
        }
        public VisualPassProperty GetTurnstileProperty(byte PassNum)
        {
            XmlElement el = (XmlElement)map.DocumentElement.SelectSingleNode("Group/Line/Pass[@Num=\"" + PassNum + "\"]");
            return new VisualPassProperty()
            {
                Pass = PassNum,
            }
         }


        private byte XmlAttr2byte(XmlElement el, string Name, byte Default = 1)
        {
            try
            {
                return Convert.ToByte(el.GetAttribute(Name));
            }
            catch
            {
                return Default;
            }
        }
        private bool XmlAttr2Bool(XmlElement el, string Name)
        {
            return el.GetAttribute(Name) == "1" ? true : false;
        }
        private void Bool2XmlAttr(ref XmlElement el, string Name, bool value)
        {
            el.SetAttribute(Name, value ? "1" : "0");
        }

    }
}
