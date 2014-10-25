using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

public class AlphaPictureBox :PictureBox
 {

    private Bitmap alpha_image=null; //透明貼圖

    public AlphaPictureBox():base()
    {
        this.SizeMode = PictureBoxSizeMode.StretchImage;
        SetStyle(ControlStyles.OptimizedDoubleBuffer, true); //設定雙緩衝
    }

     //刷新透明圖片
    public void update_alpha_image()
    {

        if (alpha_image != null) alpha_image.Dispose(); //釋放資源
         alpha_image = new Bitmap(this.Width, this.Height); //創建和controler一樣大小

         Brush white_brush=new SolidBrush(Color.White);
         Brush gray_brush = new SolidBrush(Color.FromArgb(255,191,191,191));
         Graphics g = Graphics.FromImage(alpha_image);

         int first_color_type = 1; //1 :white -1 gray
         int type ;
         for (int i = 0; i < this.Width; i += 8)
         {
             if (first_color_type == 1)
                 type = 1;
             else
                 type = -1;
   
             for (int j = 0; j < this.Height; j += 8)
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

    //繪圖
    protected override void OnPaint(PaintEventArgs pe)
    {
        if (alpha_image != null)
        {
            pe.Graphics.DrawImage(alpha_image, 0, 0);

        }

        base.OnPaint(pe);

    }


    //釋放資源
    public  new void Dispose()
    {
        if (alpha_image != null) alpha_image.Dispose(); 
        base.Dispose();
    }
  
 }

