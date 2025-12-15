using BUS;
using DAL.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace BTTuan6
{
    public partial class Form1 : Form
    {
        private readonly StudentService studentService = new StudentService();
        private readonly FacultyService facultyService = new FacultyService();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                setGridViewStyle(dgvSinhVien);
                var listFacultys = facultyService.GetAll();
                var listStudents = studentService.GetAll();
                FillFalcultyCombobox(listFacultys);
                BindGrid(listStudents);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Hàm binding list dữ liệu khoa vào combobox có tên hiện thị là tên khoa, giá trị là Mã khoa
        private void FillFalcultyCombobox(List<Faculty> listFacultys)
        {
            listFacultys.Insert(0, new Faculty());
            cbbKhoa.DataSource = listFacultys;
            cbbKhoa.DisplayMember = "FacultyName";
            cbbKhoa.ValueMember = "FacultyID";
        }

        // Hàm binding gridView từ list sinh viên
        private void BindGrid(List<Student> listStudent)
        {
            dgvSinhVien.Rows.Clear();
            foreach (var item in listStudent)
            {
                int index = dgvSinhVien.Rows.Add();
                dgvSinhVien.Rows[index].Cells[0].Value = item.StudentID;
                dgvSinhVien.Rows[index].Cells[1].Value = item.FullName;

                if (item.Faculty != null)
                    dgvSinhVien.Rows[index].Cells[2].Value = item.Faculty.FacultyName;
                dgvSinhVien.Rows[index].Cells[3].Value = item.AverageScore + "";

                if (item.MajorID != null)
                    dgvSinhVien.Rows[index].Cells[4].Value = item.Major.Name + "";
            }
        }

        private void ShowAvatar(string ImageName)
        {
            // giải phóng ảnh cũ
            if (picAvatar.Image != null)
            {
                picAvatar.Image.Dispose();
                picAvatar.Image = null;
            }

            if (string.IsNullOrEmpty(ImageName)) return;
            string parentDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            string imagePath = Path.Combine(parentDirectory, "Images", ImageName);
            if (!File.Exists(imagePath)) return;

            try
            {
                using (var fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    picAvatar.Image = Image.FromStream(fs);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải ảnh: {ex.Message}");
            }
        }

        // giao diện cho dgv
        public void setGridViewStyle(DataGridView dgview)
        {
            dgview.BorderStyle = BorderStyle.None;
            dgview.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dgview.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgview.BackgroundColor = Color.White;
            dgview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void chkUnregisterMajor_CheckedChanged(object sender, EventArgs e)
        {
            var listStudents = new List<Student>();
            if (this.chkUnregisterMajor.Checked)
                listStudents = studentService.GetAllHasNoMajor();
            else
                listStudents = studentService.GetAll();
            BindGrid(listStudents);
        }

        private void ResetForm()
        {
            txtMSSV.Text = "";
            txtHoTen.Text = "";
            txtDTB.Text = "";
            cbbKhoa.SelectedIndex = 0;

            // giải phóng ảnh cũ
            if (picAvatar.Image != null)
            {
                picAvatar.Image.Dispose();
                picAvatar.Image = null;
            }
            picAvatar.Tag = null;
        }

        private void btnAddUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string studentID = txtMSSV.Text;
                string fullName = txtHoTen.Text;
                double averageScore;
                if (!double.TryParse(txtDTB.Text, out averageScore))
                {
                    MessageBox.Show("Điểm trung bình không hợp lệ!");
                    return;
                }

                if (cbbKhoa.SelectedValue == null || string.IsNullOrEmpty(cbbKhoa.SelectedValue.ToString()))
                {
                    MessageBox.Show("Vui lòng chọn một khoa hợp lệ!");
                    return;
                }

                int facultyID = Convert.ToInt32(cbbKhoa.SelectedValue);
                Student student = new Student
                {
                    StudentID = studentID,
                    FullName = fullName,
                    AverageScore = averageScore,
                    FacultyID = facultyID
                };

                Student existingStudent = studentService.FindByID(studentID);
                if (existingStudent == null)
                {
                    studentService.InsertUpdate(student);
                }
                else
                {
                    existingStudent.FullName = student.FullName;
                    existingStudent.AverageScore = student.AverageScore;
                    existingStudent.FacultyID = student.FacultyID;
                    studentService.InsertUpdate(existingStudent);
                }

                // xử lý ảnh .jqp/.png
                string avatarFileName = null;
                if (picAvatar.Image != null)
                {
                    string extension = picAvatar.Tag as string ?? ".jpg";
                    avatarFileName = $"{studentID}{extension}";

                    string parentDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                    string imageDirectory = Path.Combine(parentDirectory, "Images");
                    string imagePath = Path.Combine(imageDirectory, avatarFileName);

                    ImageFormat format = extension.Equals(".png", StringComparison.OrdinalIgnoreCase) ? ImageFormat.Png : ImageFormat.Jpeg;
                    using (var tempImage = new Bitmap(picAvatar.Image))
                    {
                        tempImage.Save(imagePath, format);
                    }
                    studentService.UpdateAvatar(studentID, avatarFileName);
                }
                else
                {
                    studentService.UpdateAvatar(studentID, null);
                }

                var listStudents = studentService.GetAll();
                BindGrid(listStudents);
                ResetForm();
                MessageBox.Show("Thông tin sinh viên đã được lưu thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Hình ảnh (*.jpg, *.png)|*.jpg;*.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // giải phóng ảnh cũ trước khi load mới
                    if (picAvatar.Image != null)
                    {
                        picAvatar.Image.Dispose();
                        picAvatar.Image = null;
                    }

                    string extension = Path.GetExtension(openFileDialog.FileName).ToLower();
                    picAvatar.Tag = extension;
                    using (var fs = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        picAvatar.Image = Image.FromStream(fs);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi chọn ảnh: {ex.Message}");
                }
            }
        }

        private void dgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSinhVien.Rows[e.RowIndex];
                string studentID = row.Cells[0].Value?.ToString();

                if (string.IsNullOrEmpty(studentID)) return;

                Student student = studentService.FindByID(studentID);
                if (student == null) return;

                txtMSSV.Text = student.StudentID;
                txtHoTen.Text = student.FullName;
                txtDTB.Text = student.AverageScore.ToString();
                cbbKhoa.SelectedValue = student.FacultyID;

                ShowAvatar(student.Avatar);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string studentID = txtMSSV.Text.Trim();
                if (string.IsNullOrEmpty(studentID))
                {
                    MessageBox.Show("Vui lòng chọn sinh viên cần xóa!");
                    return;
                }

                var result = MessageBox.Show($"Bạn có chắc chắn muốn xóa sinh viên {studentID}?",
                             "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result != DialogResult.Yes) return;

                Student student = studentService.FindByID(studentID);
                if (student == null)
                {
                    MessageBox.Show("Không tìm thấy sinh viên để xóa.");
                    return;
                }

                studentService.Delete(studentID);

                var listStudents = studentService.GetAll();
                BindGrid(listStudents);
                ResetForm();
                MessageBox.Show("Xóa sinh viên thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa sinh viên: " + ex.Message);
            }
        }
    }
}