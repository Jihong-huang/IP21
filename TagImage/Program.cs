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
using System.Text.RegularExpressions;

namespace TagImage
{
    class Program
    {
        static void Main(string[] args)
        {
   
                int n = 0;

                
                Bitmap bmp = new Bitmap(1000, 1000);
                Graphics graphics = Graphics.FromImage(bmp);
                // Create the Font object for the image text drawing.
                Font font = new Font("Bookman Old Style", 20);

            //args[0] = "c:\\scip\\L500TankIWW.tag";
            //args[1] = "c:\\scip\\L500TankIWW.bmp";

            //string path = @"c:\scip\location.txt";
            string path = args[0];
            
         
                    char[] delimiterChars = { ' ', ',' };
                int top = 0, left = 0;
                StreamReader sr = File.OpenText(path);

                string s = "";
            //graphics.DrawString("A", font, Brushes.Red, 1000, 1000);

            while ((s = sr.ReadLine()) != null)
            {
                n++;
                Console.Write(s);
                Console.WriteLine();
                string[] words = s.Split(delimiterChars);

                top = int.Parse(words[1]) / 10;
                left = int.Parse(words[2]) / 10;
                
                //Console.Write(n.ToString() + "    " + top.ToString() + "  " + left.ToString());


                graphics.DrawString(n.ToString(), font, Brushes.Red, left, top);
             }
            bmp.Save(args[1]);
            font.Dispose();
            graphics.Flush();
            graphics.Dispose();
        }
    }
}
