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
    public partial class TurnLineEditForm : Form
    {
        public TurnLineProperties Properties;
        public TurnLineEditForm(TurnLineProperties Properties)
        {
            this.Properties = Properties;
            InitializeComponent();
            comboBox1.Items.AddRange(Turnstile.ModelName);
            comboBox1.SelectedItem = Turnstile.ModelName[(byte)Properties.TurnstileModel];
            textBox1.Text = Properties.Name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Name = textBox1.Text;
            int i;
            for (i = 0; i < Turnstile.ModelName.Length; i++)
                if (Turnstile.ModelName[i] == comboBox1.Text)
                    break;


            Properties.TurnstileModel = (Turnstile.Model)i;

            this.DialogResult = DialogResult.OK;
        }
    }
}
