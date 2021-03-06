﻿using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TurnCtrl
{
    public partial class Station : UserControl
    {
        public LineGroup.LineGroupHeaderClickHandler GroupHeaderClick;
        public TurnLine.TurnLineHeaderClickHandler LineHeaderClick;
        public Turnstile.PassNumClickHandler PassNumClick; 


        public StationProperties Properties;
        public Station()
        {
            Properties = new StationProperties();
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

        public LineGroup LineGroupAdd(LineGroupProperties prop)
        {
            
            LineGroup lg = new LineGroup(prop, toolTip)
            {
                Width = ClientRectangle.Width
                
            };
            Controls.Add(lg);
            return lg;
        }

        public LineGroup LineGroupCreate()
        {
            LineGroup gr = new LineGroup(new LineGroupProperties() { Order = (byte)(MaxGroupOrderId + 1) }, toolTip)
            {
                Width = ClientRectangle.Width,
                Left = 0
            };
            gr.HeaderClick += GroupHeaderClick;
            Controls.Add(gr);
            Compose();
            return gr;
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
                gr.BackColor = (gr.Properties.Order & 1) == 0 ? BackColor = Color.FromArgb(0xfa, 0xfa, 0xfa) : Color.FromArgb(0xee, 0xee, 0xee);
            }
        }

        public LineGroup[] getGroups()
        {
            List<LineGroup> tmp = Controls.OfType<LineGroup>().ToList();
            return tmp.OrderBy(si => si.Properties.Order).ToArray();
        }
        public LineGroup getGroupByOrderId(int Id)
        {
            foreach (LineGroup gr in getGroups())
                if (gr.Properties.Order == Id)
                    return gr;
            return null;
        }


        public int MaxGroupOrderId
        {
            get
            {
                LineGroup[] lines = getGroups();
                return lines.Length == 0 ? 0 : lines[lines.Length - 1].Properties.Order;
            }
        }

        public void SwapGroupsOrder(LineGroup gr, int TargetOrderId)
        {
            LineGroup target = getGroupByOrderId(TargetOrderId);
            byte tmp = target.Properties.Order;
            target.Properties.Order = gr.Properties.Order;
            gr.Properties.Order = tmp;
            Compose();
        }

    }
}
