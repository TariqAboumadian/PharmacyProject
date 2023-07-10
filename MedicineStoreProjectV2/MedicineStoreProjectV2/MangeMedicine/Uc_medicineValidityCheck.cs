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
    public partial class Uc_medicineValidityCheck : UserControl
    {
        BussinessLayer bussinessLayer = new BussinessLayer();
        public Uc_medicineValidityCheck()
        {
            InitializeComponent();
        }

        private void guna2ComboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            List<Medicine> medicines=new List<Medicine>();
            if (guna2ComboBox1.SelectedItem == "Valid Medicine")
            {
                medicines = bussinessLayer.GetMedicines().Where(p => (DateTime.Now < p.ExpireDate)).ToList();
                guna2DataGridView1.DataSource=medicines;
                label3.Text = "Valid Medicine";
                label3.ForeColor= Color.Green;
            }else if(guna2ComboBox1.SelectedItem == "Expired Medicine")
            {
                medicines = bussinessLayer.GetMedicines().Where(p => (p.ExpireDate < DateTime.Now)).ToList();
                guna2DataGridView1.DataSource = medicines;
                label3.Text = "Expired Medicine";
                label3.ForeColor= Color.Red;
            }else if(guna2ComboBox1.SelectedItem == "All Medicine")
            {
                medicines = bussinessLayer.GetMedicines();
                guna2DataGridView1.DataSource = medicines;
                label3.Text = "All Medicine";
                label3.ForeColor= Color.Blue;
            }
        }
    }
}
