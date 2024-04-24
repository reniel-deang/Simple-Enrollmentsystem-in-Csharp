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
    public partial class Adminform : Form
    {

        public string conn = "datasource=localhost;username=root;pass=;database=db_enrollmentdata";


        public void updatedetails(string username, string pass, string elementary, string jhs, string college, string fname, string mname, string lname, string gender, string course, string year, string birthdate, string address, string number, string guardian, string guardiannumber)
        {

            MySqlConnection conn1 = new MySqlConnection(conn);
            try
            {
                conn1.Open();
                int studentid = int.Parse(lblid.Text);
                string query = "UPDATE tb_studentinfo SET username = '" + username + "',pass = '" + pass + "', elementary ='" + elementary + "' ,jhs ='" + jhs + "' ,college ='" + college + "' ,fname ='" + fname + "' ,mname ='" + mname + "' ,lname ='" + lname + "' ,gender ='" + gender + "' ,course ='" + course + "' ,year ='" + year + "' ,birthdate ='" + birthdate + "' ,address ='" + address + "' ,number ='" + number + "' ,guardian ='" + guardian + "' ,guardianumber ='" + guardiannumber + "' ,status ='enrolled' WHERE studentid = '" + studentid + "'";
                MySqlCommand cmd = new MySqlCommand(query, conn1);
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                MessageBox.Show("Sucessfully Updated");
                getdata();
                conn1.Close();
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        public void getdata()
        {
            MySqlConnection conn1 = new MySqlConnection(conn);
            try
            {
                conn1.Open();
                string query = "SELECT * FROM tb_studentinfo WHERE status = 'enrolled' OR status = 'not enrolled' ";
                MySqlCommand cmd = new MySqlCommand(query, conn1);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                studentlist.DataSource = dt;

                // Close the connection after data retrieval
                conn1.Close();

                // Open a new connection for the second query
                conn1.Open();
                int notenrolled = 0;
                string query1 = "SELECT COUNT(*) FROM tb_studentinfo WHERE status = 'not enrolled' ";
                MySqlCommand cmd1 = new MySqlCommand(query1, conn1);
                notenrolled = Convert.ToInt32(cmd1.ExecuteScalar());
                totalpending.Text = notenrolled.ToString();

                int enrolled = 0;
                string query2 = "SELECT COUNT(*) FROM tb_studentinfo WHERE status = 'enrolled' ";
                MySqlCommand cmd2 = new MySqlCommand(query2, conn1);
                enrolled = Convert.ToInt32(cmd2.ExecuteScalar());
                totalenrolled.Text = enrolled.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Ensure the connection is closed even if an exception occurs
                conn1.Close();
            }
        }
        public Adminform()
        {
            InitializeComponent();
            clear();
            getdata();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            updatedetails(username.Text, pass.Text, elementary.Text, jhs.Text, college.Text, fname.Text, mname.Text, lname.Text, gender.Text, course.Text, year.Text, birthdate.Text, address.Text, number.Text, guardian.Text, guardiannumber.Text);
        }

        private void studentlist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0 && e.RowIndex > -1)
            {
                DataGridViewCell id = studentlist.Rows[e.RowIndex].Cells[e.ColumnIndex];
                lblid.Text = id.Value.ToString();

                DataGridViewCell valueusername = studentlist.Rows[e.RowIndex].Cells[e.ColumnIndex + 1];
                username.Text = valueusername.Value.ToString();

                DataGridViewCell valuepass = studentlist.Rows[e.RowIndex].Cells[e.ColumnIndex + 2];
                pass.Text = valuepass.Value.ToString();

                DataGridViewCell valueelementary = studentlist.Rows[e.RowIndex].Cells[e.ColumnIndex + 3];
                elementary.Text = valueelementary.Value.ToString();

                DataGridViewCell valuejhs = studentlist.Rows[e.RowIndex].Cells[e.ColumnIndex + 4];
                jhs.Text = valuejhs.Value.ToString();

                DataGridViewCell valuecollege = studentlist.Rows[e.RowIndex].Cells[e.ColumnIndex + 5];
                college.Text = valuecollege.Value.ToString();

                DataGridViewCell valuefname = studentlist.Rows[e.RowIndex].Cells[e.ColumnIndex + 6];
                fname.Text = valuefname.Value.ToString();

                DataGridViewCell valuemname = studentlist.Rows[e.RowIndex].Cells[e.ColumnIndex + 7];
                mname.Text = valuemname.Value.ToString();

                DataGridViewCell valuelname = studentlist.Rows[e.RowIndex].Cells[e.ColumnIndex + 8];
                lname.Text = valuelname.Value.ToString();

                DataGridViewCell valuegender = studentlist.Rows[e.RowIndex].Cells[e.ColumnIndex + 9];
                gender.Text = valuegender.Value.ToString();

                DataGridViewCell valuecourse = studentlist.Rows[e.RowIndex].Cells[e.ColumnIndex + 10];
                course.Text = valuecourse.Value.ToString();

                DataGridViewCell valueyear = studentlist.Rows[e.RowIndex].Cells[e.ColumnIndex + 11];
                year.Text = valueyear.Value.ToString();

                DataGridViewCell valuebirthdate = studentlist.Rows[e.RowIndex].Cells[e.ColumnIndex + 12];
                birthdate.Text = valuebirthdate.Value.ToString();

                DataGridViewCell valueaddress = studentlist.Rows[e.RowIndex].Cells[e.ColumnIndex + 13];
                address.Text = valueaddress.Value.ToString();

                DataGridViewCell valuenumber = studentlist.Rows[e.RowIndex].Cells[e.ColumnIndex + 14];
                number.Text = valuenumber.Value.ToString();

                DataGridViewCell valueguardian = studentlist.Rows[e.RowIndex].Cells[e.ColumnIndex + 15];
                guardian.Text = valueguardian.Value.ToString();

                DataGridViewCell valueguardianumber = studentlist.Rows[e.RowIndex].Cells[e.ColumnIndex + 16];
                guardiannumber.Text = valueguardianumber.Value.ToString();

                DataGridViewCell valuestatus = studentlist.Rows[e.RowIndex].Cells[e.ColumnIndex + 17];
                status.Text = valuestatus.Value.ToString();

                if(status.Text == "not enrolled")
                {
                    status.Text = "NOT ENROLLED";
                    status.ForeColor = Color.Red;
                }
                else
                {
                    status.Text = "ENROLLED";
                    status.ForeColor = Color.Green;
                }
            }
            
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            MessageBox.Show("Logout Successfully");
            form1.Show();
            this.Close();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            MySqlConnection conn1 = new MySqlConnection(conn);

            try
            {
                conn1.Open();
                int studentid = int.Parse(lblid.Text);
                string query = "DELETE FROM tb_studentinfo WHERE studentid = '" + studentid + "'";
                MySqlCommand cmd = new MySqlCommand(query, conn1);
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                MessageBox.Show("Sucessfully Dropped Student");
                getdata();
                clear();
                conn1.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        public void clear()
        {
            lblid.Text = "-";
            status.Text = "-";
            username.Text = "";
            pass.Text = "";
            fname.Text = "";
            mname.Text = "";
            lname.Text = "";
            gender.Text = "";
            course.Text = "";
            year.Text = "";
            birthdate.Text = "";
            address.Text = "";
            number.Text = "";
            guardian.Text = "";
            guardiannumber.Text = "";
            elementary.Text = "";
            jhs.Text = "";
            college.Text = "";

        }

        private void Adminform_Load(object sender, EventArgs e)
        {
            getdata();
        }
    }
}
