/*
 * Copyright 2020 tgiqfe
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;

namespace CheckMonospace
{
    /// <summary>
    /// System.Drawing.Fontで、プロポーショナルと等幅を管理
    /// 
    /// 「源ノ角ゴシック Code JP (Source Han Code JP)」が、
    ///     i×2文字の幅 ＝ w×2文字の幅
    ///     半角×3文字の幅 ＝ 全角×2文字の幅
    /// なので、これの検出の為に「ああ」の幅もチェック
    /// </summary>
    public class DrawingFontInfo
    {
        public List<Font> ProportionalList { get; set; }
        public List<Font> MonospaceList { get; set; }

        public DrawingFontInfo()
        {
            this.ProportionalList = new List<Font>();
            this.MonospaceList = new List<Font>();

            var fontNames = new InstalledFontCollection().Families.Select(x => x.Name).ToArray();

            Console.WriteLine(fontNames.Length);

            using (var bmp = new Bitmap(1, 1))
            using (var graphics = Graphics.FromImage(bmp))
            {
                foreach (var name in fontNames)
                {
                    using (Font font = new Font(name, emSize: 20))
                    {
                        float iiSize = graphics.MeasureString("iiii", font).Width;
                        float wwSize = graphics.MeasureString("wwww", font).Width;

                        if (iiSize == wwSize)
                        {
                            float aaSize = graphics.MeasureString("ああ", font).Width;
                            if(Math.Abs(iiSize - aaSize) < 1)
                            {
                                MonospaceList.Add(font);
                                continue;
                            }
                        }
                        ProportionalList.Add(font);
                    }
                }
            }
        }
    }
}
