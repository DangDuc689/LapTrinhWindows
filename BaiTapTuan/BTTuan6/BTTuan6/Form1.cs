using BTTuan6.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace BTTuan6
{
    public partial class frmQuanLySinhVien : Form
    {
        private StudentContextDB db = new StudentContextDB();

        public frmQuanLySinhVien()
        {
            InitializeComponent();
        }

        private void frmQuanLySinhVien_Load(object sender, EventArgs e)
        {
            LoadFaculty();
            LoadStudents();
        }

        private void LoadFaculty()
        {
            var list = db.Faculties.ToList();

            cbbChuyenNganh.DataSource = list;
            cbbChuyenNganh.DisplayMember = "FacultyName";
            cbbChuyenNganh.ValueMember = "FacultyID";
        }

        private void LoadStudents()
        {
            dgvSinhVien.Rows.Clear();

            var list = db.Students.ToList();

            foreach (var s in list)
            {
                dgvSinhVien.Rows.Add(
                    s.StudentID,
                    s.FullName,
                    s.Faculty?.FacultyName,
                    s.AverageScore
                );
            }
        }

        private void ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtMSSV.Text) ||
                string.IsNullOrWhiteSpace(txtHoTen.Text) ||
                string.IsNullOrWhiteSpace(txtDiemTB.Text))
            {
                throw new Exception("Vui lòng nhập đầy đủ thông tin!");
            }

            if (txtMSSV.Text.Length != 10)
            {
                throw new Exception("Mã số sinh viên phải có 10 kí tự!");
            }

            decimal AverageScore;
            if (!decimal.TryParse(txtDiemTB.Text, out AverageScore))
            {
                throw new Exception("Điểm trung bình phải là số!");
            }
        }

        private void ClearForm()
        {
            txtMSSV.Clear();
            txtHoTen.Clear();
            txtDiemTB.Clear();
            if (cbbChuyenNganh.Items.Count > 0)
                cbbChuyenNganh.SelectedIndex = 0;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateInput();

                string id = txtMSSV.Text.Trim();
                var exist = db.Students.Find(id);

                if (exist != null)
                {
                    MessageBox.Show("Mã số sinh viên đã tồn tại! Nếu muốn sửa, hãy nhấn nút Sửa.");
                    return;
                }

                Student s = new Student
                {
                    StudentID = id,
                    FullName = txtHoTen.Text.Trim(),
                    AverageScore = decimal.Parse(txtDiemTB.Text),
                    FacultyID = (int)cbbChuyenNganh.SelectedValue
                };

                db.Students.Add(s);
                db.SaveChanges();

                LoadStudents();
                MessageBox.Show("Thêm mới dữ liệu thành công!");

                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateInput();

                string id = txtMSSV.Text.Trim();
                var s = db.Students.Find(id);

                if (s == null)
                {
                    MessageBox.Show("Không tìm thấy MSSV cần sửa!");
                    return;
                }

                s.FullName = txtHoTen.Text.Trim();
                s.AverageScore = decimal.Parse(txtDiemTB.Text);
                s.FacultyID = (int)cbbChuyenNganh.SelectedValue;

                db.SaveChanges();

                LoadStudents();
                MessageBox.Show("Cập nhật dữ liệu thành công!");

                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string id = txtMSSV.Text.Trim();

                if (string.IsNullOrWhiteSpace(id))
                {
                    MessageBox.Show("Vui lòng nhập MSSV cần xoá!");
                    return;
                }

                var s = db.Students.Find(id);

                if (s == null)
                {
                    MessageBox.Show("Không tìm thấy MSSV cần xóa!");
                    return;
                }

                DialogResult dr = MessageBox.Show("Bạn có muốn xoá?", "YES/NO", MessageBoxButtons.YesNo);

                if (dr == DialogResult.Yes)
                {
                    db.Students.Remove(s);
                    db.SaveChanges();

                    LoadStudents();
                    MessageBox.Show("Xóa sinh viên thành công!");

                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvSinhVien.Rows[e.RowIndex];

            txtMSSV.Text = row.Cells[0].Value?.ToString();
            txtHoTen.Text = row.Cells[1].Value?.ToString();
            txtDiemTB.Text = row.Cells[3].Value?.ToString();

            string facultyName = row.Cells[2].Value?.ToString();
            var faculty = db.Faculties.FirstOrDefault(f => f.FacultyName == facultyName);

            if (faculty != null)
                cbbChuyenNganh.SelectedValue = faculty.FacultyID;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát chương trình?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        
    }
}
