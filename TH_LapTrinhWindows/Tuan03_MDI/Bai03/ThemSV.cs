using System;
using System.Windows.Forms;

namespace Bai03
{
    // 1. Khai báo delegate dùng để gửi dữ liệu về Form chính
    public delegate void AddStudentDelegate(string studentID, string fullName, string averageScore, string faculty);

    public partial class frmThemSV : Form
    {
        // 2. Tạo biến delegate
        public AddStudentDelegate OnAddStudent;

        public frmThemSV()
        {
            InitializeComponent();
        }

        private void frmThemSV_Load(object sender, EventArgs e)
        {
            cbbKhoa.SelectedIndex = 0;
        }

        // 3. Nút Thêm → gửi dữ liệu về Form Chính qua delegate
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ form
                string studentID = txtMSSV.Text.Trim();
                string fullName = txtTenSV.Text.Trim();
                string averageScore = txtDiemTB.Text.Trim();
                string faculty = cbbKhoa.SelectedItem.ToString();

                // Kiểm tra rỗng
                if (studentID == "" || fullName == "" || averageScore == "")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                    return;
                }

                // Kiểm tra điểm
                if (!double.TryParse(averageScore, out double diem) || diem < 0 || diem > 10)
                {
                    MessageBox.Show("Điểm phải từ 0 đến 10!");
                    return;
                }

                // Gọi delegate → Gửi dữ liệu về Form Chính
                OnAddStudent?.Invoke(studentID, fullName, averageScore, faculty);

                // Đóng form
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
