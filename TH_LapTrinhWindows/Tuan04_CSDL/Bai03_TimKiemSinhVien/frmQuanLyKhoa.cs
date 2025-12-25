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
    public partial class frmQuanLyKhoa : Form
    {
        StudentContextDB db = new StudentContextDB();
        public frmQuanLyKhoa()
        {
            InitializeComponent();
        }

        private void frmQuanLyKhoa_Load(object sender, EventArgs e)
        {
            LoadFaculty();
        }

        private void LoadFaculty()
        {
            dgvKhoa.Rows.Clear();
            var list = db.Faculties.ToList();
            foreach (var f in list)
            {
                int row = dgvKhoa.Rows.Add();
                dgvKhoa.Rows[row].Cells[0].Value = f.FacultyID;
                dgvKhoa.Rows[row].Cells[1].Value = f.FacultyName;
                dgvKhoa.Rows[row].Cells[2].Value = f.TotalProfessor;
            }
        }
        private void ResetInput()
        {
            txtMaKhoa.Clear();
            txtTenKhoa.Clear();
            txtTongGS.Clear();
            txtMaKhoa.Focus();
        }

        private void btnThemSua_Click(object sender, EventArgs e)
        {
            try
            {
                int maKhoa = int.Parse(txtMaKhoa.Text);
                var faculty = db.Faculties.FirstOrDefault(f => f.FacultyID == maKhoa);

                if (faculty == null)
                {
                    Faculty f = new Faculty()
                    {
                        FacultyID = maKhoa,
                        FacultyName = txtTenKhoa.Text,
                        TotalProfessor = string.IsNullOrEmpty(txtTongGS.Text)
                            ? (int?)null
                            : int.Parse(txtTongGS.Text)
                    };

                    db.Faculties.Add(f);
                    MessageBox.Show("Thêm khoa thành công!");
                }
                else
                {
                    faculty.FacultyName = txtTenKhoa.Text;
                    faculty.TotalProfessor = string.IsNullOrEmpty(txtTongGS.Text)
                        ? (int?)null
                        : int.Parse(txtTongGS.Text);

                    MessageBox.Show("Cập nhật khoa thành công!");
                }

                db.SaveChanges();
                LoadFaculty();
                ResetInput();
            }
            catch
            {
                MessageBox.Show("Dữ liệu không hợp lệ!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int maKhoa = int.Parse(txtMaKhoa.Text);
                var faculty = db.Faculties
                                .Include(f => f.Students)
                                .FirstOrDefault(f => f.FacultyID == maKhoa);

                if (faculty == null)
                {
                    MessageBox.Show("Không tìm thấy khoa!");
                    return;
                }

                if (faculty.Students.Any())
                {
                    MessageBox.Show("Khoa đang có sinh viên, không thể xóa!");
                    return;
                }

                db.Faculties.Remove(faculty);
                db.SaveChanges();

                LoadFaculty();
                ResetInput();

                MessageBox.Show("Xóa khoa thành công!");
            }
            catch
            {
                MessageBox.Show("Lỗi khi xóa khoa!");
            }
        }


        private void dgvKhoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKhoa.Rows[e.RowIndex];
                txtMaKhoa.Text = row.Cells[0].Value.ToString();
                txtTenKhoa.Text = row.Cells[1].Value.ToString();
                txtTongGS.Text = row.Cells[2].Value?.ToString();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn thoát không?",
                    "Xác nhận thoát",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
