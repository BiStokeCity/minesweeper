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
    public partial class HightScore : Form
    {
        public HightScore()
        {
            InitializeComponent();
        }

        private void HightScore_Load(object sender, EventArgs e)
        {
            HienThiDiem();
        }

        void HienThiDiem()
        {
            SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-V4QPNQU\SQLEXPRESS;Initial Catalog=QuanLiDiem;Integrated Security=True");
            SqlDataAdapter adap = new SqlDataAdapter("select * from Diem order by ThoiGian ",connect);
            DataTable table = new DataTable();
            adap.Fill(table);
            dgvHightScore.DataSource = table;
        }
    }
}
