namespace DelegatesAndEvents
{
    partial class Form_Main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.do_magic_btn = new System.Windows.Forms.Button();
            this.richTextBox_output = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // do_magic_btn
            // 
            this.do_magic_btn.Location = new System.Drawing.Point(642, 32);
            this.do_magic_btn.Name = "do_magic_btn";
            this.do_magic_btn.Size = new System.Drawing.Size(75, 23);
            this.do_magic_btn.TabIndex = 0;
            this.do_magic_btn.Text = "Do Magic!";
            this.do_magic_btn.UseVisualStyleBackColor = true;
            this.do_magic_btn.Click += new System.EventHandler(this.do_magic_btn_Click);
            // 
            // richTextBox_output
            // 
            this.richTextBox_output.Location = new System.Drawing.Point(12, 92);
            this.richTextBox_output.Name = "richTextBox_output";
            this.richTextBox_output.Size = new System.Drawing.Size(519, 346);
            this.richTextBox_output.TabIndex = 1;
            this.richTextBox_output.Text = "";
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.richTextBox_output);
            this.Controls.Add(this.do_magic_btn);
            this.Name = "Form_Main";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button do_magic_btn;
        private System.Windows.Forms.RichTextBox richTextBox_output;
    }
}

