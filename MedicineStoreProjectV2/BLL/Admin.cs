using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Admin
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public string userName { set; get; }
        public string Password { set; get; }
        public bool UserRole { get; set; }
    }
}
