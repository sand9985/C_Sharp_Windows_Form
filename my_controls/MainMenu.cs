
/*
#===================================
#
#  Main menu example g ver 1.0
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

    class MainMenu : MenuStrip
    {
        //0:檔案 1:影像 2:說明
        public Dictionary<String,ToolStripMenuItem> m_items; //項目表
       

        public MainMenu():base()
        {            
            create_menu();
        }
         //創建menu
        private void create_menu()
        {
            m_items = new Dictionary<String, ToolStripMenuItem>();
            ToolStripMenuItem temp=null;
            string[] main_item = new string[] { "檔案", "影像", "說明" }; //主要的item
           
            for (int i = 0; i < main_item.Length; i++)
            {
                temp = new ToolStripMenuItem(main_item[i]);
                this.m_items.Add(main_item[i], temp);
                this.Items.Add(temp);


            }
            //0:檔案下拉式選單

            temp = new ToolStripMenuItem("開啟舊檔");
            this.m_items.Add("開啟舊檔", temp);
            this.m_items["檔案"].DropDownItems.Add(temp);
            temp = new ToolStripMenuItem("儲存檔案");
            this.m_items.Add("儲存檔案", temp);
            this.m_items["檔案"].DropDownItems.Add(temp);
            temp = new ToolStripMenuItem("另存新檔");
            this.m_items.Add("另存新檔", temp);
            this.m_items["檔案"].DropDownItems.Add(temp);

            temp = new ToolStripMenuItem("離開");
            this.m_items.Add("離開", temp);
            this.m_items["檔案"].DropDownItems.Add(temp);


            //current id =7
            //1:影像 下拉式選單

            temp = new ToolStripMenuItem("灰階");
            this.m_items.Add("灰階", temp);
            this.m_items["影像"].DropDownItems.Add(temp);   


            //2:說明 下拉式選單
            temp = new ToolStripMenuItem("關於作者");
            this.m_items.Add("關於作者", temp);
            this.m_items["說明"].DropDownItems.Add(temp);   
 
             

         

        }
        
        
    }

