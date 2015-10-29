using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

public class Menu : MenuStrip
  {
     public Dictionary<String, ToolStripMenuItem> m_items; //項目表    

      public Menu() //Construct
        : base()
    {
        create_menu();

    }



     //create menu
     private void create_menu()
     {

       
         string[] main_item = new string[] { "File", "Image", "About" }; //主要的item
         ToolStripMenuItem temp = null;
         m_items = new Dictionary<String, ToolStripMenuItem>();

         //add main item.
         for (int i = 0; i < main_item.Length; i++)
         {
             temp = new ToolStripMenuItem(main_item[i]);
             this.m_items.Add(main_item[i], temp);
             this.Items.Add(temp);
         }

         //The following items ,which will be added into the menuitem "File" . 
         temp = new ToolStripMenuItem("Select a image");
         this.m_items.Add("Select a image", temp);
         this.m_items["File"].DropDownItems.Add(temp);


         temp = new ToolStripMenuItem("Save");
         temp.Enabled = false;
         this.m_items.Add("Save", temp);
         this.m_items["File"].DropDownItems.Add(temp);

         temp = new ToolStripMenuItem("Exit");
         this.m_items.Add("Exit", temp);
         this.m_items["File"].DropDownItems.Add(temp);

         //The following items ,which will be added into the menuitem "Image" . 
         temp = new ToolStripMenuItem("Adjust image tone");
         temp.Enabled = false;
         this.m_items.Add("Adjust image tone", temp);
         this.m_items["Image"].DropDownItems.Add(temp);


         //The following items ,which will be added into the menuitem "About" . 
         /*
         temp = new ToolStripMenuItem("Language");
         this.m_items.Add("Language", temp);
         this.m_items["About"].DropDownItems.Add(temp);

         temp = new ToolStripMenuItem("English");
         temp.Checked = true; //set checked 
         this.m_items["Language"].DropDownItems.Add(temp);
         temp = new ToolStripMenuItem("Chinese");
         this.m_items["Language"].DropDownItems.Add(temp);
         */



         temp = new ToolStripMenuItem("Author");
         this.m_items.Add("Author", temp);
         this.m_items["About"].DropDownItems.Add(temp);

     }
    
  

  }

