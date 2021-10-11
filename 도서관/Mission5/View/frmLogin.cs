using Mission5Lib.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mission5.View
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
            /*
            using (var db = new Library())
            {
                var emp = db.Librarian.SingleOrDefault(p => p.LoginId == txtLoginId.Text && p.Password == txtPassword.Text);
                if (emp != null)
                {
                    var form = new frmMain();
                    form.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("아이디나 비밀번호가 잘못되었습니다.", "로그인 실패");
                }
            }*/

            string loginId = txtLoginId.Text;
            string password = txtPassword.Text;

            var librarian = LibrarianDAO.GetInstance().Get(loginId);

            if(librarian != null)
            {
                if(librarian.Password == password)
                {
                    var from = new frmMain();
                    from.Show();
                    this.Hide();
                    return;
                }
            }
            MessageBox.Show("아이디나 비밀번호가 잘못되었습니다.", "로그인 실패", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

    }
}
