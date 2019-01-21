using System.Drawing;
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
                UpdateHead(true);
                UpdateHead(false);
            }
        }
        private Model _model;

        ToolTip ttip;
        public PassProperties Properties;

        public Turnstile()
        {
            _model = Model.ut2000;
            Properties = new PassProperties();
            InitializeComponent();
            Region = getTurnstileRegion();
        }

        public Turnstile(PassProperties properties, Model model, ToolTip ttip)
        {
            InitializeComponent();
            this.ttip = ttip;
            Region = getTurnstileRegion();
            Properties = properties;
            passNum.Text = properties.Number.ToString();
            properties.NumberChanged += Properties_NumberChanged;
            DrawIcons();
            _model = model;
            properties.HeadCfgChanged += Properties_HeadCfgChanged;
        }

        private void Properties_HeadCfgChanged(object sender, System.EventArgs e)
        {
            UpdateHead(((HeadChangedEventArgs)e).In);
        }

        private void Properties_PassInfoChanged(object sender, System.EventArgs e)
        {
            DrawIcons();
        }

        private void Properties_NumberChanged(object sender, System.EventArgs e)
        {
            passNum.Text = Properties.Number.ToString();
        }

        private void PassHead_MouseHover(object sender, System.EventArgs e)
        {
            ttip.ToolTipTitle = "Стойка " + ModelName[(int)model];
            RackProperties rack = ((Control)sender).Name == "inHead" ? Properties.InRack : Properties.OutRack;

            ttip.Show("Инвентарный №: " + rack.InventoryNum + "\r\nСерийный №:" + rack.SerialNum, (Control)sender);
        }


        private void hideTooltip(object sender, System.EventArgs e)
        {
            ttip.Hide((Control)sender);
        }

        private void passNum_MouseClick(object sender, MouseEventArgs e)
        {
            PassNumClick?.Invoke(this, e);
        }

        private void UpdateHead(bool In)
        {
            ImageList lst = TurnstileSkin.get(model);
            PictureBox pb = In ? inHead : outHead;
            bool enable = In ? Properties.InEnable : Properties.OutEnable;
            pb.Image = lst.Images[(In ? "in" : "out") + "_" + (enable ? "normal" : "empty")];
        }


        public void DrawIcons()
        {
            using (Graphics g = CreateGraphics())
                DrawIcons(g);
        }
        public void DrawIcons(Graphics g)
        {

            Rectangle r = new Rectangle(30, 44, 20, 20);
            using (Brush b = new SolidBrush(BackColor))
                g.FillRectangle(b, r.X, r.Y, r.Width, r.Height * 2);
            if (Properties.Express)
                g.DrawImage(TurnCtrl.Properties.Resources.Express, r);

            if (Properties.Baggage)
            {
                r.Y = 64;
                g.DrawImage(TurnCtrl.Properties.Resources.Baggage, r);
            }
        }

        private void Turnstile_Paint(object sender, PaintEventArgs e)
        {
            DrawIcons(e.Graphics);
        }
    }
}
