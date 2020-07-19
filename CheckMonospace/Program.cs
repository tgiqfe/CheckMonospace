using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Media;
using System.Windows.Markup;
using System.Threading;
using System.Windows;

namespace CheckMonospace
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowDrawingFontInfo();

            ShowMediaFontInfo();

            Console.ReadLine();
        }

        private static void ShowDrawingFontInfo()
        {
            DrawingFontInfo dfi = new DrawingFontInfo();

            Console.WriteLine("======== プロポーショナルフォント ===========");
            foreach (var font in dfi.ProportionalList)
            {
                Console.WriteLine(font.Name);
            }

            Console.WriteLine("======== 等幅フォント =======================");
            foreach (var font in dfi.MonospaceList)
            {
                Console.WriteLine(font.Name);
            }
        }

        private static void ShowMediaFontInfo()
        {
            MediaFontInfo mfi = new MediaFontInfo();

            Console.WriteLine("プロポーショナルフォント ===================");
            foreach (var font in mfi.ProportionalList)
            {
                Console.WriteLine(font.Source);
            }

            Console.WriteLine("等幅フォント ===============================");
            foreach (var font in mfi.MonospaceList)
            {
                Console.WriteLine(font.Source);
            }
        }
    }
}
