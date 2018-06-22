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
using OfficeOpenXml.Style;

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
            this.mDbPath = Application.StartupPath + "\\Databases\\" + acedemicYear + "\\" + exam + "\\" + branch + "\\"+ se +"\\paperassessment.db";
        }

        private void Form0_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            semSelect.Items.Add(s);
            doit();
            semSelect.SelectedItem = s;
            semSelect_SelectedIndexChanged(sender, e);
        }

        public void doit()
        {
            if (!File.Exists(mDbPath))
            {
                string dir = Application.StartupPath + "\\Databases\\" + acedemicYear + "\\" + exam + "\\" + branch + "\\" + s;
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                SQLiteConnection.CreateFile(mDbPath);
            }

            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=" + mDbPath + ";Version=3;");
            m_dbConnection.Open();

            string sql = "CREATE TABLE IF NOT EXISTS subject (id int PRIMARY KEY, name varchar(50) UNIQUE, sem int, todayDone int, todayModDone int, sf varchar(10), total int);";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            int num = command.ExecuteNonQuery();
            if (num != -1)
            {
                copySubjects();
            }
            sql = "CREATE TABLE IF NOT EXISTS repdate (date varchar(50), time varchar(50))";
            command = new SQLiteCommand(sql, m_dbConnection);
            int r = command.ExecuteNonQuery();
            if(r != -1)
            {
                sql = "INSERT INTO repdate (time) VALUES ('NA')";
            }
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            sql = "CREATE TABLE IF NOT EXISTS allocation (sid int, id int, assessor varchar(50), moderator varchar(50), allocated int, checked int, todayChecked int, moderated int, todayModerated int, PRIMARY KEY(sid, id), UNIQUE(sid, assessor));";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            sql = "SELECT * FROM repdate;";
            command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader1 = command.ExecuteReader();
            while(reader1.Read())
                repDate.Text = "Last Report Generated on: " + (string)reader1["time"];
            int y = 0;
            int i = s[4] - '0';
            sql = "SELECT * FROM subject WHERE sem = " + i + " ORDER BY id;";
            command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();

            panel3.Controls.Add(makeLabel(10, 10, 70, "Subject", "LavenderBlush"));
            panel3.Controls.Add(makeLabel(80, 10, 70, "Allocated", "LavenderBlush"));
            panel3.Controls.Add(makeLabel(150, 10, 70, "Checked", "LavenderBlush"));
            panel3.Controls.Add(makeLabel(220, 10, 80, "Moderated", "LavenderBlush"));
            panel3.Controls.Add(makeLabel(300, 10, 110, "Checking Entry", "LavenderBlush"));
            panel3.Controls.Add(makeLabel(410, 10, 130, "Moderation Entry", "LavenderBlush"));

            string sf;
            int tc,tm,t;
            while (reader.Read())
            {
                y = y + 30;
                sf = (string)reader["sf"];
                tc = (int)reader["todayDone"];
                tm = (int)reader["todayModDone"];
                t = (int)reader["total"];
                sql = "SELECT * FROM allocation WHERE sid = " + (int)reader["id"] + ";";
                SQLiteCommand command2 = new SQLiteCommand(sql, m_dbConnection);
                SQLiteDataReader reader2 = command2.ExecuteReader();
                int sumC = 0, sumA = 0, sumM = 0;
                while (reader2.Read())
                {
                    sumC = sumC + (int)reader2["checked"];
                    sumA = sumA + (int)reader2["allocated"];
                    sumM = sumM + (int)reader2["moderated"];
                }
                panel3.Controls.Add(makeLabel(10, 10 + y, 70, sf, "LavenderBlush"));
                panel3.Controls.Add(makeLabel(80, 10 + y, 70, sumA.ToString() + "/" + t.ToString(), "LavenderBlush"));
                panel3.Controls.Add(makeLabel(150, 10 + y, 70, sumC.ToString() + "/" + sumA.ToString(), "LavenderBlush"));
                panel3.Controls.Add(makeLabel(220, 10 + y, 80, sumM.ToString() + "/" + sumC.ToString(), "LavenderBlush"));
                if(tc == 1)
                {
                    Label l = makeLabel(300, 10 + y, 110, "✓", "LavenderBlush");
                    l.ForeColor = Color.Green;
                    panel3.Controls.Add(l);
                } else
                {
                    Label l = makeLabel(300, 10 + y, 110, "X", "LavenderBlush");
                    l.ForeColor = Color.Red;
                    panel3.Controls.Add(l);
                }
                if (tm == 1)
                {
                    Label l = makeLabel(410, 10 + y, 130, "✓", "LavenderBlush");
                    l.ForeColor = Color.Green;
                    panel3.Controls.Add(l);
                }
                else
                {
                    Label l = makeLabel(410, 10 + y, 130, "X", "LavenderBlush");
                    l.ForeColor = Color.Red;
                    panel3.Controls.Add(l);
                }
            }
        }

        public void copySubjects()
        {
            int semest = s[4] - '0';
            string sql = "SELECT * FROM subjects WHERE dept = '"+ branch + "' AND sem = " + semest + " ORDER BY id;";
            SQLiteConnection m_dbConnection1 = new SQLiteConnection("Data Source=" + Application.StartupPath + "\\subjects.db" + ";Version=3;");
            m_dbConnection1.Open();
            SQLiteCommand command1 = new SQLiteCommand(sql, m_dbConnection1);
            SQLiteDataReader reader = command1.ExecuteReader();
            SQLiteConnection m_dbConnection2 = new SQLiteConnection("Data Source=" + mDbPath + ";Version=3;");

            m_dbConnection2.Open();
            int i = 0;
            while (reader.Read())
            {
                sql = "INSERT INTO subject(id, name, sem, todayDone, todayModDone, sf , total) VALUES ("+ i +", '"+ reader[2].ToString() +"', " + semest + ", 0, 0, '" + reader[4].ToString() + "' , 0)";
                SQLiteCommand command2 = new SQLiteCommand(sql, m_dbConnection2);
                command2.ExecuteNonQuery();
                i++;
            }
            m_dbConnection1.Close();
            m_dbConnection2.Close();
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
            newLabel.BorderStyle = BorderStyle.FixedSingle;
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
            Form1 fr = new Form1(n, subject, sem, mDbPath, acedemicYear, exam, branch, ttc, "Checking");
            this.Hide();
            fr.ShowDialog();
            this.Close();
        }

        private void printReport_Click(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string f = path + "/Reports/" + acedemicYear + "\\" + exam + "\\" + branch + "\\" + s + "/" + DateTime.Today.Date.Day + "-" + DateTime.Today.Date.Month + "-" + DateTime.Today.Date.Year + ".xlsx";
            bool res = WriteExcel(f, mDbPath);
            if (res == false)
                return;
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=" + mDbPath + ";Version=3;");
            m_dbConnection.Open();
            string sql = "UPDATE allocation SET todayChecked = 0, todayModerated = 0;";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            sql = "UPDATE subject SET todayDone = 0, todayModDone = 0;";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            sql = "UPDATE repdate SET time = '" + DateTime.Now + "'";
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
            string dir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/Reports/" + acedemicYear + "\\" + exam + "\\" + branch + "\\" + s;
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            FileInfo file = new FileInfo(filename);
            SQLiteConnection dbconnect = new SQLiteConnection("Data Source=" + database + ";Version=3;");

            using (var p = new ExcelPackage(file))
            {
                int i = s[4] - '0';
                int max2 = 10, max3 = 10;
                dbconnect.Open();
                int row = 1;
                var ws = p.Workbook.Worksheets.Add("Report");
                string sql = "SELECT name, id FROM subject WHERE sem = " + i.ToString() + ";";
                SQLiteCommand query = new SQLiteCommand(sql, dbconnect);
                var reader = query.ExecuteReader();

                ws.Cells[row, 1, row, 8].Merge = true;
                ws.Cells[row, 1, row, 8].Value = branch + " ("+ exam + ") " + "SEM " + i.ToString() + " - " + DateTime.Today.Date.Day + "/" + DateTime.Today.Date.Month + "/" + DateTime.Today.Date.Year;
                ws.Cells[row, 1, row, 8].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                ws.Cells[row, 1, row, 8].Style.Font.Size = 14;
                ws.Cells[row, 1, row, 8].Style.Font.Bold = true;
                row = row + 2;

                while (reader.Read())
                {
                    ws.Cells[row, 1, row, 8].Merge = true;
                    ws.Cells[row, 1, row, 8].Value = reader[0];
                    ws.Cells[row, 1, row, 8].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    ws.Cells[row, 1, row, 8].Style.Font.Size = 12;
                    ws.Cells[row, 1, row, 8].Style.Font.Bold = true;
                    row++;

                    sql = "SELECT assessor, moderator, allocated, checked, todayChecked, moderated, todayModerated FROM allocation WHERE sid = "+ reader[1] + ";";
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
                    ws.Cells[row, 5].Value = "Total Checked";
                    ws.Cells[row, 5].AutoFitColumns();
                    ws.Cells[row, 6].Value = "Checked Today";
                    ws.Cells[row, 6].AutoFitColumns();
                    ws.Cells[row, 7].Value = "Total Moderated";
                    ws.Cells[row, 7].AutoFitColumns();
                    ws.Cells[row, 8].Value = "Moderated Today";
                    ws.Cells[row, 8].AutoFitColumns();
                    makeBorderTop(ws, row);
                    makeBorderBottom(ws, row);
                    makeBorderLeft(ws, row);
                    makeBorderRight(ws, row);
                    ws.Cells[row, 1, row, 8].Style.Font.Bold = true;
                    row++;

                    int c = 1;
                    int sumA = 0, sumC = 0, sumM = 0, sumT = 0, sumTM = 0;
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
                        sumA = sumA + (int)reader2[2];
                        ws.Cells[row, 5].Value = reader2[3];
                        sumC = sumC + (int)reader2[3];
                        ws.Cells[row, 6].Value = reader2[4];
                        sumT = sumT + (int)reader2[4];
                        ws.Cells[row, 7].Value = reader2[5];
                        sumM = sumM + (int)reader2[3];
                        ws.Cells[row, 8].Value = reader2[6];
                        sumTM = sumTM + (int)reader2[4];
                        makeBorderLeft(ws, row);
                        makeBorderRight(ws, row);
                        row++;
                        c++;
                    }
                    makeBorderTop(ws, row);
                    makeBorderBottom(ws, row);
                    makeBorderLeft(ws, row);
                    makeBorderRight(ws, row);
                    ws.Cells[row, 4].Value = sumA;
                    ws.Cells[row, 5].Value = sumC;
                    ws.Cells[row, 6].Value = sumT;
                    ws.Cells[row, 7].Value = sumM;
                    ws.Cells[row, 8].Value = sumTM;
                    row = row + 2;
                }
                dbconnect.Close();
                p.Save();
            }
            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 fr = new Form2(acedemicYear, s, exam, branch);
            this.Hide();
            fr.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
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
            Form1 fr = new Form1(n, subject, sem, mDbPath, acedemicYear, exam, branch, ttc, "Moderation");
            this.Hide();
            fr.ShowDialog();
            this.Close();
        }

        public void makeBorderTop(ExcelWorksheet ws, int row)
        {
            for(int i = 1; i <=8; i++)
            {
                ws.Cells[row, i].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            }
        }
        public void makeBorderLeft(ExcelWorksheet ws, int row)
        {
            for (int i = 1; i <= 8; i++)
            {
                ws.Cells[row, i].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            }
        }
        public void makeBorderRight(ExcelWorksheet ws, int row)
        {
            for (int i = 1; i <= 8; i++)
            {
                ws.Cells[row, i].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            }
        }
        public void makeBorderBottom(ExcelWorksheet ws, int row)
        {
            for (int i = 1; i <= 8; i++)
            {
                ws.Cells[row, i].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            }
        }
    }
}
