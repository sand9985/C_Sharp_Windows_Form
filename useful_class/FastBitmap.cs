using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

  unsafe class FastBitmap
    {
       public Bitmap img=null; //掛載用Bitmap
       private  Byte* p_base = null; //基底
       private int width;
       private BitmapData bitmap_data = null; //用來lock的data

       public FastBitmap()
       {  }
    
        //綁定圖片
       public void LockImage()
       {
           Rectangle bounds = new Rectangle(Point.Empty, img.Size);
           bitmap_data = img.LockBits(bounds, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
           width = (int)(bounds.Width * sizeof(PixelData));
           if (width % 4 != 0) width = 4 * (width / 4 + 1);
           p_base = (Byte*)bitmap_data.Scan0.ToPointer();
       
       }
      //解鎖圖片
       public void UnlockImage()
       {
           img.UnlockBits(bitmap_data);
           bitmap_data = null;
            p_base= null;
       }
       //取得像素
       public Color GetPixel(int x, int y)
       {
           PixelData* data;
           data = (PixelData*)(p_base + y * width + x * sizeof(PixelData));
           return Color.FromArgb(data->alpha, data->red, data->green, data->blue);
       }
       public void SetPixel(int x, int y, Color color)
       {
           PixelData* data = (PixelData*)(p_base + y * width + x * sizeof(PixelData));
           data->alpha = color.A;
           data->red = color.R;
           data->green = color.G;
           data->blue = color.B;
       }

    }

