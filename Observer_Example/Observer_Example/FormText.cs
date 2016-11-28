using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Observer_Example
{
    public partial class FormText : Form, IObserver
    {
        private Counter counter;
        public FormText()
        {
            counter = Counter.Instance;
            InitializeComponent();
        }

        public void Update(int count)
        {
            SetTextBox(count);
        }

        private void SetTextBox(int count)
        {
            textBox1.Text = count.ToString();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar))
            {
                if (textBox1.Text.Length > 10)
                    textBox1.Text = textBox1.Text.Substring(0, 10);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                counter.UpdateCount(Convert.ToInt32(textBox1.Text));
            }
            else
            {
                counter.UpdateCount(0);
            }
        }
    }
}
