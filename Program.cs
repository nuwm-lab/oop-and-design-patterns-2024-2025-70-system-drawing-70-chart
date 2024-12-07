using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace GraphApp
{
    public class GraphForm : Form
    {
        public GraphForm()
        {
            // Встановлення початкових параметрів форми
            this.Text = "Графік функції";
            this.ClientSize = new Size(800, 600);
            this.BackColor = Color.White;

            // Підписка на подію Paint для відображення графіка
            this.Paint += new PaintEventHandler(this.OnPaint);

            // Підписка на подію Resize для перерисовки графіка при зміні розміру форми
            this.Resize += (sender, e) => this.Invalidate();
        }

        /// <summary>
        /// Обробка події Paint для малювання графіка.
        /// </summary>
        private void OnPaint(object sender, PaintEventArgs e)
        {
            // Отримуємо графічний об'єкт
            Graphics g = e.Graphics;

            // Параметри масштабування
            int width = this.ClientSize.Width;
            int height = this.ClientSize.Height;

            // Центрування осей
            int centerX = width / 10;
            int centerY = height * 9 / 10;

            // Довжина графіка на осі X
            int graphWidth = width * 8 / 10;
            int graphHeight = height * 8 / 10;

            // Малювання координатних осей
            DrawAxes(g, centerX, centerY, graphWidth, graphHeight);

            // Малювання графіка
            DrawGraph(g, centerX, centerY, graphWidth, graphHeight);
        }

        /// <summary>
        /// Малювання координатних осей.
        /// </summary>
        private void DrawAxes(Graphics g, int centerX, int centerY, int graphWidth, int graphHeight)
        {
            Pen axisPen = new Pen(Color.Black, 2);

            // Лінія осі X
            g.DrawLine(axisPen, centerX, centerY, centerX + graphWidth, centerY);

            // Лінія осі Y
            g.DrawLine(axisPen, centerX, centerY, centerX, centerY - graphHeight);

            // Підпис осей
            Font font = new Font("Arial", 10);
            Brush brush = Brushes.Black;

            g.DrawString("X", font, brush, centerX + graphWidth + 5, centerY - 10);
            g.DrawString("Y", font, brush, centerX - 20, centerY - graphHeight - 10);
        }

        /// <summary>
        /// Малювання графіка функції.
        /// </summary>
        private void DrawGraph(Graphics g, int centerX, int centerY, int graphWidth, int graphHeight)
        {
            Pen graphPen = new Pen(Color.Red, 2);

            // Масштабування
            double scaleX = graphWidth / 0.5; // Кількість пікселів на одиницю X
            double scaleY = graphHeight / 0.25; // Кількість пікселів на одиницю Y

            // Попередня точка графіка
            PointF? prevPoint = null;

            // Розрахунок і малювання точок
            for (double x = 0; x <= 0.5; x += 0.01)
            {
                double y = (2.5 * Math.Pow(x, 3)) / (Math.Exp(2 * x) + 2);
                float pixelX = (float)(centerX + x * scaleX);
                float pixelY = (float)(centerY - y * scaleY);

                PointF currentPoint = new PointF(pixelX, pixelY);

                if (prevPoint != null)
                {
                    g.DrawLine(graphPen, prevPoint.Value, currentPoint);
                }

                prevPoint = currentPoint;
            }
        }

        /// <summary>
        /// Точка входу в програму.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GraphForm());
        }
    }
}
