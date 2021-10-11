
namespace ParkingManagementSystem
{
    partial class frmParkingStatus
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmParkingStatus));
            this.lblA01 = new System.Windows.Forms.Label();
            this.lblA10 = new System.Windows.Forms.Label();
            this.lblA05 = new System.Windows.Forms.Label();
            this.lblA04 = new System.Windows.Forms.Label();
            this.lblA03 = new System.Windows.Forms.Label();
            this.lblA02 = new System.Windows.Forms.Label();
            this.lblA09 = new System.Windows.Forms.Label();
            this.lblA08 = new System.Windows.Forms.Label();
            this.lblA07 = new System.Windows.Forms.Label();
            this.lblA06 = new System.Windows.Forms.Label();
            this.txtEnter = new System.Windows.Forms.TextBox();
            this.btnEnter = new System.Windows.Forms.Button();
            this.btnA02 = new System.Windows.Forms.Button();
            this.btnA01 = new System.Windows.Forms.Button();
            this.btnA03 = new System.Windows.Forms.Button();
            this.btnA04 = new System.Windows.Forms.Button();
            this.btnA05 = new System.Windows.Forms.Button();
            this.btnA06 = new System.Windows.Forms.Button();
            this.btnA07 = new System.Windows.Forms.Button();
            this.btnA08 = new System.Windows.Forms.Button();
            this.btnA09 = new System.Windows.Forms.Button();
            this.btnA10 = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvInquiry = new System.Windows.Forms.DataGridView();
            this.CarNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CarType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EnterTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParkingLotNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CBCarType = new System.Windows.Forms.ComboBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRemainSeat = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInquiry)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblA01
            // 
            this.lblA01.BackColor = System.Drawing.Color.Lime;
            this.lblA01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblA01.Location = new System.Drawing.Point(16, 68);
            this.lblA01.Name = "lblA01";
            this.lblA01.Size = new System.Drawing.Size(64, 54);
            this.lblA01.TabIndex = 1;
            // 
            // lblA10
            // 
            this.lblA10.BackColor = System.Drawing.Color.Lime;
            this.lblA10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblA10.Location = new System.Drawing.Point(267, 284);
            this.lblA10.Name = "lblA10";
            this.lblA10.Size = new System.Drawing.Size(64, 54);
            this.lblA10.TabIndex = 2;
            // 
            // lblA05
            // 
            this.lblA05.BackColor = System.Drawing.Color.Lime;
            this.lblA05.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblA05.Location = new System.Drawing.Point(16, 284);
            this.lblA05.Name = "lblA05";
            this.lblA05.Size = new System.Drawing.Size(64, 54);
            this.lblA05.TabIndex = 3;
            // 
            // lblA04
            // 
            this.lblA04.BackColor = System.Drawing.Color.Lime;
            this.lblA04.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblA04.Location = new System.Drawing.Point(16, 230);
            this.lblA04.Name = "lblA04";
            this.lblA04.Size = new System.Drawing.Size(64, 54);
            this.lblA04.TabIndex = 4;
            // 
            // lblA03
            // 
            this.lblA03.BackColor = System.Drawing.Color.Lime;
            this.lblA03.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblA03.Location = new System.Drawing.Point(16, 176);
            this.lblA03.Name = "lblA03";
            this.lblA03.Size = new System.Drawing.Size(64, 54);
            this.lblA03.TabIndex = 5;
            // 
            // lblA02
            // 
            this.lblA02.BackColor = System.Drawing.Color.Lime;
            this.lblA02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblA02.Location = new System.Drawing.Point(16, 122);
            this.lblA02.Name = "lblA02";
            this.lblA02.Size = new System.Drawing.Size(64, 54);
            this.lblA02.TabIndex = 6;
            // 
            // lblA09
            // 
            this.lblA09.BackColor = System.Drawing.Color.Lime;
            this.lblA09.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblA09.Location = new System.Drawing.Point(267, 230);
            this.lblA09.Name = "lblA09";
            this.lblA09.Size = new System.Drawing.Size(64, 54);
            this.lblA09.TabIndex = 7;
            // 
            // lblA08
            // 
            this.lblA08.BackColor = System.Drawing.Color.Lime;
            this.lblA08.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblA08.Location = new System.Drawing.Point(267, 176);
            this.lblA08.Name = "lblA08";
            this.lblA08.Size = new System.Drawing.Size(64, 54);
            this.lblA08.TabIndex = 8;
            // 
            // lblA07
            // 
            this.lblA07.BackColor = System.Drawing.Color.Lime;
            this.lblA07.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblA07.Location = new System.Drawing.Point(267, 122);
            this.lblA07.Name = "lblA07";
            this.lblA07.Size = new System.Drawing.Size(64, 54);
            this.lblA07.TabIndex = 9;
            // 
            // lblA06
            // 
            this.lblA06.BackColor = System.Drawing.Color.Lime;
            this.lblA06.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblA06.Location = new System.Drawing.Point(267, 68);
            this.lblA06.Name = "lblA06";
            this.lblA06.Size = new System.Drawing.Size(64, 54);
            this.lblA06.TabIndex = 10;
            // 
            // txtEnter
            // 
            this.txtEnter.Location = new System.Drawing.Point(18, 16);
            this.txtEnter.Name = "txtEnter";
            this.txtEnter.Size = new System.Drawing.Size(127, 25);
            this.txtEnter.TabIndex = 11;
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(254, 16);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(77, 25);
            this.btnEnter.TabIndex = 12;
            this.btnEnter.Text = "입장";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnA02
            // 
            this.btnA02.Enabled = false;
            this.btnA02.Location = new System.Drawing.Point(86, 131);
            this.btnA02.Name = "btnA02";
            this.btnA02.Size = new System.Drawing.Size(59, 35);
            this.btnA02.TabIndex = 13;
            this.btnA02.Text = "A-02";
            this.btnA02.UseVisualStyleBackColor = true;
            this.btnA02.Click += new System.EventHandler(this.btnA02_Click);
            // 
            // btnA01
            // 
            this.btnA01.Enabled = false;
            this.btnA01.Location = new System.Drawing.Point(86, 77);
            this.btnA01.Name = "btnA01";
            this.btnA01.Size = new System.Drawing.Size(59, 35);
            this.btnA01.TabIndex = 14;
            this.btnA01.Text = "A-01";
            this.btnA01.UseVisualStyleBackColor = true;
            this.btnA01.Click += new System.EventHandler(this.btnA01_Click);
            // 
            // btnA03
            // 
            this.btnA03.Enabled = false;
            this.btnA03.Location = new System.Drawing.Point(86, 186);
            this.btnA03.Name = "btnA03";
            this.btnA03.Size = new System.Drawing.Size(59, 35);
            this.btnA03.TabIndex = 15;
            this.btnA03.Text = "A-03";
            this.btnA03.UseVisualStyleBackColor = true;
            this.btnA03.Click += new System.EventHandler(this.btnA03_Click);
            // 
            // btnA04
            // 
            this.btnA04.Enabled = false;
            this.btnA04.Location = new System.Drawing.Point(86, 240);
            this.btnA04.Name = "btnA04";
            this.btnA04.Size = new System.Drawing.Size(59, 35);
            this.btnA04.TabIndex = 16;
            this.btnA04.Text = "A-04";
            this.btnA04.UseVisualStyleBackColor = true;
            this.btnA04.Click += new System.EventHandler(this.btnA04_Click);
            // 
            // btnA05
            // 
            this.btnA05.Enabled = false;
            this.btnA05.Location = new System.Drawing.Point(86, 293);
            this.btnA05.Name = "btnA05";
            this.btnA05.Size = new System.Drawing.Size(59, 35);
            this.btnA05.TabIndex = 17;
            this.btnA05.Text = "A-05";
            this.btnA05.UseVisualStyleBackColor = true;
            this.btnA05.Click += new System.EventHandler(this.btnA05_Click);
            // 
            // btnA06
            // 
            this.btnA06.Enabled = false;
            this.btnA06.Location = new System.Drawing.Point(202, 77);
            this.btnA06.Name = "btnA06";
            this.btnA06.Size = new System.Drawing.Size(59, 35);
            this.btnA06.TabIndex = 18;
            this.btnA06.Text = "A-06";
            this.btnA06.UseVisualStyleBackColor = true;
            this.btnA06.Click += new System.EventHandler(this.btnA06_Click);
            // 
            // btnA07
            // 
            this.btnA07.Enabled = false;
            this.btnA07.Location = new System.Drawing.Point(202, 131);
            this.btnA07.Name = "btnA07";
            this.btnA07.Size = new System.Drawing.Size(59, 35);
            this.btnA07.TabIndex = 19;
            this.btnA07.Text = "A-07";
            this.btnA07.UseVisualStyleBackColor = true;
            this.btnA07.Click += new System.EventHandler(this.btnA07_Click);
            // 
            // btnA08
            // 
            this.btnA08.Enabled = false;
            this.btnA08.Location = new System.Drawing.Point(202, 184);
            this.btnA08.Name = "btnA08";
            this.btnA08.Size = new System.Drawing.Size(59, 35);
            this.btnA08.TabIndex = 20;
            this.btnA08.Text = "A-08";
            this.btnA08.UseVisualStyleBackColor = true;
            this.btnA08.Click += new System.EventHandler(this.btnA08_Click);
            // 
            // btnA09
            // 
            this.btnA09.Enabled = false;
            this.btnA09.Location = new System.Drawing.Point(203, 240);
            this.btnA09.Name = "btnA09";
            this.btnA09.Size = new System.Drawing.Size(59, 35);
            this.btnA09.TabIndex = 21;
            this.btnA09.Text = "A-09";
            this.btnA09.UseVisualStyleBackColor = true;
            this.btnA09.Click += new System.EventHandler(this.btnA09_Click);
            // 
            // btnA10
            // 
            this.btnA10.Enabled = false;
            this.btnA10.Location = new System.Drawing.Point(202, 293);
            this.btnA10.Name = "btnA10";
            this.btnA10.Size = new System.Drawing.Size(59, 35);
            this.btnA10.TabIndex = 22;
            this.btnA10.Text = "A-10";
            this.btnA10.UseVisualStyleBackColor = true;
            this.btnA10.Click += new System.EventHandler(this.btnA10_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(447, 404);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(69, 35);
            this.btnClose.TabIndex = 23;
            this.btnClose.Text = "닫기";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dgvInquiry
            // 
            this.dgvInquiry.AllowUserToDeleteRows = false;
            this.dgvInquiry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInquiry.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CarNo,
            this.CarType,
            this.EnterTime,
            this.ParkingLotNum});
            this.dgvInquiry.Location = new System.Drawing.Point(365, 16);
            this.dgvInquiry.Name = "dgvInquiry";
            this.dgvInquiry.ReadOnly = true;
            this.dgvInquiry.RowHeadersWidth = 51;
            this.dgvInquiry.RowTemplate.Height = 27;
            this.dgvInquiry.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInquiry.Size = new System.Drawing.Size(574, 322);
            this.dgvInquiry.TabIndex = 24;
            // 
            // CarNo
            // 
            this.CarNo.DataPropertyName = "CarNo";
            this.CarNo.HeaderText = "차량 번호";
            this.CarNo.MinimumWidth = 6;
            this.CarNo.Name = "CarNo";
            this.CarNo.ReadOnly = true;
            this.CarNo.Width = 125;
            // 
            // CarType
            // 
            this.CarType.DataPropertyName = "CarType";
            this.CarType.HeaderText = "차량 종류";
            this.CarType.MinimumWidth = 6;
            this.CarType.Name = "CarType";
            this.CarType.ReadOnly = true;
            this.CarType.Width = 125;
            // 
            // EnterTime
            // 
            this.EnterTime.DataPropertyName = "EnterTime";
            this.EnterTime.HeaderText = "입장 시간";
            this.EnterTime.MinimumWidth = 6;
            this.EnterTime.Name = "EnterTime";
            this.EnterTime.ReadOnly = true;
            this.EnterTime.Width = 125;
            // 
            // ParkingLotNum
            // 
            this.ParkingLotNum.DataPropertyName = "ParkingLotNum";
            this.ParkingLotNum.HeaderText = "주차 위치";
            this.ParkingLotNum.MinimumWidth = 6;
            this.ParkingLotNum.Name = "ParkingLotNum";
            this.ParkingLotNum.ReadOnly = true;
            this.ParkingLotNum.Width = 125;
            // 
            // CBCarType
            // 
            this.CBCarType.FormattingEnabled = true;
            this.CBCarType.Items.AddRange(new object[] {
            "소형",
            "중형",
            "대형"});
            this.CBCarType.Location = new System.Drawing.Point(151, 16);
            this.CBCarType.Name = "CBCarType";
            this.CBCarType.Size = new System.Drawing.Size(97, 23);
            this.CBCarType.TabIndex = 25;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(857, 344);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(82, 25);
            this.btnExit.TabIndex = 27;
            this.btnExit.Text = "퇴장";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblRemainSeat);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(37, 358);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(183, 80);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "전광판";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "남은 자리수";
            // 
            // lblRemainSeat
            // 
            this.lblRemainSeat.AutoSize = true;
            this.lblRemainSeat.Location = new System.Drawing.Point(123, 43);
            this.lblRemainSeat.Name = "lblRemainSeat";
            this.lblRemainSeat.Size = new System.Drawing.Size(0, 15);
            this.lblRemainSeat.TabIndex = 1;
            // 
            // frmParkingStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 460);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.CBCarType);
            this.Controls.Add(this.dgvInquiry);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnA10);
            this.Controls.Add(this.btnA09);
            this.Controls.Add(this.btnA08);
            this.Controls.Add(this.btnA07);
            this.Controls.Add(this.btnA06);
            this.Controls.Add(this.btnA05);
            this.Controls.Add(this.btnA04);
            this.Controls.Add(this.btnA03);
            this.Controls.Add(this.btnA01);
            this.Controls.Add(this.btnA02);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.txtEnter);
            this.Controls.Add(this.lblA06);
            this.Controls.Add(this.lblA07);
            this.Controls.Add(this.lblA08);
            this.Controls.Add(this.lblA09);
            this.Controls.Add(this.lblA02);
            this.Controls.Add(this.lblA03);
            this.Controls.Add(this.lblA04);
            this.Controls.Add(this.lblA05);
            this.Controls.Add(this.lblA10);
            this.Controls.Add(this.lblA01);
            this.Name = "frmParkingStatus";
            this.Text = "주차 상태";
            this.Load += new System.EventHandler(this.frmParkingStatus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInquiry)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblA01;
        private System.Windows.Forms.Label lblA10;
        private System.Windows.Forms.Label lblA05;
        private System.Windows.Forms.Label lblA04;
        private System.Windows.Forms.Label lblA03;
        private System.Windows.Forms.Label lblA02;
        private System.Windows.Forms.Label lblA09;
        private System.Windows.Forms.Label lblA08;
        private System.Windows.Forms.Label lblA07;
        private System.Windows.Forms.Label lblA06;
        private System.Windows.Forms.TextBox txtEnter;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Button btnA02;
        private System.Windows.Forms.Button btnA01;
        private System.Windows.Forms.Button btnA03;
        private System.Windows.Forms.Button btnA04;
        private System.Windows.Forms.Button btnA05;
        private System.Windows.Forms.Button btnA06;
        private System.Windows.Forms.Button btnA07;
        private System.Windows.Forms.Button btnA08;
        private System.Windows.Forms.Button btnA09;
        private System.Windows.Forms.Button btnA10;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvInquiry;
        private System.Windows.Forms.ComboBox CBCarType;
        private System.Windows.Forms.DataGridViewTextBoxColumn CarNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CarType;
        private System.Windows.Forms.DataGridViewTextBoxColumn EnterTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParkingLotNum;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblRemainSeat;
        private System.Windows.Forms.Label label1;
    }
}

