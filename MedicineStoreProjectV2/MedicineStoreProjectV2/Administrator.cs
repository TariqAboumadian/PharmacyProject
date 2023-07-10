using BLL;
using MedicineStoreProjectV2.AdminControllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicineStoreProjectV2
{
    public partial class Administrator : Form
    {
        public Administrator()
        {
            Admin admin = Global.Admin1;
            InitializeComponent();
            label2.Text = admin.Name;
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void BtnaddUser_Click(object sender, EventArgs e)
        {
            panel2.Dock = DockStyle.Right;
            UC_AddUser adduser = new UC_AddUser();
            adduser.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(adduser);
        }

        private void BtnViewUser_Click(object sender, EventArgs e)
        {
            panel2.Dock = DockStyle.Right;
            UC_ViewUser viewUser = new UC_ViewUser();
            viewUser.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(viewUser);
        }

        private void BtnUpdateUser_Click(object sender, EventArgs e)
        {
            panel2.Dock = DockStyle.Right;
            UC_ProfileUpdate UpdateUser = new UC_ProfileUpdate();
            UpdateUser.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(UpdateUser);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            panel2.Dock = DockStyle.Right;
            UC_ChangePassword changepass = new UC_ChangePassword();
            changepass.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(changepass);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            MangeMeddicine mangeMeddicine = new MangeMeddicine();
            mangeMeddicine.Show();
            this.Hide();
        }

        private void BtnMangeCompany_Click(object sender, EventArgs e)
        {
            MangeCompanymed mangeCompany = new MangeCompanymed();
            mangeCompany.Show();
            this.Hide();
        }

        private void BtnReports_Click(object sender, EventArgs e)
        {
            panel2.Dock = DockStyle.Right;
            UC_GetReports report = new UC_GetReports();
            report.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(report);
        }
    }
}
