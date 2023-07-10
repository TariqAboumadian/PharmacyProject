using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicineStoreProjectV2.AdminControllers
{
    public partial class UC_AddUser : UserControl
    {
        BussinessLayer bussinessLayer=new BussinessLayer();
        public UC_AddUser()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            Txtname.Clear();
            Txtusrname.Clear();
            TxtPassord.Clear();
        }

        private void Btnsignup_Click(object sender, EventArgs e)
        {
            bool rule=false;
            if ((guna2ComboBox1.SelectedIndex) == 1)
            {
                rule=true;
            }
            else
            {
                rule=false;
            }

            int res=0;
            string name = Txtname.Text;
            string username = Txtusrname.Text;
            string password=TxtPassord.Text;
            //Regex regex = new Regex("[a-zA-Z]");
            //Regex regex1 = new Regex("^[a-zA-Z]+(?:\\d{2}|\\d{3})$");
            //bool namereg = regex.IsMatch(name);
            //bool userreg=regex1.IsMatch(username);
            //Regex regex = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[!#$%&?])[A-Za-z\\d!#$%&?]{8,}$");
            //bool passreg=regex.IsMatch(password);
            if (password.Length>0&&name.Length>0&& username.Length>0)  
            {
                res = bussinessLayer.AddUser(name,
                            username, password, rule);
            }
            if (res > 0)
            {
                MessageBox.Show("Signed Up Successfully", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Signed Up Failled", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
