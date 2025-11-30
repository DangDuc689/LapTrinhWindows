using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTTuan3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAddName_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ListViewItem item = new ListViewItem(txtLastName.Text); 
            item.SubItems.Add(txtFirstName.Text); 
            item.SubItems.Add(txtPhone.Text);     

            lstThongTin.Items.Add(item);

            txtLastName.Clear();
            txtFirstName.Clear();
            txtPhone.Clear();
            txtLastName.Focus();
        }

        private void lstThongTin_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ádfasdfasfToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void lstThongTin_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lstThongTin_SelectedIndexChanged_2(object sender, EventArgs e)
        {

        }
    }
}
