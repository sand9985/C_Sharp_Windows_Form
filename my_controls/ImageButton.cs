/*
#===================================
#
#  ImageButton ver 1.0
#  作者:NULL(w100386435)
#  個人小屋:http://home.gamer.com.tw/homeindex.php?owner=w100386435
#  轉載請保留此標籤
#====================================
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
   class ImageButton : Control
  {

      public Image backgroundImage, pressedImage; //圖片

      private bool pressed = false;  //是否按下
       public ImageButton()
           : base()
       {
           SetStyle(ControlStyles.OptimizedDoubleBuffer, true); //設定雙緩衝
       }

       //刷新control size
       public void update_size()
       {
           if (backgroundImage != null)
           {

               this.Size = new Size(backgroundImage.Width, backgroundImage.Height);
           }

       }
      
       //當滑鼠按下
       protected override void OnMouseDown(MouseEventArgs e)
       {
           this.pressed = true;
           this.Invalidate();
           base.OnMouseDown(e);
       }

         //當滑鼠離開
       protected override void OnMouseUp(MouseEventArgs e)
       {
           this.pressed = false;
           this.Invalidate();
           base.OnMouseUp(e);
       }
        //繪圖資訊
       protected override void OnPaint(PaintEventArgs e)
       {
           if (this.pressed && this.pressedImage != null)
               e.Graphics.DrawImage(this.pressedImage, 0, 0);
           else
               e.Graphics.DrawImage(this.backgroundImage, 0, 0);

           base.OnPaint(e);
       }

 }

