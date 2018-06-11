namespace Assessment
{
    partial class Form0
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
            this.semSelect = new System.Windows.Forms.ComboBox();
            this.subSelect = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.printReport = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // semSelect
            // 
            this.semSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.semSelect.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.semSelect.FormattingEnabled = true;
            this.semSelect.Location = new System.Drawing.Point(38, 43);
            this.semSelect.Name = "semSelect";
            this.semSelect.Size = new System.Drawing.Size(94, 25);
            this.semSelect.TabIndex = 0;
            this.semSelect.SelectedIndexChanged += new System.EventHandler(this.semSelect_SelectedIndexChanged);
            // 
            // subSelect
            // 
            this.subSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.subSelect.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subSelect.FormattingEnabled = true;
            this.subSelect.Location = new System.Drawing.Point(38, 112);
            this.subSelect.Name = "subSelect";
            this.subSelect.Size = new System.Drawing.Size(290, 25);
            this.subSelect.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button1.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(38, 189);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 37);
            this.button1.TabIndex = 2;
            this.button1.Text = "Go";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(674, 100);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2, 518);
            this.panel1.TabIndex = 3;
            // 
            // printReport
            // 
            this.printReport.BackColor = System.Drawing.Color.LightGreen;
            this.printReport.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printReport.Location = new System.Drawing.Point(1209, 24);
            this.printReport.Name = "printReport";
            this.printReport.Size = new System.Drawing.Size(93, 60);
            this.printReport.TabIndex = 4;
            this.printReport.Text = "Generate Report";
            this.printReport.UseVisualStyleBackColor = false;
            this.printReport.Click += new System.EventHandler(this.printReport_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LavenderBlush;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.semSelect);
            this.panel2.Controls.Add(this.subSelect);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(215, 204);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(366, 245);
            this.panel2.TabIndex = 5;
            // 
            // Form0
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.printReport);
            this.Controls.Add(this.panel1);
            this.Name = "Form0";
            this.Text = "Form0";
            this.Load += new System.EventHandler(this.Form0_Load);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox semSelect;
        private System.Windows.Forms.ComboBox subSelect;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button printReport;
        private System.Windows.Forms.Panel panel2;
    }
}