using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net.Http.Headers;
using System.Windows.Forms.VisualStyles;
using System.IO;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace Hyx_NotePad
{
    public partial class Form1 : Form
    {
        public static Font myFont = new Font("宋体", 12);
        public static Color myColor = Color.Black;
        public RichTextBox curRichTextBox = null;
        int TabPageNumber = 1;                          //记录当前打开了几个文本文件，默认会有一个空白文件

        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            //myFontSize = 14;
            myFont = new Font(myFont.Name, 14);
            curRichTextBox.SelectionFont = myFont;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            FontChange(radioButton4, myFont, myColor);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            curRichTextBox = richTextBox1;
            curRichTextBox.SelectionFont = myFont;
            this.toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            //启动时钟进行时间的变化 对timer1进行相关设置
            this.timer1.Start();
            this.timer2.Start();

            //让字体下拉框中的内容为所有字体
            FontFamily[] fontFamilies = FontFamily.Families;

            // 遍历所有字体并将字体名称添加到ComboBox中
            foreach (FontFamily fontFamily in fontFamilies)
            {
                SelectFontName.Items.Add(fontFamily.Name);
            }

            //让字体下拉框中的内容为所有字体

            string[] FontSizeSet = {"一号","小一","二号","小二","三号","小三","四号","小四","五号","小五"
                                    ,"六号","小六","8","10","10.5","12","14","16","18","20","22","24"
                                    ,"26","28","36","48","72" };


            // 遍历所有字体并将字体名称添加到ComboBox中
            foreach (string size in FontSizeSet)
            {
                SeletFontSize.Items.Add(size);
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            curRichTextBox.TextChanged += CurRichTextBox_TextChanged;
            curRichTextBox.SelectionChanged += CurRichTextBox_SelectionChanged;
        }

        private void CurRichTextBox_SelectionChanged(object sender, EventArgs e)
        {
            int selectLen = curRichTextBox.SelectionLength;
            int Textlen = curRichTextBox.Text.Length;
            NumberInfo.Text = "字数：" + selectLen + "/" + Textlen;
        }

        private void CurRichTextBox_TextChanged(object sender, EventArgs e)
        {
            int selectLen = curRichTextBox.SelectionLength;
            int Textlen = curRichTextBox.Text.Length;
            NumberInfo.Text = "字数：" + selectLen + "/" + Textlen;
        }

        private void 字体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                //得到字体选择对话框中选择的字体，并赋值给 myFont
                myFont = fontDialog1.Font;

                //让字体框和字号框显示当前字体的信息
                SelectFontName.Text = myFont.Name;
                SeletFontSize.Text = myFont.Size.ToString();
                toolStripButton18.BackColor = myColor;

                //将 文本输入框中的字体设置为 myFont
                //int selectStart = richTextBox1.SelectionStart;
                curRichTextBox.SelectionFont = myFont;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            FontChange(radioButton1, myFont, myColor);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            FontChange(radioButton2, myFont, myColor);
        }

        private void FontChange(System.Windows.Forms.RadioButton control, Font myFont, Color myColor)
        {
            Font selectFont = new Font(control.Text, myFont.Size);
            curRichTextBox.Select(curRichTextBox.SelectionStart, curRichTextBox.SelectionLength);
            curRichTextBox.SelectionFont = selectFont;
            curRichTextBox.SelectionColor = myColor;
            curRichTextBox.Select(curRichTextBox.SelectionStart, curRichTextBox.SelectionLength);
            //这一行会使所有在richTextBox1的文字全部变成myFont的文字
            //richTextBox1.Font = myFont;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            FontChange(radioButton3, myFont, myColor);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fontname = SelectFontName.Text;
            string strsize = SeletFontSize.Text;
            float fontsize = myFont.Size;
            if (fontname == "")
            {
                fontname = myFont.Name;
            }
            if (strsize != "")
            {
                //将获取到的中文的字体大小的字符转换成 数字形式的 px值
                fontsize = StrFontSizetoDouble(strsize);
                //myFontSize = fontsize;
            }
            ////将字体和字号对应ComboBox的值作为当前的字体与字号
            myFont = new Font(fontname, fontsize);
            curRichTextBox.SelectionFont = myFont;
            curRichTextBox.SelectionColor = myColor;

        }

        private float StrFontSizetoDouble(string strsize)
        {
            float fontsize = 0;
            switch (strsize)
            {
                case "一号":
                    fontsize = 26; break;
                case "小一":
                    fontsize = 24; break;
                case "二号":
                    fontsize = 22; break;
                case "小二":
                    fontsize = 18; break;
                case "三号":
                    fontsize = 16; break;
                case "小三":
                    fontsize = 15; break;
                case "四号":
                    fontsize = 14; break;
                case "小四":
                    fontsize = 12; break;
                case "五号":
                    fontsize = Convert.ToSingle(10.5); break;
                case "小五":
                    fontsize = 9; break;
                case "六号":
                    fontsize = Convert.ToSingle(7.5); break;
                case "小六":
                    fontsize = Convert.ToSingle(6.5); break;
                default:
                    fontsize = Convert.ToSingle(strsize); break;

            }
            return fontsize;
        }

        private void toolStripComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            string fontname = SelectFontName.Text;
            string strsize = SeletFontSize.Text;
            float fontsize = myFont.Size;
            if (fontname == "")
            {
                fontname = myFont.Name;
            }
            if (strsize != "")
            {
                //将获取到的中文的字体大小的字符转换成 数字形式的 px值
                fontsize = StrFontSizetoDouble(strsize);
                //myFontSize = fontsize;
            }
            ////将字体和字号对应ComboBox的值作为当前的字体与字号
            myFont = new Font(fontname, fontsize);
            curRichTextBox.SelectionFont = myFont;
            curRichTextBox.SelectionColor = myColor;
        }

        private void radioButton13_CheckedChanged(object sender, EventArgs e)
        {
            FontChange(radioButton13, myFont, myColor);
        }

        private void toolStripButton18_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                myColor = colorDialog1.Color;
                toolStripButton18.BackColor = myColor;
                curRichTextBox.SelectionColor = myColor;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //不停监测目前字体、大小和字体颜色，以便我可以方便的修改

            // 目前这个地方有一个Bug：当选择的文字是多个字体时会出错，于是先用 try catch来解决
            try
            {
                toolStripLabel3.Text = curRichTextBox.SelectionFont.Name;
                toolStripLabel4.Text = curRichTextBox.SelectionFont.Size.ToString();
                toolStripButton18.BackColor = curRichTextBox.SelectionColor;
            }
            catch (Exception ex)
            {

            }
        }


        private void label1_Click(object sender, EventArgs e)
        {
            myColor = label1.BackColor;
            curRichTextBox.SelectionColor = myColor;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            myColor = label2.BackColor;
            curRichTextBox.SelectionColor = myColor;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            myColor = label4.BackColor;
            curRichTextBox.SelectionColor = myColor;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            myColor = label3.BackColor;
            curRichTextBox.SelectionColor = myColor;
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            //myFontSize = 14;
            myFont = new Font(myFont.Name, 14);
            curRichTextBox.SelectionFont = myFont;
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            //myFontSize = Convert.ToSingle(10.5);
            myFont = new Font(myFont.Name, Convert.ToSingle(10.5));
            curRichTextBox.SelectionFont = myFont;
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            //myFontSize = 12;
            myFont = new Font(myFont.Name, 12);
            curRichTextBox.SelectionFont = myFont;
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            //myFontSize = 9;
            myFont = new Font(myFont.Name, 9);
            curRichTextBox.SelectionFont = myFont;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            //myFontSize = 18;
            myFont = new Font(myFont.Name, 18);
            curRichTextBox.SelectionFont = myFont;
        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            //myFontSize = 24;
            myFont = new Font(myFont.Name, 24);
            curRichTextBox.SelectionFont = myFont;
        }

        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {
            //myFontSize = 32;
            myFont = new Font(myFont.Name, 32);
            curRichTextBox.SelectionFont = myFont;
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filesavepath = saveFileDialog1.FileName;
                saveFileDialog1.Filter = "Text files（*.txt）|*.txt|RTF files (*.rtf)|*.rtf|All files (*.*)|*.*";
                curRichTextBox.SaveFile(filesavepath, RichTextBoxStreamType.RichText);
            }
        }

        private void 新建ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Button btn = sender as Button
            TabPageNumber += 1;                                                 //新建一个页面后 Page数目需要加1
            String PageKey = (TabPageNumber - 1).ToString();
            tabControl1.TabPages.Add(PageKey, "yxnotes" + (TabPageNumber - 1));
            tabControl1.SelectedTab = tabControl1.TabPages[PageKey];    //将页面切换到新建的页面
            // 新建一个 RichTextBox 并让该控件的父容器为新建的页面
            curRichTextBox = new RichTextBox();
            curRichTextBox.Dock = DockStyle.Fill;                       //使RichTextBoxf填满整个Page
            curRichTextBox.HideSelection = false;                       //能够让它选中
            curRichTextBox.Parent = tabControl1.SelectedTab;

            //同时初始化这个新页面字体与颜色
            myFont = new Font("宋体", 12);
            myColor = Color.Black;
            curRichTextBox.SelectionFont = myFont;
            curRichTextBox.SelectionColor = myColor;
        }

        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void 退出ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            foreach (TabPage tabPage in tabControl1.TabPages)
            {
                // 检查每个 TabPage 中的 RichTextBox
                foreach (Control control in tabPage.Controls)
                {
                    if (control is RichTextBox richTextBox)
                    {
                        // 检查 RichTextBox 中的内容是否已更改
                        if (richTextBox.Modified)
                        {
                            // 询问用户是否保存
                            DialogResult result = MessageBox.Show($"是否保存对 \"{tabPage.Text}\" 的更改？", "提示", MessageBoxButtons.YesNoCancel);
                            if (result == DialogResult.Yes)
                            {
                                // 保存内容
                                SaveFile(richTextBox);
                            }
                            else if (result == DialogResult.Cancel)
                            {
                                // 取消退出操作
                                FormClosingEventArgs args = e as FormClosingEventArgs;
                                if (args != null)
                                {
                                    args.Cancel = true;
                                }
                                return;
                            }
                            // 如果用户选择了不保存，则继续检查下一个 TabPage
                        }
                    }
                }
            }
            this.Close();
        }

        //    foreach (TabPage tabPage in this.tabControl1.TabPages)
        //    {
        //        if (curRichTextBox != null && curRichTextBox.Modified)
        //        {
        //            // 如果有未保存的文件，弹出提示框询问是否保存
        //            DialogResult result = MessageBox.Show("有未保存的文件，是否保存？", "提示", MessageBoxButtons.YesNoCancel);
        //            if (result == DialogResult.Yes)
        //            {
        //                // 保存文件
        //                SaveFile(curRichTextBox);
        //            }
        //            else if (result == DialogResult.Cancel)
        //            {
        //                // 取消关闭操作
        //                FormClosingEventArgs args = e as FormClosingEventArgs;
        //                if (args != null)
        //                {
        //                    args.Cancel = true;
        //                }
        //                return;
        //            }
        //            // 如果选择不保存，则继续关闭操作
        //        }
        //        else {
        //            this.Close();
        //        }
        //    }
        //}

        private void SaveFile(RichTextBox richTextBox)
        {
            // 保存文件的逻辑，你可以根据需要实现
            // 这里假设 SaveFileDialog 是你保存文件的对话框
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files（*.txt）|*.txt|RTF files (*.rtf)|*.rtf|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.RichText);
            }
            else
            {
                return;
            }
        }
        private void PoenFile_Click(object sender, EventArgs e)
        {
            /*设计思路：如果当前活动的窗体就是我默认打开的窗体并且目前窗体上没有任何内容
             则直接在当前窗体打开；如果活动的窗体不是默认的窗体（即我新建了一个窗体需要
            写新的文件）则打开的文件需要在另一个新的Page页展示
            关键解决点：  1、怎么判断当前激活窗体是不是我默认的那个窗体；
                         2、另建一个Page页，新建一个RichTextBox 并让RichTextBox的父容器
                        指向新建的Page;
                        3、弹出文件选择窗体，并让选择的文件在新建的RichTextBox中显示；
                        4、让新建的Page的名称显示为文件的名称
             
             */

            // 1、如果当前活动的窗体就是我默认打开的窗体并且目前窗体上没有任何内容则直接在当前窗体打开
            if ((this.tabControl1.SelectedTab.Text != "yxnotes") || (curRichTextBox.TextLength != 0))
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Text files(*.txt)|*.txt|RTF files(*.rtf)|*.rtf|All files(.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //得到文件的名称并让page显示为文件的名称
                    String[] strList = openFileDialog.FileName.Split('\\');
                    String filename = strList[(strList.Length) - 1];
                    String[] nameList = filename.Split('.');
                    String fname = nameList[0];
                    TabPageNumber += 1;                                         //新建一个页面后 Page数目需要加1
                    String PageKey = (TabPageNumber - 1).ToString();
                    TabPage newTabPage = new TabPage();
                    newTabPage.Text = fname;
                    newTabPage.Visible = true;
                    //this.tabcontrol1.tabpages.add(pagekey, "yxnotes" + (tabpagenumber - 1));
                    //this.tabControl1.SelectedTab = tabControl1.TabPages[PageKey];    //将页面切换到新建的页面
                    // 新建一个 RichTextBox 并让该控件的父容器为新建的页面
                    curRichTextBox = new RichTextBox();
                    curRichTextBox.Dock = DockStyle.Fill;                       //使RichTextBoxf填满整个Page
                    curRichTextBox.HideSelection = false;                       //能够让它选中
                    newTabPage.Controls.Add(curRichTextBox);
                    this.tabControl1.TabPages.Add(newTabPage);
                    this.tabControl1.SelectedTab = newTabPage;
                    curRichTextBox.Parent = this.tabControl1.SelectedTab;
                    this.tabControl1.Refresh();
                    //加载需要打开的文件
                    curRichTextBox.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.RichText);

                    //FileStream fileStream = new FileStream(openFileDialog.FileName, FileMode.Open);
                    //StreamReader sr = new StreamReader(fileStream);
                    //curRichTextBox.Text = sr.ReadToEnd();
                    //sr.Close();
                    //fileStream.Close();
                }

            }
            else
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Text files(*.txt)|*.txt|RTF files(*.rtf)|*.rtf|All files(.*)|*.*";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    //得到文件的名称并让page显示为文件的名称
                    String[] strList = openFileDialog1.FileName.Split('\\');
                    String filename = strList[(strList.Length) - 1];
                    String[] nameList = filename.Split('.');
                    String fname = nameList[0];
                    this.tabControl1.SelectedTab.Text = fname;    //将当前页面的名字换成文件名
                                                                  //加载需要打开的文件
                    this.tabControl1.Refresh();
                    curRichTextBox.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.RichText);

                }

            }
        }

        private void 另存为ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            保存ToolStripMenuItem_Click(sender, e);
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            this.tabControl1.Refresh();
            this.tabControl1.Update();

        }

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab != null && tabControl1.SelectedTab.Controls.Count > 0)
            {
                if (tabControl1.SelectedTab.Controls[0] is RichTextBox richTextBox)
                {
                    richTextBox.Copy();
                }
            }
        }

        private void 剪切ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab != null && tabControl1.SelectedTab.Controls.Count > 0)
            {
                if (tabControl1.SelectedTab.Controls[0] is RichTextBox richTextBox)
                {
                    richTextBox.Cut();
                }
            }
        }

        private void 粘贴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab != null && tabControl1.SelectedTab.Controls.Count > 0)
            {
                if (tabControl1.SelectedTab.Controls[0] is RichTextBox richTextBox)
                {
                    richTextBox.Paste();
                }
            }
        }

        private void 查找ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindReplaceForm findReplaceForm = FindReplaceForm.GetInstance(this);
            findReplaceForm.TopMost = true;
            findReplaceForm.Show();
        }
    }
}
