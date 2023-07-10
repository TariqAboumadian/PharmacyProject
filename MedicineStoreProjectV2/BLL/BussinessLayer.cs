using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class BussinessLayer
    {
        DataLayer dataLayer = new DataLayer();
        #region User Functions
        public List<Admin> GetUsers()
        {
            DataTable dataTable = dataLayer.GetAllUsers();
            List<Admin> admins = new List<Admin>();
            foreach (DataRow row in dataTable.Rows)
            {
                int id;
                bool role;
                bool isAdmin;
                Admin admin = new Admin();
                bool res = int.TryParse(row["ID"].ToString(), out id);
                isAdmin = bool.TryParse(row["UserRule"].ToString(), out role);
                admin.Name = row["Name"].ToString();
                admin.userName = row["userName"].ToString();
                admin.Password = row["Password"].ToString();
                admin.UserRole = isAdmin ? role:false;
                admin.ID = res ? id : 0;
                admins.Add(admin);
            }
            return admins;
        }
        public Admin CheckLogin(string usrname, string Password)
        {
            var Res = GetUsers().FirstOrDefault(p => (p.userName == usrname) && (p.Password == Password));
            return Res;
        }

        public int AddUser(string name, string usrname, string password,bool rule)
        {
            int res = dataLayer.AddUser(name, usrname, password,rule);
            return res;
        }
        public List<Admin> GetFiltterdUsers(string name)
        {
            List<Admin> admins = GetUsers().Where(p => p.Name.Contains(name)).ToList();
            return admins;
        }
        public List<Admin> GetUserById(int id)
        {
            List<Admin> admins = GetUsers().Where(p => p.ID == id).ToList();
            return admins;
        }
        public int DeleteUser(int id)
        {
            int row = dataLayer.DeleteUser(id);
            return row;
        }
        public int updateuserinfo(int id, string name, string Username, string Password)
        {
            int res = dataLayer.UpdateUser(id, name, Username, Password);
            return res;
        }
        #endregion

        #region Sell Functions
        public List<Sales> GetSales()
        {
            DataTable dataTable = dataLayer.GetSalesReport();
            List<Sales> sales = new List<Sales>();
            foreach (DataRow row in dataTable.Rows)
            {
                int id;
                int adminID;
                int medicineID;
                int quantity;
                decimal totalCost;
                int billnum;
                decimal price;
                DateTime salesDate;
                Sales sal = new Sales();
                bool resID = int.TryParse(row["SalesID"].ToString(), out id);
                bool resdminid = int.TryParse(row["AdminID"].ToString(), out adminID);
                bool resmedicineid = int.TryParse(row["MedicineID"].ToString(), out medicineID);
                bool restotalcost = decimal.TryParse(row["TotalCost"].ToString(), out totalCost);
                bool resquantity = int.TryParse(row["Quantity"].ToString(), out quantity);
                bool resSalDate = DateTime.TryParse(row["SalesDate"].ToString(), out salesDate);
                bool resbill = int.TryParse(row["billnumber"].ToString(),out billnum);
                string MedicineName = (row["MedicineName"].ToString());
                bool resprice= decimal.TryParse(row["price"].ToString(), out price);
                sal.SalesID = resID ? id : 0;
                sal.AdminID = resdminid ? adminID : 0;
                sal.MedicineName= MedicineName;
                sal.MedicineID = resmedicineid ? medicineID : 0;
                sal.Quantity = resquantity ? quantity : 0;
                sal.TotalCost = restotalcost ? totalCost : 0;
                sal.BillNumber=resbill? billnum : 0;
                sal.SalesDate = resSalDate ? salesDate.Date : DateTime.Now;
                sal.Price = resprice ? price : 0;
                sales.Add(sal);
            }
            return sales;
        }


        public int AddSales(int adminId, int medicineId, string name, decimal price, int quantity, DateTime date, int bill, decimal cost)
        {
            int count = dataLayer.AddSales(adminId, medicineId,name, price,quantity, date,bill,cost);
            return count;
        }

        public int DeleteSales(int salesid)
        {
            int count = dataLayer.DeleteSales(salesid);
            return count;
        }
        #endregion


        #region Medicine Functions
        public int AddMedicine(string name, decimal price, int unitInStock, string type, int companyID, DateTime prod_Date, DateTime expire_Date)
        {
            int count = dataLayer.AddMedicine(name, price, unitInStock, type, companyID, prod_Date, expire_Date);
            return count;
        }

        public List<Medicine> GetMedicines()
        {
            DataTable dataTable = dataLayer.GetMedicineReport();
            List<Medicine> medicines = new List<Medicine>();
            foreach (DataRow row in dataTable.Rows)
            {
                int id;
                int comID;
                int UIStock;
                decimal Price;
                DateTime prodDate;
                DateTime expireDate;
                Medicine medicine = new Medicine();
                bool resID = int.TryParse(row["ID"].ToString(), out id);
                bool resComid = int.TryParse(row["companyid"].ToString(), out comID);
                bool resStock = int.TryParse(row["unitInStock"].ToString(), out UIStock);
                bool resPrice = decimal.TryParse(row["Price"].ToString(), out Price);
                bool resProdDate = DateTime.TryParse(row["Prod_Date"].ToString(), out prodDate);
                bool resExpireDate = DateTime.TryParse(row["Expire_Date"].ToString(), out expireDate);
                medicine.Name = row["Name"].ToString();
                medicine.Type = row["Type"].ToString();
                medicine.ID = resID ? id : 0;
                medicine.CompanyID = resComid ? comID : 0;
                medicine.UnitInStock = resStock ? UIStock : 0;
                medicine.Price = resPrice ? Price : 0;
                medicine.ProdDate = resProdDate ? prodDate.Date : DateTime.Now;
                medicine.ExpireDate = resExpireDate ? expireDate.Date : DateTime.Now.AddDays(60);
                medicines.Add(medicine);
            }
            return medicines;
        }
        public List<Medicine> GetFilteredMedicines(string name)
        {
            List<Medicine> medicines =GetMedicines().Where(p=>p.Name.Contains(name)).ToList();
            return medicines;

        }
        public Medicine GetMedicineByID(int id)
        {
            Medicine medicines = GetMedicines().FirstOrDefault(p => p.ID==id);
            return medicines;

        }
        public int DeleteMedicine(int medicineId)
        {
            int count = dataLayer.DeleteMedicine(medicineId);
            return count;
        }
        public int EditMedicine(int medicineID, string name, decimal price, int unitInStock, string type, int companyID, DateTime prod_Date, DateTime expire_Date)
        {
            int count = dataLayer.EditMedicine(medicineID, name, price, unitInStock, type, companyID, prod_Date, expire_Date);
            return count;
        }
        public int EditSales(int salesID, int adminId, int medicineId, int quantity, DateTime date, string medicinename, decimal totalcost,
            decimal price, int bill)
        {
            int count = dataLayer.EditSales(salesID, adminId, medicineId, quantity, date,medicinename,totalcost,price,bill);
            return count;
        }
        #endregion

        #region Company Functions
        public List<Supplier> Getcompanies()
        {
            DataTable dataTable = dataLayer.GetCompanyReport();
            List<Supplier> suppliers = new List<Supplier>();
            foreach (DataRow row in dataTable.Rows)
            {
                int id;
                Supplier supplier = new Supplier();
                supplier.Name = row["Name"].ToString();
                supplier.Email = row["Email"].ToString();
                supplier.Address = row["Address"].ToString();
                supplier.Phone = row["Phone"].ToString();
                bool resID = int.TryParse(row["ID"].ToString(), out id);
                supplier.ID = resID ? id : 0;
                suppliers.Add(supplier);
            }
            return suppliers;
        }

        public int AddCompany(string name, string email, string address, string phone)
        {
            int count = dataLayer.AddCompany(name, email, address, phone);
            return count;
        }
        public List<Supplier>GetFilteredCompanies(string str)
        {
            List<Supplier> suppliers = Getcompanies().Where(p => p.Name.Contains(str)).ToList();
            return suppliers;
        }
        public int DeleteCompany(int companyId)
        {
            int count = dataLayer.DeleteCompany(companyId);
            return count;
        }

        public int EditCompany(int companyId, string name, string email, string address, string phone)
        {
            int count = dataLayer.EditCompany(companyId, name, email, address, phone);
            return count;
        }


        public List<CompanyMedicines> GetCompanyMedicines()
        {
            DataTable dataTable = dataLayer.GetCompanyMedicines();
            List<CompanyMedicines> medicines = new List<CompanyMedicines>();
            foreach (DataRow row in dataTable.Rows)
            {
                int id;
                int comID;
                int UIStock;
                decimal Price;
                DateTime prodDate;
                DateTime expireDate;
                CompanyMedicines medicine = new CompanyMedicines();
                bool resID = int.TryParse(row["ID"].ToString(), out id);
                bool resComid = int.TryParse(row["companyid"].ToString(), out comID);
                bool resStock = int.TryParse(row["unitInStock"].ToString(), out UIStock);
                bool resPrice = decimal.TryParse(row["Price"].ToString(), out Price);
                bool resProdDate = DateTime.TryParse(row["Prod_Date"].ToString(), out prodDate);
                bool resExpireDate = DateTime.TryParse(row["Expire_Date"].ToString(), out expireDate);
                medicine.CompanyName = row["companyName"].ToString();
                medicine.Name = row["Name"].ToString();
                medicine.Type = row["Type"].ToString();
                medicine.ID = resID ? id : 0;
                medicine.CompanyID = resComid ? comID : 0;
                medicine.UnitInStock = resStock ? UIStock : 0;
                medicine.Price = resPrice ? Price : 0;
                medicine.ProdDate = resProdDate ? prodDate.Date : DateTime.Now;
                medicine.ExpireDate = resExpireDate ? expireDate.Date : DateTime.Now.AddDays(60);
                medicines.Add(medicine);
            }
            return medicines;
        }
        #endregion
    }
}
