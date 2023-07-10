using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Xml.Linq;

namespace DAL
{
    public class DataLayer
    {
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        SqlDataAdapter sqlDataAdapter;
        DataTable dataTable;
        public DataLayer()
        {
            sqlConnection = new SqlConnection(@"Data Source=.;Initial Catalog=Yousef Pharmacy96;TrustServerCertificate=True;Integrated Security=True");
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
        }
        #region User Functions
        public DataTable GetAllUsers()
        {
            sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "select * from Admin";
            sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }

        public DataTable GetUser(int id)
        {
            sqlCommand.CommandText = $"select * from Admin where ID={id}";
            sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }
        public int AddUser(string name, string usrname, string password,bool rule)
        {
            sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "[dbo].[AddAdmin]";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter[] parameters =
            {
                 new SqlParameter("@name",name),
                 new SqlParameter("@username",usrname),
                 new SqlParameter("@Password",password),
                 new SqlParameter("@role",rule)
             };
            sqlCommand.Parameters.AddRange(parameters);

            sqlConnection.Open();
            int row = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return row;
        }

        public int DeleteUser(int id)
        {
            sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "[dbo].[DeleteAdmin]";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@ID", id);
            sqlConnection.Open();
            int row = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return row;
        }
        public int UpdateUser(int id, string name, string username, string password)
        {
            sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "[dbo].[editadmin]";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter[] parameters =
            {
                    new SqlParameter("@id",id),
                    new SqlParameter("@name",name),
                    new SqlParameter("@usrname", username),
                    new SqlParameter("@pass", password),
            };
            sqlCommand.Parameters.AddRange(parameters);
            sqlConnection.Open();
            int row = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return row;
        }
        #endregion


        #region Medicine Functions
        public int AddMedicine(string name, decimal price, int unitInStock, string type, int companyID, DateTime prod_Date, DateTime expire_Date)
        {
            sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "[dbo].[Addmedicine]";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter[] parameters =
            {
                 new SqlParameter("@name",name),
                 new SqlParameter("@price",price),
                 new SqlParameter("@unitInStock",unitInStock),
                 new SqlParameter("@Type",type),
                 new SqlParameter("@companyId",companyID),
                 new SqlParameter("@prod_Date",prod_Date.Date),
                 new SqlParameter("@expire_date",expire_Date.Date)
             };
            sqlCommand.Parameters.AddRange(parameters);

            sqlConnection.Open();
            int row = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return row;
        }
        public DataTable GetMedicineReport()
        {
            sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "select * from medicineReport";
            sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }
        public int DeleteMedicine(int medicineId)
        {
            sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "[dbo].[deletemedicine]";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@id", medicineId);
            sqlConnection.Open();
            int row = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return row;
        }

        public int EditMedicine(int medicineID, string name, decimal price, int unitInStock, string type, int companyID, DateTime prod_Date, DateTime expire_Date)
        {
            sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "[dbo].[editmedicine]";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter[] parameters =
                {
                    new SqlParameter("@id",medicineID),
                    new SqlParameter("@name",name),
                    new SqlParameter("@price",price),
                    new SqlParameter("@unitInStock",unitInStock),
                    new SqlParameter("@type",type),
                    new SqlParameter("@companyId",companyID),
                    new SqlParameter("@prodDate",prod_Date.Date),
                    new SqlParameter("@expireDate",expire_Date.Date)
                };
            sqlCommand.Parameters.AddRange(parameters);
            sqlConnection.Open();
            int row = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return row;
        }

        #endregion

        #region Sales Functions
        public DataTable GetSalesReport()
        {
            sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "select * from salesReport";
            sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }
        public int AddSales(int adminId, int medicineId, string name,decimal price, int quantity, DateTime date,int bill,decimal cost)
        {
            sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "[dbo].[Addsales]";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter[] parameters =
            {
                    new SqlParameter("@adminID", adminId),
                    new SqlParameter("@medicineID", medicineId),
                    new SqlParameter("@quantity", quantity),
                    new SqlParameter("@date", date),
                    new SqlParameter("@billnum",bill),
                    new SqlParameter("@totalcost",cost),
                    new SqlParameter("@name",name),
                    new SqlParameter("@price",price),
            };
            sqlCommand.Parameters.AddRange(parameters);
            sqlConnection.Open();
            int row = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return row;
        }

        public int DeleteSales(int salesid)
        {
            sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "[dbo].[deleteesales]";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@salesid", salesid);
            sqlConnection.Open();
            int row = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return row;
        }
        public int EditSales(int salesID, int adminId, int medicineId, int quantity, DateTime date,string medicinename,decimal totalcost,
            decimal price,int bill)
        {
            sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "[dbo].[editsales]";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter[] parameters =
            {
                    new SqlParameter("@SalesId",salesID),
                    new SqlParameter("@adminID", adminId),
                    new SqlParameter("@medicineID", medicineId),
                    new SqlParameter("@quantity", quantity),
                    new SqlParameter("@date", date.Date),
                    new SqlParameter("@medicinename",medicinename),
                    new SqlParameter("@price",price),
                    new SqlParameter("@totalcost",totalcost),
                    new SqlParameter("@billnumber",bill)
            };
            sqlCommand.Parameters.AddRange(parameters);
            sqlConnection.Open();
            int row = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return row;
        }
        #endregion

        #region Company Functions
        public DataTable GetCompanyReport()
        {
            sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "select * from companyReport";
            sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }

        public int AddCompany(string name, string email, string address, string phone)
        {
            sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "[dbo].[Addcompany]";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter[] parameters =
            {
                    new SqlParameter("@name", name),
                    new SqlParameter("@email", email),
                    new SqlParameter("@address", address),
                    new SqlParameter("@phone", phone)
            };
            sqlCommand.Parameters.AddRange(parameters);
            sqlConnection.Open();
            int row = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return row;
        }


        public int DeleteCompany(int companyId)
        {
            sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "[dbo].[deletecompany]";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@id", companyId);
            sqlConnection.Open();
            int row = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return row;
        }

        public int EditCompany(int companyId, string name, string email, string address, string phone)
        {
            sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "[dbo].[editcompany]";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter[] parameters =
           {
                    new SqlParameter("@id",companyId),
                    new SqlParameter("@name", name),
                    new SqlParameter("@email", email),
                    new SqlParameter("@address", address),
                    new SqlParameter("@phone", phone)
            };
            sqlCommand.Parameters.AddRange(parameters);
            sqlConnection.Open();
            int row = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return row;
        }

        public DataTable GetCompanyMedicines()
        {
            sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "select * from medicinecompanies";
            sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }
        #endregion
    }
}
