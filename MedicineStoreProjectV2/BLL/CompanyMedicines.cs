using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CompanyMedicines
    {
        public string CompanyName { get; set; }
        public int ID { set; get; }
        public string Name { set; get; }
        public decimal Price { set; get; }
        public int UnitInStock { set; get; }
        public string Type { set; get; }
        public int CompanyID { set; get; }
        public DateTime ProdDate { set; get; }
        public DateTime ExpireDate { set; get; }
    }
}
