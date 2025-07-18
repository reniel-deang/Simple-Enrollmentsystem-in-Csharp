using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        
        public string conn = "datasource=localhost;username=root;pass=;database=c";

        public void registeruser(string username, string pass, string elementary, string jhs, string college, string fname, string mname, string lname, string gender, string course, string year, string birthdate, string address, string number, string guardian, string guardiannumber)
        {
            MySqlConnection conn1 = new MySqlConnection(conn);
            try
            {
                Form1 form1 = new Form1();
                conn1.Open();
                string query = "INSERT INTO tb_studentinfo (username, pass, elementary, jhs, college, fname, mname, lname, gender, course, year, birthdate, address, number, guardian, guardianumber,status) VALUES ('" + username + "','" + pass + "','" + elementary + "','" + jhs + "','" + college + "','" + fname + "','" + mname + "','" + lname + "','" + gender + "','" + course + "','" + year + "','" + birthdate + "','" + address + "','" + number + "','" + guardian + "','" + guardiannumber + "','not enrolled')";
                MySqlCommand cmd = new MySqlCommand(query, conn1);

                int check = cmd.ExecuteNonQuery();

                if (check > 0)
                {
                    MessageBox.Show("Enrollement Form Sucessfully passed");
                    form1.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Something went wrong");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public Form2()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void register_Click(object sender, EventArgs e)
        {
            
            registeruser(username.Text + "@student", pass.Text, elementary.Text, jhs.Text, college.Text, fname.Text, mname.Text, lname.Text, gender.Text, course.Text, year.Text, birthdate.Value.ToShortDateString(), address.Text, number.Text, guardian.Text, guardiannumber.Text);
        }
    }
}
