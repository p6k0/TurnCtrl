using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


        public XmlDocument
            map,
            wire;

        public AsokupeConfig(XmlDocument map, XmlDocument wire)
        {
            this.map = map;
            this.wire = wire;
        }

        private XmlSerializer LineGroupSerializer = new XmlSerializer(typeof(LineGroup), new XmlRootAttribute("Station"));
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
            {
                output.Add(
                    new TurnLineProperties()
                    {
                        Id = Convert.ToByte(el.GetAttribute("Order")),
                        Name = el.GetAttribute("Name"),
                        TurnstileModel = (Turnstile.Model)Enum.Parse(typeof(Turnstile.Model), el.GetAttribute("Model"))
                    }
               );
            }
            return output.ToArray();
        }

        public PassProperty getPassProperty(byte PassNum)
        {
            XmlElement el = (XmlElement)wire.DocumentElement.SelectSingleNode("Pass[@Num=\"" + PassNum + "\"]");
            XmlElement el2 = (XmlElement)map.DocumentElement.SelectSingleNode("Group/Line/Pass[@PassNum=\"" + PassNum + "\"]");
            return new PassProperty()
            {
                Number = PassNum,
                Port = el.GetAttribute("Port"),
                Addres = Convert.ToByte(el.GetAttribute("Addr"));

        }
    }
}
}
