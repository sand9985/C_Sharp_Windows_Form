using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

public class Author : Form
{
    private Label text = new Label(); //文字
    private LinkLabel linkLabel = new LinkLabel(); //web連結
    public Button ok;
    public Author()
    {

        ok = new Button();
        ok.Text = "OK";

        ok.Location = new Point(250, 80);
        this.Controls.Add(ok);
        fixed_size(); //固定大小
        this.Text = "About author"; //標題
        this.Size = new Size(400, 150); //設定視窗大小
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
        text.Text = "HI，Welcome to use this program,my name is NULL,\n" +
        "I come from Tawian,Kinmen(24°26′N 118°20′E)";

     
        text.AutoSize = true; //自動調整文字大小
        text.Location = new Point((int)(400 * 0.1), (int)(200 * 0.1));

    }
    //設定linklabel
    private void set_link_lable()
    {

        this.linkLabel.AutoSize = true; //自動調整大小
        this.linkLabel.Text = "Author Blog";
        this.linkLabel.LinkClicked += new LinkLabelLinkClickedEventHandler(link_to_web);
        this.linkLabel.Location = new Point((int)(400 * 0.1), (int)(200 * 0.25));
    }

    //連到網頁去
    protected void link_to_web(object who, EventArgs e)
    {


        this.linkLabel.LinkVisited = true;
        System.Diagnostics.Process.Start("http://null-adventure-diarytwo.blogspot.tw/");


    }
}
