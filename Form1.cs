using System;
using System.Drawing;
using System.Windows.Forms;

namespace GraphApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Графік функції";
            this.Resize += (sender, e) => this.Invalidate(); // Перемальовування при зміні розміру
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Розміри форми
            int width = this.ClientSize.Width;
            int height = this.ClientSize.Height;

            // Поля форми
            float margin = 40; // Відступи
            RectangleF plotArea = new RectangleF(margin, margin, width - 2 * margin, height - 2 * margin);

            // Малювання осей
            g.DrawLine(Pens.Black, margin, height / 2, width - margin, height / 2); // Вісь X
            g.DrawLine(Pens.Black, width / 2, margin, width / 2, height - margin); // Вісь Y

            // Межі функції
            float xMin = 0.2f;
            float xMax = 10f;
            float dx = 0.01f;

            // Масштаб
            float xScale = plotArea.Width / (xMax - xMin);
            float yScale = plotArea.Height / 5; // Вибір масштабу для Y

            // Центр координат
            float x0 = margin;
            float y0 = height / 2;

            // Малювання графіка
            PointF? prevPoint = null;
            for (float x = xMin; x <= xMax; x += dx)
            {
                float y = (x + (float)Math.Cos(2 * x)) / (x + 2);

                // Перетворення координат у піксельну систему
                float screenX = x0 + (x - xMin) * xScale;
                float screenY = y0 - y * yScale;

                PointF currentPoint = new PointF(screenX, screenY);

                if (prevPoint != null)
                {
                    g.DrawLine(Pens.Blue, prevPoint.Value, currentPoint);
                }

                prevPoint = currentPoint;
            }
        }
    }
} 