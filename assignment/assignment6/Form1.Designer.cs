namespace assignment6
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            button1 = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            groupBox1 = new GroupBox();
            label8 = new Label();
            label7 = new Label();
            comboBox1 = new ComboBox();
            button4 = new Button();
            label2 = new Label();
            button2 = new Button();
            button3 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            groupBox2 = new GroupBox();
            dataGridView1 = new DataGridView();
            label9 = new Label();
            bindingSource1 = new BindingSource(components);
            form1BindingSource = new BindingSource(components);
            form1BindingSource1 = new BindingSource(components);
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)form1BindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)form1BindingSource1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(771, 29);
            button1.Name = "button1";
            button1.Size = new Size(118, 37);
            button1.TabIndex = 0;
            button1.Text = "查询订单";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(351, 62);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(336, 30);
            textBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(43, 59);
            label1.Name = "label1";
            label1.Size = new Size(38, 31);
            label1.TabIndex = 2;
            label1.Text = "以";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(button4);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Location = new Point(38, 110);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(912, 150);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(175, 60);
            label8.Name = "label8";
            label8.Size = new Size(134, 31);
            label8.TabIndex = 5;
            label8.Text = "为查询标准";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(187, 59);
            label7.Name = "label7";
            label7.Size = new Size(0, 24);
            label7.TabIndex = 4;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "商品名称", "金额", "客户名称" });
            comboBox1.Location = new Point(87, 59);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(82, 32);
            comboBox1.TabIndex = 3;
            comboBox1.Text = "id";
            // 
            // button4
            // 
            button4.Location = new Point(771, 100);
            button4.Name = "button4";
            button4.Size = new Size(112, 34);
            button4.TabIndex = 8;
            button4.Text = "删除订单";
            button4.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(12, 274);
            label2.Name = "label2";
            label2.Size = new Size(144, 39);
            label2.TabIndex = 5;
            label2.Text = "订单明细:";
            label2.Click += label2_Click;
            // 
            // button2
            // 
            button2.Location = new Point(389, 47);
            button2.Name = "button2";
            button2.Size = new Size(112, 34);
            button2.TabIndex = 6;
            button2.Text = "创建订单";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(413, 64);
            button3.Name = "button3";
            button3.Size = new Size(8, 8);
            button3.TabIndex = 7;
            button3.Text = "删除订单";
            button3.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(679, 36);
            button5.Name = "button5";
            button5.Size = new Size(8, 8);
            button5.TabIndex = 9;
            button5.Text = "button5";
            button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(746, 59);
            button6.Name = "button6";
            button6.Size = new Size(8, 8);
            button6.TabIndex = 10;
            button6.Text = "button6";
            button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.Location = new Point(672, 46);
            button7.Name = "button7";
            button7.Size = new Size(112, 34);
            button7.TabIndex = 11;
            button7.Text = "修改订单";
            button7.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dataGridView1);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(button7);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(groupBox1);
            groupBox2.Controls.Add(button2);
            groupBox2.Location = new Point(74, 27);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(990, 713);
            groupBox2.TabIndex = 12;
            groupBox2.TabStop = false;
            groupBox2.Text = "groupBox2";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(38, 361);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.RowTemplate.Height = 32;
            dataGridView1.Size = new Size(869, 225);
            dataGridView1.TabIndex = 13;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(146, 46);
            label9.Name = "label9";
            label9.Size = new Size(110, 31);
            label9.TabIndex = 12;
            label9.Text = "功能区：";
            // 
            // form1BindingSource
            // 
            form1BindingSource.DataSource = typeof(Form1);
            // 
            // form1BindingSource1
            // 
            form1BindingSource1.DataSource = typeof(Form1);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1188, 772);
            Controls.Add(groupBox2);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button3);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)form1BindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)form1BindingSource1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private TextBox textBox1;
        private Label label1;
        private GroupBox groupBox1;
        private Label label2;
        private ComboBox comboBox1;
        private Label label8;
        private Label label7;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private GroupBox groupBox2;
        private Label label9;
        private BindingSource bindingSource1;
        private DataGridView dataGridView1;
        private BindingSource form1BindingSource1;
        private BindingSource form1BindingSource;
    }

}