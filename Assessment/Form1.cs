using System;
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
    public partial class Form1 : Form
    {
        int sid = 2;
        int total_entries = 1;
        int txtBoxStartPosition = 50;
        int txtBoxStartPositionV = 25;
        int d = 48;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            panel1.Controls.Add(makeLabel(txtBoxStartPosition, txtBoxStartPositionV, 250, "Assessor"));
            panel1.Controls.Add(makeLabel(txtBoxStartPosition + 250 + d, txtBoxStartPositionV, 250, "Moderator"));
            panel1.Controls.Add(makeLabel(txtBoxStartPosition + 490 + 2 * d, txtBoxStartPositionV, 75, "Checked"));
            panel1.Controls.Add(makeLabel(txtBoxStartPosition + 575 + 3 * d, txtBoxStartPositionV, 10, "/"));
            panel1.Controls.Add(makeLabel(txtBoxStartPosition + 575 + 4 * d, txtBoxStartPositionV, 75, "Allocated"));
            panel1.Controls.Add(makeLabel(txtBoxStartPosition + 650 + 5 * d, txtBoxStartPositionV, 120, "Checked Today"));
            txtBoxStartPositionV += 30;
            load();
        }

        public static TextBox makeBox(int xLoc, int yLoc, int xSize, string t,string name, bool enabled, bool isNumber)
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

        private void save_but_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < total_entries; i++)
            {
                string ass, mod;
                int alloc, chkd, tchkd;
                TextBox txtBox = panel1.Controls["ass_" + i.ToString()] as TextBox;
                ass = txtBox.Text;
                txtBox = panel1.Controls["mod_" + i.ToString()] as TextBox;
                mod = txtBox.Text;
                txtBox = panel1.Controls["chkd_" + i.ToString()] as TextBox;
                chkd = Int32.Parse(txtBox.Text);
                txtBox = panel1.Controls["tchkd_" + i.ToString()] as TextBox;
                if (txtBox.Text == "")
                {
                    tchkd = 0;
                    txtBox.Text = "0";
                }
                else
                    tchkd = Int32.Parse(txtBox.Text);
                txtBox = panel1.Controls["alloc_" + i.ToString()] as TextBox;
                if (txtBox.Text == "")
                {
                    alloc = 0;
                    txtBox.Text = "0";
                }
                else
                    alloc = Int32.Parse(txtBox.Text);

                string mDbPath = Application.StartupPath + "/paperassessment.db";
                if (!File.Exists(mDbPath))
                {
                    SQLiteConnection.CreateFile(mDbPath);
                }

                SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=" + mDbPath + ";Version=3;");
                m_dbConnection.Open();
                string sql;
                SQLiteCommand command;
                sql = "SELECT todayChecked FROM allocation WHERE sid = " + sid + " AND id = " + i + ";";
                command = new SQLiteCommand(sql, m_dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();
                int actual_add = 0;
                while (reader.Read())
                    actual_add = tchkd - (int)reader["todayChecked"];
                chkd = chkd + actual_add;
                sql = "UPDATE allocation SET assessor = '" + ass + "', moderator = '" + mod + "', allocated = " + alloc + ", checked = " + chkd + ", todayChecked = " + tchkd + " WHERE sid =" + sid + " AND id = " + i + ";";
                command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
                txtBox = panel1.Controls["chkd_" + i.ToString()] as TextBox;
                txtBox.Text = chkd.ToString();
            }
        }

        private void new_chkd_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(new_chkd.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                new_chkd.Text = new_chkd.Text.Remove(new_chkd.Text.Length - 1);
            }
        }

        private void new_alloc_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(new_alloc.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                new_alloc.Text = new_alloc.Text.Remove(new_alloc.Text.Length - 1);
            }
        }

        private void new_tchkd_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(new_tchkd.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                new_tchkd.Text = new_tchkd.Text.Remove(new_tchkd.Text.Length - 1);
            }
        }

        private void addNew_Click(object sender, EventArgs e)
        {
            string mDbPath = Application.StartupPath + "/paperassessment.db";
            if (!File.Exists(mDbPath))
            {
                SQLiteConnection.CreateFile(mDbPath);
            }

            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=" + mDbPath + ";Version=3;");
            m_dbConnection.Open();

            string sql = "CREATE TABLE IF NOT EXISTS allocation (sid int, id int, assessor varchar(50), moderator varchar(50), allocated int, checked int, todayChecked int);";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            string ass, mod;
            int alloc, chkd, tchkd;
            TextBox txtBox = newPanel.Controls["new_ass"] as TextBox;
            ass = txtBox.Text;
            txtBox = newPanel.Controls["new_mod"] as TextBox;
            mod = txtBox.Text;
            txtBox = newPanel.Controls["new_chkd"] as TextBox;
            if (txtBox.Text == "")
                chkd = 0;
            else
                chkd = Int32.Parse(txtBox.Text);
            txtBox = newPanel.Controls["new_tchkd"] as TextBox;
            if (txtBox.Text == "")
                tchkd = 0;
            else
                tchkd = Int32.Parse(txtBox.Text);
            txtBox = newPanel.Controls["new_alloc"] as TextBox;
            if (txtBox.Text == "")
                alloc = 0;
            else
                alloc = Int32.Parse(txtBox.Text);

            if (ass == "")
            {
                MessageBox.Show("Please Enter Assessor's Name!", "Alert!");
                return;
            }

            if (chkd < tchkd)
            {
                MessageBox.Show("Papers checked today cannot be less than total papers!", "Alert!");
                return;
            }
            sql = "INSERT into allocation (sid, id, assessor, moderator, allocated, checked, todayChecked) values (" + sid + ", " + total_entries + ", '" + ass + "', '" + mod + "', " + alloc + ", " + chkd + ", " + tchkd + ");";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            m_dbConnection.Close();
            load();

            new_ass.Text = "";
            new_mod.Text = "";
            new_chkd.Text = "";
            new_tchkd.Text = "";
            new_alloc.Text = "";
        }

        public void load() {

            string mDbPath = Application.StartupPath + "/paperassessment.db";
            if (!File.Exists(mDbPath))
            {
                SQLiteConnection.CreateFile(mDbPath);
            }

            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=" + mDbPath + ";Version=3;");
            m_dbConnection.Open();

            string sql = "CREATE TABLE IF NOT EXISTS allocation (sid int, id int, assessor varchar(50), moderator varchar(50), allocated int, checked int, todayChecked int);";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            sql = "SELECT * FROM allocation where sid = " + sid + " AND id >= " + total_entries + " ORDER BY id";

            command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            
            while (reader.Read())
            {
                int t_id = (int)reader["id"];
                string t_ass = (string)reader["assessor"];
                string t_mod = (string)reader["moderator"];
                int t_all = (int)reader["allocated"];
                int t_chkd = (int)reader["checked"];
                int t_tchkd = (int)reader["todayChecked"];
                panel1.Controls.Add(makeBox(txtBoxStartPosition, txtBoxStartPositionV, 250, t_ass, "ass_" + t_id.ToString(), true, false));
                panel1.Controls.Add(makeBox(txtBoxStartPosition + 250 + d, txtBoxStartPositionV, 250, t_mod, "mod_" + t_id.ToString(), true, false));
                panel1.Controls.Add(makeBox(txtBoxStartPosition + 500 + 2 * d, txtBoxStartPositionV, 50, t_chkd.ToString(), "chkd_" + t_id.ToString(), false, true));
                panel1.Controls.Add(makeLabel(txtBoxStartPosition + 575 + 3 * d, txtBoxStartPositionV, 10, "/"));
                panel1.Controls.Add(makeBox(txtBoxStartPosition + 585 + 4 * d, txtBoxStartPositionV, 50, t_all.ToString(), "alloc_" + t_id.ToString(), true, true));
                panel1.Controls.Add(makeBox(txtBoxStartPosition + 665 + 5 * d, txtBoxStartPositionV, 50, t_tchkd.ToString(), "tchkd_" + t_id.ToString(), true, true));
                txtBoxStartPositionV += 30;
                total_entries++;
            }
            m_dbConnection.Close();
            newPanel.Location = new Point(0, txtBoxStartPositionV);
        }
    }
}
