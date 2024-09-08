using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DLAModel
{
    public partial class Form1 : Form
    {
        bool condition = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            condition = true;
            Random obj = new Random();
            Point coordinate;
            Graphics gg = this.CreateGraphics();
            Pen wp = new Pen(Color.White, (float)5);
            DLA eden = new DLA();
            eden.seed();
            while(condition)
            {
                eden.peridecide();
                coordinate = eden.occupysites(obj);
                gg.DrawEllipse(wp, 50 + coordinate.X * 4, coordinate.Y * 4, 2, 2);

            }

        }
    }
}
