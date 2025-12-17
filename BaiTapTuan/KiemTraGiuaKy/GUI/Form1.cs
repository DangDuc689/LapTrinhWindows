using DAL.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string id = txtGiayTo.Text.Trim();

            if (id.Length != 9 && id.Length != 12)
            {
                MessageBox.Show("Vui lòng nhập CCCD hoặc CMND", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!id.All(char.IsDigit))
            {
                MessageBox.Show("ID chỉ là các ký tự số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var db = new XetNghiemModel())
            {
                db.Configuration.LazyLoadingEnabled = false;

                var nhanVien = db.NHANVIENs.FirstOrDefault(nv => nv.ID == id);

                if (nhanVien != null)
                {
                    grbThongTinXetNghiem.Enabled = true;

                    txtHoTen.Text = nhanVien.HoTen ?? "";
                    txtSLXN.Text = (nhanVien.SoLanXN + 1).ToString();

                    rdbAmTinh.Checked = nhanVien.AmTinh;
                    rdbDuongTinh.Checked = !nhanVien.AmTinh;

                    LoadCongTy(cbbCongTy);
                    cbbCongTy.SelectedValue = nhanVien.MaCty;

                    LoadDanhSachNhanVien();
                }
                else
                {
                    grbThongTinXetNghiem.Enabled = true;

                    txtHoTen.Text = "";
                    txtSLXN.Text = "1";
                    rdbAmTinh.Checked = true;
                    rdbDuongTinh.Checked = false;

                    LoadCongTy(cbbCongTy);
                    if (cbbCongTy.Items.Count > 0)
                        cbbCongTy.SelectedIndex = 0;
                }
            }
        }

        private void LoadCongTy(ComboBox cmb)
        {
            using (var db = new XetNghiemModel())
            {
                db.Configuration.LazyLoadingEnabled = false;

                var dsCongTy = db.CONGTies?.ToList() ?? db.CONGTies.ToList();

                if (dsCongTy == null || dsCongTy.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu công ty!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                cmb.DataSource = dsCongTy;
                cmb.DisplayMember = "TenCty";
                cmb.ValueMember = "MaCty";
                cmb.SelectedIndex = -1;
            }
        }

        private void LoadDanhSachNhanVien()
        {
            dgvNhanVien.AutoGenerateColumns = false;

            dgvNhanVien.DataSource = null;
            dgvNhanVien.Rows.Clear();

            using (var db = new XetNghiemModel())
            {
                db.Configuration.LazyLoadingEnabled = false;

                var dsNhanVien = db.NHANVIENs
                    .OrderBy(nv => nv.HoTen)
                    .ToList();

                foreach (var nv in dsNhanVien)
                {
                    int rowIndex = dgvNhanVien.Rows.Add();
                    var row = dgvNhanVien.Rows[rowIndex];

                    row.Cells["colGiayTO"].Value = nv.ID;
                    row.Cells["colHoTen"].Value = nv.HoTen;
                    row.Cells["colSLXN"].Value = nv.SoLanXN;
                    row.Cells["colKQ"].Value = nv.AmTinh ? "Âm Tính" : "+";
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            grbThongTinXetNghiem.Enabled = false;
            txtSLXN.ReadOnly = true;

            LoadDanhSachNhanVien();
            LoadCongTy(cbbCongTy);
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string id = txtGiayTo.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();
            string maCty = cbbCongTy.SelectedValue?.ToString();

            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Vui lòng nhập CCCD/CMND trước khi cập nhật", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(hoTen))
            {
                MessageBox.Show("Vui lòng nhập họ tên", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(maCty))
            {
                MessageBox.Show("Vui lòng chọn công ty", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var db = new XetNghiemModel())
            {
                db.Configuration.LazyLoadingEnabled = false;

                var nhanVien = db.NHANVIENs.FirstOrDefault(nv => nv.ID == id);

                if (nhanVien == null)
                {
                    nhanVien = new NHANVIEN
                    {
                        ID = id,
                        HoTen = hoTen,
                        SoLanXN = 1, 
                        AmTinh = rdbAmTinh.Checked,
                        MaCty = maCty
                    };

                    db.NHANVIENs.Add(nhanVien);
                    db.SaveChanges();

                    MessageBox.Show("Thêm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    nhanVien.HoTen = hoTen;
                    nhanVien.SoLanXN += 1; 
                    nhanVien.AmTinh = rdbAmTinh.Checked;
                    nhanVien.MaCty = maCty;

                    db.SaveChanges();

                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadDanhSachNhanVien();
                ResetForm();
            }
        }

        private void ResetForm()
        {
            grbThongTinXetNghiem.Enabled = false;

            txtGiayTo.Text = "";
            txtHoTen.Text = "";
            txtSLXN.Text = "";

            rdbAmTinh.Checked = true;
            rdbDuongTinh.Checked = false;

            if (cbbCongTy.Items.Count > 0)
                cbbCongTy.SelectedIndex = 0;
        }

        private void danhSáchNVDươngTínhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var db = new XetNghiemModel())
            {
                db.Configuration.LazyLoadingEnabled = false;

                var dsDuongTinh = db.NHANVIENs
                    .Where(nv => !nv.AmTinh) 
                    .OrderBy(nv => nv.HoTen)
                    .ToList();

                dgvNhanVien.AutoGenerateColumns = false;
                dgvNhanVien.DataSource = null;
                dgvNhanVien.Rows.Clear();

                foreach (var nv in dsDuongTinh)
                {
                    int rowIndex = dgvNhanVien.Rows.Add();
                    var row = dgvNhanVien.Rows[rowIndex];

                    row.Cells["colGiayTO"].Value = nv.ID;
                    row.Cells["colHoTen"].Value = nv.HoTen;
                    row.Cells["colSLXN"].Value = nv.SoLanXN;
                    row.Cells["colKQ"].Value = " + "; 
                }

                MessageBox.Show($"Đã lọc {dsDuongTinh.Count} nhân viên dương tính.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void danhSáchCtyĐãTestTheoYCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var db = new XetNghiemModel())
            {
                db.Configuration.LazyLoadingEnabled = false;

                var dsCongTyDuYC = db.CONGTies
                    .Where(ct => ct.NHANVIENs.Count() >= ct.SLNV) 
                    .OrderBy(ct => ct.TenCty)
                    .ToList();

                if (dsCongTyDuYC.Count == 0)
                {
                    MessageBox.Show("Không có công ty nào đã test đủ yêu cầu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string message = "Các Công Ty đã test đủ Y/C:\n";
                for (int i = 0; i < dsCongTyDuYC.Count; i++)
                {
                    var ct = dsCongTyDuYC[i];
                    message += $"{i + 1}. {ct.TenCty}\n";
                }

                MessageBox.Show(message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        
    }
}