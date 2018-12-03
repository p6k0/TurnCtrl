using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;

namespace TurnCtrl
{
    public partial class LineGroup : UserControl
    {
        public const int
            TopOffset = 25,
            SidePadding = 5;
        public override string Text { get => groupText.Text; set => groupText.Text = value; }

        public LineGroup(string Text = "Новая группа линеек")
        {
            InitializeComponent();
            this.Text = Text;
        }
    }
}
