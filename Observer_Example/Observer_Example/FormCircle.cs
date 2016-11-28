using System.Drawing;
using System.Windows.Forms;

namespace Observer_Example
{
    public partial class FormCircle : Form, IObserver
    {
        public FormCircle()
        {
            InitializeComponent();
        }

        public void Update(int count)
        {
            UpdateCircle(count);
        }

        public void UpdateCircle(int count)
        {
            CreateGraphics().Clear(BackColor);
            Graphics g = CreateGraphics();
            Pen pen = new Pen(Color.Red);
            g.DrawEllipse(pen, 10, 10, count * 10, count * 10);
        }
    }
}
