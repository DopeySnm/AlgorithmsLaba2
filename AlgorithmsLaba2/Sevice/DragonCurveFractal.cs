using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;

namespace AlgorithmsLaba2.Sevice
{
    internal class DragonCurveFractal
    {
        private int II = 0;
        private int i = 0;
        private int depth;
        private Canvas canvas;
        private TextBlock tbLabel;
        public DragonCurveFractal(Canvas canvas, TextBlock tbLabel)
        {
            this.canvas = canvas;
            this.tbLabel = tbLabel;
        }
        public void CheckAndStart(TextBox inputRings, object sender, RoutedEventArgs e)
        {
            if (inputRings.Text != "")
            {
                depth = int.Parse(inputRings.Text);
                canvas.Children.Clear();
                tbLabel.Text = "";
                i = 0;
                II = 1;
                StartAnimation(sender, e);
                CompositionTarget.Rendering += StartAnimation;
            }
        }
        private void StartAnimation(object sender, EventArgs e)
        {
            i += 1;
            if (i % 60 == 0)
            {
                DrawDragonСurve(canvas,
                new Point(canvas.Width / 2, canvas.Height / 2 - 200),
                    new Point(canvas.Width / 2, canvas.Height / 2 + 300), II);
                string str = "Глубина отрисовки\n" +
                II.ToString();
                tbLabel.Text = str;
                II += 1;
                if (II > depth)
                {
                    tbLabel.Text = $"Глубина отрисовки\n{depth}";
                    CompositionTarget.Rendering -= StartAnimation;
                }
            }
        }
        private void DrawDragonСurve(Canvas canvas, Point pt1, Point pt2, int depth)
        {
            double xn = (pt1.X + pt2.X) / 2 + (pt2.Y - pt1.Y) / 2;
            double yn = (pt1.Y + pt2.Y) / 2 - (pt2.X - pt1.X) / 2;
            Line line = new Line();
            line.Stroke = Brushes.Black;
            line.X1 = pt1.X;
            line.Y1 = pt1.Y;
            line.X2 = pt2.X;
            line.Y2 = pt2.Y;
            canvas.Children.Add(line);
            if (depth > 1)
            {
                DrawDragonСurve(
                    canvas,
                    new Point(pt2.X, pt2.Y),
                    new Point(xn, yn),
                    depth - 1
                    );
                DrawDragonСurve(
                    canvas,
                    new Point(pt1.X, pt1.Y),
                    new Point(xn, yn),
                    depth - 1
                    );
            }
            else
            {
                return;
            }
        }
    }
}
