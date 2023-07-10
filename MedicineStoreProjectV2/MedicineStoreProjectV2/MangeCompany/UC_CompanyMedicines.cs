using BLL;
using DGVPrinterHelper;
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
    public partial class UC_CompanyMedicines : UserControl
    {
        BussinessLayer bussinessLayer = new BussinessLayer();
        public UC_CompanyMedicines()
        {
            InitializeComponent();

        }

        private void UC_CompanyMedicines_Load(object sender, EventArgs e)
        {
            List<Supplier> suppliers = bussinessLayer.Getcompanies();
            guna2ComboBox1.DataSource= suppliers;
            guna2ComboBox1.ValueMember = "ID";
            guna2ComboBox1.DisplayMember = "Name";
            List<CompanyMedicines> commedicines = bussinessLayer.GetCompanyMedicines();
            GridViewCompany.DataSource= commedicines;
        }

        private void guna2ComboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int Compid = 0;
            bool res = int.TryParse(guna2ComboBox1.SelectedValue.ToString(), out Compid);
            Compid = res ? Compid : 0;
            if (Compid > 0)
            {
                List<Medicine> medicines = bussinessLayer.GetMedicines().Where(p =>
                p.CompanyID == Compid).ToList();
                GridViewCompany.DataSource=medicines;
            }
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            DGVPrinter print = new DGVPrinter();
            print.Title = "Company Medicines Report";
            print.SubTitle = string.Format("Date :- {0} ", DateTime.Now);
            print.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            print.PageNumbers = true;
            print.PageNumberInHeader = false;
            print.PorportionalColumns = true;
            print.HeaderCellAlignment = StringAlignment.Near;
            //print.ColumnWidth =(DGVPrinter.ColumnWidthSetting) GridViewReport.Columns.GetColumnsWidth(DataGridViewElementStates.Visible);
            GridViewCompany.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            print.PrintDataGridView(GridViewCompany);
        }
    }
}
