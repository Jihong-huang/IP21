using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocationImage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static void Convert_Text_to_Image(string txt, string fontname, int fontsize, PictureBox picbox)
        {
            //creating bitmap image
            //Bitmap bmp = new Bitmap(8000, 5600);

            //FromImage method creates a new Graphics from the specified Image.
            Graphics graphics = Graphics.FromImage(picbox.BackgroundImage);
            // Create the Font object for the image text drawing.
            Font font = new Font(fontname, fontsize);
            // Instantiating object of Bitmap image again with the correct size for the text and font.
            SizeF stringSize = graphics.MeasureString(txt, font);
            //bmp = new Bitmap(bmp, (int)stringSize.Width, (int)stringSize.Height);
            //graphics = Graphics.FromImage(bmp);

            /* It can also be a way
           bmp = new Bitmap(bmp, new Size((int)graphics.MeasureString(txt, font).Width, (int)graphics.MeasureString(txt, font).Height));*/

            //Draw Specified text with specified format 
            graphics.DrawString(txt, font, Brushes.Red, 10, 20);
            font.Dispose();
            graphics.Flush();
            graphics.Dispose();
            //return bmp;     //return Bitmap Image 
        }

        private void btnconvert_Click(object sender, EventArgs e)
        {
            //string txtvalue = "3";
            int n = 0;

            //picbox.Image = 
            //Convert_Text_to_Image(txtvalue, "Bookman Old Style", 20, picbox); // Passing appropriate value to Convert_Text_to_Image method 

            picbox.SizeMode = PictureBoxSizeMode.StretchImage;
            //picbox.BackgroundImage = 
            Bitmap bmp = new Bitmap(1000, 1000);
            Graphics graphics = Graphics.FromImage(bmp);
            // Create the Font object for the image text drawing.
            Font font = new Font("Bookman Old Style", 20);


            string path = @"c:\scip\location.txt";
            char[] delimiterChars = { ' ', ',', '.', ':', '\t' };
            int top=0, left=0;
            StreamReader sr = File.OpenText(path);

            string s = "";
            //graphics.DrawString("A", font, Brushes.Red, 1000, 1000);
            
            while ((s = sr.ReadLine()) != null)
            {
                n++;

                string[] words = s.Split(delimiterChars);
                //MessageBox.Show(words[0]);
                //MessageBox.Show(words[1]);

                top = int.Parse(words[0])/10;
                left = int.Parse(words[1])/10;
                //MessageBox.Show(n.ToString()+ "    " + top.ToString() + "  " + left.ToString());

                graphics.DrawString(n.ToString(), font, Brushes.Red, left, top);
            }
            graphics.DrawString("B", font, Brushes.Red, 0, 0);
            picbox.Image = bmp;
            bmp.Save("c:\\scip\\test.bmp");
            font.Dispose();
            graphics.Flush();
            graphics.Dispose();
        }

    }
}
