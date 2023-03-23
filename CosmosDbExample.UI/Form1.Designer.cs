namespace CosmosDbExample.UI
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
            btnPriceCheaper = new Button();
            btnSupplier = new Button();
            btnProductName = new Button();
            textBoxPrice = new TextBox();
            textBoxSupplier = new TextBox();
            textBoxProductName = new TextBox();
            listBox1 = new ListBox();
            label1 = new Label();
            btnImport = new Button();
            SuspendLayout();
            // 
            // btnPriceCheaper
            // 
            btnPriceCheaper.BackColor = Color.Orange;
            btnPriceCheaper.Font = new Font("Segoe Print", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnPriceCheaper.ForeColor = SystemColors.ButtonHighlight;
            btnPriceCheaper.Location = new Point(50, 202);
            btnPriceCheaper.Name = "btnPriceCheaper";
            btnPriceCheaper.Size = new Size(338, 37);
            btnPriceCheaper.TabIndex = 1;
            btnPriceCheaper.Text = "Select Products that cheaper than -> ";
            btnPriceCheaper.UseVisualStyleBackColor = false;
            btnPriceCheaper.Click += btnPriceCheaper_Click;
            // 
            // btnSupplier
            // 
            btnSupplier.BackColor = Color.Orange;
            btnSupplier.Font = new Font("Segoe Print", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnSupplier.ForeColor = SystemColors.ButtonHighlight;
            btnSupplier.Location = new Point(50, 268);
            btnSupplier.Name = "btnSupplier";
            btnSupplier.Size = new Size(338, 37);
            btnSupplier.TabIndex = 2;
            btnSupplier.Text = "Select Products for SupplierID Number ->";
            btnSupplier.UseVisualStyleBackColor = false;
            btnSupplier.Click += btnSupplier_Click;
            // 
            // btnProductName
            // 
            btnProductName.BackColor = Color.Orange;
            btnProductName.Font = new Font("Segoe Print", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnProductName.ForeColor = SystemColors.ButtonHighlight;
            btnProductName.Location = new Point(50, 335);
            btnProductName.Name = "btnProductName";
            btnProductName.Size = new Size(338, 37);
            btnProductName.TabIndex = 3;
            btnProductName.Text = "Select Products that ProductName starts with ->";
            btnProductName.UseVisualStyleBackColor = false;
            btnProductName.Click += btnProductName_Click;
            // 
            // textBoxPrice
            // 
            textBoxPrice.Font = new Font("Segoe Print", 9F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxPrice.Location = new Point(394, 205);
            textBoxPrice.Name = "textBoxPrice";
            textBoxPrice.Size = new Size(99, 34);
            textBoxPrice.TabIndex = 4;
            // 
            // textBoxSupplier
            // 
            textBoxSupplier.Font = new Font("Segoe Print", 9F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxSupplier.Location = new Point(394, 268);
            textBoxSupplier.Name = "textBoxSupplier";
            textBoxSupplier.Size = new Size(99, 34);
            textBoxSupplier.TabIndex = 5;
            // 
            // textBoxProductName
            // 
            textBoxProductName.Font = new Font("Segoe Print", 9F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxProductName.Location = new Point(394, 337);
            textBoxProductName.Name = "textBoxProductName";
            textBoxProductName.Size = new Size(99, 34);
            textBoxProductName.TabIndex = 6;
            // 
            // listBox1
            // 
            listBox1.Font = new Font("Segoe Print", 9F, FontStyle.Regular, GraphicsUnit.Point);
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 26;
            listBox1.Location = new Point(557, 78);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(345, 342);
            listBox1.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe Print", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(228, 20);
            label1.Name = "label1";
            label1.Size = new Size(424, 40);
            label1.TabIndex = 8;
            label1.Text = "Northwind Products in Cosmos DB";
            // 
            // btnImport
            // 
            btnImport.BackColor = Color.Orange;
            btnImport.Font = new Font("Segoe Print", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnImport.ForeColor = SystemColors.ButtonHighlight;
            btnImport.Location = new Point(50, 109);
            btnImport.Name = "btnImport";
            btnImport.Size = new Size(294, 40);
            btnImport.TabIndex = 9;
            btnImport.Text = "Import Products from Northwind";
            btnImport.UseVisualStyleBackColor = false;
            btnImport.Click += btnImport_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkCyan;
            ClientSize = new Size(964, 450);
            Controls.Add(btnImport);
            Controls.Add(label1);
            Controls.Add(listBox1);
            Controls.Add(textBoxProductName);
            Controls.Add(textBoxSupplier);
            Controls.Add(textBoxPrice);
            Controls.Add(btnProductName);
            Controls.Add(btnSupplier);
            Controls.Add(btnPriceCheaper);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnPriceCheaper;
        private Button btnSupplier;
        private Button btnProductName;
        private TextBox textBoxPrice;
        private TextBox textBoxSupplier;
        private TextBox textBoxProductName;
        private ListBox listBox1;
        private Label label1;
        private Button btnImport;
    }
}