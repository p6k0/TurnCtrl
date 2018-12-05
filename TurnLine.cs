using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TurnCtrl
{
    public partial class TurnLine : UserControl
    {
        private Helper.TurnstileModels Model;

        public TurnLine()
        {
            Model = Helper.TurnstileModels.ut2000;
            InitializeComponent();
            this.Controls.Add(new Turnstile_2000() {Left=5, Top=25});
            ChangeTurnstileModel();

        }

        public TurnLine(Helper.TurnstileModels model = Helper.TurnstileModels.ut2000)
        {
            this.Model = model;
            InitializeComponent();
            ChangeTurnstileModel();
        }


        private void ChangeTurnstileModel()
        {
            switch (Model)
            {
                case Helper.TurnstileModels.ut2000:
                case Helper.TurnstileModels.ut2000_5:
                    firstEmptyHead.Image = TurnCtrl.Properties.Resources.ut2000_head_in_empty;
                    lastEmptyHead.Image = TurnCtrl.Properties.Resources.ut2000_head_out_empty;
                    break;
                case Helper.TurnstileModels.ut2012:
                case Helper.TurnstileModels.ut2012_14:
                    firstEmptyHead.Image = TurnCtrl.Properties.Resources.ut2012_head_in_empty;
                    lastEmptyHead.Image = TurnCtrl.Properties.Resources.ut2012_head_out_empty;
                    break;
                case Helper.TurnstileModels.ut2000_9:
                    firstEmptyHead.Image = TurnCtrl.Properties.Resources.ut2000_9_head_in_empty;
                    lastEmptyHead.Image = TurnCtrl.Properties.Resources.ut2000_9_head_out_empty;
                    break;
            }
        }
    }


}
