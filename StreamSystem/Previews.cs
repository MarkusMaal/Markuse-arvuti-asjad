using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StreamSystem
{
    public partial class Previews : Form
    {
        Bitmap screen = new Bitmap(1920, 1080);
        Bitmap osd = new Bitmap(1920, 1080);
        int osd_x = 1;
        int osd_y = 1;
        bool x_right = true;
        bool y_right = true;
        int osd_w = 460;
        int osd_h = 100;
        int inc = 10;
        public Previews()
        {
            InitializeComponent();
        }

        private void Previews_Load(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(1920, 1080);
            Graphics g = Graphics.FromImage(bmp);
            g.DrawImage(screen, new Point(0, 0));
            Color[] colors = { Color.FromArgb(230, 230, 230), Color.Yellow, Color.Cyan, Color.Lime, Color.Magenta, Color.Red, Color.Blue };
            for (int i = 0; i < 7; i++)
            {
                Rectangle rect = new Rectangle();
                rect.Location = new Point(i * (1920 / 7), 0);
                rect.Size = new Size(1920 / 7, 1080);
                Brush b = new SolidBrush(colors[i]);
                g.FillRectangle(b, rect);
            }
            screen = bmp;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (x_right) { osd_x+=inc; }
            else { osd_x-= inc; }

            if (osd_x > 1920 - osd_w) { x_right = false; osd_x= 1920 - osd_w; }
            else if (osd_x < 0) { x_right = true; osd_x=0; }

            if (y_right) { osd_y+= inc; }
            else { osd_y-= inc; }

            if (osd_y > 1080 - osd_h) { y_right = false; osd_y= 1080 - osd_h; }
            else if (osd_y < 0) { y_right = true; osd_y=0; }

            //update osd
            Bitmap bmp = new Bitmap(1920, 1080);
            Graphics g = Graphics.FromImage(bmp);
            //osd.Dispose();
            Rectangle rect2 = new Rectangle();
            rect2.Location = new Point(osd_x, osd_y);
            rect2.Size = new Size(osd_w, osd_h);
            Brush b2 = new SolidBrush(Color.Black);
            g.FillRectangle(b2, rect2);
            g.DrawString("No command", new Font("Arial", 52.0f, FontStyle.Regular), new SolidBrush(Color.White), new Point(osd_x + 10, osd_y + 10));
            osd = bmp;
            g.Dispose();
            screenDisp.Image = screen;
            osdDisp.Image = osd;
            combinedVideo.BackgroundImage = screen;
            combinedVideo.Image = osd;
        }
    }
}
