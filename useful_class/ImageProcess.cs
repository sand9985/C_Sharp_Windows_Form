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


        //生成透明貼圖
        public static void generate_alpha_bitmap(ref Bitmap img)
        {
            Brush white_brush = new SolidBrush(Color.White);
            Brush gray_brush = new SolidBrush(Color.FromArgb(255, 191, 191, 191));
            Graphics g = Graphics.FromImage(img);

            int first_color_type = 1; //1 :white -1 gray
            int type;
            for (int i = 0; i < img.Width; i += 8)
            {
                if (first_color_type == 1)
                    type = 1;
                else
                    type = -1;

                for (int j = 0; j < img.Height; j += 8)
                {
                    if (type == 1)
                        g.FillRectangle(white_brush, i, j, 8, 8);
                    else
                        g.FillRectangle(gray_brush, i, j, 8, 8);

                    type = -type;
                }
                first_color_type = -first_color_type;
            }

        }



        public static void adjust_tone(ref Bitmap img,int tone_r,int tone_g,int tone_b,int tone_gray)
        {
            fast_bitmap.img = img;
            fast_bitmap.LockImage();


            for (int i = 0; i < fast_bitmap.img.Width; i++)
            {
                for (int j = 0; j < fast_bitmap.img.Height; j++)
                {
                    //0.299, 0.587, 0.114 混色比例
                    Color c = fast_bitmap.GetPixel(i, j); //取得像素
                    double gray = c.R * 0.299 + c.G * 0.587 + c.B * 0.114;
                   
                    gray /= 255.0;
                    double percent = (tone_gray/255.0)- 1.0;

                    double r = gray + (gray - (c.R / 255.0)) * percent;
                    double g = gray + (gray - (c.G / 255.0)) * percent;
                    double b = gray + (gray - (c.B / 255.0)) * percent;

                    r += (tone_r / 255.0);
                    g += (tone_g / 255.0);
                    b += (tone_b / 255.0);
                   
                    int r2=(int)Math.Round(r * 255.0);
                    int g2 = (int)Math.Round(g * 255.0);
                    int b2 = (int)Math.Round(b * 255.0);
                     
                    
                    

                    r2 = Math.Max(0, r2); r2 = Math.Min(255, r2);
                    g2 = Math.Max(0, g2); g2 = Math.Min(255, g2);
                    b2 = Math.Max(0, b2); b2 = Math.Min(255, b2);

                    fast_bitmap.SetPixel(i, j, Color.FromArgb(c.A, r2, g2, b2));

                }

            }




            fast_bitmap.UnlockImage();

        }

    }

