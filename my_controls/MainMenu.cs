
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
        public ToolStripMenuItem[] m_items; //項目表
       

        public MainMenu():base()
        {            
            create_menu();
        }
         //創建menu
        private void create_menu()
        {
             m_items = new ToolStripMenuItem[8];  
            int id=0;
            string[] main_item = new string[] { "檔案", "影像", "說明" }; //主要的item
           
            for (int i = 0; i < main_item.Length; i++,id++)
            {
                m_items[id] = new ToolStripMenuItem(main_item[i]);
                this.Items.Add(m_items[id]);

            }
            //0:檔案下拉式選單
            m_items[id] = new ToolStripMenuItem("開啟舊檔");
            m_items[0].DropDownItems.Add(m_items[id]); id++;

            m_items[id] = new ToolStripMenuItem("儲存檔案");
            m_items[0].DropDownItems.Add(m_items[id]); id++;
            m_items[id] = new ToolStripMenuItem("另存新檔");
            m_items[0].DropDownItems.Add(m_items[id]); id++;
            m_items[id] = new ToolStripMenuItem("離開");
            m_items[0].DropDownItems.Add(m_items[id]); id++; 
            //current id =7


            //2:說明 下拉式選單
            m_items[id] = new ToolStripMenuItem("關於作者");
            
            m_items[2].DropDownItems.Add(m_items[id]); id++; 
             

            //Click為指派按下事件

        }
        
        
    }

