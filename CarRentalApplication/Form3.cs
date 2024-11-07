using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CarRentalApplication
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            Con = new Functions();
            showRent();
        }

         Functions Con;
        private void showRent()
        {
            string Query = "select * from RentCar";
            dataGridViewRent.DataSource = Con.GetData(Query);
        }

        private void fillComboBox()
        {
            string query = "select Username from Customer";

            txtUsername.ValueMember = "Username";
            txtUsername.DataSource = Con.GetData(query);
        }

        private void fillCarsBox()
        {
            string query = "select RegisterNo from Cars where Availability = 'YES'";

            txtCarBox.ValueMember = "RegisterNo";
            txtCarBox.DataSource = Con.GetData(query);
        }

        private void updateOnRent()
        {
            string registerNo = txtCarBox.SelectedValue.ToString();
            string query = $"update Cars set Availability = 'NO' where RegisterNo = '{registerNo}'";
            Con.setData(query);
        }

        public int Fee()
        {
            try
            {
                string registerNo = txtCarBox.SelectedValue.ToString();
                string query = $"select Price from Cars where RegisterNo = '{registerNo}'";

                DataTable dt = Con.GetData(query);

                if (dt.Rows.Count > 0)
                {
                    int fee = Convert.ToInt32(dt.Rows[0]["Price"]);
                    return fee;
                }
                else
                {
                    MessageBox.Show("No Price found.");
                    return 0;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Error in the Price format.");
                return 0;
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Price cannot be empty.");
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
                return 0;
            }
        }

        private void carBrand()
        {
            try
            {
                string regNo = txtCarBox.SelectedValue.ToString();
                string query = $"select Brand from Cars where RegisterNo = '{regNo}'";

                DataTable dt = Con.GetData(query);

                if (dt.Rows.Count > 0)
                {
                    brandLbl.Text = dt.Rows[0]["Brand"].ToString();
                }
                else
                {
                    brandLbl.Text = "Brand not found"; 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void carModel()
        {
            try
            {
                string regNo = txtCarBox.SelectedValue.ToString();
                string query = $"select Model from Cars where RegisterNo = '{regNo}'";

                DataTable dt = Con.GetData(query);

                if (dt.Rows.Count > 0)
                {
                    modelLbl.Text = dt.Rows[0]["Model"].ToString();
                }
                else
                {
                    modelLbl.Text = "Model not found";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void dataGridViewRent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCarBox.Enabled = false;
            txtUsername.Enabled = false;
            txtRentDate.Enabled = false;
            txtRentalFee.Enabled = false;
            txtCarBox.Text = dataGridViewRent.SelectedRows[0].Cells[0].Value.ToString();
            txtUsername.Text = dataGridViewRent.SelectedRows[0].Cells[1].Value.ToString();
            txtRentDate.Text = dataGridViewRent.SelectedRows[0].Cells[2].Value.ToString();
            txtReturnDate.Text = dataGridViewRent.SelectedRows[0].Cells[3].Value.ToString();
            txtRentalFee.Text = dataGridViewRent.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void carsBtn_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
            this.Hide();
        }

        private void customersBtn_Click(object sender, EventArgs e)
        {
            Form2 obj = new Form2();
            obj.Show();
            this.Hide();
        }

        private void returnBtn_Click(object sender, EventArgs e)
        {
            Form4 obj = new Form4();
            obj.Show();
            this.Hide();
        }

        private void rentBtn_Click(object sender, EventArgs e)
        {

        }

        private void addRentBtn_Click(object sender, EventArgs e)
        {
            if (txtCarBox.Text == "" || txtUsername.Text == "" || txtRentDate.Text == "" || txtReturnDate.Text == "" || txtRentalFee.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {
                    string registerNo = txtCarBox.Text.ToString().ToUpper();
                    string username = txtUsername.Text.ToString().ToUpper();

                    DateTime rentDateValue = DateTime.Parse(txtRentDate.Text);
                    DateTime returnDateValue = DateTime.Parse(txtReturnDate.Text);

                    TimeSpan difference = returnDateValue - rentDateValue;
                    int days = (int)difference.TotalDays;

                    int rentFee = Fee();

                    string rentDate = rentDateValue.ToString("yyyy-MM-dd").ToUpper();
                    string returnDate = returnDateValue.ToString("yyyy-MM-dd").ToUpper();
                    string rentalFee = (days * rentFee).ToString();
                    
                    string Query = "insert into RentCar values('{0}' , '{1}' , '{2}' , '{3}' , '{4}')";
                    Query = string.Format(Query, registerNo, username, rentDate, returnDate, rentalFee);
                    Con.setData(Query);

                    MessageBox.Show("Car Rented Successfully!!");
                    showRent();
                    updateOnRent();
                    txtCarBox.Text = "";
                    txtUsername.Text = "";
                    txtRentDate.Text = "";
                    txtReturnDate.Text = "";
                    txtRentalFee.Text = "";
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            fillComboBox();
            fillCarsBox();
            txtRentalFee.Enabled = false;
        }

        private void txtUsername_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridViewRent_MouseClick(object sender, MouseEventArgs e)
        {
            txtCarBox.Enabled = true;
            txtUsername.Enabled = true;
            txtRentDate.Enabled = true;
            txtCarBox.Text = "";
            txtUsername.Text = "";
            txtRentDate.Text = "";
            txtReturnDate.Text = "";
            txtRentalFee.Text = "";
        }

        private void editRentBtn_Click(object sender, EventArgs e)
        {
            if (txtCarBox.Text == "" || txtUsername.Text == "" || txtRentDate.Text == "" || txtReturnDate.Text == "" || txtRentalFee.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {
                    string registerNo = txtCarBox.Text.ToString().ToUpper();

                    DateTime rentDateValue = DateTime.Parse(txtRentDate.Text);
                    DateTime returnDateValue = DateTime.Parse(txtReturnDate.Text);

                    TimeSpan difference = returnDateValue - rentDateValue;
                    int days = (int)difference.TotalDays;

                    int rentFee = Fee();

                    string rentalFee = (days * rentFee).ToString();

                    string returnDate = returnDateValue.ToString("yyyy-MM-dd").ToUpper();
                    string Query = "update RentCar set  ReturnDate = '{1}', RentFee = '{2}'  where RegisterNo = '{0}' ";
                    Query = string.Format(Query, registerNo, returnDate, rentalFee);
                    Con.setData(Query);
                    MessageBox.Show("Rent Updated Successfully!!");
                    showRent();
                    txtCarBox.Text = "";
                    txtUsername.Text = "";
                    txtRentDate.Text = "";
                    txtReturnDate.Text = "";
                    txtRentalFee.Text = "";
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void txtCarBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            carBrand();
            carModel();
        }

        private void rentedDate()
        {
            try
            {
                
                DateTime rentDateValue = DateTime.Parse(txtRentDate.Text);
                DateTime returnDateValue = DateTime.Parse(txtReturnDate.Text);

                
                TimeSpan difference = returnDateValue - rentDateValue;
                int days = (int)difference.TotalDays;

                
                int dailyRentFee = Fee();

               
                int rentalFee = days * dailyRentFee;

                
                txtRentalFee.Text = rentalFee.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void txtReturnDate_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void txtReturnDate_TabIndexChanged(object sender, EventArgs e)
        {
 
        }

        private void txtReturnDate_ValueChanged_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtRentDate.Text) && DateTime.TryParse(txtRentDate.Text, out _))
            {
                rentedDate();
            }
        }
    }
}
