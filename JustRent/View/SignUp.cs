using JustRent.Controller;
using JustRent.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JustRent
{
    public partial class SignUp : Form
    {

        public static String username;
        public static String Password;
        public static String Cpassword;
        public static int gender;
        public static DateTime Birthdate;
        public static String country;

        public SignUp()
        {
            InitializeComponent();
            
        }

    private void BunifuButton1_Click(object sender, EventArgs e)
        {
            Application.DoEvents();
            SignIn f1 = new SignIn();
            f1.StartPosition = FormStartPosition.Manual;
            f1.Location = this.Location;
            this.Hide();
            f1.ShowDialog();
        }

        private void Label15_Click(object sender, EventArgs e)
        {

        }

        private void BunifuMaterialTextbox2_OnValueChanged(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox2.Text != null && (bunifuMaterialTextbox2.Text.Length > 0 && bunifuMaterialTextbox2.Text.Length <= 5))
            {
                label14.Visible = true;
                label16.Visible = false;
                label15.Visible = false;

            }
            else if(bunifuMaterialTextbox2.Text != null && (bunifuMaterialTextbox2.Text.Length > 5 && bunifuMaterialTextbox2.Text.Length <= 12)){
                label15.Visible = true;
                label14.Visible = false;
                label16.Visible = false;

            }
            else if (bunifuMaterialTextbox2.Text != null && (bunifuMaterialTextbox2.Text.Length > 12 && bunifuMaterialTextbox2.Text.Length <= 17)){
                label16.Visible = true;
                label14.Visible = false;
                label15.Visible = false;



            }
        }

        private void BunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void BunifuThinButton22_Click(object sender, EventArgs e)
        {
            username = bunifuMaterialTextbox1.Text.ToString();
            Password = bunifuMaterialTextbox2.Text.ToString();
            Cpassword = bunifuMaterialTextbox3.Text.ToString();

            if (bunifuRadioButton2.Checked)
            {
                gender = 1;
            }
            else if (bunifuRadioButton1.Checked)
            {
                gender = 0;
            }
            else if (bunifuRadioButton3.Checked)
            {
                gender = 2;
            }


            Birthdate = bunifuDatepicker1.Value;
            country = bunifuMaterialTextbox4.Text;


            if (username!="" && Password!="" && Cpassword!="" && country!="" && bunifuDatepicker1.Value != null && (bunifuRadioButton1.Checked==true || bunifuRadioButton2.Checked == true || bunifuRadioButton3.Checked == true))
                {
                   if (Cpassword.Equals(Password)&&Cpassword!=""&&Password!="") {


                    User u = new User(username, Password, gender, Birthdate, country);
                    UserManager.instance.signUp(u);
                    MessageBox.Show("SignUp has been succesfully");

                }

                else
                {
                    label17.Text= "Passwords are not match";
                }



            }
                else
                {
                   label17.Text= "Please fill the textboxes";
                }
                
           
        }

        private void SignUp_Load(object sender, EventArgs e)
        {

        }
    }
}
