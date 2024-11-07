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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            Con = new Functions();
            showCustomers();
        }

        Functions Con;
        private void showCustomers()
        {
            string Query = "select * from Customer";
            dataGridViewCustomers.DataSource = Con.GetData(Query);
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void carsBtn_Click(object sender, EventArgs e)
        {
            Form1 Obj = new Form1();
            Obj.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtName.Text == "" || txtNIC.Text == "" || txtPhoneNo.Text == "" || txtAddress.Text == "" )
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {
                    string username = txtUsername.Text.ToUpper();
                    string name = txtName.Text.ToUpper();
                    string nic = txtNIC.Text.ToUpper();
                    string phoneNo = txtPhoneNo.Text.ToUpper();
                    string address = txtAddress.Text.ToUpper();
                    string Query = "insert into Customer values('{0}' , '{1}' , '{2}' , '{3}' , '{4}' )";
                    Query = string.Format(Query, username, name, nic, phoneNo, address);
                    Con.setData(Query);
                    MessageBox.Show("Record Added Successfully!!");
                    showCustomers();
                    txtUsername.Text = "";
                    txtName.Text = "";
                    txtNIC.Text = "";
                    txtPhoneNo.Text = "";
                    txtAddress.Text = "";
                    
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void dataGridViewCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUsername.Enabled = false;
            txtUsername.Text = dataGridViewCustomers.SelectedRows[0].Cells[0].Value.ToString();
            txtName.Text = dataGridViewCustomers.SelectedRows[0].Cells[1].Value.ToString();
            txtNIC.Text = dataGridViewCustomers.SelectedRows[0].Cells[2].Value.ToString();
            txtPhoneNo.Text = dataGridViewCustomers.SelectedRows[0].Cells[3].Value.ToString();
            txtAddress.Text = dataGridViewCustomers.SelectedRows[0].Cells[4].Value.ToString();
            
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtName.Text == "" || txtNIC.Text == "" || txtPhoneNo.Text == "" || txtAddress.Text == "" )
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {
                    string username = txtUsername.Text.ToUpper();
                    string name = txtName.Text.ToUpper();
                    string nic = txtNIC.Text.ToUpper();
                    string phoneNo = txtPhoneNo.Text.ToUpper();
                    string address = txtAddress.Text.ToUpper();
                   
                    string Query = "update Customer set  Name = '{1}' , NIC = '{2}' , PhoneNo = '{3}' , Address = '{4}' where UserName = '{0}' ";
                    Query = string.Format(Query, username, name, nic, phoneNo, address);
                    Con.setData(Query);
                    MessageBox.Show("Record Updated Successfully!!");
                    showCustomers();
                    txtUsername.Text = "";
                    txtName.Text = "";
                    txtNIC.Text = "";
                    txtPhoneNo.Text = "";
                    txtAddress.Text = "";
                    
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void dataGridViewCustomers_MouseClick(object sender, MouseEventArgs e)
        {
            txtUsername.Enabled = true;
            txtUsername.Text = "";
            txtName.Text = "";
            txtNIC.Text = "";
            txtPhoneNo.Text = "";
            txtAddress.Text = "";
            
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtName.Text == "" || txtNIC.Text == "" || txtPhoneNo.Text == "" || txtAddress.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {
                    string username = txtUsername.Text.ToUpper();
                    string Query = "delete from Customer where UserName = '{0}'";
                    Query = string.Format(Query, username);
                    Con.setData(Query);
                    MessageBox.Show("Record Deleted Successfully!!");
                    showCustomers();
                    txtUsername.Text = "";
                    txtName.Text = "";
                    txtNIC.Text = "";
                    txtPhoneNo.Text = "";
                    txtAddress.Text = "";
                    
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void customersBtn_Click(object sender, EventArgs e)
        {

        }

        private void rentBtn_Click(object sender, EventArgs e)
        {
            Form3 obj = new Form3();
            obj.Show();
            this.Hide();
        }

        private void returnBtn_Click(object sender, EventArgs e)
        {
            Form4 obj = new Form4();
            obj.Show();
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
