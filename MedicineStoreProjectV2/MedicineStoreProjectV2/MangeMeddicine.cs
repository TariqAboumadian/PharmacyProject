using BLL;
using MedicineStoreProjectV2.AdminControllers;
using MedicineStoreProjectV2.MangeMedicine;
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
    public partial class MangeMeddicine : Form
    {
        public MangeMeddicine()
        {
            InitializeComponent();
            Admin admin=Global.Admin1;
            role = admin.UserRole;
            if (role == false)
            {
                BtnBack.Visible = false;
            }
            adminid = admin.ID;
        }
        bool role = true;
        int adminid;
        private void BtnBack_Click(object sender, EventArgs e)
        {
            if (role == true)
            {
                Administrator admin = new Administrator();
                admin.Show();
                this.Hide();
            }
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void BtnAddMedicine_Click(object sender, EventArgs e)
        {
            panel2.Dock = DockStyle.Right;
            UC_AddMedicine addMedicine = new UC_AddMedicine();
            addMedicine.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(addMedicine);
        }

        private void BtnViewMedicine_Click(object sender, EventArgs e)
        {
            panel2.Dock = DockStyle.Right;
            UC_ViewMedicine viewMedicine = new UC_ViewMedicine();
            viewMedicine.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(viewMedicine);
        }

        private void BtnUpdateMedicine_Click(object sender, EventArgs e)
        {
            panel2.Dock = DockStyle.Right;
            UC_UpdateMedicine updateMedicine = new UC_UpdateMedicine();
            updateMedicine.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(updateMedicine);
        }

        private void BtnCheckMedicine_Click(object sender, EventArgs e)
        {
            panel2.Dock = DockStyle.Right;
            Uc_medicineValidityCheck checkMedicine = new Uc_medicineValidityCheck();
            checkMedicine.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(checkMedicine);
        }

        private void BtnSell_Click(object sender, EventArgs e)
        {
            panel2.Dock = DockStyle.Right;
            UC_SellMedicine sell = new UC_SellMedicine();
            sell.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(sell);
        }

        private void BtnMangeCompany_Click(object sender, EventArgs e)
        {
            MangeCompanymed mangeCompany = new MangeCompanymed();
            mangeCompany.Show();
            this.Hide();
        }

        private void BtnSalesReport_Click(object sender, EventArgs e)
        {
            panel2.Dock = DockStyle.Right;
            SalesReports alesreport = new SalesReports();
            alesreport.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(alesreport);
        }
    }
}
