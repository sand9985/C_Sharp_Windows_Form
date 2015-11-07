using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public class RS232_ToolStrip:ToolStrip
 {
    public ToolStripMenuItem file;
    public ToolStripMenuItem setting;
    public ToolStripMenuItem Exit;

    public RS232_ToolStrip():base()
    {
        this.Renderer = new MainFormToolStripRenderer();
        setup_item();
       
    }

    private void setup_item()
    {

        create_main_item(ref file, UART_Project.Properties.Resources.File);
        create_main_item(ref setting, UART_Project.Properties.Resources.Setting);
        create_drop_down_item(ref file, ref Exit, UART_Project.Properties.Resources.Exit);
        this.Renderer = new MainFormToolStripRenderer();

    }
    private void create_drop_down_item(ref ToolStripMenuItem container, ref ToolStripMenuItem item2,String str)
    {
        item2 = new ToolStripMenuItem();
        item2.Text = str;
        container.DropDownItems.Add(item2);

    }

    private void create_main_item(ref ToolStripMenuItem item,String str)
    {
        item= new ToolStripMenuItem();
        item.Text = str;
        this.Items.Add(item);
    }
    private class MainFormToolStripRenderer : ToolStripProfessionalRenderer
    {

        public MainFormToolStripRenderer()
        {
            this.RoundedEdges = false;
        }
        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            base.OnRenderToolStripBorder(e);

            var y = e.ToolStrip.Height - 1;
            e.Graphics.DrawLine(new Pen(SystemColors.ControlDark, 1), new Point(0, y), new Point(e.ToolStrip.Width, y));
        }
    }


}

