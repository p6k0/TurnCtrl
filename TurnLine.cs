using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TurnCtrl
{
    public partial class TurnLine : UserControl
    {
        #region Событие действия Линейки
        public delegate void TurnLineHeaderClickHandler(object sender, MouseEventArgs e);
        public event TurnLineHeaderClickHandler HeaderClick;
        #endregion

        private ToolTip ttip;
        public TurnLineProperties Properties;

        public TurnLine(TurnLineProperties Properties, ToolTip ttip)
        {
            this.ttip = ttip;
            this.Properties = Properties;
            Properties.ModelChanged += Properties_ModelChanged;
            Properties.NameChanged += Properties_NameChanged;
            InitializeComponent();
            TextLbl.Text = Properties.Name;
            ChangeEmptyHeads();
        }

        private void Properties_NameChanged(object Sender,EventArgs e)
        {
            TextLbl.Text = Properties.Name;
        }

        private void Properties_ModelChanged(object Sender, EventArgs e)
        {
            ChangeEmptyHeads();
            foreach (Turnstile turn in getTurnstiles())
                turn.model = Properties.TurnstileModel;
        }

        private void ChangeEmptyHeads()
        {
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

        public void MoveBottom()
        {
            if (Properties.Order == ((LineGroup)Parent).MaxLineOrderId)
                return;
            ((LineGroup)Parent).SwapGroupsOrder(this, Properties.Order + 1);
        }

        public void MoveTop()
        {
            if (Properties.Order == 1)
                return;
            ((LineGroup)Parent).SwapGroupsOrder(this, Properties.Order - 1);
        }

        public Turnstile addTurnstile(PassProperties prop)
        {

            Turnstile turn = new Turnstile(prop, Properties.TurnstileModel, ttip)
            {
                Top = 25
            };
            Controls.Add(turn);
            return turn;
        }

        public void CreatePass()
        {
            Turnstile[] turns = getTurnstiles();
            byte MaxOrder = (byte)(turns.Length == 0 ? 0 : turns[turns.Length - 1].Properties.Order);
            Turnstile t = new Turnstile(
                    new PassProperties()
                    {
                        Order = (byte)(MaxOrder + 1),
                        OutRack = MaxOrder == 0 ? new RackProperties() : turns[turns.Length - 1].Properties.InRack
                    },
                    Properties.TurnstileModel,
                    ttip
            )
            {
                Left = 5 + 60 * (MaxOrder),
                Top = 25
            };
            t.PassNumClick += ((Station)((LineGroup)Parent).Parent).PassNumClick;
            Controls.Add(t);

            Width = 30 + 60 * (MaxOrder + 1);
            ((LineGroup)Parent).Compose();
        }

        public Turnstile[] getTurnstiles()
        {
            List<Turnstile> tmp = Controls.OfType<Turnstile>().ToList();
            return tmp.OrderBy(si => si.Properties.Order).ToArray();
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
                r = t[0].Properties.OutRack;
            else
                r = t[t.Length - 1].Properties.InRack;
            t = null;
            ttip.ToolTipTitle = "Стойка " + Turnstile.ModelName[(int)Properties.TurnstileModel];
            ttip.Show("Инвентарный №: " + r.InventoryNum + "\r\nСерийный №:" + r.SerialNum, IsFirst ? firstEmptyHead : lastEmptyHead);
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

        private void TextLbl_MouseClick(object sender, MouseEventArgs e)
        {
            HeaderClick?.Invoke(this, e);
        }

        private void TurnLine_ControlAdded(object sender, ControlEventArgs e)
        {
            if (!(e.Control is Turnstile))
                return;
            ((Turnstile)e.Control).model = Properties.TurnstileModel;
        }
    }
}
