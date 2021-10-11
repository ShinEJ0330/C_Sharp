using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingManagementSystem
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (var db = new ParkingDB())
            {
                
                var admin = db.Admins.SingleOrDefault(p => p.LoginId == textLogin.Text && p.Password == textPassword.Text);
                if (admin != null)
                {
                    this.Hide();

                    var form = new frmIncome();
                    form.ShowDialog();

                    this.Close();
                }
                else
                {
                    MessageBox.Show("아이디나 비밀번호가 잘못되었습니다.", "로그인 실패");

                }
            }
        }
    }
}
