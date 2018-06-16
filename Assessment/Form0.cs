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
using OfficeOpenXml;

namespace Assessment
{
    public partial class Form0 : Form
    {
        string s, acedemicYear, exam, branch, mDbPath;
        public Form0(string ay, string se, string ex, string br)
        {
            InitializeComponent();
            this.s = se;
            this.acedemicYear = ay;
            this.exam = ex;
            this.branch = br;
            this.mDbPath = Application.StartupPath + "\\Databases\\" + acedemicYear + "\\" + exam + "\\" + branch + "\\paperassessment.db";
        }

        private void Form0_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            semSelect.Items.Add("Sem 3");
            semSelect.Items.Add("Sem 4");
            semSelect.Items.Add("Sem 5");
            semSelect.Items.Add("Sem 6");
            doit();
            semSelect.SelectedItem= s;
            semSelect_SelectedIndexChanged(sender, e);
        }

        public void doit()
        {
            if (!File.Exists(mDbPath))
            {
                string dir = Application.StartupPath + "\\Databases\\" + acedemicYear + "\\" + exam + "\\" + branch;
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                SQLiteConnection.CreateFile(mDbPath);
            }

            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=" + mDbPath + ";Version=3;");
            m_dbConnection.Open();

            string sql = "CREATE TABLE IF NOT EXISTS subject (id int PRIMARY KEY, name varchar(50) UNIQUE, sem int, todayDone int, sf varchar(10), total int);";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            int num = command.ExecuteNonQuery();
            if (num != -1)
            {
                if (branch == "CMPN")
                    fillCMPN();
                else
                    fillETRX();
            }

            sql = "CREATE TABLE IF NOT EXISTS allocation (sid int, id int, assessor varchar(50), moderator varchar(50), allocated int, checked int, todayChecked int, PRIMARY KEY(sid, id), UNIQUE(sid, assessor));";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            int i = 3;
            int y = 0;
            while (i < 7)
            {
                sql = "SELECT * FROM subject WHERE sem = " + i + " ORDER BY id;";
                command = new SQLiteCommand(sql, m_dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();
                Label btn = makeLabel(20, 54 + y, 60, "SEM" + i.ToString(), "White");
                panel3.Controls.Add(btn);
                string sf;
                int t, s = 0;
                while (reader.Read())
                {
                    sf = (string)reader["sf"];
                    t = (int)reader["todayDone"];

                    if (t == 1)
                        btn = makeLabel(114 + s, 54 + y, 60, sf, "green");
                    else
                        btn = makeLabel(114 + s, 54 + y, 60, sf, "red");
                    panel3.Controls.Add(btn);
                    s = s + 80;
                }
                y = y + 40;
                i = i + 1;
            }

        }
        public void fillCMPN()
        {
            string sql;
            sql = "INSERT INTO subject (id, name, sem, todayDone, sf, total) VALUES (1, 'Applied Mathematics 3', 3, 0, 'AM 3', 0);";
            exec(sql);
            sql = "INSERT INTO subject (id, name, sem, todayDone, sf, total) VALUES (2, 'Digital Logic Design and Analysis', 3, 0, 'DLDA', 0);";
            exec(sql);
            sql = "INSERT INTO subject (id, name, sem, todayDone, sf, total) VALUES (3, 'Discrete Mathematics', 3, 0, 'DIS', 0);";
            exec(sql);
            sql = "INSERT INTO subject (id, name, sem, todayDone, sf, total) VALUES (4, 'Electronic Circuits and Communication Fundamentals', 3, 0, 'ECCF', 0);";
            exec(sql);
            sql = "INSERT INTO subject (id, name, sem, todayDone, sf, total) VALUES (5, 'Data Structures', 3, 0, 'DS', 0);";
            exec(sql);
            sql = "INSERT INTO subject (id, name, sem, todayDone, sf, total) VALUES (6, 'Applied Mathematics 4', 4, 0, 'AM 4', 0);";
            exec(sql);
            sql = "INSERT INTO subject (id, name, sem, todayDone, sf, total) VALUES (7, 'Analysis of Algorithms', 4, 0, 'AOA', 0);";
            exec(sql);
            sql = "INSERT INTO subject (id, name, sem, todayDone, sf, total) VALUES (8, 'Computer Organization and Architecture', 4, 0, 'COA', 0);";
            exec(sql);
            sql = "INSERT INTO subject (id, name, sem, todayDone, sf, total) VALUES (9, 'Computer Graphics', 4, 0, 'CG', 0);";
            exec(sql);
            sql = "INSERT INTO subject (id, name, sem, todayDone, sf, total) VALUES (10, 'Operating Systems', 4, 0, 'OS', 0);";
            exec(sql);
            sql = "INSERT INTO subject (id, name, sem, todayDone, sf, total) VALUES (11, 'Microprocessor', 5, 0, 'MP', 0);";
            exec(sql);
            sql = "INSERT INTO subject (id, name, sem, todayDone, sf, total) VALUES (12, 'Database Management System', 5, 0, 'DBMS', 0);";
            exec(sql);
            sql = "INSERT INTO subject (id, name, sem, todayDone, sf, total) VALUES (13, 'Computer Network', 5, 0, 'CN', 0);";
            exec(sql);
            sql = "INSERT INTO subject (id, name, sem, todayDone, sf, total) VALUES (14, 'Theory of Computer Science', 5, 0, 'TCS', 0);";
            exec(sql);
            sql = "INSERT INTO subject (id, name, sem, todayDone, sf, total) VALUES (15, 'Department Level Optional Course 1', 5, 0, 'OC 1', 0);";
            exec(sql);
            sql = "INSERT INTO subject (id, name, sem, todayDone, sf, total) VALUES (16, 'Software Engineering', 6, 0, 'SE', 0);";
            exec(sql);
            sql = "INSERT INTO subject (id, name, sem, todayDone, sf, total) VALUES (17, 'System Programming and Compiler Construction', 6, 0, 'SPCC', 0);";
            exec(sql);
            sql = "INSERT INTO subject (id, name, sem, todayDone, sf, total) VALUES (18, 'Data Warehousing & Mining', 6, 0, 'DWM', 0);";
            exec(sql);
            sql = "INSERT INTO subject (id, name, sem, todayDone, sf, total) VALUES (19, 'Cryptography & System Security', 6, 0, 'CSS', 0);";
            exec(sql);
            sql = "INSERT INTO subject (id, name, sem, todayDone, sf, total) VALUES (20, 'Department Level Optional Course 2', 6, 0, 'OC 2', 0);";
            exec(sql);
        }
        
        public void fillETRX()
        {
            string sql;
            sql = "INSERT INTO subject (id, name, sem, todayDone, sf, total) VALUES (1, 'Applied Mathematics 3', 3, 0, 'AM3', 0);";
            exec(sql);
            sql = "INSERT INTO subject (id, name, sem, todayDone, sf, total) VALUES (2, 'Electronic Devices and Circuits 1', 3, 0, 'EDC1', 0);";
            exec(sql);
            sql = "INSERT INTO subject (id, name, sem, todayDone, sf, total) VALUES (3, 'Digital Circuit Design', 3, 0, 'DCD', 0);";
            exec(sql);
            sql = "INSERT INTO subject (id, name, sem, todayDone, sf, total) VALUES (4, 'Electrical Network Analysis and Synthesis', 3, 0, 'ENAS', 0);";
            exec(sql);
            sql = "INSERT INTO subject (id, name, sem, todayDone, sf, total) VALUES (5, 'Electronics Instruments and Measurement', 3, 0, 'EIM', 0);";
            exec(sql);
            sql = "INSERT INTO subject (id, name, sem, todayDone, sf, total) VALUES (6, 'Applied Mathematics 4', 4, 0, 'AM4', 0);";
            exec(sql);
            sql = "INSERT INTO subject (id, name, sem, todayDone, sf, total) VALUES (7, 'Electronic Devices and Circuits 2', 4, 0, 'EDC2', 0);";
            exec(sql);
            sql = "INSERT INTO subject (id, name, sem, todayDone, sf, total) VALUES (8, 'Microprocessors and Applications', 4, 0, 'MP', 0);";
            exec(sql);
            sql = "INSERT INTO subject (id, name, sem, todayDone, sf, total) VALUES (9, 'Digital System Design', 4, 0, 'DSD', 0);";
            exec(sql);
            sql = "INSERT INTO subject (id, name, sem, todayDone, sf, total) VALUES (10, 'Principles of Communication Engineering', 4, 0, 'PCE', 0);";
            exec(sql);
            sql = "INSERT INTO subject (id, name, sem, todayDone, sf, total) VALUES (11, 'Linear Control Systems', 4, 0, 'LCS', 0);";
            exec(sql);
            sql = "INSERT INTO subject (id, name, sem, todayDone, sf, total) VALUES (12, 'Micro-controllers and Applications', 5, 0, 'MCA', 0);";
            exec(sql);
            sql = "INSERT INTO subject (id, name, sem, todayDone, sf, total) VALUES (13, 'Digital Communication', 5, 0, 'DC', 0);";
            exec(sql);
            sql = "INSERT INTO subject (id, name, sem, todayDone, sf, total) VALUES (14, 'Engineering Electromagnetics', 5, 0, 'EE', 0);";
            exec(sql);
            sql = "INSERT INTO subject (id, name, sem, todayDone, sf, total) VALUES (15, 'Design with Linear Integrated Circuits', 5, 0, 'DLIC', 0);";
            exec(sql);
            sql = "INSERT INTO subject (id, name, sem, todayDone, sf, total) VALUES (16, 'Department Level Optional courses 1', 5, 0, 'DOC1', 0);";
            exec(sql);
            sql = "INSERT INTO subject (id, name, sem, todayDone, sf, total) VALUES (17, 'Embedded System and RTOS', 6, 0, 'ES', 0);";
            exec(sql);
            sql = "INSERT INTO subject (id, name, sem, todayDone, sf, total) VALUES (18, 'Computer Communication Network', 6, 0, 'CN', 0);";
            exec(sql);
            sql = "INSERT INTO subject (id, name, sem, todayDone, sf, total) VALUES (19, 'VLSI Design', 6, 0, 'VLSI', 0);";
            exec(sql);
            sql = "INSERT INTO subject (id, name, sem, todayDone, sf, total) VALUES (20, 'Signals and systems', 6, 0, 'SS', 0);";
            exec(sql);
            sql = "INSERT INTO subject (id, name, sem, todayDone, sf, total) VALUES (21, 'Department Level Optional courses 2', 6, 0, 'DOC2', 0);";
            exec(sql);
        }
        public void exec(string sql)
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=" + mDbPath + ";Version=3;");
            m_dbConnection.Open();
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            m_dbConnection.Close();
        }

