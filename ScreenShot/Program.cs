using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.IO;
using System.Windows;



namespace Test_Application_C_Sharp
{
    class Program
    {

        public static void pause()
        {
            Console.Read();
        }

        static void Main()
        {
            string? data;
            while (true)
            {

                Console.WriteLine("Take screen shot -- 1");
                Console.WriteLine("Look at screen shots -- 2");
                Console.WriteLine("Delete shot -- 3");
                data = Console.ReadLine();
                if (data == "1")
                {
                    Bitmap memoryImage;
                    memoryImage = new Bitmap(1000, 900);
                    Size s = new Size(memoryImage.Width, memoryImage.Height);

                    Graphics memoryGraphics = Graphics.FromImage(memoryImage);

                    memoryGraphics.CopyFromScreen(0, 0, 0, 0, s);

                    string fileName = string.Format($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\ScreenShots") +
                              @"\Screen Shot" + "_" +
                              DateTime.Now.ToString("(dd_MMMM_hh_mm_ss_tt)") + ".png";

                    memoryImage.Save(fileName);

                    Console.WriteLine("Picture has been saved...");
                    Program.pause();
                }
                else if (data == "2")
                {
                    foreach (var folder in Directory.GetFiles($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\ScreenShots"))
                    {
                        if (folder.EndsWith(".png"))
                        {
                            Console.WriteLine(folder);
                        }
                    }
                    Thread.Sleep(6000);
                }
                else if (data == "3")
                {
                    Console.WriteLine("enter name of screenshot: ");
                    data = Console.ReadLine();

                    foreach (string folder in Directory.GetFiles($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\ScreenShots"))
                    {
                        if (folder == data)
                        {
                            File.Delete(folder);
                        }
                    }

                }
            }
        }
    }
}