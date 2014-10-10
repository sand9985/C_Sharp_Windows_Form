/*
#===================================
#
#  Number_Textbox ver 1.0
#  作者:sand9985
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
   
     public Number_Textbox():base()
     {
       

     }

  


      //只能輸入數字
     protected override void OnKeyPress(KeyPressEventArgs e)
       {
            base.OnKeyPress(e);
            if (e.KeyChar == '-' && this.Text.Length==0) return;

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

        }
    


   }