        public static Label makeLabel(int xLoc, int yLoc, int xSize, string t, string color)
        {
            Label newLabel = new Label();
            newLabel.Location = new System.Drawing.Point(xLoc, yLoc);
            newLabel.Size = new System.Drawing.Size(xSize, 30);
            newLabel.Font = new Font("Arial", 11);
            if (color == "green")
                newLabel.BackColor = Color.Green;
            else if (color == "red")
                newLabel.BackColor = Color.Red;
            else newLabel.BackColor = Color.LavenderBlush;
            newLabel.AutoSize = false;
            newLabel.Text = t;
            return newLabel;
        }
        private void semSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            subSelect.Items.Clear();
            int sem = semSelect.Text[4] - '0';
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=" + mDbPath + ";Version=3;");
            m_dbConnection.Open();

            string sql = "SELECT name FROM subject WHERE sem = " + sem + ";";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                string n = (string)reader["name"];
                subSelect.Items.Add(n);
            }
            subSelect.SelectedIndex = 0;
            subSelect.Focus();
            getTotalPapers(subSelect.Text);
        }

        private void subSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            getTotalPapers(subSelect.Text);
        }

        public void getTotalPapers(string sub)
        {
            string subject = subSelect.Text;
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=" + mDbPath + ";Version=3;");
            m_dbConnection.Open();

            string sql = "SELECT total FROM subject WHERE name = '" + sub + "';";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            int n = 0;
            while (reader.Read())
            {
                n = (int)reader["total"];
            }
            totalToCheck.Text = n.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string subject = subSelect.Text;
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=" + mDbPath + ";Version=3;");
            m_dbConnection.Open();

            string sql = "SELECT id FROM subject WHERE name = '" + subject + "';";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            int n = 0;
            while (reader.Read())
            {
                n = (int)reader["id"];
            }
            string sem = semSelect.Text;
            int ttc = Int32.Parse(totalToCheck.Text);
            Form1 fr = new Form1(n, subject, sem, mDbPath, acedemicYear, exam, branch, ttc);
            this.Hide();
            fr.ShowDialog();
            this.Close();
        }

        private void printReport_Click(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string f = path + "/Todays Reports/" + branch + ".xlsx";
            bool res = WriteExcel(f, mDbPath);
            if (res == false)
                return;
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=" + mDbPath + ";Version=3;");
            m_dbConnection.Open();
            string sql = "UPDATE allocation SET todayChecked = 0;";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            sql = "UPDATE subject SET  todayDone = 0;";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            m_dbConnection.Close();
            MessageBox.Show("Today's Report Generated !", "Message");
        }
        public bool WriteExcel(string filename, string database)
        {
            if (File.Exists(filename))
            {
                try
                {
                    File.Delete(filename);
                }
                catch
                {
                    MessageBox.Show("Please Close the previous Report !");
                    return false;
                }       
            }
            FileInfo file = new FileInfo(filename);
            SQLiteConnection dbconnect = new SQLiteConnection("Data Source=" + database + ";Version=3;");

            using (var p = new ExcelPackage(file))
            {
                int max2 = 8, max3 = 8;
                dbconnect.Open();
                int row = 1;
                var ws = p.Workbook.Worksheets.Add("Report");
                for (int i = 3; i <= 6; i++)
                {
                    string sql = "SELECT name, id FROM subject WHERE sem = " + i.ToString() + ";";
                    SQLiteCommand query = new SQLiteCommand(sql, dbconnect);
                    var reader = query.ExecuteReader();

                    ws.Cells[row, 1, row, 6].Merge = true;
                    ws.Cells[row, 1, row, 6].Value = "SEMESTER " + i.ToString();
                    ws.Cells[row, 1, row, 6].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    ws.Cells[row, 1, row, 6].Style.Font.Size = 14;
                    ws.Cells[row, 1, row, 6].Style.Font.Bold = true;
                    row = row + 2;

                    while (reader.Read())
                    {
                        ws.Cells[row, 1, row, 6].Merge = true;
                        ws.Cells[row, 1, row, 6].Value = reader[0];
                        ws.Cells[row, 1, row, 6].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        ws.Cells[row, 1, row, 6].Style.Font.Size = 12;
                        ws.Cells[row, 1, row, 6].Style.Font.Bold = true;
                        row++;

                        sql = "SELECT assessor, moderator, allocated, checked, todayChecked FROM allocation WHERE sid = "+ reader[1] + ";";
                        SQLiteCommand query2 = new SQLiteCommand(sql, dbconnect);
                        var reader2 = query2.ExecuteReader();
                        ws.Cells[row, 1].Value = "Sr No.";
                        ws.Cells[row, 1].AutoFitColumns();
                        ws.Cells[row, 2].Value = "Assessor";
                        ws.Cells[row, 2].AutoFitColumns();
                        ws.Cells[row, 3].Value = "Moderator";
                        ws.Cells[row, 3].AutoFitColumns();
                        ws.Cells[row, 4].Value = "Allocated";
                        ws.Cells[row, 4].AutoFitColumns();
                        ws.Cells[row, 5].Value = "Checked";
                        ws.Cells[row, 5].AutoFitColumns();
                        ws.Cells[row, 6].Value = "TodayChecked";
                        ws.Cells[row, 6].AutoFitColumns();
                        ws.Cells[row, 1, row, 6].Style.Font.Bold = true;
                        row++;

                        int c = 1;
                        while (reader2.Read())
                        {
                            ws.Cells[row, 1].Value = c.ToString();
                            int t = ((string)reader2[0]).Length;
                            ws.Cells[row, 2].Value = reader2[0];
                            if (t > max2)
                            {
                                ws.Cells[row, 2].AutoFitColumns();
                                max2 = t;
                            }
                            t = ((string)reader2[1]).Length;
                            ws.Cells[row, 3].Value = reader2[1];
                            if (t > max3)
                            {
                                ws.Cells[row, 3].AutoFitColumns();
                                max3 = t;
                            }
                            ws.Cells[row, 4].Value = reader2[2];
                            ws.Cells[row, 5].Value = reader2[3];
                            ws.Cells[row, 6].Value = reader2[4];
                            row++;
                            c++;
                        }

                        row = row + 2;
                    }

                    row = row + 1;
                }
                dbconnect.Close();
                p.Save();
            }
            return true;
        }
    }
}
