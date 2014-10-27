/*
#===================================
#
#  AlphaPictureBox ver 1.0
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

public class AlphaPictureBox : PictureBox
{

    private Bitmap alpha_image = null; //透明貼圖

    public AlphaPictureBox()
        : base()
    {
        this.SizeMode = PictureBoxSizeMode.StretchImage;
        SetStyle(ControlStyles.OptimizedDoubleBuffer, true); //設定雙緩衝
    }

    //刷新透明圖片
    public void update_alpha_image()
    {

        if (alpha_image != null) alpha_image.Dispose(); //釋放資源
        alpha_image = new Bitmap(this.Width, this.Height); //創建和controler一樣大小
        ImageProcess.generate_alpha_bitmap(ref alpha_image); //生成透明貼圖


    }

    //繪圖
    protected override void OnPaint(PaintEventArgs pe)
    {
        if (alpha_image != null)
        {
            pe.Graphics.DrawImage(alpha_image, 0, 0);
        }
         base.OnPaint(pe);



    }

    //釋放資源
    public new void Dispose()
    {
        if (alpha_image != null) alpha_image.Dispose();
        base.Dispose();
    }

}
