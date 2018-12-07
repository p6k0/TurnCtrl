using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TurnCtrl
{
    public partial class LineGroupEditForm : Form
    {
        public readonly LineGroupProperties Properties;
        public LineGroupEditForm(LineGroupProperties Properties)
        {
            this.Properties = Properties;
            InitializeComponent();
            textBox1.Text = Properties.Name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Name = textBox1.Text;
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
