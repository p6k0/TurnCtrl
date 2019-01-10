using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TurnCtrl
{
    public partial class LineGroup : UserControl
    {
        public delegate void LineGroupHeaderClickHandler(object sender, MouseEventArgs e);
        public event LineGroupHeaderClickHandler HeaderClick;


        private ToolTip ttip;
        public LineGroupProperties Properties;


        public LineGroup()
        {
            InitializeComponent();
        }

        public LineGroup(LineGroupProperties Properties, ToolTip ttip)
        {
            this.ttip = ttip;
            this.Properties = Properties;
            Properties.NameChanged += Properties_NameChanged;
            InitializeComponent();
            groupName.Text = Properties.Name;
        }

        private void Properties_NameChanged(object Sender,EventArgs e)
        {
            groupName.Text = Properties.Name;
        }

        public TurnLine addLine(TurnLineProperties prop)
        {
            TurnLine ln = new TurnLine(prop, ttip);
            Controls.Add(ln);
            return ln;
        }
        #region перемещение в станции
        public void MoveTop()
        {
            if (Properties.Order == 1)
                return;
            ((Station)Parent).SwapGroupsOrder(this, Properties.Order - 1);
        }
        public void MoveBottom()
        {
            if (Properties.Order == ((Station)Parent).MaxGroupOrderId)
                return;
            ((Station)Parent).SwapGroupsOrder(this, Properties.Order + 1);
        }
        #endregion

        public void createLine()
        {
            TurnLine t = new TurnLine(
                new TurnLineProperties()
                {
                    Order = (byte)(MaxLineOrderId + 1)
                }
                , ttip)
            {
                Top = groupName.Height + LinePadding
            };
            t.HeaderClick += ((Station)Parent).LineHeaderClick;
            Controls.Add(t);
            Compose();

        }



        private const int LinePadding = 5;
        public void Compose()
        {
            int TopOffset = groupName.Height;
            int CurrentWidth = 0;
            int StartOffset = 0;
            List<TurnLine> LinesInLine = new List<TurnLine>();
            TurnLine[] lines = getTurnLines();
            foreach (TurnLine ln in lines)
            {
                if (CurrentWidth + ln.Width > Width)
                {
                    StartOffset = (Width - CurrentWidth) / 2;
                    for (int i = 0; i < LinesInLine.Count; i++)
                    {
                        LinesInLine[i].Top = TopOffset;
                        LinesInLine[i].Left = StartOffset;
                        StartOffset += LinesInLine[i].Width + LinePadding;
                    }
                    TopOffset += ln.Height + LinePadding;
                    CurrentWidth = 0;
                    LinesInLine.Clear();
                }
                LinesInLine.Add(ln);
                CurrentWidth += ln.Width + LinePadding;
            }
            if (LinesInLine.Count != 0)
            {
                StartOffset = (Width - CurrentWidth) / 2;
                for (int i = 0; i < LinesInLine.Count; i++)
                {
                    LinesInLine[i].Top = TopOffset;
                    LinesInLine[i].Left = StartOffset;
                    StartOffset += LinesInLine[i].Width + 5;
                }
                TopOffset += LinePadding;
            }
            Height = TopOffset + 180;
            ((Station)Parent).Compose();
        }

        public TurnLine[] getTurnLines()
        {
            List<TurnLine> tmp = Controls.OfType<TurnLine>().ToList();
            return tmp.OrderBy(si => si.Properties.Order).ToArray();
        }

        public byte MaxLineOrderId
        {
            get
            {
                TurnLine[] lines = getTurnLines();
                return (byte)(lines.Length == 0 ? 0 : lines[lines.Length - 1].Properties.Order);
            }
        }

        private void LineGroup_ControlRemoved(object sender, ControlEventArgs e)
        {
            Compose();
        }


        public void SwapGroupsOrder(TurnLine gr, int TargetOrderId)
        {
            TurnLine target = getLineByOrderId(TargetOrderId);
            byte tmp = target.Properties.Order;
            target.Properties.Order = gr.Properties.Order;
            gr.Properties.Order = tmp;
            Compose();
        }

        public TurnLine getLineByOrderId(int OrderId)
        {
            foreach (TurnLine ln in getTurnLines())
                if (ln.Properties.Order == OrderId)
                    return ln;
            return null;
        }

        private void groupName_MouseClick(object sender, MouseEventArgs e)
        {
            HeaderClick?.Invoke(this, e);
        }
    }
}
