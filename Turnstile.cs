using System.Windows.Forms;


namespace TurnCtrl
{
    public partial class Turnstile : UserControl
    {
        public delegate void PassNumClickHandler(object sender, MouseEventArgs e);
        public event PassNumClickHandler PassNumClick;

        public Model model
        {
            get => _model;
            set
            {
                _model = value;
                UpdateSkin();
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
            Region = getTurnstileRegion();
        }

        public Turnstile(PassProperies properties, Model model, ToolTip ttip)
        {
            _model = model;
            InitializeComponent();
            this.ttip = ttip;
            Region = getTurnstileRegion();
            Properties = properties;
            Compose();
        }

        private void PassHead_MouseHover(object sender, System.EventArgs e)
        {
            ttip.ToolTipTitle = "Стойка " + ModelName[(int)model];
            RackProperties rack = ((Control)sender).Name == "inHead" ? Properties.RightRack : Properties.LeftRack;

            ttip.Show("Инвентарный №: " + rack.InventoryNum + "\r\nСерийный №:" + rack.SerialNum, (Control)sender);
        }


        private void hideTooltip(object sender, System.EventArgs e)
        {
            ttip.Hide((Control)sender);
        }

        private void passNum_MouseClick(object sender, MouseEventArgs e)
        {
            PassNumClick(this, e);
        }

        private void UpdateSkin()
        {
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
        }

        public void Compose()
        {
            passNum.Text = Properties.Number.ToString();

            

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
