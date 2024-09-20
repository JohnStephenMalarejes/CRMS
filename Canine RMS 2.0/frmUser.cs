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
    public partial class frmUser : Form
    {
        MySqlConnection cn;
        MySqlCommand cm;
        ClassDB db = new ClassDB();
        MnuMaintenance mnt;
        public string _id;
        public frmUser(MnuMaintenance mnt)
        {
            InitializeComponent();
            cn = new MySqlConnection();
            cn = ClassDB.GetCon();
            this.mnt = mnt;
        }

        private void btnClose2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you want to save this user?", Var._title, MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    cn.Open();
                    cm = new MySqlCommand("INSERT into tbluser (lname, fname, mname, pos) values (@lname, @fname, @mname, @pos)", cn);
                    cm.Parameters.AddWithValue("@lname", txtLname.Text);
                    cm.Parameters.AddWithValue("@fname", txtFname.Text);
                    cm.Parameters.AddWithValue("@mname", txtMname.Text);
                    cm.Parameters.AddWithValue("@pos", cboPos.Text);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Data has been saved", Var._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Clear();
                    mnt.Loader();
                }
                

            }catch(Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, Var._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            
        }
        public void Clear()
        {
            txtLname.Clear();
            txtFname.Clear();
            txtMname.Clear();
            cboPos.Text = " ";
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            txtLname.Focus();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you want to update this user?", Var._title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new MySqlCommand("UPDATE tbluser SET lname=@lname, fname=@fname, mname=@mname, pos=@pos where id=@id", cn);
                    cm.Parameters.AddWithValue("@lname", txtLname.Text);
                    cm.Parameters.AddWithValue("@fname", txtFname.Text);
                    cm.Parameters.AddWithValue("@mname", txtMname.Text);
                    cm.Parameters.AddWithValue("@pos", cboPos.Text);
                    cm.Parameters.AddWithValue("@id", _id);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Data has been updated", Var._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Clear();
                    mnt.Loader();
                    this.Dispose();
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
