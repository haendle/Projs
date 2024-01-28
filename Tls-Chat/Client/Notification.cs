using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Notification : Form
    {
        private int x;
        private int y;

        private enum enumAction
        {
            WAIT,
            START,
            CLOSE
        }

        private enumAction action;

        public Notification()
        {
            InitializeComponent();
        }

        public void showNotification(string message)
        {
            string fname;

            this.Opacity = 0.0;
            this.StartPosition = FormStartPosition.Manual;

            for (int i = 1; i < 10; i++)
            {
                fname = "alert" + i.ToString();
                Notification frm = (Notification)Application.OpenForms[fname];

                if (frm == null)
                {
                    this.Name = fname;
                    this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width + 15;
                    this.y = Screen.PrimaryScreen.WorkingArea.Height - this.Height * i - 5 * i;
                    this.Location = new Point(this.x, this.y);

                    break;
                }
            }

            this.x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;

            if (message.Length > 7)
            {
                message.Substring(0, 7);
                this.label.Text = message + "...";
            }

            else
            {
                this.label.Text = message;
            }

            this.Show();

            this.action = enumAction.START;
            this.timer.Interval = 1;
            this.timer.Start();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            timer.Interval = 1;
            action = enumAction.CLOSE;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            switch (this.action)
            {
                case enumAction.WAIT:
                    {
                        timer.Interval = 3000;
                        action = enumAction.CLOSE;
                        break;
                    }

                case enumAction.START:
                    {
                        timer.Interval = 1;
                        this.Opacity += 0.1;

                        if (this.x < this.Location.X)
                        {
                            this.Left--;
                        }

                        else
                        {
                            if (this.Opacity == 1.0)
                            {
                                action = enumAction.WAIT;
                            }
                        }

                        break;
                    }

                case enumAction.CLOSE:
                    {
                        timer.Interval = 1;

                        this.Opacity -= 0.1;
                        this.Left -= 3;

                        if (base.Opacity == 0.0)
                        {
                            base.Close();
                        }

                        break;
                    }
            }
        }
    }
}
