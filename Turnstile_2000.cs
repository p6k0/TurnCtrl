using System.Windows.Forms;

namespace TurnCtrl
{
    public partial class Turnstile_2000 : UserControl
    {
        public Turnstile_2000()
        {
            InitializeComponent();
            Region = Helper.getTurnstileRegion();
            PictureBox pb = Helper.CreateBagageIcon();
            this.Controls.Add(pb);
            pb = Helper.CreateExpressIcon();
            this.Controls.Add(pb);
        }
    }
}
