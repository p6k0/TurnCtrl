using System.IO.Ports;
using System.Windows.Forms;

namespace TurnCtrl
{
    public partial class TurnstileEditForm : Form
    {
        public VisualPassProperty prop;
        public TurnstileEditForm(VisualPassProperty prop)
        {
            this.prop = prop;
            InitializeComponent();
            this.Text = "Настройка прохода (порядковый номер: "+prop.OrderId+")";
            foreach (string port in SerialPort.GetPortNames())
                comboBox1.Items.Add(port);
            passNum.Value = prop.Pass.Number;
            address.Value = prop.Pass.Addres;
            comboBox1.SelectedItem = prop.Pass.Port;

            baggage.Checked = prop.Pass.Baggage;
            express.Checked = prop.Pass.Express;

            inEnable.Checked = prop.Pass.InEnable;
            outEnable.Checked = prop.Pass.OutEnable;

            leftInvNum.Text = prop.LeftRack.InventoryNum;
            leftSNum.Value = prop.LeftRack.SerialNum;

            rightInvNum.Text = prop.RightRack.InventoryNum;
            rightSNum.Value = prop.RightRack.SerialNum;
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            prop.Pass.Number = (byte)passNum.Value;
            prop.Pass.Addres = (byte)address.Value;
            prop.Pass.Port = comboBox1.SelectedIndex == -1? string.Empty: comboBox1.SelectedItem.ToString();

            prop.Pass.InEnable = inEnable.Checked;
            prop.Pass.OutEnable = outEnable.Checked;

            prop.Pass.Baggage = baggage.Checked;
            prop.Pass.Express = express.Checked;

            prop.LeftRack.InventoryNum = leftInvNum.Text;
            prop.LeftRack.SerialNum = (ulong)leftSNum.Value;

            prop.RightRack.InventoryNum = rightInvNum.Text;
            prop.RightRack.SerialNum = (ulong)rightSNum.Value;



            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Ignore;
            this.Close();
        }
    }
}
