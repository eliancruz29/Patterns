using System.Drawing;
using System.Windows.Forms;

namespace Observer_Example
{
    public partial class FormRectangle : Form, IObserver
    {
        public FormRectangle()
        {
            InitializeComponent();
        }

        public void Update(int count)
        {
            UpdateRectangle(count);
        }

        private void UpdateRectangle(int count)
        {
            CreateGraphics().Clear(BackColor);
            SolidBrush myBrush = new SolidBrush(Color.Red);
            Graphics formGraphics = CreateGraphics();

            formGraphics.FillRectangle(myBrush, new Rectangle(0, 0, count * 10, count * 10));
            myBrush.Dispose();
            formGraphics.Dispose();
        }
    }
}
