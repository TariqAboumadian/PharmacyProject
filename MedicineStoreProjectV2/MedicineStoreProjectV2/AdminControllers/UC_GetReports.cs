using BLL;
using DGVPrinterHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicineStoreProjectV2.AdminControllers
{
    public partial class UC_GetReports : UserControl
    {
        BussinessLayer bussinessLayer = new BussinessLayer();
        public UC_GetReports()
        {
            InitializeComponent();
        }
        string Title = "";
        private void guna2ComboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (guna2ComboBox1.SelectedItem== "Users")
            {
                List<Admin> users = bussinessLayer.GetUsers();
                GridViewReport.DataSource=users;
                Title = "user Admin Report";
                label3.Text = "Users";
            }
            else if(guna2ComboBox1.SelectedItem== "Medicines")
            {
                List<Medicine> medicines=bussinessLayer.GetMedicines();
                GridViewReport.DataSource=medicines;
                Title = "Medicin Report";
                label3.Text = "Medicines";
            }
            else if(guna2ComboBox1.SelectedItem == "Companies")
            {
                List<Supplier> suppliers = bussinessLayer.Getcompanies();
                GridViewReport.DataSource=suppliers;
                Title = "Medicin Company Report";
                label3.Text = "Companies";
            }
            else if (guna2ComboBox1.SelectedItem == "Sales")
            {
                List<Sales> sales = bussinessLayer.GetSales();
                GridViewReport.DataSource = sales;
                Title = "Medicin Sales Report";
                label3.Text = "Sales";
            }
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            DGVPrinter print = new DGVPrinter();
            print.Title = Title;
            print.SubTitle = string.Format("Date :- {0} ", DateTime.Now);
            print.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            print.PageNumbers = true;
            print.PageNumberInHeader = false;
            print.PorportionalColumns = true;
            print.HeaderCellAlignment = StringAlignment.Near;
            //print.ColumnWidth =(DGVPrinter.ColumnWidthSetting) GridViewReport.Columns.GetColumnsWidth(DataGridViewElementStates.Visible);
            GridViewReport.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            print.PrintDataGridView(GridViewReport);

        }
    }
}
