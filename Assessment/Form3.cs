﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace Assessment
{
    public partial class Form3 : Form
    {
        int sid;
        int total_entries;
        int txtBoxStartPosition;
        int txtBoxStartPositionV = 25;
        int d;
        string name;
        string sem;
        string mDbPath;
        string acedemicYear, exam, branch, cORm;
        int total;

        public Form3(int sid, string name, string sem, string dbPath, string ay, string ex, string br, string cm, int total)
        {
            InitializeComponent();
            this.sid = sid;
            this.name = name;
            this.total_entries = 1;
            this.txtBoxStartPosition = 50;
            this.txtBoxStartPositionV = 25;
            this.d = 30;
            this.sem = sem;
            this.mDbPath = dbPath;
            this.acedemicYear = ay;
            this.exam = ex;
            this.branch = br;
            this.cORm = cm;
            this.total = total;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            
            Label ltop = makeLabel(75, 40, 400, name + " (" + sem + " - " + branch + ")");
            ltop.Font = new Font("Arial", 11, FontStyle.Bold);
            this.Controls.Add(ltop);
            if (cORm == "Moderation")
                panel1.Controls.Add(makeLabel(txtBoxStartPosition, txtBoxStartPositionV, 250, "Moderators Name"));
            else
                panel1.Controls.Add(makeLabel(txtBoxStartPosition, txtBoxStartPositionV, 250, "Assessor Name"));

            panel1.Controls.Add(makeLabel(txtBoxStartPosition + 250 + d, txtBoxStartPositionV, 500, "College"));

            panel1.Controls.Add(makeLabel(txtBoxStartPosition + 750 + 2 * d, txtBoxStartPositionV, 100, "Experience (Year's)"));

            panel1.Controls.Add(makeLabel(txtBoxStartPosition + 850 + 3 * d, txtBoxStartPositionV, 200, "Tel. No."));

            txtBoxStartPositionV += 30;

            load();
        }

        private void saveBut_Click(object sender, EventArgs e)
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=" + mDbPath + ";Version=3;");
            m_dbConnection.Open();

            string sql;
            SQLiteCommand command;
            for (int i = 1; i < total_entries; i++)
            {
                string tname, tcoll, texp, tphn;
                TextBox txtBox1 = panel1.Controls["name_" + i.ToString()] as TextBox;
                TextBox txtBox2 = panel1.Controls["coll_" + i.ToString()] as TextBox;
                TextBox txtBox3 = panel1.Controls["exp_" + i.ToString()] as TextBox;
                TextBox txtBox4 = panel1.Controls["phn_" + i.ToString()] as TextBox;

                tname = txtBox1.Text;
                tcoll = txtBox2.Text;
                texp = txtBox3.Text;
                tphn = txtBox4.Text;

                if (tname == "")
                {
                    MessageBox.Show("Please Enter Faculty Name!", "Alert!");
                    txtBox1.Focus();
                    return;
                }

                if (tcoll == "")
                {
                    MessageBox.Show("Please Enter College Name!", "Alert!");
                    txtBox2.Focus();
                    return;
                }
                
                sql = "UPDATE faculty SET name = '" + tname + "',  college = '" + tcoll + "', exp = '" + texp + "',  phn = '" + tphn + "' WHERE sid =" + sid + " AND id = " + i + " AND cORm = '" + cORm + "';";
                command = new SQLiteCommand(sql, m_dbConnection);

                try
                {
                    command.ExecuteNonQuery();
                }
                catch (System.Exception ex)
                {
                    if (ex.Message.Contains("UNIQUE"))
                        MessageBox.Show("NOT Saved ! Faculty named '" + tname + "' Already Exists!", "Alert!");
                    m_dbConnection.Close();
                    txtBox1.Focus();
                    return;
                }
            }
            m_dbConnection.Close();

            Button tempButt = (Button)sender;
            if (tempButt.Text == "Save")
            {
                MessageBox.Show("Saved!", "Alert!");
            }
        }

        private void addNew_Click(object sender, EventArgs e)
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=" + mDbPath + ";Version=3;");
            m_dbConnection.Open();

            string name, college, experience, phone;
            TextBox txtBox1 = newPanel.Controls["new_name"] as TextBox;
            TextBox txtBox2 = newPanel.Controls["new_coll"] as TextBox;
            TextBox txtBox3 = newPanel.Controls["new_exp"] as TextBox;
            TextBox txtBox4 = newPanel.Controls["new_phn"] as TextBox;

            name = txtBox1.Text;
            college = txtBox2.Text;
            experience = txtBox3.Text;
            phone = txtBox4.Text;

            if (name == "")
            {
                MessageBox.Show("Please Enter Faculty Name!", "Alert!");
                txtBox1.Focus();
                return;
            }

            if (college == "")
            {
                MessageBox.Show("Please Enter College Name!", "Alert!");
                txtBox2.Focus();
                return;
            }
            
            string sql = "INSERT into faculty (id, sid, cORm, name, college, exp, phn) values (" + total_entries + ", " + sid + ", '" + cORm + "', '" + name + "', '" + college + "', '" + experience + "', '" +  phone + "');";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);

            try
            {
                command.ExecuteNonQuery();
            }

            catch (System.Exception ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    MessageBox.Show("Faculty named '" + name + "' Already Exists!", "Alert!");
                    txtBox1.Focus();
                }
                m_dbConnection.Close();
                return;
            }
            new_name.Text = "";
            new_coll.Text = "";
            new_exp.Text = "";
            new_phn.Text = "";
            m_dbConnection.Close();
            load();
            saveBut_Click(sender, e);
        }

        private void backBut_Click(object sender, EventArgs e)
        {
            Form1 fr = new Form1(sid, name, sem, mDbPath, acedemicYear, exam, branch, total, cORm);
            this.Hide();
            fr.ShowDialog();
            this.Close();
        }

        private void new_exp_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(new_exp.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter numbers only.");
                new_exp.Text = new_exp.Text.Remove(new_exp.Text.Length - 1);
            }
        }

        public static TextBox makeBox(int xLoc, int yLoc, int xSize, string t, string name, bool enabled, bool isNumber)
        {
            TextBox newText = new TextBox();
            newText.ReadOnly = !enabled;
            newText.Name = name;
            newText.Location = new System.Drawing.Point(xLoc, yLoc);
            newText.Size = new System.Drawing.Size(xSize, 30);
            newText.Font = new Font("Arial", 11);
            newText.Text = t;
            if (isNumber == true)
            {
                newText.TextChanged += (s, e) =>
                {
                    if (System.Text.RegularExpressions.Regex.IsMatch(newText.Text, "[^0-9]"))
                    {
                        MessageBox.Show("Please enter only numbers.");
                        newText.Text = newText.Text.Remove(newText.Text.Length - 1);
                    }
                };
            }
            return newText;
        }

        public static Label makeLabel(int xLoc, int yLoc, int xSize, string t)
        {
            Label newLabel = new Label();
            newLabel.Location = new System.Drawing.Point(xLoc, yLoc);
            newLabel.Size = new System.Drawing.Size(xSize, 30);
            newLabel.Font = new Font("Arial", 11);
            newLabel.Text = t;
            return newLabel;
        }

        public void load()
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=" + mDbPath + ";Version=3;");
            m_dbConnection.Open();

            string sql = "SELECT * FROM faculty where sid = " + sid + " AND id >= " + total_entries + " AND cORm == '" + cORm + "' ORDER BY id";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            
            while (reader.Read())
            {
                int t_id = (int)reader["id"];
                string t_name = (string)reader["name"];
                string t_college = (string)reader["college"];
                string t_exp = (string)reader["exp"];
                string t_phn = (string)reader["phn"];

                panel1.Controls.Add(makeBox(txtBoxStartPosition, txtBoxStartPositionV, 250, t_name, "name_" + t_id.ToString(), true, false));
                panel1.Controls.Add(makeBox(txtBoxStartPosition + 250 + d, txtBoxStartPositionV, 500, t_college, "coll_" + t_id.ToString(), true, false));
                panel1.Controls.Add(makeBox(txtBoxStartPosition + 750 + 2 * d, txtBoxStartPositionV, 100, t_exp, "exp_" + t_id.ToString(), true, true));
                panel1.Controls.Add(makeBox(txtBoxStartPosition + 850 + 3 * d, txtBoxStartPositionV, 130, t_phn, "phn_" + t_id.ToString(), true, false));
                txtBoxStartPositionV += 30;
                total_entries++;
            }

            m_dbConnection.Close();

            newPanel.Location = new Point(0, txtBoxStartPositionV);
        }
    }
}
