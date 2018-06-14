using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;


namespace Assessment
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            once();
            Application.Run(new Form0("Sem 3"));
        }

        static void once()
        {
            string mDbPath = Application.StartupPath + "/paperassessment.db";
            if (!File.Exists(mDbPath))
            {
                SQLiteConnection.CreateFile(mDbPath);
            }

            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=" + mDbPath + ";Version=3;");
            m_dbConnection.Open();

            string sql = "CREATE TABLE IF NOT EXISTS subject (id int PRIMARY KEY, name varchar(50) UNIQUE, sem int, todayDone int, sf varchar(10));";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            int i = command.ExecuteNonQuery();
            if (i == -1)
                return;
            sql = "INSERT INTO subject (id, name, sem, todayDone, sf) VALUES (1, 'Applied Mathematics 3', 3, 0, 'AM 3');";
            exec(sql);
            sql = "INSERT INTO subject (id, name, sem, todayDone, sf) VALUES (2, 'Digital Logic Design and Analysis', 3, 0, 'DLDA');";
            exec(sql);
            sql = "INSERT INTO subject (id, name, sem, todayDone, sf) VALUES (3, 'Discrete Mathematics', 3, 0, 'DIS');";
            exec(sql);
            sql = "INSERT INTO subject (id, name, sem, todayDone, sf) VALUES (4, 'Electronic Circuits and Communication Fundamentals', 3, 0, 'ECCF');";
            exec(sql);
            sql = "INSERT INTO subject (id, name, sem, todayDone, sf) VALUES (5, 'Data Structures', 3, 0, 'DS');";
            exec(sql);
            sql = "INSERT INTO subject (id, name, sem, todayDone, sf) VALUES (6, 'Applied Mathematics 4', 4, 0, 'AM 4');";
            exec(sql);
            sql = "INSERT INTO subject (id, name, sem, todayDone, sf) VALUES (7, 'Analysis of Algorithms', 4, 0, 'AOA');";
            exec(sql);
            sql = "INSERT INTO subject (id, name, sem, todayDone, sf) VALUES (8, 'Computer Organization and Architecture', 4, 0, 'COA');";
            exec(sql);
            sql = "INSERT INTO subject (id, name, sem, todayDone, sf) VALUES (9, 'Computer Graphics', 4, 0, 'CG');";
            exec(sql);
            sql = "INSERT INTO subject (id, name, sem, todayDone, sf) VALUES (10, 'Operating Systems', 4, 0, 'OS');";
            exec(sql);
            sql = "INSERT INTO subject (id, name, sem, todayDone, sf) VALUES (11, 'Microprocessor', 5, 0, 'MP');";
            exec(sql);
            sql = "INSERT INTO subject (id, name, sem, todayDone, sf) VALUES (12, 'Database Management System', 5, 0, 'DBMS');";
            exec(sql);
            sql = "INSERT INTO subject (id, name, sem, todayDone, sf) VALUES (13, 'Computer Network', 5, 0, 'CN');";
            exec(sql);
            sql = "INSERT INTO subject (id, name, sem, todayDone, sf) VALUES (14, 'Theory of Computer Science', 5, 0, 'TCS');";
            exec(sql);
            sql = "INSERT INTO subject (id, name, sem, todayDone, sf) VALUES (15, 'Department Level Optional Course 1', 5, 0, 'OC 1');";
            exec(sql);
            sql = "INSERT INTO subject (id, name, sem, todayDone, sf) VALUES (16, 'Software Engineering', 6, 0, 'SE');";
            exec(sql);
            sql = "INSERT INTO subject (id, name, sem, todayDone, sf) VALUES (17, 'System Programming and Compiler Construction', 6, 0, 'SPCC');";
            exec(sql);
            sql = "INSERT INTO subject (id, name, sem, todayDone, sf) VALUES (18, 'Data Warehousing & Mining', 6, 0, 'DWM');";
            exec(sql);
            sql = "INSERT INTO subject (id, name, sem, todayDone, sf) VALUES (19, 'Cryptography & System Security', 6, 0, 'CSS');";
            exec(sql);
            sql = "INSERT INTO subject (id, name, sem, todayDone, sf) VALUES (20, 'Department Level Optional Course 2', 6, 0, 'OC 2');";
            exec(sql);

            sql = "CREATE TABLE IF NOT EXISTS allocation (sid int, id int, assessor varchar(50), moderator varchar(50), allocated int, checked int, todayChecked int, PRIMARY KEY(sid, id), UNIQUE(sid, assessor));";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }

        static void exec(string sql)
        {
            string mDbPath = Application.StartupPath + "/paperassessment.db";
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=" + mDbPath + ";Version=3;");
            m_dbConnection.Open();
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            m_dbConnection.Close();
        }

    }
}