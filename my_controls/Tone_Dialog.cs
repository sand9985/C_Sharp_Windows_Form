using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;

  public class Tone_Dialog:Form
  {

      public Label[] labels,value_labels;
      public Panel panel;
      public HScrollBar[] h_scollbar;
      public Button ok, cancel;

     


      //初始
      public Tone_Dialog()
      {

         
         
          labels = new Label[4];
          h_scollbar = new HScrollBar[4];
          value_labels = new Label[4];

          this.Height = 250;
          this.Width = 300;

          //set background
          panel = new Panel();
          panel.BackColor = Color.FromArgb(200, 200, 200);
          panel.Width = (int)(300 * 0.8);
          panel.Height = (int)(250* 0.6);
          panel.Location = new Point((int)(300 * 0.1), 20);

          panel.BorderStyle = BorderStyle.FixedSingle;
          String[] text = { "Red", "Green", "Blue", "Gray" };


          for (int i = 0; i < labels.Length; i++)
         {
              labels[i] = new Label();
              labels[i].Text = text[i];
              labels[i].Location = new Point(10, i * 40 + 10);
             
              //set label color
              switch(i){
                  case 0: labels[i].ForeColor = Color.Red; break;
                  case 1: labels[i].ForeColor = Color.Green; break;
                  case 2: labels[i].ForeColor = Color.Blue; break;
                  case 3: labels[i].ForeColor = Color.Gray; break;

                }
              h_scollbar[i] = new HScrollBar();
              h_scollbar[i].Location = new Point(70, i * 40 +10-3);
              h_scollbar[i].Width = 110;
              if (i != 3)
                  h_scollbar[i].Minimum = -255;
              else
                  h_scollbar[i].Minimum = 0;

              h_scollbar[i].Maximum = 264;
              h_scollbar[i].Value = 0;

              value_labels[i] = new Label();
              value_labels[i].Text = h_scollbar[i].Value.ToString();
              value_labels[i].Location = new Point(200, i * 40 + 10);


              panel.Controls.Add(value_labels[i]);
              panel.Controls.Add(h_scollbar[i]);
              panel.Controls.Add(labels[i]);
          }   
          this.Controls.Add(panel);
         
          ok = new Button(); ok.Text = "OK";
          cancel = new Button(); cancel.Text = "Cancel";

          ok.Location = new Point(panel.Location.X+20, panel.Height + 30);
          cancel.Location = new Point(ok.Location.X + 100, ok.Location.Y);
          this.Controls.Add(ok); this.Controls.Add(cancel);

          this.Text = "Tone Adjust";
          this.FormBorderStyle = FormBorderStyle.FixedDialog;
          this.MaximizeBox = false;
          this.MinimizeBox = false;

      }
      public void update_value_text(int index)
      {

     
          value_labels[index].Text = h_scollbar[index].Value.ToString();
      }

    

      public void reset()
      {
          for (int i = 0; i < h_scollbar.Length; i++)
          {
              h_scollbar[i].Value = 0;
              update_value_text(i);
          }
                   

      }


  }

