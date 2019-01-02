using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TurnCtrl
{
    public partial class LineGroup : UserControl
    {
        public delegate void LineGroupHeaderClickHandler(LineGroup linegroup);
        public event LineGroupHeaderClickHandler HeaderClick;


        private ToolTip ttip;
        public LineGroupProperties Properties;


        public LineGroup()
        {
            InitializeComponent();
            ContextMenu = new ContextMenu(new MenuItem[]
                {
                    new MenuItem("Конфигурация",editGroup_click),
                    new MenuItem("-"),
                    new MenuItem("Удалить",deleteGroup_click)
                });
        }

        public LineGroup(LineGroupProperties Properties, ToolTip ttip, bool Editable)
        {
            this.ttip = ttip;
            this.Properties = Properties;
            InitializeComponent();
            groupName.Text = Properties.Name;
            MenuItem[] items;
            if (Editable)
            {
                items = new MenuItem[]
                {
                    new MenuItem("Конфигурация",editGroup_click),
                    new MenuItem("Добавить линейку",addLine_click),
                    new MenuItem("-"),
                    new MenuItem("Вверх по списку",moveTop_click),
                    new MenuItem("Вниз по списку",moveBottop_click),
                    new MenuItem("-"),
                    new MenuItem("Удалить",deleteGroup_click)
                };
            }
            else
            {
                items = new MenuItem[]
                {
                    new MenuItem("Аварийное открытие",editGroup_click),
                    new MenuItem("-"),
                    new MenuItem("Вернуть в нормальный режим",deleteGroup_click)
                };
            }
            groupName.ContextMenu = new ContextMenu(items);
        }

        public TurnLine addLine(TurnLineProperties prop, bool Editable)
        {
            TurnLine ln = new TurnLine(prop, ttip, Editable);
            Controls.Add(ln);
            return ln;
        }
        #region перемещение в станции
        private void moveTop_click(object sender, EventArgs e)
        {
            if (Properties.Id == 1)
                return;
            ((Station)Parent).SwapGroupsOrder(this, Properties.Id - 1);
        }
        private void moveBottop_click(object sender, EventArgs e)
        {
            if (Properties.Id == ((Station)Parent).MaxGroupOrderId)
                return;
            ((Station)Parent).SwapGroupsOrder(this, Properties.Id + 1);
        }
        #endregion

        private void addLine_click(object sender, EventArgs e)
        {
            Controls.Add(new TurnLine(new TurnLineProperties() { Id = MaxLineOrderId + 1, }, ttip, true) { Top = groupName.Height + LinePadding });
            Compose();

        }

        private void deleteGroup_click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить группу линеек?", "Подтверждение действия", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.Yes)
            {
                Station st = (Station)Parent;
                Parent.Controls.Remove(this);
                st.Compose();
            }
        }

        private void editGroup_click(object sender, EventArgs e)
        {
            using (LineGroupEditForm f = new LineGroupEditForm(Properties))
            {
                switch (f.ShowDialog(this))
                {
                    case DialogResult.OK:
                        Properties = f.Properties;
                        Upd();
                        break;
                    default:
                        return;
                }
            }
        }

        public void Upd()
        {
            groupName.Text = Properties.Name;
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
            return tmp.OrderBy(si => si.Properties.Id).ToArray();
        }

        public int MaxLineOrderId
        {
            get
            {
                TurnLine[] lines = getTurnLines();
                return lines.Length == 0 ? 0 : lines[lines.Length - 1].Properties.Id;
            }
        }

        private void LineGroup_ControlRemoved(object sender, ControlEventArgs e)
        {
            Compose();
        }


        public void SwapGroupsOrder(TurnLine gr, int TargetOrderId)
        {
            TurnLine target = getLineByOrderId(TargetOrderId);
            int tmp = target.Properties.Id;
            target.Properties.Id = gr.Properties.Id;
            gr.Properties.Id = tmp;
            Compose();
        }

        public TurnLine getLineByOrderId(int OrderId)
        {
            foreach (TurnLine ln in getTurnLines())
                if (ln.Properties.Id == OrderId)
                    return ln;
            return null;
        }
    }
}
