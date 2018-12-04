using System.Windows.Forms;


namespace TurnCtrl
{
    public partial class Turnstile_2000 : UserControl
    {
        ToolTip ttip;
        PassProperies Properties;
        private PictureBox
             Baggage, Express;

        public Turnstile_2000()
        {
            Properties = new PassProperies();
            InitializeComponent();
            Region = Helper.getTurnstileRegion();
            SpecButton.Image = TurnCtrl.Properties.Resources.COG;
            SpecButton.Click += EditProperties_Click;
        }

        public Turnstile_2000(PassProperies properties, ToolTip ttip, bool Editable = false)
        {
            InitializeComponent();
            this.ttip = ttip;
            Region = Helper.getTurnstileRegion();
            Properties = properties;
            if (Editable)
            {
                SpecButton.Image = TurnCtrl.Properties.Resources.COG;
                SpecButton.Click += EditProperties_Click;
            }
            else
            {
                SpecButton.Image = TurnCtrl.Properties.Resources.SOS_0;
                SpecButton.Click += OpenMode_Click;
            }
            Upd();
        }

        private void OpenMode_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void EditProperties_Click(object sender, System.EventArgs e)
        {
            using (PassEditForm f = new PassEditForm(Properties))
            {
                switch (f.ShowDialog(this))
                {
                    case DialogResult.OK:
                        Properties = f.prop;
                        Upd();
                        break;
                    case DialogResult.Ignore:
                        this.Dispose();
                        break;
                    default:
                        return;
                }
            }
        }

        private void SpecButton_MouseHover(object sender, System.EventArgs e)
        {
            ttip.Show("Включить режим \"Антипаника\"",SpecButton);
        }

        private void Turnstile_2000_Load(object sender, System.EventArgs e)
        {

        }

        public void Upd()
        {
            passNum.Text = Properties.PassNum.ToString();

            if (Properties.InEnable)
                inHead.Image = Properties.InEnable ? TurnCtrl.Properties.Resources.ut2000_head_in_normal : TurnCtrl.Properties.Resources.ut2000_head_in_empty;
            else
                outHead.Image = Properties.InEnable ? TurnCtrl.Properties.Resources.ut2000_head_out_normal : TurnCtrl.Properties.Resources.ut2000_head_out_empty;



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
