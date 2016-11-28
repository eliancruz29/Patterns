using System;
using System.Windows.Forms;

namespace Observer_Example
{
    public partial class FormMain : Form
    {
        private Counter counter;
        public FormMain()
        {
            counter = Counter.Instance;
            InitializeComponent();
            FormText frmText = new FormText();
            frmText.Show();
            counter.RegisterObserver(frmText);
            FormRectangle frmRectangle = new FormRectangle();
            frmRectangle.Show();
            counter.RegisterObserver(frmRectangle);
            FormCircle frmCircle = new FormCircle();
            frmCircle.Show();
            counter.RegisterObserver(frmCircle);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            counter.Increment();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            counter.Decrement();
        }
    }
}
