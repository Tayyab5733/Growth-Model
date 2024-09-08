using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace DLAModel
{
    class DLA
    {
        int size = 300, x, y;
        bool[,] oc; //oc=occupied
        bool[,] peri;//peri=perimeter

        public DLA()
        {
            oc = new bool[size, size];
            peri = new bool[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    oc[i, j] = false;
                    peri[i, j] = false;
                }
            }
        }
        public void seed()
        {
            oc[(int)size / 2, (int)size / 2] = true;
            // for (int j = 0; j < size; j++)
            // {
            //   oc[0, j] = true; //top boundry k tmam cells ko true kry ga
            //     oc[sizeof- 1, j] = true;//bottom boundry k tmam cells ko true kry ga
            //     oc[j, 0] = true;//left boundry k tmam cells ko true kry ga
            //     oc[j, sizeof- 1] = true;//right boundry k tmam cells ko true kry ga
            //}
        }
        public void peridecide()
        {
            for (int i = 1; i < size - 1; i++)
            {
                for (int j = 1; j < size - 1; j++)
                {
                    if (oc[i, j] == true)
                    {
                        if (oc[i - 1, j] == false)
                        {
                            peri[i - 1, j] = true;
                        }
                        if (oc[i + 1, j] == false)
                        {
                            peri[i + 1, j] = true;
                        }
                        if (oc[i, j - 1] == false)
                        {
                            peri[i, j - 1] = true;
                        }
                        if (oc[i, j + 1] == false)
                        {
                            peri[i, j + 1] = true;
                        }
                    }//end if exteenal
                }//end for internal
            }//end for external
        }//end method decide peri
        public Point occupysites(Random obj)
        {
            Point coordinates = new Point();
            x = obj.Next(0, size);
            y = obj.Next(0, size);
            while (peri[x, y] == false)
            {
                if (obj.NextDouble() < 0.5 && x < (size - 1))
                {
                    x = x + 1;
                }
                else if (x > 0)
                {
                    x = x - 1;
                }
                if (obj.NextDouble() < 0.5 && y < (size - 1))
                {
                    y = y + 1;
                }
                else if (y > 0)
                {
                    y = y - 1;
                }
            }
            if (peri[x, y] == true)
            {
                oc[x, y] = true;
                peri[x, y] = false;
                coordinates.X = x;
                coordinates.Y = y;
            }
            return coordinates;
        }
    }
}
