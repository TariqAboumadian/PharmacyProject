using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Sales
    {
        public int SalesID { set; get; }
        public int AdminID { set; get; }
        public string MedicineName { get; set; }
        public int Quantity { set; get; }
        public decimal Price { get;set; }
        public decimal TotalCost { set; get; }
        public int MedicineID { set; get; }

        public DateTime SalesDate { set; get; }
        public int BillNumber { get; set; }
    }
}
