using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTTuan4
{
    public partial class frmQuanLySinhVien : Form
    {
        public frmQuanLySinhVien()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbbChuyenNganh.SelectedIndex = 0;
        }

        private int getSelectedRow(string StudentID)
        {
            for (int i = 0; i < dgvSinhVien.Rows.Count; i++)
            {
                var cellValue = dgvSinhVien.Rows[i].Cells[0].Value;
                if (cellValue != null && cellValue.ToString() == StudentID) return i;
            }
            return -1;
        }

        private void insertUpdate(int selectedRow)
        {
            dgvSinhVien.Rows[selectedRow].Cells[0].Value = txtMSSV.Text;
            dgvSinhVien.Rows[selectedRow].Cells[1].Value = txtHoTen.Text;
            dgvSinhVien.Rows[selectedRow].Cells[2].Value = rdbNam.Checked ? "Nam" : "Nữ";
            dgvSinhVien.Rows[selectedRow].Cells[3].Value = float.Parse(txtDiemTB.Text).ToString();
            dgvSinhVien.Rows[selectedRow].Cells[4].Value = cbbChuyenNganh.Text;
        }

        private void btnThemSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMSSV.Text == "" || txtHoTen.Text == "" || txtDiemTB.Text == "")
                    throw new Exception("Vui lòng nhập đầy đủ thông tin sinh viên!");
                int selectedRow = getSelectedRow(txtMSSV.Text);
                if (selectedRow == -1)
                {
                    selectedRow = dgvSinhVien.Rows.Add();
                    insertUpdate(selectedRow);
                    CountGender();
                    MessageBox.Show("Thêm mới dữ liệu thành công!", "Thông Báo", MessageBoxButtons.OK);
                }
                else
                {
                    insertUpdate(selectedRow);
                    CountGender();
                    MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông Báo", MessageBoxButtons.OK);
                }
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
                int selectedRow = getSelectedRow(txtMSSV.Text);
                if (selectedRow == -1)
                {
                    throw new Exception("Không tìm thấy MSSV cần xoá!");
                }
                else
                {
                    DialogResult dr = MessageBox.Show("Bạn có muốn xoá?", "YES/NO", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        dgvSinhVien.Rows.RemoveAt(selectedRow);
                        CountGender();
                        MessageBox.Show("Xoá sinh viên thành công!", "Thông Báo", MessageBoxButtons.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSinhVien.Rows[e.RowIndex];

                txtMSSV.Text = row.Cells[0].Value?.ToString();
                txtHoTen.Text = row.Cells[1].Value?.ToString();

                string gender = row.Cells[2].Value?.ToString();
                if (gender == "Nam")
                    rdbNam.Checked = true;
                else
                    rdbNu.Checked = true;

                txtDiemTB.Text = row.Cells[3].Value?.ToString();
                cbbChuyenNganh.Text = row.Cells[4].Value?.ToString();
            }
        }

        private void CountGender()
        {
            int soNam = 0, soNu = 0;

            foreach (DataGridViewRow row in dgvSinhVien.Rows)
            {
                if (row.IsNewRow) continue;

                string gender = row.Cells[2].Value?.ToString();
                if (gender == "Nam") soNam++;
                else if (gender == "Nữ") soNu++;
            }

            lblNam.Text = "Tổng SV Nam: " + soNam;
            lblNu.Text = "Nữ: " + soNu;
        }


    }
}