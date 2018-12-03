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
    public partial class TurnPlace: UserControl
    {


        public int PlaceWidth = 1000;
        private int TopOffset = 0;

        public TurnPlace()
        {
            InitializeComponent();
        }

        public LineGroup AddLineGroup(string Name)
        {
            LineGroup gr = new LineGroup(Name);
            this.Controls.Add(gr);
            return gr;
        }
    }
}
