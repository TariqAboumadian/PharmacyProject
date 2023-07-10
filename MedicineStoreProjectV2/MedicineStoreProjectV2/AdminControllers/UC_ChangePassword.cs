using BLL;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicineStoreProjectV2.AdminControllers
{
    public partial class UC_ChangePassword : UserControl
    {
        BussinessLayer bussinessLayer = new BussinessLayer();
        public UC_ChangePassword()
        {
            InitializeComponent();
        }

        private void BtnChangepass_Click(object sender, EventArgs e)
        {
            Admin admin = bussinessLayer.GetUsers()
                .Where(p => (p.Password == Txtoldpass.Text)&&(p.userName==Txtusrname.Text)).FirstOrDefault();
            if (admin != null && Txtnewpass.Text == Txtconfirmpass.Text)
            {
                var result = bussinessLayer.updateuserinfo(admin.ID, admin.Name, admin.userName, Txtnewpass.Text);
                if (result == 1)
                {
                    MessageBox.Show("Change Password Success!","Info",
                        MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Change Password Failled!", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                }    
            }
        }

        private void Txtconfirmpass_TextChanged(object sender, EventArgs e)
        {
            if (Txtconfirmpass.Text != Txtnewpass.Text)
                label6.Text = "New Password Must be matched";
            else
                label6.Text = "";
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            Txtconfirmpass.Clear();
            Txtnewpass.Clear();
            Txtoldpass.Clear();
            Txtusrname.Clear();
        }

        private void Txtnewpass_TextChanged(object sender, EventArgs e)
        {
            if (Txtconfirmpass.Text != Txtnewpass.Text)
                label6.Text = "New Password Must be matched";
            else
                label6.Text = "";
        }
    }
}
