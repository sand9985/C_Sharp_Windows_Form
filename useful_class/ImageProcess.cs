/*
#===================================
#
#  ImageProcess ver 1.0
#  作者:NULL(w100386435)
#  個人小屋:http://home.gamer.com.tw/homeindex.php?owner=w100386435
#  轉載請保留此標籤
#====================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace ImageTool
{
    class ImageProcess
    {
        private static FastBitmap fast_bitmap = new FastBitmap();
        //灰階
        public static void gray(ref Bitmap img)
        {
            fast_bitmap.img = img;
            fast_bitmap.LockImage();

            for (int i = 0; i < fast_bitmap.img.Width; i++)
            {
                for (int j = 0; j < fast_bitmap.img.Height; j++)
                {
                    //0.299, 0.587, 0.114 混色比例
                    Color c=fast_bitmap.GetPixel(i, j); //取得像素
                    double gray = c.R * 0.299 + c.G * 0.587 + c.B * 0.114;
                    gray=Math.Round(gray); //四捨五入
                    fast_bitmap.SetPixel(i, j, Color.FromArgb(c.A, (int)gray, (int)gray, (int)gray));
                    
                }

            }

            fast_bitmap.UnlockImage();
        }
    }
}
