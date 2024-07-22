using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hyx_NotePad
{
    public partial class FindReplaceForm : Form
    {
        //定义一个Form1类型的变量接收主窗体的引用，以便后续调用Form1中的控件
        private Form1 mainForm;
        private static FindReplaceForm instance;
        private int lastFoundIndex = -1;

        private FindReplaceForm(Form1 frm)
        {
            InitializeComponent();
            this.mainForm = frm;
        }

        public static FindReplaceForm GetInstance(Form1 frm)
        {
            if (instance == null)
            {
                instance = new FindReplaceForm(frm);
            }
            return instance;
        }

        private void FindReplaceForm_Load(object sender, EventArgs e)
        {

        }
        public string GetFindBoxText() { return FindtextBox.Text; }
        public string GetReplaceBoxText() { return ReplacetextBox.Text; }
        private void HighlightText(string searchText, RichTextBox richTextBox)
        {
            int index = 0;
            while (index < richTextBox.Text.LastIndexOf(searchText))
            {
                richTextBox.Find(searchText, index, richTextBox.TextLength, RichTextBoxFinds.None);
                richTextBox.SelectionBackColor = Color.LightBlue;
                index = richTextBox.Text.IndexOf(searchText, index) + 1;
            }
        }

        private void ReplaceCur_Click(object sender, EventArgs e)
        {
            RichTextBox richTextBox = this.mainForm.curRichTextBox;
            string searchText = GetFindBoxText();
            string replaceText = GetReplaceBoxText();

            // 查找并替换
            int index = richTextBox.Text.IndexOf(searchText);
            if (index != -1)
            {
                richTextBox.Text = richTextBox.Text.Remove(index, searchText.Length).Insert(index, replaceText);
            }

        }

        private void Findbutton_Click(object sender, EventArgs e)
        {
            RichTextBox richTextBox = this.mainForm.curRichTextBox;
            string searchText = GetFindBoxText();
            if (!string.IsNullOrEmpty(searchText))
            {
                // Highlight all occurrences of the search text
                HighlightText(searchText, richTextBox);

                // Scroll to the first occurrence
                int firstIndex = richTextBox.Text.IndexOf(searchText);
                if (firstIndex >= 0)
                    richTextBox.Select(firstIndex, searchText.Length);
                else
                    MessageBox.Show("未找到匹配的文本。", "查找", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //if (this.mainForm.tabControl1.SelectedTab != null && this.mainForm.tabControl1.SelectedTab.Controls.Count > 0)
            //{
            //    if (this.mainForm.tabControl1.SelectedTab.Controls[0] is RichTextBox richTextBox)
            //    {
            //        string searchText = GetFindBoxText();
            //        int index = richTextBox.Find(searchText, richTextBox.SelectionStart + richTextBox.SelectionLength, RichTextBoxFinds.None);
            //        if (index != -1)
            //        {
            //            richTextBox.Select(index, searchText.Length);
            //            richTextBox.ScrollToCaret();
            //            richTextBox.Focus();
            //            richTextBox.SelectionBackColor = Color.Yellow;
            //        }
            //        else
            //        {
            //            MessageBox.Show("未找到匹配的文本。");
            //        }
            //    }
            //}
        }

        private void NextOne_Click(object sender, EventArgs e)
        {
            RichTextBox richTextBox = this.mainForm.curRichTextBox;
            string searchText = GetFindBoxText();
            int currentIndex = richTextBox.Find(searchText, lastFoundIndex + 1, RichTextBoxFinds.None);

            if (currentIndex == -1)
            {
                if (lastFoundIndex == -1)
                {
                    MessageBox.Show("没有找到匹配的字符", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("已经到达文档末尾", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                // 重置上一次查找的索引
                lastFoundIndex = -1;
            }
            else
            {
                lastFoundIndex = currentIndex;
                richTextBox.SelectionStart = currentIndex;
                richTextBox.SelectionLength = searchText.Length;
                richTextBox.ScrollToCaret();
                richTextBox.Focus();
            }

            //string searchText = GetFindBoxText(); // 获取要查找的字符串
            //RichTextBox richTextBox = this.mainForm.curRichTextBox;
            //int startIndex =richTextBox.Text.IndexOf(searchText, richTextBox.SelectionStart + richTextBox.SelectionLength);

            //if (startIndex != -1)
            //{
            //    // 找到匹配项
            //    richTextBox.Select(startIndex, searchText.Length); // 选择匹配项
            //    richTextBox.ScrollToCaret(); // 滚动到匹配项位置
            //    richTextBox.Focus(); // 焦点移到文本框以确保用户可以看到匹配项
            //}
            //else
            //{
            //    // 没有找到匹配项
            //    MessageBox.Show("未找到匹配项。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RichTextBox richTextBox = this.mainForm.curRichTextBox;
            string searchText = GetFindBoxText();
            string replaceText = GetReplaceBoxText();

            // 遍历整个文档，将所有匹配的文本替换为指定的文本
            richTextBox.Text = richTextBox.Text.Replace(searchText, replaceText);

        }
    }
}
