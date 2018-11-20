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
        bool firstTime;
        public Form3(int sid, string name, string sem, string dbPath, string ay, string ex, string br, string cm)
        {
            InitializeComponent();
            this.sid = sid;
            this.name = name;
            this.total_entries = 1;
            this.txtBoxStartPosition = 50;
            this.txtBoxStartPositionV = 25;
            this.d = 48;
            this.sem = sem;
            this.mDbPath = dbPath;
            this.acedemicYear = ay;
            this.exam = ex;
            this.branch = br;
            this.cORm = cm;
            this.firstTime = true;
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

            string sql = "SELECT * FROM faculty where sid = " + sid + " AND id >= " + total_entries + " AND cORm == " + cORm + " ORDER BY id";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();

            
            while (reader.Read())
            {
                int t_id = (int)reader["id"];
                string t_name = (string)reader["name"];
                string t_college = (string)reader["college"];
                string t_exp = (string)reader["exp"];
                string t_phn = (string)reader["phn"];

                panel1.Controls.Add(makeBox(txtBoxStartPosition, txtBoxStartPositionV, 250, t_name, "name_" + t_id.ToString(), false, false));
                panel1.Controls.Add(makeBox(txtBoxStartPosition + 250 + d, txtBoxStartPositionV, 500, t_name, "coll_" + t_id.ToString(), false, false));
                panel1.Controls.Add(makeBox(txtBoxStartPosition + 750 + 2 * d, txtBoxStartPositionV, 100, t_name, "exp_" + t_id.ToString(), false, false));
                panel1.Controls.Add(makeBox(txtBoxStartPosition + 850 + 3 * d, txtBoxStartPositionV, 200, t_name, "phn_" + t_id.ToString(), false, false));
                txtBoxStartPositionV += 30;
                total_entries++;
            }

            m_dbConnection.Close();

            //newPanel.Location = new Point(0, txtBoxStartPositionV);
        }
    }
}
