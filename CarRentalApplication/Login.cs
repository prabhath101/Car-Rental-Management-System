using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalApplication
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if(username.Text =="" || password.Text == "")
            {
                MessageBox.Show("Please enter The Username & Password!");
            }
            else
            {
                if(username.Text == "Admin" && password.Text == "admin")
                {
            
                    Form1 Obj = new Form1();
                    Obj.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Incorrect Username or Password!");
                }
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
