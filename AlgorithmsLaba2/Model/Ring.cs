using System;
using System.Collections.Generic;

using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace AlgorithmsLaba2.Model
{
    class Ring
    {
        private Rectangle ring;
        public Ring(double width, double height)
        {
            ring = new Rectangle();
            ring.Width = width;
            ring.Height = height;
            ring.Stroke = Brushes.Black;
            Brush brush = PickBrush();
            while (true)
            {
                if (brush != Brushes.Transparent || brush != Brushes.White)
                {
                    break;
                }
                brush = PickBrush();
            }
            ring.Fill = brush;
            ring.RadiusX = 30;
            ring.RadiusY = 60;
        }
        public Rectangle GetRect()
        {
            return this.ring;
        }
        private Brush PickBrush()
        {
            Brush result = Brushes.Beige;

            Random rnd = new Random();

            Type brushesType = typeof(Brushes);

            PropertyInfo[] properties = brushesType.GetProperties();

            int random = rnd.Next(properties.Length);
            result = (Brush)properties[random].GetValue(null, null);

            return result;
        }
    }
}
