namespace Assessment
{
    partial class Form2
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.aySel = new System.Windows.Forms.ComboBox();
            this.scSel = new System.Windows.Forms.ComboBox();
            this.exSel = new System.Windows.Forms.ComboBox();
            this.braSel = new System.Windows.Forms.ComboBox();
            this.semSel = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LavenderBlush;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.semSel);
            this.panel1.Controls.Add(this.braSel);
            this.panel1.Controls.Add(this.exSel);
            this.panel1.Controls.Add(this.scSel);
            this.panel1.Controls.Add(this.aySel);
            this.panel1.Location = new System.Drawing.Point(492, 150);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(531, 330);
            this.panel1.TabIndex = 0;
            // 
            // aySel
            // 
            this.aySel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.aySel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aySel.FormattingEnabled = true;
            this.aySel.Location = new System.Drawing.Point(165, 25);
            this.aySel.Name = "aySel";
            this.aySel.Size = new System.Drawing.Size(200, 25);
            this.aySel.TabIndex = 0;
            this.aySel.SelectedIndexChanged += new System.EventHandler(this.aySel_SelectedIndexChanged);
            // 
            // scSel
            // 
            this.scSel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.scSel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scSel.FormattingEnabled = true;
            this.scSel.Location = new System.Drawing.Point(165, 74);
            this.scSel.Name = "scSel";
            this.scSel.Size = new System.Drawing.Size(200, 25);
            this.scSel.TabIndex = 1;
            // 
            // exSel
            // 
            this.exSel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.exSel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exSel.FormattingEnabled = true;
            this.exSel.Location = new System.Drawing.Point(165, 120);
            this.exSel.Name = "exSel";
            this.exSel.Size = new System.Drawing.Size(200, 25);
            this.exSel.TabIndex = 2;
            // 
            // braSel
            // 
            this.braSel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.braSel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.braSel.FormattingEnabled = true;
            this.braSel.Location = new System.Drawing.Point(165, 168);
            this.braSel.Name = "braSel";
            this.braSel.Size = new System.Drawing.Size(200, 25);
            this.braSel.TabIndex = 3;
            // 
            // semSel
            // 
            this.semSel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.semSel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.semSel.FormattingEnabled = true;
            this.semSel.Location = new System.Drawing.Point(165, 215);
            this.semSel.Name = "semSel";
            this.semSel.Size = new System.Drawing.Size(200, 25);
            this.semSel.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button1.Location = new System.Drawing.Point(239, 267);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 34);
            this.button1.TabIndex = 5;
            this.button1.Text = "Go";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.panel1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox semSel;
        private System.Windows.Forms.ComboBox braSel;
        private System.Windows.Forms.ComboBox exSel;
        private System.Windows.Forms.ComboBox scSel;
        private System.Windows.Forms.ComboBox aySel;
    }
}