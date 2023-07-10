using BLL;
using DGVPrinterHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicineStoreProjectV2.MangeMedicine
{
    public partial class UC_SellMedicine : UserControl
    {
        BussinessLayer bussinessLayer = new BussinessLayer();
        int maxbillnum=0;
        int adminid;
        int MedicineId;
        decimal totalamount = 0;
        public UC_SellMedicine()
        {
            InitializeComponent();
            Admin admin=Global.Admin1;
            List<Medicine> medicines = bussinessLayer.GetMedicines().
                     Where(p => p.ExpireDate > DateTime.Now).ToList();
            guna2ComboBox1.DataSource = medicines;
            guna2ComboBox1.DisplayMember = "Name";
            guna2ComboBox1.ValueMember = "ID";
            adminid = admin.ID;
            maxbillnum = bussinessLayer.GetSales().Max(p => p.BillNumber);
            maxbillnum++;
            Txtbillnumber.Text = maxbillnum.ToString();
        }
        private void label9_Click(object sender, EventArgs e)
        {
        }
        
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            MedicineId = int.Parse(Txtsearch.Text);
            Medicine medicine = bussinessLayer.GetMedicineByID(MedicineId);
            if (medicine != null && medicine.ExpireDate > DateTime.Now)
            {
                Txtname.Text = medicine.Name;
                Txtprice.Text = medicine.Price.ToString();
                guna2ComboBox1.SelectedValue = int.Parse(Txtsearch.Text);
            }
            else
            {
                MessageBox.Show("Medicine Not Exists", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void guna2ComboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            MedicineId=int.Parse(guna2ComboBox1.SelectedValue.ToString());
            Medicine medicine = bussinessLayer.GetMedicineByID(MedicineId);
            if(medicine!= null)
            {
                Txtname.Text = medicine.Name;
                Txtprice.Text = medicine.Price.ToString();
            }
        }

        private void BtnAddToCart_Click(object sender, EventArgs e)
        {
            bool res;
            int quantity;
            res = int.TryParse(Txtnoofunits.Text,out quantity);
            quantity = res ? quantity : 0;
            int bill=0;
             res= int.TryParse(Txtbillnumber.Text,out bill);
            bill = res ? bill : 0;
            decimal Totalcost=0;
            res = decimal.TryParse(Txttotalprice.Text,out Totalcost);
            Totalcost = res ? Totalcost : 0;
            string mname = Txtname.Text;
            int insertres = 0;
            int updateres = 0;
            int n;
            Medicine medicine=bussinessLayer.GetMedicineByID(MedicineId);
            if (medicine.UnitInStock >= quantity)
            {
                if (quantity > 0 && bill > 0 && Totalcost > 0 && mname.Length>0)
                {
                    insertres = bussinessLayer.AddSales(adminid, medicine.ID,mname,medicine.Price,
                        quantity,DateTime.Now.Date,bill,Totalcost);
                    updateres = bussinessLayer.EditMedicine(medicine.ID, medicine.Name,
                        medicine.Price, (medicine.UnitInStock - quantity), medicine.Type, medicine.CompanyID,
                        medicine.ProdDate, medicine.ExpireDate);
                    List<Sales> sales = bussinessLayer.GetSales().Where(p => p.BillNumber == bill).ToList();
                    guna2DataGridView1.DataSource = sales;
                    totalamount = sales.Sum(p => p.TotalCost);
                    label11.Text="RS: "+totalamount.ToString();
                    Txtnoofunits.Clear();
                }
                else
                {
                    MessageBox.Show($"You Must enter Valid Data", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show($"Quantity Ordered More Than Units In Stock" +
                    $"There Was {medicine.UnitInStock}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (insertres > 0)
            {
                MessageBox.Show($"Item Added Successfully", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            //-----------------------------------------------------

        }

        private void Txtnoofunits_TextChanged(object sender, EventArgs e)
        {
            bool res;
            decimal price;
            decimal units;
            res = decimal.TryParse(Txtprice.Text,out price);
            price = res ? price : 0;
            res = decimal.TryParse(Txtnoofunits.Text, out units);
            units = res ? units : 0;
            decimal total =  price*units;
            Txttotalprice.Text = total.ToString();
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            DGVPrinter print = new DGVPrinter();
            print.Title = "Medicine Bill";
            print.SubTitle = string.Format("Date :- {0} ", DateTime.Now.Date);
            print.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            print.PageNumbers = true;
            print.PageNumberInHeader = false;
            print.PorportionalColumns = true;
            print.HeaderCellAlignment = StringAlignment.Near;
            print.Footer = "Total Payable Amount : " + totalamount;
            print.FooterSpacing = 15;
            print.PrintDataGridView(guna2DataGridView1);
            totalamount = 0;
            maxbillnum += 1;
            Txtbillnumber.Text = maxbillnum.ToString();
            label11.Text = "Rs. 00";
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            Remove();
        }
        void Remove()
        {
            int selectedRowCount = guna2DataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (selectedRowCount > 0)

            {
                for (int i = 0; i < selectedRowCount; i++)
                {
                    var id = int.Parse(guna2DataGridView1.SelectedRows[i].Cells[0].Value.ToString());
                    bussinessLayer.DeleteSales(id);
                    var medicineid = int.Parse(guna2DataGridView1.SelectedRows[i].Cells[6].Value.ToString());
                    Medicine medicine = bussinessLayer.GetMedicineByID(medicineid);
                    var quantity = int.Parse(guna2DataGridView1.SelectedRows[i].Cells[3].Value.ToString());
                    bussinessLayer.EditMedicine(medicineid, medicine.Name, medicine.Price, (medicine.UnitInStock + quantity),
                        medicine.Type, medicine.CompanyID, medicine.ProdDate, medicine.ExpireDate);
                    totalamount -= decimal.Parse(guna2DataGridView1.SelectedRows[i].Cells[5].Value.ToString());
                    label11.Text = "Rs: " + totalamount.ToString();
                    List<Sales> sales = bussinessLayer.GetSales().Where(p => p.BillNumber == int.Parse(Txtbillnumber.Text)).ToList();
                    guna2DataGridView1.DataSource = sales;
                }

            }
        }
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            Remove();
            int quantity = int.Parse(Txtnoofunits.Text);
            int bill = int.Parse(Txtbillnumber.Text);
            decimal Totalcost = decimal.Parse(Txttotalprice.Text);
            string mname = Txtname.Text;
            int insertres = 0;
            int updateres = 0;
            int n;
            Medicine medicine = bussinessLayer.GetMedicineByID(MedicineId);
            if (medicine.UnitInStock >= quantity)
            {
                if (quantity > 0 && bill > 0 && Totalcost > 0 && mname.Length > 0)
                {
                    insertres = bussinessLayer.AddSales(adminid, medicine.ID, mname, medicine.Price,
                        quantity, DateTime.Now.Date, bill, Totalcost);
                    updateres = bussinessLayer.EditMedicine(medicine.ID, medicine.Name,
                        medicine.Price, (medicine.UnitInStock - quantity), medicine.Type, medicine.CompanyID,
                        medicine.ProdDate, medicine.ExpireDate);
                    List<Sales> sales = bussinessLayer.GetSales().Where(p => p.BillNumber == bill).ToList();
                    guna2DataGridView1.DataSource = sales;
                    totalamount = sales.Sum(p => p.TotalCost);
                    label11.Text = "RS: " + totalamount.ToString();
                    Txtnoofunits.Clear();
                }
                else
                {
                    MessageBox.Show($"You Must enter Valid Data", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show($"Quantity Ordered More Than Units In Stock" +
                    $"There Was {medicine.UnitInStock}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (insertres > 0)
            {
                MessageBox.Show($"Item Updated Successfully", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Txtname.Text = guna2DataGridView1.CurrentRow.Cells[2].Value.ToString();
            Txtprice.Text = guna2DataGridView1.CurrentRow.Cells[4].Value.ToString();
            Txtbillnumber.Text = guna2DataGridView1.CurrentRow.Cells[8].Value.ToString();
            Txtnoofunits.Text = guna2DataGridView1.CurrentRow.Cells[3].Value.ToString();
            MedicineId=int.Parse(guna2DataGridView1.CurrentRow.Cells[6].Value.ToString());
        }
    }
}
