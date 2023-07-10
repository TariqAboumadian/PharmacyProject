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
    public partial class UC_EditCompany : UserControl
    {
        BussinessLayer bussinessLayer=new BussinessLayer();
        int suplierid;
        public UC_EditCompany()
        {
            InitializeComponent();
            List<Supplier> suppliers = bussinessLayer.Getcompanies();
            guna2ComboBox1.DataSource = suppliers;
            guna2ComboBox1.ValueMember = "ID";
            guna2ComboBox1.DisplayMember = "Name";
        }

        private void guna2ComboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Supplier suplier = bussinessLayer.Getcompanies().FirstOrDefault(p => p.ID == int.Parse(guna2ComboBox1.SelectedValue.ToString()));
            if(suplier!=null)
            {
                Txtname.Text = suplier.Name;
                TxtEmail.Text = suplier.Email;
                TxtAdress.Text = suplier.Address;
                TxtPhone.Text= suplier.Phone;
                suplierid=suplier.ID;
            }
            else
            {
                MessageBox.Show("Company Not Founded","Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUpdte_Click(object sender, EventArgs e)
        {
            string name = Txtname.Text;
            string email=TxtEmail.Text;
            string address = TxtAdress.Text;
            string phone = TxtPhone.Text;
            if (name.Length > 0 && email.Length > 0 && address.Length > 0 && phone.Length > 0&&suplierid>0)
            {
                int x = bussinessLayer.EditCompany(suplierid, name, email, address, phone);
                if (x > 0)
                {
                    MessageBox.Show("Company Updated Successully", "Info",
                         MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Update Failed!", "Error",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please Check Your Data", "Error",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            TxtAdress.Clear();
            TxtEmail.Clear();
            Txtname.Clear();
            TxtPhone.Clear();
        }
    }
}
