namespace GUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.txtGiayTo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grbThongTinXetNghiem = new System.Windows.Forms.GroupBox();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.cbbCongTy = new System.Windows.Forms.ComboBox();
            this.txtSLXN = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.rdbDuongTinh = new System.Windows.Forms.RadioButton();
            this.rdbAmTinh = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvNhanVien = new System.Windows.Forms.DataGridView();
            this.colGiayTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSLXN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.chucwToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhSáchNVDươngTínhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhSáchCtyĐãTestTheoYCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.xuấtBáoCáoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.grbThongTinXetNghiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTim);
            this.groupBox1.Controls.Add(this.txtGiayTo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(34, 94);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(376, 93);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin nhân viên";
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(291, 38);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(58, 22);
            this.btnTim.TabIndex = 2;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // txtGiayTo
            // 
            this.txtGiayTo.Location = new System.Drawing.Point(114, 38);
            this.txtGiayTo.Name = "txtGiayTo";
            this.txtGiayTo.Size = new System.Drawing.Size(162, 22);
            this.txtGiayTo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "CCCD/ CMND";
            // 
            // grbThongTinXetNghiem
            // 
            this.grbThongTinXetNghiem.Controls.Add(this.btnCapNhat);
            this.grbThongTinXetNghiem.Controls.Add(this.cbbCongTy);
            this.grbThongTinXetNghiem.Controls.Add(this.txtSLXN);
            this.grbThongTinXetNghiem.Controls.Add(this.txtHoTen);
            this.grbThongTinXetNghiem.Controls.Add(this.rdbDuongTinh);
            this.grbThongTinXetNghiem.Controls.Add(this.rdbAmTinh);
            this.grbThongTinXetNghiem.Controls.Add(this.label5);
            this.grbThongTinXetNghiem.Controls.Add(this.label4);
            this.grbThongTinXetNghiem.Controls.Add(this.label3);
            this.grbThongTinXetNghiem.Controls.Add(this.label2);
            this.grbThongTinXetNghiem.Location = new System.Drawing.Point(34, 208);
            this.grbThongTinXetNghiem.Name = "grbThongTinXetNghiem";
            this.grbThongTinXetNghiem.Size = new System.Drawing.Size(376, 373);
            this.grbThongTinXetNghiem.TabIndex = 0;
            this.grbThongTinXetNghiem.TabStop = false;
            this.grbThongTinXetNghiem.Text = "Thông tin xét nghiệm";
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Location = new System.Drawing.Point(109, 322);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(103, 24);
            this.btnCapNhat.TabIndex = 2;
            this.btnCapNhat.Text = "Cập Nhật";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // cbbCongTy
            // 
            this.cbbCongTy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbCongTy.FormattingEnabled = true;
            this.cbbCongTy.Location = new System.Drawing.Point(136, 264);
            this.cbbCongTy.Name = "cbbCongTy";
            this.cbbCongTy.Size = new System.Drawing.Size(198, 24);
            this.cbbCongTy.TabIndex = 1;
            // 
            // txtSLXN
            // 
            this.txtSLXN.Location = new System.Drawing.Point(135, 104);
            this.txtSLXN.Name = "txtSLXN";
            this.txtSLXN.Size = new System.Drawing.Size(199, 22);
            this.txtSLXN.TabIndex = 1;
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(135, 44);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(199, 22);
            this.txtHoTen.TabIndex = 1;
            // 
            // rdbDuongTinh
            // 
            this.rdbDuongTinh.AutoSize = true;
            this.rdbDuongTinh.Location = new System.Drawing.Point(154, 209);
            this.rdbDuongTinh.Name = "rdbDuongTinh";
            this.rdbDuongTinh.Size = new System.Drawing.Size(97, 20);
            this.rdbDuongTinh.TabIndex = 0;
            this.rdbDuongTinh.TabStop = true;
            this.rdbDuongTinh.Text = "Dương Tính";
            this.rdbDuongTinh.UseVisualStyleBackColor = true;
            // 
            // rdbAmTinh
            // 
            this.rdbAmTinh.AutoSize = true;
            this.rdbAmTinh.Location = new System.Drawing.Point(154, 171);
            this.rdbAmTinh.Name = "rdbAmTinh";
            this.rdbAmTinh.Size = new System.Drawing.Size(77, 20);
            this.rdbAmTinh.TabIndex = 0;
            this.rdbAmTinh.TabStop = true;
            this.rdbAmTinh.Text = "Âm Tính";
            this.rdbAmTinh.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 267);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Công Ty";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "kết Quả";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "SLXN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Họ Tên";
            // 
            // dgvNhanVien
            // 
            this.dgvNhanVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNhanVien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colGiayTO,
            this.colHoTen,
            this.colSLXN,
            this.colKQ});
            this.dgvNhanVien.Location = new System.Drawing.Point(443, 94);
            this.dgvNhanVien.Name = "dgvNhanVien";
            this.dgvNhanVien.RowHeadersWidth = 51;
            this.dgvNhanVien.Size = new System.Drawing.Size(703, 487);
            this.dgvNhanVien.TabIndex = 1;
            // 
            // colGiayTO
            // 
            this.colGiayTO.HeaderText = "CCCD/ CMND";
            this.colGiayTO.MinimumWidth = 6;
            this.colGiayTO.Name = "colGiayTO";
            // 
            // colHoTen
            // 
            this.colHoTen.HeaderText = "Họ Và Tên";
            this.colHoTen.MinimumWidth = 6;
            this.colHoTen.Name = "colHoTen";
            // 
            // colSLXN
            // 
            this.colSLXN.HeaderText = "Số lần XN";
            this.colSLXN.MinimumWidth = 6;
            this.colSLXN.Name = "colSLXN";
            // 
            // colKQ
            // 
            this.colKQ.HeaderText = "Kết quả";
            this.colKQ.MinimumWidth = 6;
            this.colKQ.Name = "colKQ";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chucwToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1158, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // chucwToolStripMenuItem
            // 
            this.chucwToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.danhSáchNVDươngTínhToolStripMenuItem,
            this.danhSáchCtyĐãTestTheoYCToolStripMenuItem,
            this.toolStripSeparator1,
            this.xuấtBáoCáoToolStripMenuItem});
            this.chucwToolStripMenuItem.Name = "chucwToolStripMenuItem";
            this.chucwToolStripMenuItem.Size = new System.Drawing.Size(96, 24);
            this.chucwToolStripMenuItem.Text = "Chức Năng";
            // 
            // danhSáchNVDươngTínhToolStripMenuItem
            // 
            this.danhSáchNVDươngTínhToolStripMenuItem.Name = "danhSáchNVDươngTínhToolStripMenuItem";
            this.danhSáchNVDươngTínhToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.danhSáchNVDươngTínhToolStripMenuItem.Size = new System.Drawing.Size(328, 26);
            this.danhSáchNVDươngTínhToolStripMenuItem.Text = "Danh Sách NV Dương Tính";
            this.danhSáchNVDươngTínhToolStripMenuItem.Click += new System.EventHandler(this.danhSáchNVDươngTínhToolStripMenuItem_Click);
            // 
            // danhSáchCtyĐãTestTheoYCToolStripMenuItem
            // 
            this.danhSáchCtyĐãTestTheoYCToolStripMenuItem.Name = "danhSáchCtyĐãTestTheoYCToolStripMenuItem";
            this.danhSáchCtyĐãTestTheoYCToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.danhSáchCtyĐãTestTheoYCToolStripMenuItem.Size = new System.Drawing.Size(328, 26);
            this.danhSáchCtyĐãTestTheoYCToolStripMenuItem.Text = "Danh Sách Cty Đã Test Theo Y/C";
            this.danhSáchCtyĐãTestTheoYCToolStripMenuItem.Click += new System.EventHandler(this.danhSáchCtyĐãTestTheoYCToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(325, 6);
            // 
            // xuấtBáoCáoToolStripMenuItem
            // 
            this.xuấtBáoCáoToolStripMenuItem.Name = "xuấtBáoCáoToolStripMenuItem";
            this.xuấtBáoCáoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.xuấtBáoCáoToolStripMenuItem.Size = new System.Drawing.Size(328, 26);
            this.xuấtBáoCáoToolStripMenuItem.Text = "Xuất Báo Cáo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(419, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(411, 42);
            this.label6.TabIndex = 0;
            this.label6.Text = "Thông Tin Xét Nghiệm";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1158, 604);
            this.Controls.Add(this.dgvNhanVien);
            this.Controls.Add(this.grbThongTinXetNghiem);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Quản Lý Xét Nghiệm";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grbThongTinXetNghiem.ResumeLayout(false);
            this.grbThongTinXetNghiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox grbThongTinXetNghiem;
        private System.Windows.Forms.DataGridView dgvNhanVien;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem chucwToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.TextBox txtGiayTo;
        private System.Windows.Forms.ComboBox cbbCongTy;
        private System.Windows.Forms.RadioButton rdbAmTinh;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.TextBox txtSLXN;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.RadioButton rdbDuongTinh;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripMenuItem danhSáchNVDươngTínhToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem danhSáchCtyĐãTestTheoYCToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem xuấtBáoCáoToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGiayTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSLXN;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKQ;
    }
}

