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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Con = new Functions();
            showCars();
        }

        Functions Con;
        private void showCars()
        {
            string Query = "select * from Cars";
            dataGridViewCars.DataSource = Con.GetData(Query);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void customersBtn_Click(object sender, EventArgs e)
        {
            Form2 Obj = new Form2();
            Obj.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(txtRegisterNo.Text == "" || txtBrand.Text == "" || txtModel.Text == "" || txtType.Text == "" || txtAvailability.Text == "" || txtPrice.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {
                    string RegisterNo = txtRegisterNo.Text.ToUpper();
                    string Brand = txtBrand.Text.ToUpper();
                    string Model = txtModel.Text.ToUpper();
                    string Type = txtType.Text.ToUpper();
                    string Availability = txtAvailability.Text.ToUpper();
                    string Price = txtPrice.Text.ToUpper();
                    string Query = "insert into Cars values('{0}' , '{1}' , '{2}' , '{3}' , '{4}' , '{5}')";
                    Query = string.Format(Query, RegisterNo, Brand, Model, Type, Availability, Price);
                    Con.setData(Query);
                    MessageBox.Show("Record Added Successfully!!");
                    showCars();
                    txtRegisterNo.Text = "";
                    txtBrand.Text = "";
                    txtModel.Text = "";
                    txtType.Text = "";
                    txtAvailability.Text = "";
                    txtPrice.Text = "";
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message); 
                }
            }
        }

        private void dataGridViewCars_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {  
            txtRegisterNo.Enabled = false; 
            txtRegisterNo.Text = dataGridViewCars.SelectedRows[0].Cells[0].Value.ToString();
            txtBrand.Text = dataGridViewCars.SelectedRows[0].Cells[1].Value.ToString();
            txtModel.Text = dataGridViewCars.SelectedRows[0].Cells[2].Value.ToString();
            txtType.Text = dataGridViewCars.SelectedRows[0].Cells[3].Value.ToString();
            txtAvailability.Text = dataGridViewCars.SelectedRows[0].Cells[4].Value.ToString();
            txtPrice.Text = dataGridViewCars.SelectedRows[0].Cells[5].Value.ToString();
        }





        private void button6_Click(object sender, EventArgs e)
        {
            if (txtRegisterNo.Text == "" || txtBrand.Text == "" || txtModel.Text == "" || txtType.Text == "" || txtAvailability.Text == "" || txtPrice.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {
                    string RegisterNo = txtRegisterNo.Text.ToUpper();
                    string Brand = txtBrand.Text.ToUpper();
                    string Model = txtModel.Text.ToUpper();
                    string Type = txtType.Text.ToUpper();
                    string Availability = txtAvailability.Text.ToUpper();
                    string Price = txtPrice.Text.ToUpper();
                    string Query = "update Cars set  Brand = '{1}' , Model = '{2}' , Type = '{3}' , Availability = '{4}' ,Price = '{5}' where RegisterNo = '{0}' ";
                    Query = string.Format(Query, RegisterNo, Brand, Model, Type, Availability, Price);
                    Con.setData(Query);
                    MessageBox.Show("Record Updated Successfully!!");
                    showCars();
                    txtRegisterNo.Text = "";
                    txtBrand.Text = "";
                    txtModel.Text = "";
                    txtType.Text = "";
                    txtAvailability.Text = "";
                    txtPrice.Text = "";
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void dataGridViewCars_MouseClick(object sender, MouseEventArgs e)
        {
            txtRegisterNo.Enabled = true;
            txtRegisterNo.Text = "";
            txtBrand.Text = "";
            txtModel.Text = "";
            txtType.Text = "";
            txtAvailability.Text = "";
            txtPrice.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (txtRegisterNo.Text == "" || txtBrand.Text == "" || txtModel.Text == "" || txtType.Text == "" || txtAvailability.Text == "" || txtPrice.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {
                    string RegisterNo = txtRegisterNo.Text.ToUpper();
                    string Query = "delete from Cars where RegisterNo = '{0}'";
                    Query = string.Format(Query, RegisterNo);
                    Con.setData(Query);
                    MessageBox.Show("Record Deleted Successfully!!");
                    showCars();
                    txtRegisterNo.Text = "";
                    txtBrand.Text = "";
                    txtModel.Text = "";
                    txtType.Text = "";
                    txtAvailability.Text = "";
                    txtPrice.Text = "";
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rentBtn_Click(object sender, EventArgs e)
        {
            Form3 Obj = new Form3();
            Obj.Show();
            this.Hide();
        }

        private void returnBtn_Click(object sender, EventArgs e)
        {
            Form4 Obj = new Form4();
            Obj.Show();
            this.Hide();
        }

        private void carsBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
