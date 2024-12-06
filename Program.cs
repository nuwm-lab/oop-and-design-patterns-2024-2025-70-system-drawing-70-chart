using System;
using System.Drawing;
using System.Windows.Forms;

namespace LabWork
{
    internal class Form1 : Form
    {
        private const double XMin = 2.3;
        private const double XMax = 7.8;
        private const double DeltaX = 0.9;
        private const int Margin = 20;

        public Form1()
        {
            this.Text = "Графік функції";
            this.Width = 800;
            this.Height = 600;

            this.Paint += Form1_Paint;

            this.Resize += (s, e) => this.Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawGraph(e.Graphics);
        }

        private void DrawGraph(Graphics graph)
        {
            using (Pen pen = new Pen(Color.Red, 2))
            using (Font axisFont = new Font("Arial", 10))
            {
                int formWidth = this.ClientSize.Width;
                int formHeight = this.ClientSize.Height;

                double scaleX = (formWidth - 2 * Margin) / (XMax - XMin);
                double scaleY = (formHeight - 2 * Margin) / 20.0;

                graph.DrawLine(Pens.Black, Margin, formHeight / 2, formWidth - Margin, formHeight / 2);
                graph.DrawLine(Pens.Black, formWidth / 2, Margin, formWidth / 2, formHeight - Margin);
                graph.DrawString("X", axisFont, Brushes.Black, formWidth - Margin, formHeight / 2 + 5);
                graph.DrawString("Y", axisFont, Brushes.Black, formWidth / 2 + 5, Margin);

                double xPrev = XMin;
                double yPrev = CalculateFunction(xPrev);
                int prevX = (int)(Margin + (xPrev - XMin) * scaleX);
                int prevY = (int)(formHeight / 2 - yPrev * scaleY);

                for (double x = XMin + DeltaX; x <= XMax; x += DeltaX)
                {
                    double y = CalculateFunction(x);
                    if (Math.Abs(y) > 1000) continue;

                    int currentX = (int)(Margin + (x - XMin) * scaleX);
                    int currentY = (int)(formHeight / 2 - y * scaleY);
                    graph.DrawLine(pen, prevX, prevY, currentX, currentY);

                    prevX = currentX;
                    prevY = currentY;
                }
            }
        }

        private double CalculateFunction(double x)
        {
            double denominator = Math.Sin(3 * x) - x;
            return Math.Abs(denominator) > 1e-6 ? (6 * x + 4) / denominator : double.NaN;
        }
    }
}
