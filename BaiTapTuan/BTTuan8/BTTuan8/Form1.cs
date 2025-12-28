using BTTuan8.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace BTTuan8
{
    public partial class Form1 : Form
    {
        private SchoolContext db = new SchoolContext();

        public Form1()
        {
            InitializeComponent();

            // Xử lý sự kiện khi thêm mới từ BindingNavigator
            studentsBindingSource.AddingNew += StudentsBindingSource_AddingNew;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadMajors();
            LoadData();
            BindControls();
        }

        // Xử lý khi click nút "+" trên BindingNavigator
        private void StudentsBindingSource_AddingNew(object sender, System.ComponentModel.AddingNewEventArgs e)
        {
            // Tạo sinh viên mới với giá trị mặc định
            e.NewObject = new Student
            {
                FullName = "",
                Age = 18,
                Major = cbbMajor.Items.Count > 0 ? cbbMajor.Items[0].ToString() : ""
            };
        }

        private void LoadData()
        {
            try
            {
                studentsBindingSource.DataSource = db.Students.ToList();
                dgvStudents.DataSource = studentsBindingSource;

                if (dgvStudents.Columns["StudentId"] != null)
                    dgvStudents.Columns["StudentId"].HeaderText = "Mã SV";
                if (dgvStudents.Columns["FullName"] != null)
                    dgvStudents.Columns["FullName"].HeaderText = "Họ Tên";
                if (dgvStudents.Columns["Age"] != null)
                    dgvStudents.Columns["Age"].HeaderText = "Tuổi";
                if (dgvStudents.Columns["Major"] != null)
                    dgvStudents.Columns["Major"].HeaderText = "Ngành Học";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMajors()
        {
            cbbMajor.Items.Clear();
            cbbMajor.Items.Add("Công nghệ thông tin");
            cbbMajor.Items.Add("Khoa học máy tính");
            cbbMajor.Items.Add("Hệ thống thông tin");
            cbbMajor.Items.Add("Kỹ thuật phần mềm");
            cbbMajor.Items.Add("Trí tuệ nhân tạo");
            cbbMajor.Items.Add("An toàn thông tin");
            cbbMajor.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void BindControls()
        {
            txtFullName.DataBindings.Clear();
            txtAge.DataBindings.Clear();
            cbbMajor.DataBindings.Clear();

            // Đổi sang DataSourceUpdateMode.OnPropertyChanged để tự động cập nhật
            txtFullName.DataBindings.Add("Text", studentsBindingSource, "FullName",
                true, DataSourceUpdateMode.OnPropertyChanged);
            txtAge.DataBindings.Add("Text", studentsBindingSource, "Age",
                true, DataSourceUpdateMode.OnPropertyChanged);
            cbbMajor.DataBindings.Add("Text", studentsBindingSource, "Major",
                true, DataSourceUpdateMode.OnPropertyChanged);
        }

        // NÚT THÊM - Lưu sinh viên hiện tại vào database
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có đang ở chế độ thêm mới không
                if (studentsBindingSource.Current == null)
                {
                    MessageBox.Show("Không có dữ liệu để lưu!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Student currentStudent = (Student)studentsBindingSource.Current;

                // Validate dữ liệu
                if (string.IsNullOrWhiteSpace(currentStudent.FullName))
                {
                    MessageBox.Show("Vui lòng nhập họ tên!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtFullName.Focus();
                    return;
                }

                if (currentStudent.Age < 15 || currentStudent.Age > 100)
                {
                    MessageBox.Show("Tuổi phải từ 15 đến 100!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAge.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(currentStudent.Major))
                {
                    MessageBox.Show("Vui lòng chọn ngành học!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbbMajor.Focus();
                    return;
                }

                // Kiểm tra xem sinh viên này đã có trong DB chưa
                if (currentStudent.StudentId == 0)
                {
                    // Thêm mới
                    db.Students.Add(currentStudent);
                    db.SaveChanges();
                    MessageBox.Show("Thêm sinh viên thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Cập nhật
                    db.Entry(currentStudent).State = EntityState.Modified;
                    db.SaveChanges();
                    MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Reload dữ liệu
                LoadData();
                studentsBindingSource.MoveLast();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // NÚT SỬA - Cập nhật thông tin
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (studentsBindingSource.Current == null)
                {
                    MessageBox.Show("Vui lòng chọn sinh viên cần sửa!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Student selectedStudent = (Student)studentsBindingSource.Current;

                // Validate
                if (string.IsNullOrWhiteSpace(selectedStudent.FullName))
                {
                    MessageBox.Show("Vui lòng nhập họ tên!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (selectedStudent.Age < 15 || selectedStudent.Age > 100)
                {
                    MessageBox.Show("Tuổi phải từ 15 đến 100!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (selectedStudent.StudentId == 0)
                {
                    MessageBox.Show("Vui lòng sử dụng nút 'Thêm' để lưu sinh viên mới!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                db.Entry(selectedStudent).State = EntityState.Modified;
                db.SaveChanges();
                LoadData();

                MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa thông tin: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // NÚT XÓA
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (studentsBindingSource.Current == null)
                {
                    MessageBox.Show("Vui lòng chọn sinh viên cần xóa!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Student selectedStudent = (Student)studentsBindingSource.Current;

                if (selectedStudent.StudentId == 0)
                {
                    // Nếu chưa lưu vào DB, chỉ cần remove khỏi BindingSource
                    studentsBindingSource.RemoveCurrent();
                    MessageBox.Show("Đã hủy thêm mới!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DialogResult result = MessageBox.Show(
                    $"Bạn có chắc muốn xóa sinh viên '{selectedStudent.FullName}'?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    db.Students.Remove(selectedStudent);
                    db.SaveChanges();
                    LoadData();
                    MessageBox.Show("Xóa sinh viên thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa sinh viên: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (db != null)
            {
                db.Dispose();
            }
        }
    }
}