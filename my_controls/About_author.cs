/*
#===================================
#
#  About_author dialog ver 1.0
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
   class About_author : Form
    {
       private Label text = new Label(); //文字
       private LinkLabel linkLabel= new LinkLabel(); //web連結

       public About_author()
       {
           fixed_size(); //固定大小
           this.Text = "關於作者"; //標題
           this.Size = new Size(400, 200); //設定視窗大小
           this.ShowIcon = false; //不顯示icon
           this.Controls.Add(text);
           this.Controls.Add(linkLabel);
           set_link_lable();
           set_text_label();


       }
       //固定大小不可拉動
       private void fixed_size()
       {
           this.MaximizeBox = false;
           this.MinimizeBox = false;
           this.FormBorderStyle = FormBorderStyle.FixedSingle;

       }
       //設定文字資訊
       private void set_text_label()
       {
           text.Text = "你好，我是NULL，歡迎使用此工具，這是一個\n簡易的影像處理小工具，會後續追加功能!!"; //文字資訊
           text.AutoSize = true; //自動調整文字大小
           text.Location = new Point((int)(400 * 0.1), (int)(200 * 0.1));

       }
       //設定linklabel
       private void set_link_lable()
       {

           this.linkLabel.AutoSize = true; //自動調整大小
           this.linkLabel.Text = "作者小屋";
           this.linkLabel.LinkClicked += new LinkLabelLinkClickedEventHandler(link_to_web);
           this.linkLabel.Location = new Point((int)(400 * 0.1), (int)(200 * 0.25));
       }
      
         //連到網頁去
       protected void link_to_web(object who, EventArgs e)
       {

         
           this.linkLabel.LinkVisited = true;
           System.Diagnostics.Process.Start("http://home.gamer.com.tw/homeindex.php?owner=w100386435"); 


       }
    }

