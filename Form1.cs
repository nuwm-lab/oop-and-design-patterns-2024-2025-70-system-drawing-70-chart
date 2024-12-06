using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Invalidate(); // Викликає перерисування форми
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawAxes(e.Graphics);  // Малює осі координат
            DrawGraph(e.Graphics); // Малює графік
        }

        private void DrawAxes(Graphics graph)
        {
            Pen axisPen = new Pen(Color.Black, 2);

            int centerX = this.ClientSize.Width / 2;
            int centerY = this.ClientSize.Height / 2;

            // Малювання горизонтальної осі
            graph.DrawLine(axisPen, 0, centerY, this.ClientSize.Width, centerY);

            // Малювання вертикальної осі
            graph.DrawLine(axisPen, centerX, 0, centerX, this.ClientSize.Height);
        }

        private void DrawGraph(Graphics graph)
        {
            Pen pen = new Pen(Color.SlateBlue, 3);

            int centerX = this.ClientSize.Width / 2;
            int centerY = this.ClientSize.Height / 2;

            int startX = centerX, startY = centerY;

            for (double x2 = 0; x2 <= 0.5; x2 += 0.05)
            {
                double yValue = (2.5 * Math.Pow(x2, 3)) / (Math.Exp(2 * x2) + 2);

                int scaledX = centerX + (int)(x2 * 400);
                int scaledY = centerY - (int)(yValue * 400);

                graph.DrawLine(pen, startX, startY, scaledX, scaledY);
                startX = scaledX;
                startY = scaledY;
            }
        }
    }
}
