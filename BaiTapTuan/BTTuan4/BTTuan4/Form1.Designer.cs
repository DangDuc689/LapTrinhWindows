namespace BTTuan4
{
    partial class frmQuanLySinhVien
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
            this.gpbThongTinSV = new System.Windows.Forms.GroupBox();
            this.txtDiemTB = new System.Windows.Forms.TextBox();
            this.rdbNu = new System.Windows.Forms.RadioButton();
            this.rdbNam = new System.Windows.Forms.RadioButton();
            this.cbbChuyenNganh = new System.Windows.Forms.ComboBox();
            this.txtMSSV = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvSinhVien = new System.Windows.Forms.DataGridView();
            this.colMSSV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGioiTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiemTB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKhoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.btnThemSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.lblNam = new System.Windows.Forms.Label();
            this.lblNu = new System.Windows.Forms.Label();
            this.gpbThongTinSV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVien)).BeginInit();
            this.SuspendLayout();
            // 
            // gpbThongTinSV
            // 
            this.gpbThongTinSV.Controls.Add(this.txtDiemTB);
            this.gpbThongTinSV.Controls.Add(this.rdbNu);
            this.gpbThongTinSV.Controls.Add(this.rdbNam);
            this.gpbThongTinSV.Controls.Add(this.cbbChuyenNganh);
            this.gpbThongTinSV.Controls.Add(this.txtMSSV);
            this.gpbThongTinSV.Controls.Add(this.label6);
            this.gpbThongTinSV.Controls.Add(this.label5);
            this.gpbThongTinSV.Controls.Add(this.label4);
            this.gpbThongTinSV.Controls.Add(this.label3);
            this.gpbThongTinSV.Controls.Add(this.label2);
            this.gpbThongTinSV.Location = new System.Drawing.Point(33, 67);
            this.gpbThongTinSV.Name = "gpbThongTinSV";
            this.gpbThongTinSV.Size = new System.Drawing.Size(357, 280);
            this.gpbThongTinSV.TabIndex = 0;
            this.gpbThongTinSV.TabStop = false;
            this.gpbThongTinSV.Text = "Thông Tin Sinh Viên";
            // 
            // txtDiemTB
            // 
            this.txtDiemTB.Location = new System.Drawing.Point(171, 184);
            this.txtDiemTB.Name = "txtDiemTB";
            this.txtDiemTB.Size = new System.Drawing.Size(100, 20);
            this.txtDiemTB.TabIndex = 0;
            // 
            // rdbNu
            // 
            this.rdbNu.AutoSize = true;
            this.rdbNu.Checked = true;
            this.rdbNu.Location = new System.Drawing.Point(266, 139);
            this.rdbNu.Name = "rdbNu";
            this.rdbNu.Size = new System.Drawing.Size(39, 17);
            this.rdbNu.TabIndex = 3;
            this.rdbNu.TabStop = true;
            this.rdbNu.Text = "Nu";
            this.rdbNu.UseVisualStyleBackColor = true;
            // 
            // rdbNam
            // 
            this.rdbNam.AutoSize = true;
            this.rdbNam.Location = new System.Drawing.Point(171, 139);
            this.rdbNam.Name = "rdbNam";
            this.rdbNam.Size = new System.Drawing.Size(47, 17);
            this.rdbNam.TabIndex = 3;
            this.rdbNam.Text = "Nam";
            this.rdbNam.UseVisualStyleBackColor = true;
            // 
            // cbbChuyenNganh
            // 
            this.cbbChuyenNganh.FormattingEnabled = true;
            this.cbbChuyenNganh.Items.AddRange(new object[] {
            "Quản Trị Kinh Doanh",
            "Công Nghệ Thông Tin",
            "Ngôn Ngữ Anh",
            "Luật"});
            this.cbbChuyenNganh.Location = new System.Drawing.Point(171, 227);
            this.cbbChuyenNganh.Name = "cbbChuyenNganh";
            this.cbbChuyenNganh.Size = new System.Drawing.Size(153, 21);
            this.cbbChuyenNganh.TabIndex = 2;
            // 
            // txtMSSV
            // 
            this.txtMSSV.Location = new System.Drawing.Point(171, 34);
            this.txtMSSV.Name = "txtMSSV";
            this.txtMSSV.Size = new System.Drawing.Size(100, 20);
            this.txtMSSV.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(48, 230);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Chuyên Ngành";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Giới Tính";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Điểm TB";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Họ Tên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã Sinh Viên";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(333, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(423, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "Quản Lý Thông Tin Sinh Viên";
            // 
            // dgvSinhVien
            // 
            this.dgvSinhVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSinhVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSinhVien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMSSV,
            this.colHoTen,
            this.colGioiTinh,
            this.colDiemTB,
            this.colKhoa});
            this.dgvSinhVien.Location = new System.Drawing.Point(424, 67);
            this.dgvSinhVien.Name = "dgvSinhVien";
            this.dgvSinhVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSinhVien.Size = new System.Drawing.Size(664, 315);
            this.dgvSinhVien.TabIndex = 2;
            this.dgvSinhVien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSinhVien_CellClick);
            // 
            // colMSSV
            // 
            this.colMSSV.HeaderText = "MSSV";
            this.colMSSV.Name = "colMSSV";
            this.colMSSV.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colHoTen
            // 
            this.colHoTen.HeaderText = "Họ Tên";
            this.colHoTen.Name = "colHoTen";
            this.colHoTen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colGioiTinh
            // 
            this.colGioiTinh.HeaderText = "Giới Tính";
            this.colGioiTinh.Name = "colGioiTinh";
            this.colGioiTinh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colDiemTB
            // 
            this.colDiemTB.HeaderText = "Điểm TB";
            this.colDiemTB.Name = "colDiemTB";
            this.colDiemTB.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colKhoa
            // 
            this.colKhoa.HeaderText = "Khoa";
            this.colKhoa.Name = "colKhoa";
            this.colKhoa.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(204, 150);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(100, 20);
            this.txtHoTen.TabIndex = 0;
            // 
            // btnThemSua
            // 
            this.btnThemSua.Location = new System.Drawing.Point(169, 372);
            this.btnThemSua.Name = "btnThemSua";
            this.btnThemSua.Size = new System.Drawing.Size(75, 23);
            this.btnThemSua.TabIndex = 3;
            this.btnThemSua.Text = "Thêm/ Sửa";
            this.btnThemSua.UseVisualStyleBackColor = true;
            this.btnThemSua.Click += new System.EventHandler(this.btnThemSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(282, 372);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 3;
            this.btnXoa.Text = "Xoá";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // lblNam
            // 
            this.lblNam.AutoSize = true;
            this.lblNam.Location = new System.Drawing.Point(886, 409);
            this.lblNam.Name = "lblNam";
            this.lblNam.Size = new System.Drawing.Size(74, 13);
            this.lblNam.TabIndex = 1;
            this.lblNam.Text = "Tổng SV Nam";
            // 
            // lblNu
            // 
            this.lblNu.AutoSize = true;
            this.lblNu.Location = new System.Drawing.Point(1017, 409);
            this.lblNu.Name = "lblNu";
            this.lblNu.Size = new System.Drawing.Size(21, 13);
            this.lblNu.TabIndex = 1;
            this.lblNu.Text = "Nữ";
            // 
            // frmQuanLySinhVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 450);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThemSua);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.dgvSinhVien);
            this.Controls.Add(this.lblNu);
            this.Controls.Add(this.lblNam);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gpbThongTinSV);
            this.Name = "frmQuanLySinhVien";
            this.Text = "Quản Lý Thông Tin Sinh Viên";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gpbThongTinSV.ResumeLayout(false);
            this.gpbThongTinSV.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbThongTinSV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvSinhVien;
        private System.Windows.Forms.TextBox txtMSSV;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtDiemTB;
        private System.Windows.Forms.RadioButton rdbNu;
        private System.Windows.Forms.RadioButton rdbNam;
        private System.Windows.Forms.ComboBox cbbChuyenNganh;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnThemSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Label lblNam;
        private System.Windows.Forms.Label lblNu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMSSV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGioiTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiemTB;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKhoa;
    }
}
