using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TurnCtrl
{
    public partial class Station : UserControl
    {
        public StationProperties Properties;
        public Station()
        {
            InitializeComponent();
            HorizontalScroll.Maximum = 0;
            AutoScroll = false;
            VerticalScroll.Visible = true;
            AutoScroll = true;
        }

        public Station(StationProperties prop)
        {
            Properties = prop;
            InitializeComponent();
            HorizontalScroll.Maximum = 0;
            AutoScroll = false;
            VerticalScroll.Visible = true;
            AutoScroll = true;
        }

        public LineGroup LineGroupAdd(LineGroupProperties prop, bool Editable)
        {
            LineGroup lg = new LineGroup(prop, toolTip, Editable)
            {
                Width = ClientRectangle.Width
            };
            Controls.Add(lg);
            return lg;
        }

        public void LineGroupCreate()
        {
            LineGroup gr = new LineGroup(new LineGroupProperties() { Id = MaxGroupOrderId + 1 }, toolTip, true)
            {
                Width = ClientRectangle.Width,
                Left = 0
            };
            Controls.Add(gr);
            Compose();
        }

        public void Compose()
        {
            //this.clie
            int TopOffset = 0;
            LineGroup[] groups = getGroups();
            foreach (LineGroup gr in groups)
            {
                gr.Top = TopOffset;
                TopOffset += gr.Height;
                gr.BackColor = (gr.Properties.Id & 1) == 0 ? BackColor = Color.FromArgb(0xfa, 0xfa, 0xfa) : Color.FromArgb(0xf5, 0xf5, 0xf5);
            }
        }

        public LineGroup[] getGroups()
        {
            List<LineGroup> tmp = Controls.OfType<LineGroup>().ToList();
            return tmp.OrderBy(si => si.Properties.Id).ToArray();
        }
        public LineGroup getGroupByOrderId(int Id)
        {
            foreach (LineGroup gr in getGroups())
                if (gr.Properties.Id == Id)
                    return gr;
            return null;
        }


        public int MaxGroupOrderId
        {
            get
            {
                LineGroup[] lines = getGroups();
                return lines.Length == 0 ? 0 : lines[lines.Length - 1].Properties.Id;
            }
        }

        public void SwapGroupsOrder(LineGroup gr, int TargetOrderId)
        {
            LineGroup target = getGroupByOrderId(TargetOrderId);
            int tmp = target.Properties.Id;
            target.Properties.Id = gr.Properties.Id;
            gr.Properties.Id = tmp;
            Compose();
        }

    }
}
