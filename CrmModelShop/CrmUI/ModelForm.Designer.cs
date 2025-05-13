namespace CrmUI
{
    partial class ModelForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CashBoxCount = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.ProductsCount = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.CustomersCount = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.CustomerSpeed = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.CashBoxSpeed = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.CashBoxCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductsCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomersCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CashBoxSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(577, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Запустить модель";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(433, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Количество касс";
            // 
            // CashBoxCount
            // 
            this.CashBoxCount.Location = new System.Drawing.Point(586, 0);
            this.CashBoxCount.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.CashBoxCount.Name = "CashBoxCount";
            this.CashBoxCount.Size = new System.Drawing.Size(120, 23);
            this.CashBoxCount.TabIndex = 2;
            this.CashBoxCount.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.CashBoxCount.ValueChanged += new System.EventHandler(this.CashBoxCount_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(433, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Количество товара";
            // 
            // ProductsCount
            // 
            this.ProductsCount.Location = new System.Drawing.Point(586, 27);
            this.ProductsCount.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.ProductsCount.Name = "ProductsCount";
            this.ProductsCount.Size = new System.Drawing.Size(120, 23);
            this.ProductsCount.TabIndex = 2;
            this.ProductsCount.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.ProductsCount.ValueChanged += new System.EventHandler(this.ProductsCount_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(433, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Количество покупателей";
            // 
            // CustomersCount
            // 
            this.CustomersCount.Location = new System.Drawing.Point(586, 53);
            this.CustomersCount.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.CustomersCount.Name = "CustomersCount";
            this.CustomersCount.Size = new System.Drawing.Size(120, 23);
            this.CustomersCount.TabIndex = 2;
            this.CustomersCount.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.CustomersCount.ValueChanged += new System.EventHandler(this.CustomersCount_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(433, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "Таймаут покупки";
            // 
            // CustomerSpeed
            // 
            this.CustomerSpeed.Location = new System.Drawing.Point(586, 81);
            this.CustomerSpeed.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.CustomerSpeed.Name = "CustomerSpeed";
            this.CustomerSpeed.Size = new System.Drawing.Size(120, 23);
            this.CustomerSpeed.TabIndex = 2;
            this.CustomerSpeed.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.CustomerSpeed.ValueChanged += new System.EventHandler(this.CustomerSpeed_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(433, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "Таймаут кассы";
            // 
            // CashBoxSpeed
            // 
            this.CashBoxSpeed.Location = new System.Drawing.Point(586, 110);
            this.CashBoxSpeed.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.CashBoxSpeed.Name = "CashBoxSpeed";
            this.CashBoxSpeed.Size = new System.Drawing.Size(120, 23);
            this.CashBoxSpeed.TabIndex = 2;
            this.CashBoxSpeed.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.CashBoxSpeed.ValueChanged += new System.EventHandler(this.CashBoxSpeed_ValueChanged);
            // 
            // ModelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 450);
            this.Controls.Add(this.CashBoxSpeed);
            this.Controls.Add(this.CustomerSpeed);
            this.Controls.Add(this.CustomersCount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ProductsCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CashBoxCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "ModelForm";
            this.Text = "ModelForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ModelForm_FormClosing);
            this.Load += new System.EventHandler(this.ModelForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CashBoxCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductsCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomersCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CashBoxSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button1;
        private Label label1;
        private NumericUpDown CashBoxCount;
        private Label label2;
        private NumericUpDown ProductsCount;
        private Label label3;
        private NumericUpDown CustomersCount;
        private Label label4;
        private NumericUpDown CustomerSpeed;
        private Label label5;
        private NumericUpDown CashBoxSpeed;
    }
}