using System.Windows.Forms;


namespace TurnCtrl
{
    public partial class Turnstile : UserControl
    {
        public Model model
        {
            get => _model;
            set
            {
                _model = value;
                Compose();
            }
        }
        private Model _model;


        ToolTip ttip;
        public PassProperies Properties;
        private PictureBox
             Baggage, Express;

        public Turnstile()
        {
            _model = Model.ut2000;
            Properties = new PassProperies();
            InitializeComponent();
            passNum.ContextMenu = new ContextMenu(
            new MenuItem[]
                {
                    new MenuItem("Конфигурация",editPass_click),
                    new MenuItem("-"),
                    new MenuItem("Удалить",deletePass_click)
                }
            );
            Region = getTurnstileRegion();
        }

        public Turnstile(PassProperies properties, Model model, ToolTip ttip, bool Editable = false)
        {
            _model = model;
            InitializeComponent();
            this.ttip = ttip;
            Region = getTurnstileRegion();
            Properties = properties;
            MenuItem[] items;
            if (Editable)
            {
                items = new MenuItem[]
                {
                    new MenuItem("Конфигурация",editPass_click),
                    new MenuItem("-"),
                    new MenuItem("Удалить",deletePass_click)
                };
            }
            else
            {
                items = new MenuItem[]
                {
                    new MenuItem("Аварийное открытие",editPass_click),
                    new MenuItem("-"),
                    new MenuItem("Вернуть в нормальный режим",deletePass_click)
                };
            }
            passNum.ContextMenu = new ContextMenu(items);
            Compose();
        }

        private void deletePass_click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить проход?", "Подтверждение действия", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.Yes)
                Parent.Controls.Remove(this);
        }
        private void openPass_click(object sender, System.EventArgs e)
        {
            Parent.Controls.Remove(this);
        }
        private void editPass_click(object sender, System.EventArgs e)
        {
            using (PassEditForm f = new PassEditForm(Properties))
            {
                switch (f.ShowDialog(this))
                {
                    case DialogResult.OK:
                        Properties = f.prop;
                        Compose();
                       // ((TurnLine)Parent).PassReconfigured(Properties);
                        break;
                    default:
                        return;
                }
            }
        }

        private void passNum_MouseClick(object sender, MouseEventArgs e)
        {
            passNum.ContextMenu.Show((Control)sender, e.Location);
        }

        private void PassHead_MouseHover(object sender, System.EventArgs e)
        {
            ttip.ToolTipTitle = "Стойка " + ModelName[(int)model];
            RackProperties rack = ((Control)sender).Name == "inHead" ? Properties.LeftRack : Properties.RightRack;

            ttip.Show("Инвентарный №: " +  rack.InventoryNum + "\r\nСерийный №:" + rack.SerialNum, (Control)sender);
        }


        private void hideTooltip(object sender, System.EventArgs e)
        {
            ttip.Hide((Control)sender);
        }

        public void Compose()
        {
            passNum.Text = Properties.PassNum.ToString();

            switch (model)
            {
                case Model.ut2000:
                case Model.ut2000_5:
                    inHead.Image = Properties.InEnable ? TurnCtrl.Properties.Resources.ut2000_head_in_normal : TurnCtrl.Properties.Resources.ut2000_head_in_empty;
                    outHead.Image = Properties.OutEnable ? TurnCtrl.Properties.Resources.ut2000_head_out_normal : TurnCtrl.Properties.Resources.ut2000_head_out_empty;
                    break;
                case Model.ut2012:
                case Model.ut2012_14:
                    inHead.Image = Properties.InEnable ? TurnCtrl.Properties.Resources.ut2012_head_in_normal : TurnCtrl.Properties.Resources.ut2012_head_in_empty;
                    outHead.Image = Properties.OutEnable ? TurnCtrl.Properties.Resources.ut2012_head_out_normal : TurnCtrl.Properties.Resources.ut2012_head_out_empty;
                    break;
                case Model.ut2000_9:
                    inHead.Image = Properties.InEnable ? TurnCtrl.Properties.Resources.ut2000_9_head_in_normal : TurnCtrl.Properties.Resources.ut2000_9_head_in_empty;
                    outHead.Image = Properties.OutEnable ? TurnCtrl.Properties.Resources.ut2000_9_head_out_normal : TurnCtrl.Properties.Resources.ut2000_9_head_out_empty;
                    break;
            }

            if (Properties.Baggage)
            {
                if (Baggage == null)
                {
                    Baggage = Helper.CreateBagageIcon();
                    Controls.Add(Baggage);
                }
            }
            else
            {
                if (Baggage != null)
                {
                    Controls.Remove(Baggage);
                    Baggage = null;
                }
            }

            #region Иконка экспресс
            if (Properties.Express)
            {
                if (Express == null)
                {
                    Express = Helper.CreateExpressIcon();
                    Controls.Add(Express);
                }
            }
            else
            {
                if (Express != null)
                {
                    Controls.Remove(Express);
                    Express = null;
                }
            }
            #endregion


        }
    }
}
