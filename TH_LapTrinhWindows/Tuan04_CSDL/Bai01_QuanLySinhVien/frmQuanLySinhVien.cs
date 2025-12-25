using Bai01_QuanLySinhVien.Models;
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

namespace Bai01_QuanLySinhVien
{
    public partial class frmQuanLySinhVien : Form
    {
        public frmQuanLySinhVien()
        {
            InitializeComponent();
        }

        private void frmQuanLySinhVien_Load(object sender, EventArgs e)
        {
            try
            {
                StudentContextDB context = new StudentContextDB();
                List<Faculty> listFaculties = context.Faculties.ToList();
                List<Student> listStudents = context.Students.ToList();
                FillFacultyCombobox(listFaculties);
                BindGrid(listStudents);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);                
            }
        }

        private void BindGrid(List<Student> listStudents)
        {
            dgvSinhVien.Rows.Clear();
            foreach (var item in listStudents)
            {
                int index = dgvSinhVien.Rows.Add();
                dgvSinhVien.Rows[index].Cells[0].Value = item.StudentID;
                dgvSinhVien.Rows[index].Cells[1].Value = item.FullName;
                dgvSinhVien.Rows[index].Cells[2].Value = item.Faculty.FacultyName;
                dgvSinhVien.Rows[index].Cells[3].Value = item.AverageScore;
            }
        }

        private void FillFacultyCombobox(List<Faculty> listFaculties)
        {
            this.cbbKhoa.DataSource = listFaculties;
            this.cbbKhoa.DisplayMember = "FacultyName";
            this.cbbKhoa.ValueMember = "FacultyID";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                StudentContextDB db = new StudentContextDB();
                List<Student> studentLst = db.Students.ToList();
                if (txtMSSV.Text.Length != 10)
                {
                    MessageBox.Show("Mã số sinh viên phải có 10 ký tự!", "Thông Báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; 
                }

                if (studentLst.Any(s => s.StudentID == txtMSSV.Text))
                {
                    MessageBox.Show("Mã SV đã tồn tại. Vui lòng Nhập một mã khác.", "Thông Báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning); 
                    return;
                }

                var newStudent = new Student
                {
                    StudentID = txtMSSV.Text,
                    FullName = txtHoTen.Text,
                    FacultyID = int.Parse(cbbKhoa.SelectedValue.ToString()),
                    AverageScore = double.Parse(txtDiemTB.Text)
                };

                db.Students.Add(newStudent);
                db.SaveChanges();

                BindGrid(db.Students.Include(s => s.Faculty).ToList());
                ResetInput();
                MessageBox.Show("Thêm dữ liệu mới thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e) 
        {
            try
            {
                StudentContextDB db = new StudentContextDB();
                List<Student> studentList = db.Students.ToList();  
                var student = studentList.FirstOrDefault(s => s.StudentID == txtMSSV.Text);
                if (student != null)
                {                    
                    student.FullName = txtHoTen.Text;
                    student.FacultyID = int.Parse(cbbKhoa.SelectedValue.ToString());
                    student.AverageScore = double.Parse(txtDiemTB.Text);
                    db.SaveChanges();
                    BindGrid(db.Students.Include(s => s.Faculty).ToList());
                    ResetInput();
                    MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông Báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy MSSV cần sửa!", "Thông Báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật dữ liệu: {ex.Message}", "Thông Báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                StudentContextDB db = new StudentContextDB();
                List<Student> studentList = db.Students.ToList();
                var student = studentList.FirstOrDefault(s => s.StudentID == txtMSSV.Text);
                if (student != null)
                {
                    DialogResult result = MessageBox.Show(
                        "Bạn có chắc chắn muốn xoá sinh viên này?",
                        "Xác nhận xoá",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        db.Students.Remove(student);
                        db.SaveChanges();
                        BindGrid(db.Students.Include(s => s.Faculty).ToList());
                        ResetInput();

                        MessageBox.Show("Xóa sinh viên thành công!", "Thông Báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sinh viên cần xóa!", "Thông Báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Không tìm thấy sinh viên cần xóa!", "Thông Báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvSinhVien.Rows[e.RowIndex];
                txtMSSV.Text = selectedRow.Cells[0].Value.ToString();
                txtHoTen.Text = selectedRow.Cells[1].Value.ToString();
                cbbKhoa.Text = selectedRow.Cells[2].Value.ToString();
                txtDiemTB.Text = selectedRow.Cells[3].Value.ToString();
            }
        }

        private void ResetInput()
        {
            txtMSSV.Clear();
            txtHoTen.Clear();
            txtDiemTB.Clear();
            cbbKhoa.SelectedIndex = 0;
        }

    }
}
