using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TurnCtrl
{
    public partial class TurnLine : UserControl
    {
        private ToolTip ttip;
        public TurnLineProperties Properties;

        public TurnLine(TurnLineProperties Properties, ToolTip ttip, bool Editable = false)
        {
            this.ttip = ttip;
            this.Properties = Properties;
            InitializeComponent();
            MenuItem[] mi;
            if (Editable)
            {
                mi = new MenuItem[] {
                    new MenuItem("Настройка", editLine_click),
                    new MenuItem("Добавить проход",addPass_click),
                    new MenuItem("-"),
                    new MenuItem("Вверх по списку",moveTop_click),
                    new MenuItem("Вниз по списку",moveBottom_click),
                    new MenuItem("-"),
                    new MenuItem("Удалить линейку",deleteLine_click),
                };
            }
            else
            {
                mi = new MenuItem[] {
                    new MenuItem("Настройка", editLine_click),
                    new MenuItem("Добавить проход",addPass_click),
                    new MenuItem("-"),
                    new MenuItem("Удалить линейку",deleteLine_click),
                };
            }
            TextLbl.ContextMenu = new ContextMenu(mi);
            Upd();
        }

        private void moveBottom_click(object sender, EventArgs e)
        {
            if (Properties.Id == ((LineGroup)Parent).MaxLineOrderId)
                return;
            ((LineGroup)Parent).SwapGroupsOrder(this, Properties.Id + 1);
        }

        private void moveTop_click(object sender, EventArgs e)
        {
            if (Properties.Id == 1)
                return;
            ((LineGroup)Parent).SwapGroupsOrder(this, Properties.Id - 1);
        }

        public Turnstile addTurnstile(PassProperies prop, bool Editable)
        {

            Turnstile turn = new Turnstile(prop, Properties.TurnstileModel, ttip, Editable)
            {
                Top = 25
            };
            Controls.Add(turn);
            return turn;
        }

        private void deleteLine_click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить линейку?", "Подтверждение действия", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.Yes)
            {
                LineGroup pr = (LineGroup)Parent;
                pr.Controls.Remove(this);
                pr.Compose();
                Dispose();
            }
        }
        private void addPass_click(object sender, System.EventArgs e)
        {
            Turnstile[] turns = getTurnstiles();
            int MaxOrder = turns.Length == 0 ? 0 : turns[turns.Length - 1].Properties.Order;

            Controls.Add(
                new Turnstile(
                    new PassProperies()
                    {
                        Order = MaxOrder + 1,
                        LeftRack = MaxOrder == 0 ? new RackProperties() : turns[turns.Length - 1].Properties.RightRack
                    }, Properties.TurnstileModel, ttip, true)
                { Left = 5 + 60 * (MaxOrder), Top = 25 });
            Width = 30 + 60 * (MaxOrder + 1);
            ((LineGroup)Parent).Compose();
        }
        private void editLine_click(object sender, System.EventArgs e)
        {
            using (TurnLineEditForm f = new TurnLineEditForm(Properties))
            {
                switch (f.ShowDialog(this))
                {
                    case DialogResult.OK:
                        Properties = f.Properties;
                        Upd();
                        foreach (Turnstile turn in getTurnstiles())
                            turn.model = Properties.TurnstileModel;
                        break;
                    default:
                        return;
                }
            };
        }

        public Turnstile[] getTurnstiles()
        {
            List<Turnstile> tmp = Controls.OfType<Turnstile>().ToList();
            return tmp.OrderBy(si => si.Properties.Order).ToArray();
        }


        private void Upd()
        {
            TextLbl.Text = Properties.Name;

            switch (Properties.TurnstileModel)
            {
                case Turnstile.Model.ut2000:
                case Turnstile.Model.ut2000_5:
                    firstEmptyHead.Image = TurnCtrl.Properties.Resources.ut2000_head_in_empty;
                    lastEmptyHead.Image = TurnCtrl.Properties.Resources.ut2000_head_out_empty;
                    break;
                case Turnstile.Model.ut2012:
                case Turnstile.Model.ut2012_14:
                    firstEmptyHead.Image = TurnCtrl.Properties.Resources.ut2012_head_in_empty;
                    lastEmptyHead.Image = TurnCtrl.Properties.Resources.ut2012_head_out_empty;
                    break;
                case Turnstile.Model.ut2000_9:
                    firstEmptyHead.Image = TurnCtrl.Properties.Resources.ut2000_9_head_in_empty;
                    lastEmptyHead.Image = TurnCtrl.Properties.Resources.ut2000_9_head_out_empty;
                    break;
            }
        }

        public void Compose()
        {
            Turnstile[] turns = getTurnstiles();
            for (int i = 0; i < turns.Length; i++)
            {

                turns[i].Left = 5 + 60 * i;
            }
            Width = 30 + turns.Length * 60;
        }


        private void TurnLine_ControlRemoved(object sender, ControlEventArgs e)
        {
            Turnstile[] tt = getTurnstiles();
            if (tt.Length == 0) //Если не осталось проходов возвращаем минимальную ширину
            {
                Width = 90;
                return;
            }
            for (int i = 0; i < tt.Length; i++)
            {
                if (tt[i].Properties.Order > ((Turnstile)e.Control).Properties.Order)
                    tt[i].Properties.Order -= 1;
                tt[i].Left = 5 + (tt[i].Properties.Order - 1) * 60;

            }
            Width = 30 + 60 * (tt[tt.Length - 1].Properties.Order);
            ((LineGroup)Parent).Compose();
        }

        public Turnstile getPassByOrder(int OrderId)
        {
            foreach (Turnstile t in getTurnstiles())
            {
                if (t.Properties.Order == OrderId)
                    return t;
            }
            return null;
        }

        private void EmptyHead_MouseHover(object sender, System.EventArgs e)
        {
            bool IsFirst = ((Control)sender).Name == "firstEmptyHead";
            Turnstile[] t = getTurnstiles();
            if (t.Length == 0) return;
            RackProperties r;
            if (IsFirst)
                r = t[0].Properties.LeftRack;
            else
                r = t[t.Length - 1].Properties.RightRack;
            t = null;
            ttip.ToolTipTitle = "Стойка " + Turnstile.ModelName[(int)Properties.TurnstileModel];
            ttip.Show("Инвентарный №: " + r.InventoryNum + "\r\nСерийный №:" + r.SerialNum, IsFirst? firstEmptyHead:lastEmptyHead);
        }

        private void TurnLine_Paint(object sender, PaintEventArgs e)
        {
            using (Brush b = new SolidBrush(BackColor))
                e.Graphics.FillRectangle(b, DisplayRectangle);
            using (Pen p = new Pen(TextLbl.BackColor))
            {
                e.Graphics.DrawRectangle(p, 0, 0, Width - 1, Height - 1);
            }
        }


    }
}
