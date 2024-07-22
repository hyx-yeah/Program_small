namespace Hyx_NotePad
{
    partial class FindReplaceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindReplaceForm));
            this.Replacelabel = new System.Windows.Forms.Label();
            this.FindLabel = new System.Windows.Forms.Label();
            this.FindtextBox = new System.Windows.Forms.TextBox();
            this.ReplacetextBox = new System.Windows.Forms.TextBox();
            this.NextOne = new System.Windows.Forms.Button();
            this.ReplaceCur = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.Findbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Replacelabel
            // 
            this.Replacelabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Replacelabel.Image = global::Hyx_NotePad.Properties.Resources.替换__1_;
            this.Replacelabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Replacelabel.Location = new System.Drawing.Point(30, 60);
            this.Replacelabel.Name = "Replacelabel";
            this.Replacelabel.Size = new System.Drawing.Size(64, 31);
            this.Replacelabel.TabIndex = 1;
            this.Replacelabel.Text = "替换";
            this.Replacelabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FindLabel
            // 
            this.FindLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FindLabel.Image = global::Hyx_NotePad.Properties.Resources.查找1;
            this.FindLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FindLabel.Location = new System.Drawing.Point(30, 18);
            this.FindLabel.Name = "FindLabel";
            this.FindLabel.Size = new System.Drawing.Size(64, 32);
            this.FindLabel.TabIndex = 0;
            this.FindLabel.Text = "查找";
            this.FindLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FindtextBox
            // 
            this.FindtextBox.BackColor = System.Drawing.SystemColors.HighlightText;
            this.FindtextBox.Location = new System.Drawing.Point(101, 26);
            this.FindtextBox.Name = "FindtextBox";
            this.FindtextBox.Size = new System.Drawing.Size(182, 21);
            this.FindtextBox.TabIndex = 2;
            // 
            // ReplacetextBox
            // 
            this.ReplacetextBox.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ReplacetextBox.Location = new System.Drawing.Point(100, 67);
            this.ReplacetextBox.Name = "ReplacetextBox";
            this.ReplacetextBox.Size = new System.Drawing.Size(182, 21);
            this.ReplacetextBox.TabIndex = 3;
            // 
            // NextOne
            // 
            this.NextOne.BackColor = System.Drawing.Color.LightBlue;
            this.NextOne.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NextOne.Location = new System.Drawing.Point(33, 140);
            this.NextOne.Name = "NextOne";
            this.NextOne.Size = new System.Drawing.Size(75, 23);
            this.NextOne.TabIndex = 4;
            this.NextOne.Text = "下一处";
            this.NextOne.UseVisualStyleBackColor = false;
            this.NextOne.Click += new System.EventHandler(this.NextOne_Click);
            // 
            // ReplaceCur
            // 
            this.ReplaceCur.BackColor = System.Drawing.Color.LightBlue;
            this.ReplaceCur.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ReplaceCur.Location = new System.Drawing.Point(126, 140);
            this.ReplaceCur.Name = "ReplaceCur";
            this.ReplaceCur.Size = new System.Drawing.Size(75, 23);
            this.ReplaceCur.TabIndex = 5;
            this.ReplaceCur.Text = "替换";
            this.ReplaceCur.UseVisualStyleBackColor = false;
            this.ReplaceCur.Click += new System.EventHandler(this.ReplaceCur_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.LightBlue;
            this.button3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.Location = new System.Drawing.Point(216, 140);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "全部替换";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Findbutton
            // 
            this.Findbutton.BackColor = System.Drawing.Color.LightBlue;
            this.Findbutton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Findbutton.Location = new System.Drawing.Point(33, 111);
            this.Findbutton.Name = "Findbutton";
            this.Findbutton.Size = new System.Drawing.Size(249, 23);
            this.Findbutton.TabIndex = 7;
            this.Findbutton.Text = "查找";
            this.Findbutton.UseVisualStyleBackColor = false;
            this.Findbutton.Click += new System.EventHandler(this.Findbutton_Click);
            // 
            // FindReplaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 175);
            this.Controls.Add(this.Findbutton);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.ReplaceCur);
            this.Controls.Add(this.NextOne);
            this.Controls.Add(this.ReplacetextBox);
            this.Controls.Add(this.FindtextBox);
            this.Controls.Add(this.Replacelabel);
            this.Controls.Add(this.FindLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FindReplaceForm";
            this.Text = "查找替换";
            this.Load += new System.EventHandler(this.FindReplaceForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label FindLabel;
        private System.Windows.Forms.Label Replacelabel;
        private System.Windows.Forms.Button NextOne;
        private System.Windows.Forms.Button ReplaceCur;
        private System.Windows.Forms.Button button3;
        public System.Windows.Forms.TextBox FindtextBox;
        public System.Windows.Forms.TextBox ReplacetextBox;
        private System.Windows.Forms.Button Findbutton;
    }
}