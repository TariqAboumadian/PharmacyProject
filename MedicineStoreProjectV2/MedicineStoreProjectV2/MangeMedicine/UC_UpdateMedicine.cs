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
using System.Xml.Linq;

namespace MedicineStoreProjectV2.MangeMedicine
{
    public partial class UC_UpdateMedicine : UserControl
    {
        BussinessLayer bussinessLayer = new BussinessLayer();
        Medicine medicine;
        public UC_UpdateMedicine()
        {
            InitializeComponent();
            medicine=new Medicine();
            List<Medicine> medicines = bussinessLayer.GetMedicines();
            ComboChoseMedicine.DataSource = medicines;
            ComboChoseMedicine.DisplayMember = "Name";
            ComboChoseMedicine.ValueMember = "ID";
            List<Supplier>supliers=bussinessLayer.Getcompanies();
            Combocompanyname.DataSource=supliers;
            Combocompanyname.DisplayMember = "Name";
            Combocompanyname.ValueMember = "ID";
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            Txtname.Clear();
            Txtprice.Clear();
            Txtquantity.Clear();
            TxtType.Clear();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            int newquantity = 0;
            bool res= int.TryParse(TxtaddQantity.Text,out newquantity);
            newquantity = res ? newquantity : 0;
            string name = Txtname.Text;
            decimal price = decimal.Parse(Txtprice.Text);
            int quantity = int.Parse(Txtquantity.Text) + newquantity;
            int compID = int.Parse(Combocompanyname.SelectedValue.ToString());
            string type = TxtType.Text;
            DateTime prod_date = dateprod.Value;
            DateTime exprire_date = dateExpire.Value;
            if (name.Length > 0 && price > 0 && quantity > 0 && type.Length > 0 && prod_date < exprire_date)
            {
                var result = bussinessLayer.EditMedicine(medicine.ID, name, price, quantity, type, compID, prod_date, exprire_date);
                if (result == 1)
                {
                    MessageBox.Show("Updated Successfully", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Update Failled!", "Error",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComboChoseMedicine_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int id = int.Parse(ComboChoseMedicine.SelectedValue.ToString());
             medicine= bussinessLayer.GetMedicines()
                .Where(p => p.ID == id).FirstOrDefault();

            if (medicine != null)
            {
                Txtname.Text = medicine.Name;
                Txtprice.Text = medicine.Price.ToString();
                Txtquantity.Text = medicine.UnitInStock.ToString();
                TxtType.Text = medicine.Type;
                Combocompanyname.SelectedValue = medicine.CompanyID;
                dateprod.Value = medicine.ProdDate;
                dateExpire.Value = medicine.ExpireDate;
            }
            else
            {
                MessageBox.Show("Medicine not found");
            }
        }
    }
}
