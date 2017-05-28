using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;

namespace ShootingStarsGame
{

    [Serializable]
    public class Star
    {

        public static readonly int RADIUS = 30;

        public int State { get; set; }

        public Point Center { get; set; }

        public PointF []points = new PointF[7];

        public Star()
        {
            Random r = new Random();
            State = r.Next(2);
        }

        public void Move()
        {
            Center = new Point(Center.X, Center.Y + 3);
        }

        public void Draw(Graphics g)
        {
            Brush b = null;
            Pen p = null;
            if (State == 0)
            {
                b = new SolidBrush(Color.WhiteSmoke);
            }
            else
            {
                b = new SolidBrush(Color.Yellow);
            }
            points = StarPoints(5, new Rectangle(Center.X, Center.Y, RADIUS, RADIUS));
            g.FillPolygon(b, points);
            b.Dispose();

        }
     

        public bool Hit(Point position)
        {
            if (RADIUS * RADIUS >= (Center.X - position.X) * (Center.X - position.X) + (Center.Y - position.Y) * (Center.Y - position.Y))
            {
                State++;
                if (State == 2)
                {
                    return true;
                }
            }
            return false;
        }

        public PointF[] StarPoints(int num_points, Rectangle bounds)
        {
            // Make room for the points.
            PointF[] pts = new PointF[num_points];

            double rx = bounds.Width / 2;
            double ry = bounds.Height / 2;
            double cx = bounds.X + rx;
            double cy = bounds.Y + ry;

            // Start at the top.
            double theta = -Math.PI / 2;
            double dtheta = 4 * Math.PI / num_points;
            for (int i = 0; i < num_points; i++)
            {
                pts[i] = new PointF(
                    (float)(cx + rx * Math.Cos(theta)),
                    (float)(cy + ry * Math.Sin(theta)));
                theta += dtheta;
            }

            return pts;
        }

    }
}
