using System;
using System.Data;
using System.Windows.Forms;

namespace CarRentalApplication
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            Con = new Functions();
        }

        Functions Con;

        private void fillCarsBox()
        {
            string query = "select RegisterNo from Cars where Availability = 'NO'";

            txtCarBox.ValueMember = "RegisterNo";
            txtCarBox.DataSource = Con.GetData(query);
        }

        private void updateOnReturn()
        {
            string registerNo = txtCarBox.SelectedValue.ToString();
            string query = $"update Cars set Availability = 'YES' where RegisterNo = '{registerNo}'";
            Con.setData(query);
        }

        public int rentalFee()
        {
            try
            {
                string registerNo = txtCarBox.SelectedValue.ToString();
                string query = $"select RentFee from RentCar where RegisterNo = '{registerNo}'";

                DataTable dt = Con.GetData(query);

                if (dt.Rows.Count > 0) 
                {
                    int fee = Convert.ToInt32(dt.Rows[0]["RentFee"]); 
                    return fee;
                }
                else
                {
                    MessageBox.Show("No rental fee data found.");
                    return 0;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Error in the rental fee format.");
                return 0;
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Rental fee cannot be empty.");
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

        private void rentedDate()
        {
            try
            {
                string regNo = txtCarBox.SelectedValue.ToString();
                string query = $"select RentDate from RentCar where RegisterNo = '{regNo}'";

                DataTable dt = Con.GetData(query);

                if (dt.Rows.Count > 0)
                {
                    rentDateLbl.Text = dt.Rows[0]["RentDate"].ToString();
                }
                else
                {
                    rentDateLbl.Text = "RentDate not found";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void returnDate()
        {
            try
            {
                string regNo = txtCarBox.SelectedValue.ToString();
                string query = $"select ReturnDate from RentCar where RegisterNo = '{regNo}'";

                DataTable dt = Con.GetData(query);

                if (dt.Rows.Count > 0)
                {
                    returnDateLbl.Text = dt.Rows[0]["ReturnDate"].ToString();
                }
                else
                {
                    returnDateLbl.Text = "ReturnDate not found";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
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

        private void rentBtn_Click(object sender, EventArgs e)
        {
            Form3 obj = new Form3();
            obj.Show();
            this.Hide();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            fillCarsBox();
        }

        private void dataGridViewReturn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void returnCarBtn_Click(object sender, EventArgs e)
        {
            if (txtCarBox.Text == "" || txtFine.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {
                    string registerNo = txtCarBox.Text.ToString().ToUpper();
                    string fine = txtFine.Text.ToString().ToUpper();

                    int rentFee = rentalFee();
                    if (rentFee == 0)
                    {
                        return;
                    }

                    int totalPayment = Convert.ToInt32(fine) + rentFee;

                    string msg = $"The Car {registerNo} is successfully Returned!!! \nYour fine is {fine} and your rent is {rentFee}\nYour Full Payment: {totalPayment}";

                    string query = $"delete from RentCar where RegisterNo = '{registerNo}'";
                    Con.setData(query);

                    MessageBox.Show(msg, "Car Returned Successfully!!");

                    updateOnReturn();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("An error occurred: " + Ex.Message);
                }
            }
        }

        private void txtCarBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            carBrand();
            carModel();
            rentedDate();
            returnDate();
        }
    }
}
