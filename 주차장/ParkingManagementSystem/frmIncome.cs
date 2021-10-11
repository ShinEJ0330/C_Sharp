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
    public partial class frmIncome : Form
    {
        public frmIncome()
        {
            InitializeComponent();
        }

        private void frmIncome_Load(object sender, EventArgs e)
        {
            RefreshIncomeView();
        }

        private void RefreshIncomeView()
        {
            using (var db = new ParkingDB())
            {
                lblTotalParkNum.Text = db.CheckOuts.Where(p => DbFunctions.DiffDays(p.EnterTime, DateTime.Today.Date) == 0).Count().ToString();
                lblCalculateNum.Text = db.CheckOuts.Where(p => p.ParkingCharge != null && DbFunctions.DiffDays(p.ExitTime, DateTime.Today) == 0).Count().ToString();
                lblTotalSales.Text = db.CheckOuts.Where(p => p.ParkingCharge != null && DbFunctions.DiffDays(p.ExitTime, DateTime.Today) == 0).Sum(p => p.ParkingCharge).ToString();
                lblNumOfAvailable.Text = (db.ParkInfoes.Count() - db.ParkInfoes.Where(p => p.Status == true).Count()).ToString();

                txtSmall.Text = db.Rules.Where(p => p.CarType == "소형").Select(p => p.ChargeOfHour).First().ToString();
                txtMedium.Text = db.Rules.Where(p => p.CarType == "중형").Select(p => p.ChargeOfHour).First().ToString();
                txtLarge.Text = db.Rules.Where(p => p.CarType == "대형").Select(p => p.ChargeOfHour).First().ToString();
            }
        }

        private void btnParking_Click(object sender, EventArgs e)
        {
            var form = new frmParkingStatus();
            form.Show();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            using (var db = new ParkingDB())
            {
                var small = db.Rules.SingleOrDefault(p => p.CarType == "소형");
                var medium = db.Rules.SingleOrDefault(p => p.CarType == "중형");
                var large = db.Rules.SingleOrDefault(p => p.CarType == "대형");

                small.ChargeOfHour = Convert.ToInt32(txtSmall.Text);
                medium.ChargeOfHour = Convert.ToInt32(txtMedium.Text);
                large.ChargeOfHour = Convert.ToInt32(txtLarge.Text);

                db.SaveChanges();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshIncomeView();
        }
    }
}
