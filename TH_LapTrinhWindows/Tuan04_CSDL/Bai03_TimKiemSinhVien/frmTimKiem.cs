using Bai03_TimKiemSinhVien.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace Bai03_TimKiemSinhVien
{
    public partial class frmTimKiem : Form
    {
        StudentContextDB db = new StudentContextDB();

        public frmTimKiem()
        {
            InitializeComponent();
        }

        private void frmTimKiem_Load(object sender, EventArgs e)
        {
            try
            {
                // Load danh sách khoa vào ComboBox
                var listFaculties = db.Faculties.ToList();
                cbbKhoa.DataSource = listFaculties;
                cbbKhoa.DisplayMember = "FacultyName";
                cbbKhoa.ValueMember = "FacultyID";
                cbbKhoa.SelectedIndex = -1; // Không chọn khoa nào mặc định

                // Load tất cả sinh viên khi mở form
                LoadAllStudents();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadAllStudents()
        {
            try
            {
                var listStudents = db.Students.Include(s => s.Faculty).ToList();
                BindGrid(listStudents);
                lblKetQua.Text = $"Kết quả tìm kiếm: {listStudents.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BindGrid(List<Student> listStudents)
        {
            dgvKetQua.Rows.Clear();
            foreach (var item in listStudents)
            {
                int index = dgvKetQua.Rows.Add();
                dgvKetQua.Rows[index].Cells[0].Value = item.StudentID;
                dgvKetQua.Rows[index].Cells[1].Value = item.FullName;
                dgvKetQua.Rows[index].Cells[2].Value = item.Faculty?.FacultyName;
                dgvKetQua.Rows[index].Cells[3].Value = item.AverageScore;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy danh sách tất cả sinh viên
                var query = db.Students.Include(s => s.Faculty).AsQueryable();

                // Tìm theo MSSV (nếu có nhập)
                if (!string.IsNullOrWhiteSpace(txtMSSV.Text))
                {
                    string mssv = txtMSSV.Text.Trim();
                    query = query.Where(s => s.StudentID.Contains(mssv));
                }

                // Tìm theo Họ Tên (nếu có nhập)
                if (!string.IsNullOrWhiteSpace(txtHoTen.Text))
                {
                    string hoTen = txtHoTen.Text.Trim().ToLower();
                    query = query.Where(s => s.FullName.ToLower().Contains(hoTen));
                }

                // Tìm theo Khoa (nếu có chọn)
                if (cbbKhoa.SelectedIndex >= 0)
                {
                    int facultyID = (int)cbbKhoa.SelectedValue;
                    query = query.Where(s => s.FacultyID == facultyID);
                }

                // Lấy kết quả
                var result = query.ToList();

                // Hiển thị kết quả
                BindGrid(result);
                lblKetQua.Text = $"Kết quả tìm kiếm: {result.Count}";

                // Thông báo nếu không tìm thấy
                if (result.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy sinh viên nào phù hợp với điều kiện tìm kiếm!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Reset tất cả các ô nhập liệu
            txtMSSV.Clear();
            txtHoTen.Clear();
            cbbKhoa.SelectedIndex = -1;

            // Load lại tất cả sinh viên
            LoadAllStudents();
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvKetQua_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Có thể thêm chức năng khi click vào dòng nếu cần
            // Ví dụ: hiển thị thông tin chi tiết
        }
    }
}