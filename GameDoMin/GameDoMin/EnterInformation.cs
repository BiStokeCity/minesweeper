using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace GameDoMin
{
    public partial class EnterInformation : Form
    {
        public EnterInformation()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {

            try
            {
                SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-V4QPNQU\SQLEXPRESS;Initial Catalog=QuanLiDiem;Integrated Security=True");
                connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connect;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = System.String.Concat("insert into Diem values("+ "'"+ txtCode.Text.ToString() +"','" +txtName.Text.ToString() +"','"+ txtTime.Text.ToString() + "')");
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm thành công");
            }catch(SqlException){
                MessageBox.Show("Không thêm được");
            }
            


        }

        public string getTextBoxTime { get { return txtTime.Text; } }

        public string setTextBoxTime { set { txtTime.Text = value; } }
        private void EnterInformation_Load(object sender, EventArgs e)
        {

            
        }
    }
}
