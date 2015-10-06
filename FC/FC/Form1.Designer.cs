namespace FC
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_calculate = new System.Windows.Forms.Button();
            this.button_addSI = new System.Windows.Forms.Button();
            this.panel_SI = new System.Windows.Forms.Panel();
            this.textBox_mainSI = new System.Windows.Forms.TextBox();
            this.button_add = new System.Windows.Forms.Button();
            this.textBoxmainSiDeg = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel_SI.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_calculate
            // 
            this.button_calculate.Location = new System.Drawing.Point(606, 208);
            this.button_calculate.Name = "button_calculate";
            this.button_calculate.Size = new System.Drawing.Size(143, 210);
            this.button_calculate.TabIndex = 8;
            this.button_calculate.Text = "Сalculate";
            this.button_calculate.UseVisualStyleBackColor = true;
            this.button_calculate.Click += new System.EventHandler(this.button_calculate_Click);
            // 
            // button_addSI
            // 
            this.button_addSI.Location = new System.Drawing.Point(606, 12);
            this.button_addSI.Name = "button_addSI";
            this.button_addSI.Size = new System.Drawing.Size(143, 47);
            this.button_addSI.TabIndex = 9;
            this.button_addSI.Text = "addSI";
            this.button_addSI.UseVisualStyleBackColor = true;
            this.button_addSI.Click += new System.EventHandler(this.button_addSI_Click);
            // 
            // panel_SI
            // 
            this.panel_SI.Controls.Add(this.richTextBox1);
            this.panel_SI.Controls.Add(this.textBoxmainSiDeg);
            this.panel_SI.Controls.Add(this.button_add);
            this.panel_SI.Controls.Add(this.textBox_mainSI);
            this.panel_SI.Location = new System.Drawing.Point(494, 12);
            this.panel_SI.Name = "panel_SI";
            this.panel_SI.Size = new System.Drawing.Size(255, 406);
            this.panel_SI.TabIndex = 10;
            this.panel_SI.Visible = false;
            // 
            // textBox_mainSI
            // 
            this.textBox_mainSI.Location = new System.Drawing.Point(6, 66);
            this.textBox_mainSI.Multiline = true;
            this.textBox_mainSI.Name = "textBox_mainSI";
            this.textBox_mainSI.Size = new System.Drawing.Size(100, 28);
            this.textBox_mainSI.TabIndex = 0;
            // 
            // button_add
            // 
            this.button_add.Location = new System.Drawing.Point(31, 238);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(75, 23);
            this.button_add.TabIndex = 1;
            this.button_add.Text = "add";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // textBoxmainSiDeg
            // 
            this.textBoxmainSiDeg.Location = new System.Drawing.Point(133, 74);
            this.textBoxmainSiDeg.Name = "textBoxmainSiDeg";
            this.textBoxmainSiDeg.Size = new System.Drawing.Size(100, 20);
            this.textBoxmainSiDeg.TabIndex = 2;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(5, 116);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(228, 96);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(761, 430);
            this.Controls.Add(this.panel_SI);
            this.Controls.Add(this.button_addSI);
            this.Controls.Add(this.button_calculate);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel_SI.ResumeLayout(false);
            this.panel_SI.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_calculate;
        private System.Windows.Forms.Button button_addSI;
        private System.Windows.Forms.Panel panel_SI;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.TextBox textBox_mainSI;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox textBoxmainSiDeg;
    }
}

