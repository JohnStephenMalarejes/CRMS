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

namespace Canine_RMS_2._0
{
    public partial class MnuMaintenance : Form
    {
        MySqlConnection cn;
        MySqlCommand cm;
        MySqlDataReader dr;
        ClassDB db = new ClassDB();
        public MnuMaintenance()
        {
            InitializeComponent();
            cn = new MySqlConnection();
            cn = ClassDB.GetCon();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnMntnAdd_Click(object sender, EventArgs e)
        {
            frmUser u = new frmUser(this);
            u.btnUpdate.Enabled = false;
            u.ShowDialog();
        }

        public void Loader()
        {
            try
            {
                dgOfficial.Rows.Clear();
                cn.Open();
                cm = new MySqlCommand("SELECT * from tbluser", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    dgOfficial.Rows.Add(dr["id"].ToString(), dr["lname"].ToString(), dr["fname"].ToString(), dr["mname"].ToString(), dr["pos"].ToString());
                }
                dr.Close();
                cn.Close();
                dgOfficial.ClearSelection();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, Var._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string colName = dgOfficial.Columns[e.ColumnIndex].Name;
                if (colName == "btnEdit")
                {
                    frmUser u = new frmUser(this);
                    u.btnSave.Enabled = false;
                    u._id = dgOfficial.Rows[e.RowIndex].Cells[0].Value.ToString();
                    u.txtLname.Text = dgOfficial.Rows[e.RowIndex].Cells[1].Value.ToString();
                    u.txtFname.Text = dgOfficial.Rows[e.RowIndex].Cells[2].Value.ToString();
                    u.txtMname.Text = dgOfficial.Rows[e.RowIndex].Cells[3].Value.ToString();
                    u.cboPos.Text = dgOfficial.Rows[e.RowIndex].Cells[4].Value.ToString();
                    u.ShowDialog();
                }
                else if (colName == "btnDel")
                {
                    if (MessageBox.Show("Do you want to delete this user?", Var._title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cn.Open();
                        cm = new MySqlCommand("DELETE from tbluser where id like '" + dgOfficial.Rows[e.RowIndex].Cells[0].Value.ToString() + "'", cn);
                        cm.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show("Data has been deleted", Var._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Loader();
                    }
                }
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, Var._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
