/*
#===================================
#
#  DecideDialog ver 1.0
#  作者:sand9985
#  轉載請保留此標籤
#====================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
  public  class DecideDialog:Form
  {
      public Label info = null;

      public DecideDialog()
      {

          init();
          
      }
      //初始化
      private void init()
      {
          
          this.FormBorderStyle = FormBorderStyle.FixedDialog;
          //取消放大縮小盒
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Text = "訊息";
          this.Size = new Size(200, 150);
          //創建確認
          Button OK = new Button();
          OK.Text = "確認";
          OK.DialogResult = DialogResult.OK;
          OK.Location = new Point(10, 90);
          this.Controls.Add(OK);

          //創建取消
          Button cancel = new Button();
          cancel.Text = "取消";
          cancel.DialogResult = DialogResult.Cancel;
          cancel.Location = new Point(110, 90);
          this.Controls.Add(cancel);

          //訊息
          info = new Label();
          info.AutoSize = true;
          this.Controls.Add(info);
        
      }

  }

