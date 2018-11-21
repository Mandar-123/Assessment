namespace Assessment
{
    partial class Form3
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
            this.newPanel = new System.Windows.Forms.Panel();
            this.addNew = new System.Windows.Forms.Button();
            this.new_phn = new System.Windows.Forms.TextBox();
            this.new_exp = new System.Windows.Forms.TextBox();
            this.new_coll = new System.Windows.Forms.TextBox();
            this.new_name = new System.Windows.Forms.TextBox();
            this.backBut = new System.Windows.Forms.Button();
            this.saveBut = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.newPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LavenderBlush;
            this.panel1.Controls.Add(this.newPanel);
            this.panel1.Location = new System.Drawing.Point(75, 77);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1216, 620);
            this.panel1.TabIndex = 0;
            // 
            // newPanel
            // 
            this.newPanel.Controls.Add(this.saveBut);
            this.newPanel.Controls.Add(this.backBut);
            this.newPanel.Controls.Add(this.addNew);
            this.newPanel.Controls.Add(this.new_phn);
            this.newPanel.Controls.Add(this.new_exp);
            this.newPanel.Controls.Add(this.new_coll);
            this.newPanel.Controls.Add(this.new_name);
            this.newPanel.Location = new System.Drawing.Point(0, 426);
            this.newPanel.Name = "newPanel";
            this.newPanel.Size = new System.Drawing.Size(1216, 138);
            this.newPanel.TabIndex = 0;
            // 
            // addNew
            // 
            this.addNew.BackColor = System.Drawing.Color.LightSkyBlue;
            this.addNew.Location = new System.Drawing.Point(1150, 0);
            this.addNew.Name = "addNew";
            this.addNew.Size = new System.Drawing.Size(50, 28);
            this.addNew.TabIndex = 4;
            this.addNew.Text = "Add";
            this.addNew.UseVisualStyleBackColor = false;
            this.addNew.Click += new System.EventHandler(this.addNew_Click);
            // 
            // new_phn
            // 
            this.new_phn.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.new_phn.Location = new System.Drawing.Point(990, 0);
            this.new_phn.Name = "new_phn";
            this.new_phn.Size = new System.Drawing.Size(130, 25);
            this.new_phn.TabIndex = 3;
            // 
            // new_exp
            // 
            this.new_exp.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.new_exp.Location = new System.Drawing.Point(860, 0);
            this.new_exp.Name = "new_exp";
            this.new_exp.Size = new System.Drawing.Size(100, 25);
            this.new_exp.TabIndex = 2;
            // 
            // new_coll
            // 
            this.new_coll.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.new_coll.Location = new System.Drawing.Point(330, 0);
            this.new_coll.Name = "new_coll";
            this.new_coll.Size = new System.Drawing.Size(500, 25);
            this.new_coll.TabIndex = 1;
            // 
            // new_name
            // 
            this.new_name.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.new_name.Location = new System.Drawing.Point(50, 0);
            this.new_name.Name = "new_name";
            this.new_name.Size = new System.Drawing.Size(250, 25);
            this.new_name.TabIndex = 0;
            // 
            // backBut
            // 
            this.backBut.BackColor = System.Drawing.Color.LightSkyBlue;
            this.backBut.Location = new System.Drawing.Point(483, 75);
            this.backBut.Name = "backBut";
            this.backBut.Size = new System.Drawing.Size(100, 40);
            this.backBut.TabIndex = 5;
            this.backBut.Text = "Back";
            this.backBut.UseVisualStyleBackColor = false;
            // 
            // saveBut
            // 
            this.saveBut.BackColor = System.Drawing.Color.LightSkyBlue;
            this.saveBut.Location = new System.Drawing.Point(633, 75);
            this.saveBut.Name = "saveBut";
            this.saveBut.Size = new System.Drawing.Size(100, 40);
            this.saveBut.TabIndex = 6;
            this.saveBut.Text = "Save";
            this.saveBut.UseVisualStyleBackColor = false;
            this.saveBut.Click += new System.EventHandler(this.saveBut_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.panel1);
            this.Name = "Form3";
            this.Text = "Paper Assesment";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.panel1.ResumeLayout(false);
            this.newPanel.ResumeLayout(false);
            this.newPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel newPanel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox new_name;
        private System.Windows.Forms.TextBox new_exp;
        private System.Windows.Forms.TextBox new_coll;
        private System.Windows.Forms.TextBox new_phn;
        private System.Windows.Forms.Button addNew;
        private System.Windows.Forms.Button saveBut;
        private System.Windows.Forms.Button backBut;
    }
}