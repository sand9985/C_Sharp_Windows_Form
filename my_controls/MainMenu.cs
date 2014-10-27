
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
using System.Drawing.Drawing2D;
using System.Drawing;
public class MainMenu : MenuStrip
{
    //0:檔案 1:影像 2:說明
    public Dictionary<String, ToolStripMenuItem> m_items; //項目表    
    

    public MainMenu()
        : base()
    {
        create_menu();
        setting_custom_menu();
        

    }
    //設定客製化菜單
    private void setting_custom_menu()
    {
        CustomToolStripRenderer custom_render = null;//繪製menu用
        CustomToolColorTable color_table = null; //繪製的顏色表
        color_table = new CustomToolColorTable();
        custom_render = new CustomToolStripRenderer(color_table);
        this.Renderer = custom_render;

    }
    //創建menu
    private void create_menu()
    {
        m_items = new Dictionary<String, ToolStripMenuItem>();
        ToolStripMenuItem temp = null;
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

     //調色板
   private class CustomToolColorTable : ProfessionalColorTable
    {

        public CustomToolColorTable()
            : base()
        {      }
      
        public override Color MenuStripGradientEnd
        {
            get
            {
                return Color.FromArgb(255, 225, 225, 225);
            }

        }
        public override Color MenuStripGradientBegin
        {
            get
            {
               return Color.FromArgb(255, 200, 200, 200);
            }
        }



    }
  
     //用來修改menu繪製
    public  class CustomToolStripRenderer : ToolStripProfessionalRenderer
    {
        public CustomToolStripRenderer(ProfessionalColorTable color_table)
            : base(color_table)
        {  }
        //畫背景
        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
         
            base.OnRenderToolStripBackground(e);
            LinearGradientMode mode = LinearGradientMode.Horizontal;
            using (LinearGradientBrush b = new LinearGradientBrush(e.AffectedBounds, ColorTable.MenuStripGradientBegin, ColorTable.MenuStripGradientEnd, mode))
            {
               e.Graphics.FillRectangle(b, e.AffectedBounds);
            }
        }

    } //end



}

