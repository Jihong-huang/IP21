using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace NodeLocation
{
    class Program      
    {
        static void Main(string[] args)
        {
            //int top = 0, left = 0;
            string top="", left = "";
            string sNumber = "";        

            //Console.Write(args.Length);
            //string path = @"c:\scip\L500TankIWW0.xml";
            XmlTextReader reader = new XmlTextReader(args[0]);
            bool flag=false;
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // The node is an element.
                        if (reader.Name == "Datafield")
                        {
                            sNumber = reader.GetAttribute("defaultText");
                            Console.Write(sNumber+ ",");
                            flag = true;
                            //Console.Write("<" + reader.Name);
                            //Console.WriteLine(">");
                        }


                        if (flag && (reader.Name == "Location"))
                        {

                            top = reader.GetAttribute("top");
                            left = reader.GetAttribute("left");
                            //Console.Write("top=" + top.ToString() + "  left=" + left.ToString());
                            Console.Write(top + "," + left);
                            Console.WriteLine();
                        }

                        break;
                    case XmlNodeType.Text: //Display the text in each element.
                        if (flag)
                        {
                            Console.WriteLine(reader.Value);
                        }
                        break;

                    case XmlNodeType.EndElement: //Display the end of the element.
                        if (reader.Name == "Datafield")
                        {
                            flag = false;
                        }
                        //Console.Write("</" + reader.Name);
                        //Console.WriteLine(">");
                        break;
                }
            }

        }

    }
}
