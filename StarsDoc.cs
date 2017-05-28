using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingStarsGame
{
    [Serializable]
    public class StarsDoc
    {
        public List<Star> Stars { get; set; }

        public int Score = 0;
        public int missedStars = 10;
        public int rand = 0;           

        public StarsDoc()
        {
            Stars = new List<Star>();
         
        }

        public void AddStar(Point center)
        {
            Star s = new Star();
            s.Center = center;
            Stars.Add(s);
        }
        
        public void Hit(Point position)
        {
            foreach (Star s in Stars)
            {
                s.Hit(position);
            }
            for (int i = Stars.Count - 1; i >= 0; --i)
            {
                if (Stars[i].State == 2)
                {
                    Stars.RemoveAt(i);
                    Score += 1;
                }
            }
        }

        public void Move(int width, int height)
        {
            foreach (Star s in Stars)
            {
                s.Move();
                if (s.Center.Y > height - Star.RADIUS / 2)
                {
                    s.State = -1;
                }
            }
            for (int i = Stars.Count - 1; i >= 0; --i)
            {
                if (Stars[i].State == -1)
                { 

                    Stars.RemoveAt(i);
                    if (Score > 0) {
                        Score -= 1;

                    }
                    missedStars--;
                                       
                    if (missedStars == 0) {
                        Form1 fm = new Form1();
                        fm.Operiraj();
                       // fm.Close();
                        //fm.Hide();
                       // GameOverScreen gm = new GameOverScreen();
                       // gm.Show();
                        

                        rand = 1;
                        
                    }
                }
                if (rand==1)
                {//za da go prekine beskonecnoto prikazuvanje na game over
                    break;
                }
            }
        }

        public void Draw(Graphics g)
        {
            foreach (Star s in Stars)
            {
                s.Draw(g);
            }
        }
    }
}
