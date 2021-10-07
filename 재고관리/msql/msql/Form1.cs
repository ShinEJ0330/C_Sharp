using MySql.Data.MySqlClient;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace msql
{
    public partial class Form1 : Form
    {

        string strServerName;
        string strDatabase;
        string strUserID;
        string strUserPW;

        MySqlConnection connection;
        Boolean dbConnectionResult = false;

        public Form1()
        {
            InitializeComponent();
            DBConnection("127.0.0.1", "factorydb", "root", "sej123123!");
            dbConnectionResult = DBOpen();
            if (dbConnectionResult)
            {
                MessageBox.Show("DB 오픈 성공");
            }
            else
            {
                MessageBox.Show("DB 오픈 실패");
            }
            DBClose();
        }
        public void DBConnection(string strServerName, string strDatabase, string strUserID, string strUserPW)
        {
            this.strServerName = strServerName;
            this.strDatabase = strDatabase;
            this.strUserID = strUserID;
            this.strUserPW = strUserPW;
            string connectionString;
            connectionString = "SERVER=" + strServerName + " ; " + "DATABASE=" + strDatabase + " ; " +
                                     "UID=" + strUserID + " ; " + "PASSWORD=" + strUserPW + " ; ";
            connection = new MySqlConnection(connectionString);
        }
        public Boolean DBOpen()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        break;
                    case 1045:
                        break;
                }
                return false;
            }
        }
        public Boolean DBClose()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                return false;
            }
        }

        //DB값 콤보박스에 입력
        private void Form1_Load(object sender, EventArgs e)
        {
            string str = "SELECT * from maketypetb";
            connection.Open();
            MySqlDataAdapter da = new MySqlDataAdapter(str, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbType.DataSource = dt;
            cbType.DisplayMember = "TypeName";
            cbTypeFind.DataSource = dt;
            cbTypeFind.DisplayMember = "TypeName";

            DBClose();

            string str1 = "SELECT * from linetb";
            connection.Open();
            MySqlDataAdapter da1 = new MySqlDataAdapter(str1, connection);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            cbLineNo.DataSource = dt1;
            cbLineNo.DisplayMember = "LineNo";
            cbinquiryLine.DataSource = dt1;
            cbinquiryLine.DisplayMember = "LineNo";
            cbNSLine.DataSource = dt1;
            cbNSLine.DisplayMember = "LineNo";
            cbMonitoringLineNo.DataSource = dt1;
            cbMonitoringLineNo.DisplayMember = "LineNo";

            DBClose();

            string str2 = "SELECT * from clienttb";
            connection.Open();
            MySqlDataAdapter da2 = new MySqlDataAdapter(str2, connection);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            cbinquiryClient.DataSource = dt2;
            cbinquiryClient.DisplayMember = "ClientName";
            cbInputClient.DataSource = dt2;
            cbInputClient.DisplayMember = "ClientName";

            DBClose();
        }

        // 재고관리
        public Boolean Sql(string strSql)
        {
            DBOpen();
            try
            {
                MySqlCommand cmd = new MySqlCommand(strSql, connection);
                cmd.ExecuteNonQuery();
                DBClose();
                return true;
            }
            catch (Exception ex)
            {
                DBClose();
                return false;
            }
        }

        private void SqlSelect(string strSqlQuery)
        {
            if (DBOpen() == true)
            {
                MySqlCommand cmd = new MySqlCommand(strSqlQuery, connection);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvList.DataSource = dt;

                DBClose();
            }
            return;
        }

        private void btnProductInsert_Click(object sender, EventArgs e)
        {
            string strSql;
            strSql = $"INSERT INTO 재고테이블 values ('{txtBoxProductNo.Text}'" + $",'{txtBoxProductName.Text}'"
                       + $",'{cbType.Text}'" + $",'{txtBoxStandard.Text}'" + $",'{txtBoxEa.Text}'" + $",'{txtBoxCompany.Text}'" + $",'{txtBoxEtc.Text}')";
            Sql(strSql);
            strSql = "select * from 재고테이블";
            SqlSelect(strSql);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string strSql;
            strSql = $"select * from 재고테이블 where ProductName like '%{txtBoxProductNameFind.Text}%'"
                        + $" AND Type like '%{cbTypeFind.Text}%'";
            SqlSelect(strSql);
        }

        // 입고관리
        private void btnInputProductNoSelect_Click(object sender, EventArgs e)
        {
            string strSql;
            strSql = $"select * from 재고테이블 where ProductNo like '%{txtBoxInputSearch.Text}%'";
            SqlInputSelect(strSql, 0);
        }

        private void btnInputProductNameSelect_Click(object sender, EventArgs e)
        {
            string strSql;
            strSql = $"select * from 재고테이블 where ProductName like '%{txtBoxInputSearch.Text}%'";
            SqlInputSelect(strSql, 0);
        }

        private void SqlInputSelect(string strSqlQuery, int iLocate)
        {
            if (DBOpen() == true)
            {
                MySqlCommand cmd = new MySqlCommand(strSqlQuery, connection);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                switch (iLocate)
                {
                    case 0:
                        dgvInventory.DataSource = dt;
                        break;
                    case 1:
                        dgvInput.DataSource = dt;
                        break;
                }
                dgvList.DataSource = dt;
                DBClose();
            }
            return;
        }

        private void dgvInventory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtBoxInputProductNo.Text = dgvInventory.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            if (txtBoxInputCost.Text != "" && cbInputClient.Text != "" && txtBoxInputEa.Text != "")
            {
                if (DBOpen() == true)
                {
                    string strProductName = "";
                    string strSqlQuery = $"SELECT ProductName, Ea FROM 재고테이블 " +
                                              $"WHERE ProductNo = '{txtBoxInputProductNo.Text}'";
                    MySqlCommand cmd = new MySqlCommand(strSqlQuery, connection);
                    MySqlDataReader rdl = cmd.ExecuteReader();

                    int computeEaSum = 0;
                    int saveEaValue = 0;
                    int plusEaValue = int.Parse(txtBoxInputEa.Text);

                    while (rdl.Read())
                    {
                        strProductName = rdl.GetString(0);
                        saveEaValue = rdl.GetInt32(1);

                        computeEaSum = saveEaValue + plusEaValue;
                    }
                    rdl.Close();

                    strSqlQuery = $"UPDATE 재고테이블 SET EA = {computeEaSum}" +
                                      $" WHERE ProductNo = '{txtBoxInputProductNo.Text}'";

                    MySqlCommand cmd2 = new MySqlCommand(strSqlQuery, connection);
                    int check = cmd2.ExecuteNonQuery();
                    if (check > 0)
                    {
                        MessageBox.Show("수량이 변경되었습니다.");
                    }
                    else
                    {
                        MessageBox.Show("데이터 입력에 실패하셨습니다.");
                    }
                    DBClose();

                    string strSql;
                    strSql = $"select * from 재고테이블 where ProductNo" +
                               $" like '%{txtBoxInputSearch.Text}%'";
                    SqlInputSelect(strSql, 0);

                    strSqlQuery = $"INSERT INTO 입고테이블(ProductNo, ProductName, Ea, Cost, Client, InputDate) "
                                      + $" values ('{txtBoxInputProductNo.Text}'" + $",'{strProductName}'" + $",{plusEaValue}"
                                      + $",{txtBoxInputCost.Text}" + $",'{cbInputClient.Text}'," + $"'{DateTime.Now.ToString("yyyy-MM-dd")}')";

                    Sql(strSqlQuery);
                    strSqlQuery = "select * from 입고테이블";
                    SqlInputSelect(strSqlQuery, 1);
                }
            }
            else
            {
                MessageBox.Show("값을 입력하세요.");
            }
        }

        //출고관리
        private void SqlOutputSelect(string strSqlQuery, int iLocate)
        {
            if (DBOpen() == true)
            {
                MySqlCommand cmd = new MySqlCommand(strSqlQuery, connection);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                switch (iLocate)
                {
                    case 0:
                        dgvOutputInventory.DataSource = dt;
                        break;
                    case 1:
                        dgvOutput.DataSource = dt;
                        break;
                }
                dgvList.DataSource = dt;
                DBClose();
            }
            return;
        }

        private void btnOutputProductNoSelect_Click_1(object sender, EventArgs e)
        {
            string strSql;
            strSql = $"select * from 재고테이블 where ProductNo like '%{txtBoxOutputSearch.Text}%'";
            SqlOutputSelect(strSql, 0);
        }

        private void btnOutputProductNameSelect_Click(object sender, EventArgs e)
        {
            string strSql;
            strSql = $"select * from 재고테이블 where ProductName like '%{txtBoxOutputSearch.Text}%'";
            SqlOutputSelect(strSql, 0);
        }

        private void btnOutput_Click(object sender, EventArgs e)
        {
            if (cbLineNo.Text != "" && txtBoxOutputEa.Text != "")
            {
                if (DBOpen() == true)
                {
                    string strProductName = "";
                    string strSqlQuery = $"SELECT ProductName, Ea FROM 재고테이블 " +
                                          $" WHERE ProductNo = '{txtBoxOutputProductNo.Text}'";
                    MySqlCommand cmd = new MySqlCommand(strSqlQuery, connection);
                    MySqlDataReader rdl = cmd.ExecuteReader();

                    int computeEaSum = 0;
                    int saveEaValue = 0;
                    int minusEaValue = int.Parse(txtBoxOutputEa.Text);

                    while (rdl.Read())
                    {
                        strProductName = rdl.GetString(0);
                        saveEaValue = rdl.GetInt32(1);

                        computeEaSum = saveEaValue - minusEaValue;
                    }
                    rdl.Close();

                    if (minusEaValue > saveEaValue)
                    {
                        MessageBox.Show("출고할 수량이 잘못되었습니다.");
                    }
                    else
                    {
                        strSqlQuery = $"UPDATE 재고테이블 SET EA = {computeEaSum}" +
                                            $" WHERE ProductNo = '{txtBoxOutputProductNo.Text}'";

                        MySqlCommand cmd2 = new MySqlCommand(strSqlQuery, connection);
                        int check = cmd2.ExecuteNonQuery();

                        if (check > 0)
                        {
                            MessageBox.Show("수량이 변경되었습니다.");
                        }
                        else
                        {
                            MessageBox.Show("데이터 입력에 실패하셨습니다.");
                        }
                        DBClose();

                        string strSql;
                        strSql = $"select * from 재고테이블 where ProductNo" +
                                    $" like '%{txtBoxOutputSearch.Text}%'";
                        SqlOutputSelect(strSql, 0);

                        strSqlQuery = $"INSERT INTO 출고테이블(ProductNo, ProductName, LineNo, Ea, OutputDate) " + $" values ('{txtBoxOutputProductNo.Text}'" +
                                           $",'{strProductName}'" + $",'{cbLineNo.Text}'" + $",{minusEaValue}," + $"'{DateTime.Now.ToString("yyyy-MM-dd")}')";
                        Sql(strSqlQuery);
                        strSqlQuery = "select * from 출고테이블";
                        SqlOutputSelect(strSqlQuery, 1);
                    }
                }
            }
            else
            {
                MessageBox.Show("값을 입력하세요.");
            }
        }

        private void dgvOutputInventory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtBoxOutputProductNo.Text = dgvOutputInventory.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        //조회
        private void SqlinquirySelect(string strSqlQuery)
        {
            if (DBOpen() == true)
            {
                MySqlCommand cmd = new MySqlCommand(strSqlQuery, connection);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvinquiry.DataSource = dt;
                dgvList.DataSource = dt;
                DBClose();
            }
            return;
        }

        private void btninquiry_Click(object sender, EventArgs e)
        {
            if ((string)cbTable.SelectedItem == "입고 테이블")
            {
                if ((string)cbinquiryClient.Text == "전체")
                {
                    string inputTime = $"SELECT* FROM 입고테이블 WHERE " +
                                         $"InputDate between '{dtpinquiryStart.Value}' and '{dtpinquiryEnd.Value}'";
                    SqlinquirySelect(inputTime);
                }
                else
                {
                    string inputTime = $"SELECT* FROM 입고테이블 WHERE " +
                                         $"InputDate between '{dtpinquiryStart.Value}' and '{dtpinquiryEnd.Value}' AND " +
                                         $"Client like '%{cbinquiryClient.Text}%'";
                    SqlinquirySelect(inputTime);
                }
            }
            else if ((string)cbTable.SelectedItem == "출고 테이블")
            {
                if ((string)cbinquiryLine.Text == "전체")
                {
                    string outputTime = $"SELECT* FROM 출고테이블 WHERE " +
                                               $"OutputDate between '{dtpinquiryStart.Value}' and '{dtpinquiryEnd.Value}'";
                    SqlinquirySelect(outputTime);
                }
                else
                {
                    string outputTime = $"SELECT* FROM 출고테이블 WHERE " +
                                               $"OutputDate between '{dtpinquiryStart.Value}' and '{dtpinquiryEnd.Value}' AND " +
                                               $"LineNo like '%{cbinquiryLine.Text}%'";
                    SqlinquirySelect(outputTime);
                }
            }
            else
            {
                MessageBox.Show("테이블을 선택하세요.");
            }
            DBClose();
        }

        private void cbTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((string)cbTable.SelectedItem == "입고 테이블")
            {
                cbinquiryClient.Enabled = true;
                cbinquiryLine.Enabled = false;
            }
            else if ((string)cbTable.SelectedItem == "출고 테이블")
            {
                cbinquiryLine.Enabled = true;
                cbinquiryClient.Enabled = false;
            }
        }

        //통계화면
        private void btnNSInquiry_Click(object sender, EventArgs e)
        {
            if (rbOperateTime.Checked)
            {
                if ((string)cbinquiryLine.Text == "전체")
                {
                    if ((string)cbNSSortation.Text == "일자별")
                    {
                        //일자별만
                        string strQuery = "SELECT LineNo, date_format(startTime,' %Y - %m - %d') as 날짜, " +
                           "sum(timestampdiff(Minute, StartTime, EndTime)) as 가동시간 " + "from devicestatustb " +
                           $"where startTime between '{dtpNSStart.Value}' and '{dtpNSEnd.Value}' " + 
                           " AND EndTime is not null " + "group by LineNo, 날짜 " + "order by 날짜";
                        connection.Open();
                        MySqlCommand cmd = new MySqlCommand(strQuery, connection);
                        MySqlDataReader dr = cmd.ExecuteReader();
                        chart.Series.Clear();
                        Series series1 = new Series();
                        Series series2 = new Series();
                        Series series3 = new Series();
                        chart.Series.Add(series1);
                        chart.Series.Add(series2);
                        chart.Series.Add(series3);
                        series1.Name = "라인1";
                        series2.Name = "라인2";
                        series3.Name = "라인3";
                        string strLineNo;
                        string strDate;
                        int iSumprocess;
                        while (dr.Read())
                        {
                            strLineNo = dr.GetString("LineNo");
                            strDate = dr.GetString("날짜");
                            iSumprocess = dr.GetInt32("가동시간");
                            switch (strLineNo)
                            {
                                case "라인1":
                                    chart.Series[0].Points.AddXY(strDate, iSumprocess);
                                    break;
                                case "라인2":
                                    chart.Series[1].Points.AddXY(strDate, iSumprocess);
                                    break;
                                case "라인3":
                                    chart.Series[2].Points.AddXY(strDate, iSumprocess);
                                    break;
                            }
                        }
                        dr.Close();
                        DBClose();
                    }
                    else if ((string)cbNSSortation.Text == "장비별")
                    {
                        string strQuery = "SELECT concat(LineNo, '\n', DeviceName) as 라인별장비, " +
                            "sum(timestampdiff(Minute, StartTime, EndTime)) as 가동시간 " + "from devicestatustb " +
                           $"where startTime between '{dtpNSStart.Value}' and '{dtpNSEnd.Value}' " + "group by 라인별장비";
                        connection.Open();
                        MySqlDataAdapter da = new MySqlDataAdapter(strQuery, connection);

                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        chart.Series.Clear();
                        chart.Titles.Clear();
                        Series series = new Series();
                        chart.Series.Add(series);
                        chart.DataSource = dt;
                        series.IsVisibleInLegend = false;
                        chart.Series[0].XValueMember = "라인별장비";
                        chart.Series[0].YValueMembers = "가동시간";
                        chart.Titles.Add("라인별 장비 가동시간");
                        connection.Close();
                    }
                }
                else
                {
                    // 라인별
                    if ((string)cbNSSortation.Text == "일자별")
                    {
                        //일자별
                        string strQuery = "SELECT LineNo, DeviceName, date_format(startTime,' %Y - %m - %d') as 날짜, " +
                            "sum(timestampdiff(Minute, StartTime, EndTime)) as 가동시간 " + "from devicestatustb " +
                            $"where LineNo like '%{cbNSLine.Text}%' " + " AND EndTime is not null " + 
                            $"AND startTime between '{dtpNSStart.Value}' and '{dtpNSEnd.Value}' " +
                            "group by LineNo, DeviceName, 날짜 " + "order by 날짜";
                        connection.Open();
                        MySqlCommand cmd = new MySqlCommand(strQuery, connection);
                        MySqlDataReader dr = cmd.ExecuteReader();
                        chart.Series.Clear();
                        Series series1 = new Series();
                        Series series2 = new Series();
                        Series series3 = new Series();
                        chart.Series.Add(series1);
                        chart.Series.Add(series2);
                        chart.Series.Add(series3);
                        series1.Name = "장비1";
                        series2.Name = "장비2";
                        series3.Name = "장비3";
                        string strDeviceName;
                        string strDate;
                        int iSumprocess;
                        while (dr.Read())
                        {
                            strDeviceName = dr.GetString("DeviceName");
                            strDate = dr.GetString("날짜");
                            iSumprocess = dr.GetInt32("가동시간");
                            switch (strDeviceName)
                            {
                                case "장비1":
                                    chart.Series[0].Points.AddXY(strDate, iSumprocess);
                                    break;
                                case "장비2":
                                    chart.Series[1].Points.AddXY(strDate, iSumprocess);
                                    break;
                                case "장비3":
                                    chart.Series[2].Points.AddXY(strDate, iSumprocess);
                                    break;
                            }
                        }
                        dr.Close();
                        DBClose();
                    }
                    else if ((string)cbNSSortation.Text == "장비별")
                    {
                        //장비별
                        string strQuery = "SELECT LineNo, DeviceName, sum(timestampdiff(Minute, StartTime, EndTime)) as 가동시간 " +
                            "from devicestatustb " + $"where LineNo like '%{cbNSLine.Text}%' " +
                           $"AND startTime between '{dtpNSStart.Value}' and '{dtpNSEnd.Value}' " + "group by LineNo, DeviceName";
                        connection.Open();
                        MySqlDataAdapter da = new MySqlDataAdapter(strQuery, connection);

                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        chart.Series.Clear();
                        chart.Titles.Clear();
                        Series series = new Series();
                        chart.Series.Add(series);
                        series.Name = "장비별 가동시간";
                        chart.DataSource = dt;
                        chart.Series[0].XValueMember = "DeviceName";
                        chart.Series[0].YValueMembers = "가동시간";
                        connection.Close();
                    }
                }
            }
            else if (rbError.Checked)
            {
                if ((string)cbinquiryLine.Text == "전체")
                {
                    //전체 오류
                    if ((string)cbNSSortation.Text == "일자별")
                    {
                        //일자별
                        string strQuery = "SELECT count(EventTime) as 오류, date_format(EventTime,' %Y - %m - %d') as 날짜, SensorName,  LineNo," +
                            " concat(LineNo, '\n', SensorName) as 센서별오류 from sensorerrortb " +
                           $"where EventTime between '{dtpNSStart.Value}' and '{dtpNSEnd.Value}' " + "group by LineNo, 날짜" + " order by 날짜";
                        connection.Open();
                        MySqlCommand cmd = new MySqlCommand(strQuery, connection);
                        MySqlDataReader dr = cmd.ExecuteReader();
                        chart.Series.Clear();
                        Series series1 = new Series();
                        Series series2 = new Series();
                        Series series3 = new Series();
                        chart.Series.Add(series1);
                        chart.Series.Add(series2);
                        chart.Series.Add(series3);
                        series1.Name = "라인1";
                        series2.Name = "라인2";
                        series3.Name = "라인3";
                        string strDeviceName;
                        string strDate;
                        int iSumprocess;
                        while (dr.Read())
                        {
                            strDeviceName = dr.GetString("LineNo");
                            strDate = dr.GetString("날짜");
                            iSumprocess = dr.GetInt32("오류");
                            switch (strDeviceName)
                            {
                                case "라인1":
                                    chart.Series[0].Points.AddXY(strDate, iSumprocess);
                                    break;
                                case "라인2":
                                    chart.Series[1].Points.AddXY(strDate, iSumprocess);
                                    break;
                                case "라인3":
                                    chart.Series[2].Points.AddXY(strDate, iSumprocess);
                                    break;
                            }
                        }
                        dr.Close();
                        DBClose();
                    }
                    else if ((string)cbNSSortation.Text == "장비/센서별")
                    {
                        //장비/센서별
                        string strQuery = "SELECT count(EventTime) as 오류, SensorName,  LineNo," + " concat(LineNo, '\n', SensorName) as 센서별오류" +
                            " from sensorerrortb " + $"where EventTime between '{dtpNSStart.Value}' and '{dtpNSEnd.Value}' " + "group by LineNo, SensorName";
                        connection.Open();
                        MySqlDataAdapter da = new MySqlDataAdapter(strQuery, connection);

                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        chart.Series.Clear();
                        chart.Titles.Clear();
                        Series series = new Series();
                        chart.Series.Add(series);
                        chart.DataSource = dt;
                        series.IsVisibleInLegend = false;
                        chart.Series[0].XValueMember = "센서별오류";
                        chart.Series[0].YValueMembers = "오류";
                        chart.Titles.Add("장비/센서별 오류");
                        connection.Close();
                    }
                }
                else
                {
                    //라인별 오류
                    if ((string)cbNSSortation.Text == "일자별")
                    {
                        //일자별
                        string strQuery = "SELECT count(EventTime) as 오류, date_format(EventTime,' %Y - %m - %d') as 날짜, SensorName,  LineNo " +
                            "from sensorerrortb" + $" where LineNo like '%{cbNSLine.Text}%' " + $"AND EventTime between '{dtpNSStart.Value}' and '{dtpNSEnd.Value}' " +
                            "group by LineNo, 날짜" + " order by 날짜";
                        connection.Open();
                        MySqlDataAdapter da = new MySqlDataAdapter(strQuery, connection);

                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        chart.Series.Clear();
                        chart.Titles.Clear();
                        Series series = new Series();
                        chart.Series.Add(series);
                        chart.DataSource = dt;
                        series.IsVisibleInLegend = false;
                        chart.Series[0].XValueMember = "날짜";
                        chart.Series[0].YValueMembers = "오류";
                        chart.Titles.Add("일자별 오류");
                        connection.Close();
                    }
                    else if ((string)cbNSSortation.Text == "장비/센서별")
                    {
                        //장비/센서별
                        string strQuery = "SELECT LineNo, SensorName, count(EventTime) as 오류 " + "from sensorerrortb " +
                            $"where LineNo like '%{cbNSLine.Text}%' " + $"AND EventTime between '{dtpNSStart.Value}' and '{dtpNSEnd.Value}' " +
                            "group by LineNo, SensorName";
                        connection.Open();
                        MySqlDataAdapter da = new MySqlDataAdapter(strQuery, connection);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        chart.Series.Clear();
                        chart.Titles.Clear();
                        chart.DataSource = dt;
                        Series series = new Series();
                        chart.Series.Add(series);
                        series.IsVisibleInLegend = false;
                        chart.Series[0].XValueMember = "SensorName";
                        chart.Series[0].YValueMembers = "오류";
                        chart.Titles.Add("장비/센서별 오류");
                        connection.Close();
                    }
                }
            }
        }

        private void rbError_CheckedChanged(object sender, EventArgs e)
        {
            cbNSSortation.Items.Clear();
            cbNSSortation.Items.Add("일자별");
            cbNSSortation.Items.Add("장비/센서별");
        }

        private void rbOperateTime_CheckedChanged(object sender, EventArgs e)
        {
            cbNSSortation.Items.Clear();
            cbNSSortation.Items.Add("일자별");
            cbNSSortation.Items.Add("장비별");
        }

        //웹캠 동작
        VideoCapture captureCam;
        private void btnCamOn_Click(object sender, EventArgs e)
        {
            captureCam = new VideoCapture();
            captureCam.Open(0, VideoCaptureAPIs.ANY);

            if (!captureCam.IsOpened())
            {
                MessageBox.Show("오픈 실패!");
            }
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var bgWorker = (BackgroundWorker)sender;
            while (!bgWorker.CancellationPending)
            {
                var frmaeMat = captureCam.RetrieveMat();
                var frameBitmap = BitmapConverter.ToBitmap(frmaeMat);
                pbVideo.Image?.Dispose();
                pbVideo.Image = frameBitmap;
                Thread.Sleep(100);
            }
        }

        private void btnCamOff_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
            captureCam.Dispose();
            pbVideo.Image = Properties.Resources.배경0;
        }       
    }
}