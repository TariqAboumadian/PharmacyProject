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
    public partial class UC_ViewUser : UserControl
    {
        BussinessLayer bussinessLayer = new BussinessLayer();
        List<Admin> admins = new List<Admin>();
        public UC_ViewUser()
        {
            InitializeComponent();
            admins = bussinessLayer.GetUsers();
            GridViewUser.DataSource = admins;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            admins = bussinessLayer.GetUsers();
            GridViewUser.DataSource = admins;
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            admins = bussinessLayer.GetFiltterdUsers(TxtSearch.Text);
            GridViewUser.DataSource = admins;
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are You sure ? Delete :","Warnning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                int selectedRowCount =
                    GridViewUser.Rows.GetRowCount(DataGridViewElementStates.Selected);

                if (selectedRowCount > 0)
                {
                    for (int i = 0; i < selectedRowCount; i++)
                    {
                        var res = GridViewUser.SelectedRows[i].Cells[0].Value.ToString();
                        bussinessLayer.DeleteUser(int.Parse(res));
                    }
                    admins = bussinessLayer.GetUsers();
                    GridViewUser.DataSource = admins;
                }
            }
        }
    }
}
