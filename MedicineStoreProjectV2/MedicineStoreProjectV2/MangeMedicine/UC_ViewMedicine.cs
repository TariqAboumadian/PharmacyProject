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

namespace MedicineStoreProjectV2.MangeMedicine
{

    public partial class UC_ViewMedicine : UserControl
    {
        BussinessLayer bussinessLayer = new BussinessLayer();
        public UC_ViewMedicine()
        {
            InitializeComponent();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            List<Medicine> medicines=bussinessLayer.GetMedicines();
            GridViewUser.DataSource = medicines;
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            List<Medicine> medicines = bussinessLayer.GetFilteredMedicines(TxtSearch.Text);
            GridViewUser.DataSource = medicines;
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You sure ? Delete :", "Warnning",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                int selectedRowCount =
                    GridViewUser.Rows.GetRowCount(DataGridViewElementStates.Selected);

                if (selectedRowCount > 0)
                {
                    for (int i = 0; i < selectedRowCount; i++)
                    {
                        var res = GridViewUser.SelectedRows[i].Cells[0].Value.ToString();
                        bussinessLayer.DeleteMedicine(int.Parse(res));
                    }
                    List<Medicine> medicines = bussinessLayer.GetMedicines();
                    GridViewUser.DataSource = medicines;
                }
            }
        }
    }
}
