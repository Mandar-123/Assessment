namespace Assessment
{
    partial class Form1
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
            this.sumT = new System.Windows.Forms.Label();
            this.sumC = new System.Windows.Forms.Label();
            this.sumA = new System.Windows.Forms.Label();
            this.addNew = new System.Windows.Forms.Button();
            this.new_tchkd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.new_alloc = new System.Windows.Forms.TextBox();
            this.new_chkd = new System.Windows.Forms.TextBox();
            this.new_mod = new System.Windows.Forms.TextBox();
            this.new_ass = new System.Windows.Forms.TextBox();
            this.save_but = new System.Windows.Forms.Button();
            this.backBut = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.newPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.LavenderBlush;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.newPanel);
            this.panel1.Location = new System.Drawing.Point(75, 77);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1216, 620);
            this.panel1.TabIndex = 0;
            // 
            // newPanel
            // 
            this.newPanel.Controls.Add(this.sumT);
            this.newPanel.Controls.Add(this.sumC);
            this.newPanel.Controls.Add(this.sumA);
            this.newPanel.Controls.Add(this.addNew);
            this.newPanel.Controls.Add(this.new_tchkd);
            this.newPanel.Controls.Add(this.label1);
            this.newPanel.Controls.Add(this.new_alloc);
            this.newPanel.Controls.Add(this.new_chkd);
            this.newPanel.Controls.Add(this.new_mod);
            this.newPanel.Controls.Add(this.new_ass);
            this.newPanel.Controls.Add(this.save_but);
            this.newPanel.Location = new System.Drawing.Point(0, 329);
            this.newPanel.Margin = new System.Windows.Forms.Padding(0);
            this.newPanel.Name = "newPanel";
            this.newPanel.Size = new System.Drawing.Size(1084, 118);
            this.newPanel.TabIndex = 1;
            // 
            // sumT
            // 
            this.sumT.AutoSize = true;
            this.sumT.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sumT.Location = new System.Drawing.Point(959, 38);
            this.sumT.Name = "sumT";
            this.sumT.Size = new System.Drawing.Size(0, 17);
            this.sumT.TabIndex = 10;
            // 
            // sumC
            // 
            this.sumC.AutoSize = true;
            this.sumC.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sumC.Location = new System.Drawing.Point(650, 38);
            this.sumC.Name = "sumC";
            this.sumC.Size = new System.Drawing.Size(0, 17);
            this.sumC.TabIndex = 9;
            // 
            // sumA
            // 
            this.sumA.AutoSize = true;
            this.sumA.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sumA.Location = new System.Drawing.Point(831, 38);
            this.sumA.Name = "sumA";
            this.sumA.Size = new System.Drawing.Size(0, 17);
            this.sumA.TabIndex = 8;
            // 
            // addNew
            // 
            this.addNew.BackColor = System.Drawing.Color.LightSkyBlue;
            this.addNew.Location = new System.Drawing.Point(1035, 0);
            this.addNew.Name = "addNew";
            this.addNew.Size = new System.Drawing.Size(50, 28);
            this.addNew.TabIndex = 7;
            this.addNew.Text = "Add";
            this.addNew.UseVisualStyleBackColor = false;
            this.addNew.Click += new System.EventHandler(this.addNew_Click);
            // 
            // new_tchkd
            // 
            this.new_tchkd.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.new_tchkd.Location = new System.Drawing.Point(955, 0);
            this.new_tchkd.Name = "new_tchkd";
            this.new_tchkd.Size = new System.Drawing.Size(50, 24);
            this.new_tchkd.TabIndex = 6;
            this.new_tchkd.TextChanged += new System.EventHandler(this.new_tchkd_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(769, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "/";
            // 
            // new_alloc
            // 
            this.new_alloc.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.new_alloc.Location = new System.Drawing.Point(827, 0);
            this.new_alloc.Name = "new_alloc";
            this.new_alloc.Size = new System.Drawing.Size(50, 24);
            this.new_alloc.TabIndex = 4;
            this.new_alloc.TextChanged += new System.EventHandler(this.new_alloc_TextChanged);
            // 
            // new_chkd
            // 
            this.new_chkd.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.new_chkd.Location = new System.Drawing.Point(646, 0);
            this.new_chkd.Margin = new System.Windows.Forms.Padding(0);
            this.new_chkd.Name = "new_chkd";
            this.new_chkd.Size = new System.Drawing.Size(50, 24);
            this.new_chkd.TabIndex = 3;
            this.new_chkd.TextChanged += new System.EventHandler(this.new_chkd_TextChanged);
            // 
            // new_mod
            // 
            this.new_mod.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.new_mod.Location = new System.Drawing.Point(348, 0);
            this.new_mod.Margin = new System.Windows.Forms.Padding(0);
            this.new_mod.Name = "new_mod";
            this.new_mod.Size = new System.Drawing.Size(250, 24);
            this.new_mod.TabIndex = 2;
            // 
            // new_ass
            // 
            this.new_ass.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.new_ass.Location = new System.Drawing.Point(50, 0);
            this.new_ass.Margin = new System.Windows.Forms.Padding(0);
            this.new_ass.Name = "new_ass";
            this.new_ass.Size = new System.Drawing.Size(250, 24);
            this.new_ass.TabIndex = 1;
            // 
            // save_but
            // 
            this.save_but.BackColor = System.Drawing.Color.LightSkyBlue;
            this.save_but.Location = new System.Drawing.Point(556, 75);
            this.save_but.Name = "save_but";
            this.save_but.Size = new System.Drawing.Size(100, 40);
            this.save_but.TabIndex = 0;
            this.save_but.Text = "Save";
            this.save_but.UseVisualStyleBackColor = false;
            this.save_but.Click += new System.EventHandler(this.save_but_Click);
            // 
            // backBut
            // 
            this.backBut.BackColor = System.Drawing.Color.LightPink;
            this.backBut.Location = new System.Drawing.Point(28, 12);
            this.backBut.Name = "backBut";
            this.backBut.Size = new System.Drawing.Size(44, 30);
            this.backBut.TabIndex = 1;
            this.backBut.Text = "<--";
            this.backBut.UseVisualStyleBackColor = false;
            this.backBut.Click += new System.EventHandler(this.backBut_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.backBut);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.newPanel.ResumeLayout(false);
            this.newPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button save_but;
        private System.Windows.Forms.Panel newPanel;
        private System.Windows.Forms.TextBox new_ass;
        private System.Windows.Forms.TextBox new_mod;
        private System.Windows.Forms.TextBox new_chkd;
        private System.Windows.Forms.TextBox new_alloc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox new_tchkd;
        private System.Windows.Forms.Button addNew;
        private System.Windows.Forms.Label sumT;
        private System.Windows.Forms.Label sumC;
        private System.Windows.Forms.Label sumA;
        private System.Windows.Forms.Button backBut;
    }
}

