using JustRent.Controller;
using JustRent.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JustRent
{
    public partial class SignIn : Form
    {
        public static String username;
        public static String Password;
        public SignIn()
        {
            InitializeComponent();
           
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void DoubleBitmapControl1_Click(object sender, EventArgs e)
        {

        }

        private void BunifuToggleSwitch1_OnValuechange(object sender, EventArgs e)
        {
        }

        private void BunifuThinButton21_Click(object sender, EventArgs e)
        {
            Application.DoEvents();
            SignUp f2 = new SignUp();
            f2.StartPosition = FormStartPosition.Manual;
            f2.Location = this.Location;
            this.Hide();
            f2.ShowDialog();

        }

        public static implicit operator SignIn(SignUp v)
        {
            throw new NotImplementedException();
        }

        private void BunifuImageButton1_Click(object sender, EventArgs e)
        {
            bunifuMaterialTextbox2.isPassword = false;
            bunifuImageButton1.Visible = false;
            bunifuImageButton2.Visible = true;
        }

        private void BunifuImageButton2_Click(object sender, EventArgs e)
        {
            bunifuMaterialTextbox2.isPassword = true;
            bunifuImageButton2.Visible = false;
            bunifuImageButton1.Visible = true;
        }

        private void Label8_Click(object sender, EventArgs e)
        {

        }

        private void BunifuThinButton22_Click(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();

            username = bunifuMaterialTextbox1.Text.ToString();
            Password = bunifuMaterialTextbox2.Text.ToString();
            
            


        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            label8.Visible = true;
            timer1.Stop();

        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();
            if (UserManager.instance.SignIn(username, Password) != null)
            {
                Application.DoEvents();
                MainPage m1 = new MainPage();
                m1.StartPosition = FormStartPosition.Manual;
                m1.Location = this.Location;
                this.Hide();
                m1.ShowDialog();
            }
            else
            {
                label17.Text="Worng username or Password";
            }
        }
    }
}
