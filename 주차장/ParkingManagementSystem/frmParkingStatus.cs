using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingManagementSystem
{
    public partial class frmParkingStatus : Form
    {
        public frmParkingStatus()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEnable(bool TF)
        {
            btnA01.Enabled = TF;
            btnA02.Enabled = TF;
            btnA03.Enabled = TF;
            btnA04.Enabled = TF;
            btnA05.Enabled = TF;
            btnA06.Enabled = TF;
            btnA07.Enabled = TF;
            btnA08.Enabled = TF;
            btnA09.Enabled = TF;
            btnA10.Enabled = TF;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEnter.Text))
            {
                MessageBox.Show("차량 번호를 입력하세요.", "오 류");
                return;
            }

            if (CBCarType.SelectedItem == null)
            {
                MessageBox.Show("차량 종류를 선택하세요.", "오 류");
                return;
            }

            MessageBox.Show("차량 위치를 선택하세요.", "입장");
            btnEnable(true);
        }

        private void DBInsert(string parkingLotNum)
        {
            using (var db = new ParkingDB())
            {
                var checkOut = db.CheckOuts.FirstOrDefault(p => p.Id == 1);
                var status = db.ParkInfoes.SingleOrDefault(p => p.ParkingLotNum == parkingLotNum);

                checkOut.CarNo = txtEnter.Text;
                checkOut.CarType = CBCarType.SelectedItem.ToString();
                checkOut.EnterTime = DateTime.Now;
                checkOut.ParkingLotNum = parkingLotNum;
                checkOut.ExitTime = null;
                checkOut.ParkingCharge = null;

                status.Status = true;

                db.CheckOuts.Add(checkOut);
                db.SaveChanges();
            }
            MessageBox.Show("차량을 주차했습니다.", "주차 완료");
            RefreshLabel();
        }

        private void RefreshDGV()
        {
            List<CarCheckOut> list = new List<CarCheckOut>();

            using (var db = new ParkingDB())
            {
                var carCheckOuts = from p in db.CheckOuts
                                   where p.ExitTime == null
                                   select new { p.CarNo, p.CarType, p.EnterTime, p.ParkingLotNum };

                foreach (var checkOut in carCheckOuts.ToList())
                {
                    var info = new CarCheckOut();
                    info.CarNo = checkOut.CarNo;
                    info.CarType = checkOut.CarType;
                    info.EnterTime = checkOut.EnterTime;
                    info.ParkingLotNum = checkOut.ParkingLotNum;
                    list.Add(info);
                }
            }

            dgvInquiry.AutoGenerateColumns = false;
            dgvInquiry.DataSource = list;
        }

        private void btnA01_Click(object sender, EventArgs e)
        {

            using (var db = new ParkingDB())
            {
                var status = db.ParkInfoes.SingleOrDefault(p => p.ParkingLotNum == "A-01");

                if (status.Status == false)
                {
                    btnEnable(false);
                    DBInsert("A-01");
                    RefreshDGV();
                }
                else
                {
                    MessageBox.Show("차량이 주차되어 있습니다.", "오 류");
                }
            }
        }

        private void btnA02_Click(object sender, EventArgs e)
        {
            using (var db = new ParkingDB())
            {
                var status = db.ParkInfoes.SingleOrDefault(p => p.ParkingLotNum == "A-02");

                if (status.Status == false)
                {
                    btnEnable(false);
                    DBInsert("A-02");
                    RefreshDGV();
                }
                else
                {
                    MessageBox.Show("차량이 주차되어 있습니다.", "오 류");
                }
            }

        }

        private void btnA03_Click(object sender, EventArgs e)
        {
            using (var db = new ParkingDB())
            {
                var status = db.ParkInfoes.SingleOrDefault(p => p.ParkingLotNum == "A-03");

                if (status.Status == false)
                {
                    btnEnable(false);
                    DBInsert("A-03");
                    RefreshDGV();
                }
                else
                {
                    MessageBox.Show("차량이 주차되어 있습니다.", "오 류");
                }
            }
        }

        private void btnA04_Click(object sender, EventArgs e)
        {
            using (var db = new ParkingDB())
            {
                var status = db.ParkInfoes.SingleOrDefault(p => p.ParkingLotNum == "A-04");

                if (status.Status == false)
                {
                    btnEnable(false);
                    DBInsert("A-04");
                    RefreshDGV();
                }
                else
                {
                    MessageBox.Show("차량이 주차되어 있습니다.", "오 류");
                }

            }
        }

        private void btnA05_Click(object sender, EventArgs e)
        {
            using (var db = new ParkingDB())
            {
                var status = db.ParkInfoes.SingleOrDefault(p => p.ParkingLotNum == "A-05");

                if (status.Status == false)
                {
                    btnEnable(false);
                    DBInsert("A-05");
                    RefreshDGV();
                }
                else
                {
                    MessageBox.Show("차량이 주차되어 있습니다.", "오 류");
                }

            }
        }

        private void btnA06_Click(object sender, EventArgs e)
        {
            using (var db = new ParkingDB())
            {
                var status = db.ParkInfoes.SingleOrDefault(p => p.ParkingLotNum == "A-06");

                if (status.Status == false)
                {
                    btnEnable(false);
                    DBInsert("A-06");
                    RefreshDGV();
                }
                else
                {
                    MessageBox.Show("차량이 주차되어 있습니다.", "오 류");
                }

            }
        }

        private void btnA07_Click(object sender, EventArgs e)
        {
            using (var db = new ParkingDB())
            {
                var status = db.ParkInfoes.SingleOrDefault(p => p.ParkingLotNum == "A-07");

                if (status.Status == false)
                {
                    btnEnable(false);
                    DBInsert("A-07");
                    RefreshDGV();
                }
                else
                {
                    MessageBox.Show("차량이 주차되어 있습니다.", "오 류");
                }

            }
        }

        private void btnA08_Click(object sender, EventArgs e)
        {
            using (var db = new ParkingDB())
            {
                var status = db.ParkInfoes.SingleOrDefault(p => p.ParkingLotNum == "A-08");

                if (status.Status == false)
                {
                    btnEnable(false);
                    DBInsert("A-08");
                    RefreshDGV();
                }
                else
                {
                    MessageBox.Show("차량이 주차되어 있습니다.", "오 류");
                }

            }
        }

        private void btnA09_Click(object sender, EventArgs e)
        {
            using (var db = new ParkingDB())
            {
                var status = db.ParkInfoes.SingleOrDefault(p => p.ParkingLotNum == "A-09");

                if (status.Status == false)
                {
                    btnEnable(false);
                    DBInsert("A-09");
                    RefreshDGV();
                }
                else
                {
                    MessageBox.Show("차량이 주차되어 있습니다.", "오 류");
                }
            }
        }

        private void btnA10_Click(object sender, EventArgs e)
        {
            using (var db = new ParkingDB())
            {
                var status = db.ParkInfoes.SingleOrDefault(p => p.ParkingLotNum == "A-10");

                if (status.Status == false)
                {
                    btnEnable(false);
                    DBInsert("A-10");
                    RefreshDGV();
                }
                else
                {
                    MessageBox.Show("차량이 주차되어 있습니다.", "오 류");
                }
            }
        }
        
        private void frmParkingStatus_Load(object sender, EventArgs e)
        {
            RefreshLabel();
            RefreshDGV();
        }

        private void RefreshLabel()
        {
            string[] parkingLotNums = { "A-01", "A-02", "A-03", "A-04", "A-05", "A-06", "A-07", "A-08", "A-09", "A-10" };
            Label[] lblParkingLotNum = { lblA01, lblA02, lblA03, lblA04, lblA05, lblA06, lblA07, lblA08, lblA09, lblA10 };

            using (var db = new ParkingDB())
            {
                for (int i = 0; i < parkingLotNums.Length; i++)
                {
                    string parkingLotNum = parkingLotNums[i];
                    var stat = db.ParkInfoes.SingleOrDefault(p => p.ParkingLotNum == parkingLotNum);
                    if (stat.Status)
                        lblParkingLotNum[i].BackColor = Color.Red;
                    else
                        lblParkingLotNum[i].BackColor = Color.Lime;
                }

                var remainSeat = db.ParkInfoes.Where(p => p.Status == false).Count();
                lblRemainSeat.Text = remainSeat.ToString();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            using (var db = new ParkingDB())
            {
                var carNo = dgvInquiry.CurrentRow.Cells[0].Value;
                var carType = dgvInquiry.CurrentRow.Cells[1].Value;
                var carCheckOut = db.CheckOuts.Where(p => p.ExitTime == null && p.CarNo == carNo).FirstOrDefault();
                var rule = db.Rules.Where(p => p.CarType == carType).FirstOrDefault();
                var stat = db.ParkInfoes.FirstOrDefault(p => p.ParkingLotNum == carCheckOut.ParkingLotNum);

                carCheckOut.ExitTime = DateTime.Now;
                TimeSpan diff_time = Convert.ToDateTime(carCheckOut.ExitTime).Subtract(carCheckOut.EnterTime);
                carCheckOut.ParkingCharge = Convert.ToInt32(diff_time.TotalHours) * rule.ChargeOfHour;
                stat.Status = false;

                db.SaveChanges();
            }
            RefreshDGV();
            RefreshLabel();
        }
    }
}
