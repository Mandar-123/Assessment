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
        string s;
        public Form0(string se)
        {
            InitializeComponent();
            this.s = se;
        }

        private void Form0_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            semSelect.Items.Add("Sem 3");
            semSelect.Items.Add("Sem 4");
            semSelect.Items.Add("Sem 5");
            semSelect.Items.Add("Sem 6");
            semSelect.SelectedItem = "Sem " + s.ToString();
            semSelect.SelectedItem= s;
            semSelect_SelectedIndexChanged(sender, e);
            doit();
        }

        public void doit()
        {
            string mDbPath = Application.StartupPath + "/paperassessment.db";
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=" + mDbPath + ";Version=3;");
            m_dbConnection.Open();
            int i = 3;
            int y = 0;
            while (i < 7)
            {
                string sql = "SELECT * FROM subject WHERE sem = " + i + " ORDER BY id;";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();
                Label btn = makeLabel(20, 54 + y, 60, "SEM" + i.ToString(), "hite");
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
            string mDbPath = Application.StartupPath + "/paperassessment.db";
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string subject = subSelect.Text;
            string mDbPath = Application.StartupPath + "/paperassessment.db";
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
            Form1 fr = new Form1(n, subject, sem);
            this.Hide();
            fr.ShowDialog();
            this.Close();
        }

        private void printReport_Click(object sender, EventArgs e)
        {
            string mDbPath = Application.StartupPath + "/paperassessment.db";
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string f = path + "/Today.xlsx";
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

                    MessageBox.Show(row.ToString());
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
                        ws.Cells[row, 2].Value = "Assessor";
                        ws.Cells[row, 3].Value = "Moderator";
                        ws.Cells[row, 4].Value = "Allocated";
                        ws.Cells[row, 5].Value = "Checked";
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
