using System.IO.Ports;
using System.Windows.Forms;

namespace TurnCtrl
{
    public partial class PassEditForm : Form
    {
        public PassProperies prop;
        public PassEditForm(PassProperies prop)
        {
            this.prop = prop;
            InitializeComponent();
            foreach (string port in SerialPort.GetPortNames())
                comboBox1.Items.Add(port);
            passNum.Value = prop.PassNum;
            address.Value = prop.Address;
            comboBox1.SelectedItem = prop.Port;

            baggage.Checked = prop.Baggage;
            express.Checked = prop.Express;

            inEnable.Checked = prop.InEnable;
            outEnable.Checked = prop.OutEnable;

            leftInvNum.Text = prop.LeftRack.InventoryNum;
            leftSNum.Value = prop.LeftRack.SerialNum;

            rightInvNum.Text = prop.RightRack.InventoryNum;
            rightSNum.Value = prop.RightRack.SerialNum;
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            prop.PassNum = (int)passNum.Value;
            prop.Address = (int)address.Value;
            prop.Port = comboBox1.SelectedItem.ToString();

            prop.InEnable = inEnable.Checked;
            prop.OutEnable = outEnable.Checked;

            prop.Baggage = baggage.Checked;
            prop.Express = express.Checked;

            prop.LeftRack.InventoryNum = leftInvNum.Text;
            prop.LeftRack.SerialNum = (ulong)leftSNum.Value;

            prop.LeftRack.InventoryNum = leftInvNum.Text;
            prop.LeftRack.SerialNum = (ulong)leftSNum.Value;
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
