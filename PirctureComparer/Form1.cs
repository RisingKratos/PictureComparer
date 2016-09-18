using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PirctureComparer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog firstPictureDialog = new OpenFileDialog())
            {
                firstPictureDialog.Title = "Select first picture";

                if(firstPictureDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = new Bitmap(firstPictureDialog.FileName);
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog secondPictureDialog = new OpenFileDialog())
            {
                secondPictureDialog.Title = "Select second picture";

                if (secondPictureDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox2.Image = new Bitmap(secondPictureDialog.FileName);
                }
            }
        }

        private void CompareButton_Click(object sender, EventArgs e)
        {
            Bitmap firstPicture = new Bitmap(pictureBox1.Image);
            Bitmap secondPicture = new Bitmap(pictureBox2.Image);

            for (int x = 0; x < firstPicture.Width; ++x)
            {
                for (int y = 0; y < firstPicture.Height; ++y)
                {
                    if (firstPicture.GetPixel(x, y) != secondPicture.GetPixel(x, y))
                    {
                        Graphics filler = pictureBox2.CreateGraphics();
                        filler.DrawRectangle(Pens.Red,x,y,1,1);
                    }
                }
            }
        }
    }
}
