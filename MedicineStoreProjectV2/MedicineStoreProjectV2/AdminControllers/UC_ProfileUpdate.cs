using BLL;
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
   
    public partial class UC_ProfileUpdate : UserControl
    {
        BussinessLayer bussinessLayer=new BussinessLayer();
        public UC_ProfileUpdate()
        {
            InitializeComponent();
            List<Admin> admins=bussinessLayer.GetUsers();
            ComboSearch.DataSource=admins;
            ComboSearch.DisplayMember="Name";
            ComboSearch.ValueMember = "ID";
        }
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Txtusrid.Text);
            string name=Txtname.Text;
            string Usrname=Txtusrname.Text;
            string password=Txtpassword.Text;
            int x=bussinessLayer.updateuserinfo(id, name, Usrname, password); ;
            if (x > 0)
            {
                MessageBox.Show("Update Confirmed Successfully","Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Update Failled", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComboSearch_SelectionChangeCommitted(object sender, EventArgs e)
        {
            List<Admin> admin = bussinessLayer.GetUserById(int.Parse(ComboSearch.SelectedValue.ToString()));
            if (admin.Count > 0)
            {
                Txtusrid.Text = admin[0].ID.ToString();
                Txtname.Text = admin[0].Name;
                Txtusrname.Text = admin[0].userName;
                Txtpassword.Text = admin[0].Password;
            }
            else
            {
                MessageBox.Show("This User Id Not Found", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            Txtusrid.Clear();
            Txtusrname.Clear();
            Txtname.Clear();
            TxtPassord.Clear();
            Txtpassword.Clear();
        }
    }
}
