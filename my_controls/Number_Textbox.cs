/*
#===================================
#
#  Number_Textbox ver 1.0
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

 class Number_Textbox:TextBox
    {
      private int min;
      private int max;

     public Number_Textbox():base()
     {
         //預設
         min = 0;
         max = 100;

     }

     //設定修正範圍
     public void set_range(int min,int max){
         this.min = min;
         this.max = max;


     }

      //只能輸入數字
     protected override void OnKeyPress(KeyPressEventArgs e)
       {
            base.OnKeyPress(e);
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

        }
    


   }

