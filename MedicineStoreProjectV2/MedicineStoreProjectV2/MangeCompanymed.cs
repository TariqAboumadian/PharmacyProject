using BLL;
using MedicineStoreProjectV2.AdminControllers;
using MedicineStoreProjectV2.MangeCompany;
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
    public partial class MangeCompanymed : Form
    {
        bool role;
        public MangeCompanymed()
        {
            InitializeComponent();
            Admin admin = Global.Admin1;
            role = admin.UserRole;
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            if (role)
            {
                Administrator admin = new Administrator();
                admin.Show();
                this.Hide();
            }
            else
            {
                MangeMeddicine mangeMeddicine = new MangeMeddicine();
                mangeMeddicine.Show();
                this.Hide();
            }
        }

        private void BtnaddCompany_Click(object sender, EventArgs e)
        {
            panel2.Dock = DockStyle.Right;
            UC_AddCompany addCompany = new UC_AddCompany();
            addCompany.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(addCompany);
        }

        private void BtnViewCompany_Click(object sender, EventArgs e)
        {
            panel2.Dock = DockStyle.Right;
            UC_ViewCompany viewCompany = new UC_ViewCompany();
            viewCompany.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(viewCompany);
        }

        private void BtnUpdateCompany_Click(object sender, EventArgs e)
        {
            panel2.Dock = DockStyle.Right;
            UC_EditCompany editCompany = new UC_EditCompany();
            editCompany.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(editCompany);
        }

        private void BtnCompMedicines_Click(object sender, EventArgs e)
        {
            panel2.Dock = DockStyle.Right;
            UC_CompanyMedicines compmedicine = new UC_CompanyMedicines();
            compmedicine.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(compmedicine);
        }
    }
}
