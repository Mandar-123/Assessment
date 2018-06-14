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
        public Form0()
        {
            InitializeComponent();
        }

        private void Form0_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            semSelect.Items.Add("Sem 3");
            semSelect.Items.Add("Sem 4");
            semSelect.Items.Add("Sem 5");
            semSelect.Items.Add("Sem 6");
            semSelect.SelectedItem = "Sem 3";
            semSelect_SelectedIndexChanged(sender, e);
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
            string f = Application.StartupPath + "/Today.xlsx";
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
                dbconnect.Open();
                int row = 1;
                for (int i = 3; i <= 6; i++)
                {
                    var ws = p.Workbook.Worksheets.Add(i.ToString());
                    string sql = "SELECT name, id FROM subject";                                  //query
                    SQLiteCommand query = new SQLiteCommand(sql, dbconnect);
                    var reader = query.ExecuteReader();

                    while (reader.Read())
                    {
                        ws.Cells[row, 1, row, 6].Merge = true;
                        ws.Cells[row, 1, row, 6].Value = reader[0];
                        ws.Cells[row, 1, row, 6].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        ws.Cells[row, 1, row, 6].Style.Font.Size = 14;
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
                            ws.Cells[row, 2].Value = reader2[0];
                            ws.Cells[row, 3].Value = reader2[1];
                            ws.Cells[row, 4].Value = reader2[2];
                            ws.Cells[row, 5].Value = reader2[3];
                            ws.Cells[row, 6].Value = reader2[4];
                            row++;
                        }

                        row = row + 2;
                    }
                }
                dbconnect.Close();
                p.Save();
            }
            return true;
        }
    }
}
