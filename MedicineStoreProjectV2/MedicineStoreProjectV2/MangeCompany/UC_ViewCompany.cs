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

namespace MedicineStoreProjectV2.MangeCompany
{
    public partial class UC_ViewCompany : UserControl
    {
        BussinessLayer bussinessLayer=new BussinessLayer();
        public UC_ViewCompany()
        {
            InitializeComponent();
            List<Supplier> suppliers = bussinessLayer.Getcompanies();
            GridViewCompany.DataSource = suppliers;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            List<Supplier> suppliers = bussinessLayer.Getcompanies();
            GridViewCompany.DataSource= suppliers;
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            List<Supplier> suppliers = bussinessLayer.GetFilteredCompanies(TxtSearch.Text);
            GridViewCompany.DataSource= suppliers;
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            List<Supplier> suppliers = bussinessLayer.Getcompanies();
            if (MessageBox.Show("Are You sure ? Delete :", "Warnning",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                int selectedRowCount =
                    GridViewCompany.Rows.GetRowCount(DataGridViewElementStates.Selected);

                if (selectedRowCount > 0)
                {
                    for (int i = 0; i < selectedRowCount; i++)
                    {
                        var res = GridViewCompany.SelectedRows[i].Cells[0].Value.ToString();
                        bussinessLayer.DeleteCompany(int.Parse(res));
                    }
                    suppliers = bussinessLayer.Getcompanies();
                    GridViewCompany.DataSource = suppliers;
                }
            }
        }
    }
}
