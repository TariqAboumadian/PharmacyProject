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

namespace MedicineStoreProjectV2.MangeCompany
{
    public partial class UC_AddCompany : UserControl
    {
        BussinessLayer bussinessLayer = new BussinessLayer();
        public UC_AddCompany()
        {
            InitializeComponent();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            TxtAdress.Clear();
            TxtEmail.Clear();
            Txtname.Clear();
            TxtPhone.Clear();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string name = Txtname.Text;
            string phone = TxtPhone.Text;
            string mail=TxtEmail.Text;
            string address=TxtAdress.Text;
            if(name.Length>0 && phone.Length>0 && mail.Length > 0 && address.Length > 0)
            {
                int x = bussinessLayer.AddCompany(name, mail, address, phone);
                if (x > 0)
                {
                    MessageBox.Show("New Company Added", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please Check Your Data", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please Check Your Data","Error",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
