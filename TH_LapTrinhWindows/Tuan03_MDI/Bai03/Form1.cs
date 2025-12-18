using System;
using System.Windows.Forms;

namespace Bai03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvSinhVien.Columns.Clear();
            dgvSinhVien.AllowUserToAddRows = false;

            dgvSinhVien.ColumnCount = 5;
            dgvSinhVien.Columns[0].Name = "Số TT";
            dgvSinhVien.Columns[0].Width = 60; 
            dgvSinhVien.Columns[1].Name = "Mã Số SV";
            dgvSinhVien.Columns[2].Name = "Tên Sinh Viên";
            dgvSinhVien.Columns[3].Name = "Khoa";
            dgvSinhVien.Columns[4].Name = "Điểm TB";
        }

        private void menuAddStudent_Click(object sender, EventArgs e)
        {
            frmThemSV frm = new frmThemSV();
            frm.OnAddStudent = AddNewStudent;
            frm.ShowDialog();
        }

        private void AddNewStudent(string mssv, string hoten, string diemtb, string khoa)
        {
            foreach (DataGridViewRow row in dgvSinhVien.Rows)
            {
                if (row.Cells[1].Value != null &&
                    row.Cells[1].Value.ToString().Equals(mssv, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Mã số sinh viên này đã tồn tại!");
                    return;
                }
            }

            int stt = dgvSinhVien.Rows.Count;
            if (dgvSinhVien.AllowUserToAddRows) 
            {
                stt = dgvSinhVien.Rows.Count; 
            }
            else
            {
                stt = dgvSinhVien.Rows.Count + 1;
            }

            dgvSinhVien.Rows.Add(stt, mssv, hoten, khoa, diemtb);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTim.Text.Trim().ToLower();

            foreach (DataGridViewRow row in dgvSinhVien.Rows)
            {
                if (row.Cells[2].Value != null) 
                {
                    string name = row.Cells[2].Value.ToString().ToLower();
                    row.Visible = name.Contains(keyword);
                }
            }
        }

        private void tìmKiếmTheoTênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn thoát không?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}