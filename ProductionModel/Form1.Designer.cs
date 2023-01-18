namespace ProductionModel
{
    partial class Form1
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.clear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox4_rules = new System.Windows.Forms.ListBox();
            this.label_res_reverse_output = new System.Windows.Forms.Label();
            this.listBox5 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(241, 420);
            this.listBox1.TabIndex = 0;
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 16;
            this.listBox2.Items.AddRange(new object[] {
            "Выбранные факты:"});
            this.listBox2.Location = new System.Drawing.Point(280, 69);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(241, 164);
            this.listBox2.TabIndex = 1;
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            this.listBox2.DoubleClick += new System.EventHandler(this.listBox2_DoubleClick);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button1.Location = new System.Drawing.Point(280, 436);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(241, 58);
            this.button1.TabIndex = 2;
            this.button1.Text = "Прямой вывод";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.ItemHeight = 16;
            this.listBox3.Items.AddRange(new object[] {
            "Результат прямого вывода:"});
            this.listBox3.Location = new System.Drawing.Point(280, 239);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(241, 164);
            this.listBox3.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button2.Location = new System.Drawing.Point(831, 249);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(241, 58);
            this.button2.TabIndex = 4;
            this.button2.Text = "Обратный вывод";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // clear
            // 
            this.clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.clear.Location = new System.Drawing.Point(815, 436);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(241, 58);
            this.clear.TabIndex = 5;
            this.clear.Text = "Очистить";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(619, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 25);
            this.label1.TabIndex = 10;
            this.label1.Text = "Тип вывода";
            // 
            // listBox4_rules
            // 
            this.listBox4_rules.FormattingEnabled = true;
            this.listBox4_rules.ItemHeight = 16;
            this.listBox4_rules.Items.AddRange(new object[] {
            "Использованные правила:"});
            this.listBox4_rules.Location = new System.Drawing.Point(550, 69);
            this.listBox4_rules.Name = "listBox4_rules";
            this.listBox4_rules.Size = new System.Drawing.Size(241, 324);
            this.listBox4_rules.TabIndex = 12;
            // 
            // label_res_reverse_output
            // 
            this.label_res_reverse_output.AutoSize = true;
            this.label_res_reverse_output.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label_res_reverse_output.Location = new System.Drawing.Point(826, 323);
            this.label_res_reverse_output.Name = "label_res_reverse_output";
            this.label_res_reverse_output.Size = new System.Drawing.Size(230, 25);
            this.label_res_reverse_output.TabIndex = 15;
            this.label_res_reverse_output.Text = "Результат будет здесь";
            // 
            // listBox5
            // 
            this.listBox5.FormattingEnabled = true;
            this.listBox5.ItemHeight = 16;
            this.listBox5.Items.AddRange(new object[] {
            "Выбор целевого факта:"});
            this.listBox5.Location = new System.Drawing.Point(831, 76);
            this.listBox5.Name = "listBox5";
            this.listBox5.Size = new System.Drawing.Size(241, 164);
            this.listBox5.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 517);
            this.Controls.Add(this.listBox5);
            this.Controls.Add(this.label_res_reverse_output);
            this.Controls.Add(this.listBox4_rules);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listBox3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox4_rules;
        private System.Windows.Forms.Label label_res_reverse_output;
        private System.Windows.Forms.ListBox listBox5;
    }
}

