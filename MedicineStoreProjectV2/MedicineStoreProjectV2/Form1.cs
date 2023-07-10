using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
namespace MedicineStoreProjectV2
{
    public partial class Form1 : Form
    {
        BussinessLayer bussinessLayer=new BussinessLayer();
        public Form1()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            TxtUser.Clear();
            TxtPassword.Clear();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            Splash splash = new Splash();
            Admin admin1 = bussinessLayer.CheckLogin(TxtUser.Text, TxtPassword.Text);
            Global.Admin1 = admin1;
            if (admin1!=null && admin1.UserRole==true)
            {
                this.Hide();
                splash.ShowDialog();
                Administrator admin = new Administrator();
                admin.Show();
                this.Hide();
            }
            else if(admin1 !=null && admin1.UserRole == false)
            {
                this.Hide();
                splash.ShowDialog();
                MangeMeddicine mangeMeddicine = new MangeMeddicine();
                mangeMeddicine.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("UserName Or Password Was Wrong","Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    public class Global
    {
        Admin admin;
        public static Admin Admin1 { get; set ; }
    }
}
