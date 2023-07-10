using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicineStoreProjectV2.MangeMedicine
{
    public partial class UC_AddMedicine : UserControl
    {
        BussinessLayer bussinessLayer = new BussinessLayer();
        public UC_AddMedicine()
        {
            InitializeComponent();
            List<Supplier> suppliers = bussinessLayer.Getcompanies();
            Combocompanyname.DataSource = suppliers;
            Combocompanyname.ValueMember= "ID";
            Combocompanyname.DisplayMember = "Name";
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            Txtname.Clear();
            Txtprice.Clear();
            Txtquantity.Clear();
            TxtType.Clear();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            bool rs;
            decimal price=0;
            string name = Txtname.Text;
            rs =decimal.TryParse(Txtprice.Text,out price);
            price=rs?price:0;
            int quantity = 0;
             rs= int.TryParse(Txtquantity.Text,out quantity);
            quantity=rs?quantity:0;
            string m_type = TxtType.Text;
            DateTime prod_date = dateprod.Value;
            DateTime Expire_date = dateExpire.Value;
            int companyid = int.Parse(Combocompanyname.SelectedValue.ToString());
            if (name.Length>0 && price > 0 && quantity > 0 && m_type.Length>0 && prod_date < Expire_date)
            {
                var res = bussinessLayer.AddMedicine(name, price, quantity, m_type, companyid, prod_date.Date, Expire_date.Date);
                if (res == 1)
                {
                    MessageBox.Show("Medicine has been added", "Info",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Medicine Failed To add", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
