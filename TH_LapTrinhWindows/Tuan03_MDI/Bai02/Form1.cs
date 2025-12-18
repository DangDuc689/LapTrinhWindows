using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Bai02
{
    public partial class Form1 : Form
    {
        string currentFile = "";
        bool isNewFile = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThongTin thongTIn = new frmThongTin();
            thongTIn.ShowDialog();
        }

        private void địnhDạngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog();
            fontDlg.ShowColor = true;
            fontDlg.ShowApply = true;
            fontDlg.ShowEffects = true;
            fontDlg.ShowHelp = true;
            if (fontDlg.ShowDialog() != DialogResult.Cancel)
            {
                rtbVanBan.ForeColor = fontDlg.Color;
                rtbVanBan.Font = fontDlg.Font;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbbFontChu.TextChanged += cbbFontChu_TextChanged;
            cbbFontSize.TextChanged += cbbFontSize_TextChanged;
            foreach (FontFamily font in FontFamily.Families)
                cbbFontChu.Items.Add(font.Name);

            int[] sizes = { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            foreach (int size in sizes)
                cbbFontSize.Items.Add(size);

            cbbFontChu.Text = "Tahoma";
            cbbFontSize.Text = "14";
            rtbVanBan.Font = new Font("Tahoma", 14);
        }

        private void CreateFile_Click(object sender, EventArgs e)
        {
            rtbVanBan.Clear();
            cbbFontChu.Text = "Tahoma";
            cbbFontSize.Text = "14";
            rtbVanBan.Font = new Font("Tahoma", 14);

            currentFile = "";
            isNewFile = true;
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Rich Text (*.rtf)|*.rtf|Text Files (*.txt)|*.txt";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                currentFile = ofd.FileName;
                isNewFile = false;

                if (currentFile.EndsWith(".rtf"))
                    rtbVanBan.LoadFile(currentFile, RichTextBoxStreamType.RichText);
                else
                    rtbVanBan.LoadFile(currentFile, RichTextBoxStreamType.PlainText);
            }
        }

        private void SaveFile_Click(object sender, EventArgs e)
        {
            if (isNewFile)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Rich Text Format |*.rtf";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    currentFile = sfd.FileName;

                    rtbVanBan.SaveFile(currentFile, RichTextBoxStreamType.RichText);

                    isNewFile = false;

                    MessageBox.Show("Lưu văn bản thành công!", "Thông báo");
                }
            }
            else
            {
                rtbVanBan.SaveFile(currentFile, RichTextBoxStreamType.RichText);
                MessageBox.Show("Lưu văn bản thành công!", "Thông báo");
            }
        }

        private void cbbFontChu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rtbVanBan.SelectionFont == null) return;
            rtbVanBan.SelectionFont = new Font(
                    cbbFontChu.SelectedItem.ToString(),
                    rtbVanBan.SelectionFont.Size,
                    rtbVanBan.SelectionFont.Style
                );
        }

        private void cbbFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rtbVanBan.SelectionFont == null) return;

            float newSize = float.Parse(cbbFontSize.SelectedItem.ToString());

            rtbVanBan.SelectionFont = new Font(
                rtbVanBan.SelectionFont.FontFamily,
                newSize,
                rtbVanBan.SelectionFont.Style
            );
        }

        private void ToggleStyle(FontStyle style)
        {
            if (rtbVanBan.SelectionFont == null) return;

            Font current = rtbVanBan.SelectionFont;
            FontStyle newStyle;

            if (current.Style.HasFlag(style))
                newStyle = current.Style & ~style;
            else
                newStyle = current.Style | style;

            rtbVanBan.SelectionFont = new Font(
                current.FontFamily,
                current.Size,
                newStyle
            );
        }

        private void btnBold_Click(object sender, EventArgs e)
        {
            ToggleStyle(FontStyle.Bold);
        }

        private void btnItalic_Click(object sender, EventArgs e)
        {
            ToggleStyle(FontStyle.Italic);
        }

        private void btnUnderline_Click(object sender, EventArgs e)
        {
            ToggleStyle(FontStyle.Underline);
        }

        private void cbbFontChu_TextChanged(object sender, EventArgs e)
        {
            string fontName = cbbFontChu.Text.Trim();
            if (string.IsNullOrEmpty(fontName)) return;

            float currentSize = rtbVanBan.Font.Size;
            rtbVanBan.Font = new Font(fontName, currentSize);
            
            
        }


        private void cbbFontSize_TextChanged(object sender, EventArgs e)
        {
            string sizeText = cbbFontSize.Text.Trim();
            if (!float.TryParse(sizeText, out float newSize)) return;

            if (newSize <= 0) return;
                Font currentFont = rtbVanBan.Font;
                rtbVanBan.Font = new Font(currentFont.FontFamily, newSize, currentFont.Style);
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
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
