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
    public partial class SalesReports : UserControl
    {
        BussinessLayer bussinessLayer = new BussinessLayer();
        public SalesReports()
        {
            InitializeComponent();
            List<Sales> sales = bussinessLayer.GetSales();
            GridViewUser.DataSource=sales;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SalesReports_Load(object sender, EventArgs e)
        {
            List<Sales> sales = bussinessLayer.GetSales();
            GridViewUser.DataSource = sales;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {

            

            if (guna2ComboBox1.SelectedItem== "Medicine Name")
            {
                string str = Txtname.Text;
                if (str.Length > 0)
                {
                    List<Sales> sales = bussinessLayer.GetSales().Where(p => p.MedicineName.Contains(str)).ToList();
                    GridViewUser.DataSource = sales;
                }
                else
                {
                    MessageBox.Show("Enter Valid Name", "Warnning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if(guna2ComboBox1.SelectedItem == "Sales Date")
            {
                DateTime date = PikerSalesDate.Value.Date;
                List<Sales> sales = bussinessLayer.GetSales().Where(p =>
                    p.SalesDate==date).ToList();
                GridViewUser.DataSource = sales;
            }
            else if(guna2ComboBox1.SelectedItem == "Bill Number")
            {
                int bill = 0;
                bool res = int.TryParse(Txtbill.Text, out bill);
                bill = res ? bill : 0;
                if (bill > 0)
                {
                    List<Sales> sales = bussinessLayer.GetSales().Where(p => p.BillNumber==bill).ToList();
                    GridViewUser.DataSource = sales;
                }
                else
                {
                    MessageBox.Show("Enter Valid Bill Number", "Warnning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
