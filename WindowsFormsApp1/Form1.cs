using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Form2 form2 = new Form2();
        Adminform adminform = new Adminform();
        Studentdashboard studentdashboard = new Studentdashboard();
        public string conn = "datasource=localhost;username=root;pass=;database=db_enrollmentdata";

        public void login(string username, string pass)
        {
            MySqlConnection conn1 = new MySqlConnection(conn);
            try
            {
                conn1.Open();
                string query = "SELECT * FROM tb_studentinfo WHERE username = BINARY '" + username + "' AND pass = BINARY '" + pass + "'";
                MySqlCommand cmd = new MySqlCommand(query, conn1);
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                

                if (reader.Read())
                {
                    if(username.Contains("@admin")) 
                    {
                        MessageBox.Show("Yawa ADMIN");
                        this.Hide();
                        adminform.Show();
                   
                    }

                    else
                    {
                        MessageBox.Show("Yawa STODINT");
                        this.Hide();
                        studentdashboard.Show();
                        
                    }
                    
                }
                else
                {
                    MessageBox.Show("Wrong Credentials, Please Try again");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           

        }

        
        
        public Form1()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            form2.Show();
           
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            login(username.Text, password.Text);
        }
    }
}
