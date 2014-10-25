/*
#===================================
#
#  ImageProcess ver 1.0
#  作者:sand9985
#  轉載請保留此標籤
#====================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

   public class ImageProcess
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

        //最小容納圖片範圍
        public static void minimum_bound_box(ref Bitmap img)
        {
            fast_bitmap.img = img;
            fast_bitmap.LockImage();
            int min_x = fast_bitmap.img.Width;
            int max_x = 0;
            int min_y = fast_bitmap.img.Height;
            int max_y = 0;
            for (int i = 0; i < fast_bitmap.img.Width; i++)
            {
                for (int j = 0; j < fast_bitmap.img.Height; j++)
                {

                    Color c = fast_bitmap.GetPixel(i, j); //取得像素

                    if (c.A != 0)
                    {
                        min_x = Math.Min(min_x, i);
                        max_x = Math.Max(max_x, i);
                        min_y = Math.Min(min_y, j);
                        max_y = Math.Max(max_y, j);


                    }

                }
            }

            fast_bitmap.UnlockImage();
            int x=min_x;
            int y=min_y;
            int width=(max_x - min_x)+1;
            int height=(max_y-min_y)+1;

            Bitmap new_bitmap = new Bitmap(width, height);

            Graphics g = Graphics.FromImage(new_bitmap);
            GraphicsUnit units = GraphicsUnit.Pixel;
            Rectangle rect=new Rectangle(0,0,width,height);
            Rectangle rect2=new Rectangle(x,y,width,height);
            g.DrawImage(img, rect, rect2, units);

            img.Dispose(); //釋放資源
            img = new_bitmap; //取代成新的圖片


        }


            

    }

