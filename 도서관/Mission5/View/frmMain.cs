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
    public partial class frmMain : Form
    {
        private Member searchedMember;
        private BookCopy searchedBookCopy;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void RefrashMemberInfo()
        {
            if (string.IsNullOrEmpty(txtMemberId.Text))
            {
                MessageBox.Show("회원 아이디를 입력하세요.", "입력오류");
                return;
            }
            searchedMember = MemberDAO.GetInstance().Get(txtMemberId.Text);

            if (searchedMember == null)
            {
                MessageBox.Show("입력한 아이디에 해당하는 회원이 존재하지 않습니다.", "회원 조회 오류");
                return;
            }

            lblMemberName.Text = searchedMember.Name;
            lblPhoneNo.Text = searchedMember.PhoneNo;

            var summary = MemberCheckOutDAO.GetInstance().GetCheckOutSummary(searchedMember.Id);
            lblNumOfCheckOut.Text = summary.NumOfBookCheckOut.ToString();
            lblNumOfAvailable.Text = summary.NumOfBookAvailable.ToString();
            lblNumOfOverdue.Text = summary.NumOfBookOverdue.ToString();
            lblDaysOfOverdue.Text = summary.DaysOfOverdue.ToString("0,0");
            lblOverdueFee.Text = summary.OverdueFee.ToString("0,0");

            var bookCopyList = MemberCheckOutDAO.GetInstance().GetCheckOutBookInfoList(searchedMember.Id);
            dgvBookList.AutoGenerateColumns = false;
            dgvBookList.DataSource = bookCopyList;
        }

        private void btnSearchMember_Click(object sender, EventArgs e)
        {
            RefrashMemberInfo();
            /*
            using (var db = new Library())
            {
                var emp = db.Member.SingleOrDefault(p => p.LoginId == txtMemberId.Text);
                if (emp != null)
                {
                    btnReturn.Enabled = false;

                }
                else
                {
                    MessageBox.Show("입력한 아이디에 해당하는 회원이 존재하지 않습니다.", "회원 조회 오류");
                }
            }*/
        }
        
        private void btnReturn_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvBookList.CurrentRow.Cells[0].Value);
            string bookCopyCode = Convert.ToString(dgvBookList.CurrentRow.Cells[1].Value);
            int overdueDays = Convert.ToInt32(dgvBookList.CurrentRow.Cells[5].Value);
            int overdueCharge = Convert.ToInt32(dgvBookList.CurrentRow.Cells[6].Value);

            var checkOut = CheckOutDAO.GetInstance().Get(id);
            checkOut.ReturnDate = DateTime.Now;
            checkOut.OverdueDays = overdueDays;
            checkOut.OverdueCharge = overdueCharge;
            CheckOutDAO.GetInstance().Update(checkOut);

            var bookCopy = BookCopyDAO.GetInstance().Get(bookCopyCode);
            bookCopy.BookStatus = 0;    //대출 가능 상태
            BookCopyDAO.GetInstance().Update(bookCopy);

            RefrashMemberInfo();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void RefrashBookInfo()
        {
            if (string.IsNullOrEmpty(txtBookCopyCode.Text))
            {
                MessageBox.Show("도서등록번호를 입력하세요.", "입력오류");
                return;
            }
            searchedBookCopy = BookCopyDAO.GetInstance().Get(txtBookCopyCode.Text);

            if (searchedBookCopy == null)
            {
                MessageBox.Show("입력한 도서등록번호에 해당하는 도서가 존재하지 않습니다.", "도서 조회 오류");
                return;
            }

            var book = BookDAO.GetInstance().Get(searchedBookCopy.BookCopyCode.Substring(0, 6));
            lblTitle.Text = book.Title;
            lblPublisher.Text = book.Publisher;
        }

        private void btnSearchBookCopy_Click(object sender, EventArgs e)
        {
            RefrashBookInfo();
            /*
            using (var db = new Library())
            {
                var emp = db.Book.SingleOrDefault(p => p.BookCode == txtBookCopyCode.Text);
                if (emp != null)
                {
                    btnCheckOut.Enabled = false;
                }
                else
                {
                    MessageBox.Show("입력한 도서등록번호에 해당하는 도서가 존재하지 않습니다.", "도서 조회 오류");
                }
            }*/
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            var summary = MemberCheckOutDAO.GetInstance().GetCheckOutSummary(searchedMember.Id);

            if (summary.NumOfBookAvailable == 0)
            {
                MessageBox.Show("이미 최대로 대출중 입니다.", "대출 오류");
                return;
            }

            if (summary.NumOfBookOverdue > 0)
            {
                MessageBox.Show("연체중인 도서가 있습니다.", "대출 오류");
                return;
            }

            if (searchedBookCopy.BookStatus == 1)
            {
                MessageBox.Show("이미 대출중인 책입니다.", "대출 오류");
                return;
            }


            // checkOut
            var rule = RuleDAO.GetInstance().Get();
            var checkOut = CheckOutDAO.GetInstance().Get(searchedMember.Id);
            checkOut.MemberId = searchedMember.Id;
            checkOut.BookCopyId = searchedBookCopy.Id;
            checkOut.CheckOutDate = DateTime.Now;
            checkOut.DueDate = checkOut.CheckOutDate.AddDays(rule.RentDays);
            checkOut.ReturnDate = null;
            checkOut.OverdueDays = null;
            checkOut.OverdueCharge = null;
            checkOut.LibrarianId = 1;
            CheckOutDAO.GetInstance().Add(checkOut);


            // bookCopy
            var bookCopy = BookCopyDAO.GetInstance().Get(searchedBookCopy.Id);
            bookCopy.BookStatus = 1;
            BookCopyDAO.GetInstance().Update(bookCopy);

            RefrashMemberInfo();
        }
    }
}
