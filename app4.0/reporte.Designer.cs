namespace app4._0
{
    partial class reporte
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
            this.btnXLSX = new System.Windows.Forms.Button();
            this.btnCSV = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.SuspendLayout();
            // 
            // btnXLSX
            // 
            this.btnXLSX.Location = new System.Drawing.Point(55, 155);
            this.btnXLSX.Name = "btnXLSX";
            this.btnXLSX.Size = new System.Drawing.Size(94, 34);
            this.btnXLSX.TabIndex = 7;
            this.btnXLSX.Text = "XLSX";
            this.btnXLSX.UseVisualStyleBackColor = true;
            this.btnXLSX.Click += new System.EventHandler(this.btnXLSX_Click);
            // 
            // btnCSV
            // 
            this.btnCSV.Location = new System.Drawing.Point(55, 90);
            this.btnCSV.Name = "btnCSV";
            this.btnCSV.Size = new System.Drawing.Size(94, 34);
            this.btnCSV.TabIndex = 6;
            this.btnCSV.Text = "CSV";
            this.btnCSV.UseVisualStyleBackColor = true;
            this.btnCSV.Click += new System.EventHandler(this.btnCSV_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(55, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 34);
            this.button1.TabIndex = 5;
            this.button1.Text = "TXT";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvReport
            // 
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport.Location = new System.Drawing.Point(218, 5);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.Size = new System.Drawing.Size(560, 420);
            this.dgvReport.TabIndex = 4;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnXLSX);
            this.Controls.Add(this.btnCSV);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvReport);
            this.Name = "Form3";
            this.Text = "Generar Reporte";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnXLSX;
        private System.Windows.Forms.Button btnCSV;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvReport;
    }
}