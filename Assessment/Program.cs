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
        static string mDbPath = Application.StartupPath +  "\\subjects.db";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!File.Exists(mDbPath))
            {
                SQLiteConnection.CreateFile(mDbPath);
            }

            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=" + mDbPath + ";Version=3;");
            m_dbConnection.Open();

            string sql = "CREATE TABLE IF NOT EXISTS subjects (dept varchar(5), id int, name varchar(50), sem int, sf varchar(10), PRIMARY KEY (dept, id));";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            int num = command.ExecuteNonQuery();
            if (num != -1)
            {
                fillCMPN();
                fillETRX();
            }
            Application.Run(new Form2("2018 - 2019", "Sem 3", "Dec 18", "CMPN"));
        }

        public static void fillCMPN()
        {
            string sql;
            sql = "INSERT INTO subjects (dept, id, name, sem, sf) VALUES ('CMPN', 1, 'Applied Mathematics 3', 3, 'AM 3');";
            exec(sql);
            sql = "INSERT INTO subjects (dept, id, name, sem, sf) VALUES ('CMPN', 2, 'Digital Logic Design and Analysis', 3, 'DLDA');";
            exec(sql);
            sql = "INSERT INTO subjects (dept, id, name, sem, sf) VALUES ('CMPN', 3, 'Discrete Mathematics', 3, 'DIS');";
            exec(sql);
            sql = "INSERT INTO subjects (dept, id, name, sem, sf) VALUES ('CMPN', 4, 'Electronic Circuits and Communication Fundamentals', 3, 'ECCF');";
            exec(sql);
            sql = "INSERT INTO subjects (dept, id, name, sem, sf) VALUES ('CMPN', 5, 'Data Structures', 3, 'DS');";
            exec(sql);
            sql = "INSERT INTO subjects (dept, id, name, sem, sf) VALUES ('CMPN', 6, 'Applied Mathematics 4', 4, 'AM 4');";
            exec(sql);
            sql = "INSERT INTO subjects (dept, id, name, sem, sf) VALUES ('CMPN', 7, 'Analysis of Algorithms', 4, 'AOA');";
            exec(sql);
            sql = "INSERT INTO subjects (dept, id, name, sem, sf) VALUES ('CMPN', 8, 'Computer Organization and Architecture', 4, 'COA');";
            exec(sql);
            sql = "INSERT INTO subjects (dept, id, name, sem, sf) VALUES ('CMPN', 9, 'Computer Graphics', 4, 'CG');";
            exec(sql);
            sql = "INSERT INTO subjects (dept, id, name, sem, sf) VALUES ('CMPN', 10 ,'Operating Systems', 4, 'OS');";
            exec(sql);
            sql = "INSERT INTO subjects (dept, id, name, sem, sf) VALUES ('CMPN', 11, 'Microprocessor', 5, 'MP');";
            exec(sql);
            sql = "INSERT INTO subjects (dept, id, name, sem, sf) VALUES ('CMPN', 12, 'Database Management System', 5, 'DBMS');";
            exec(sql);
            sql = "INSERT INTO subjects (dept, id, name, sem, sf) VALUES ('CMPN', 13, 'Computer Network', 5, 'CN');";
            exec(sql);
            sql = "INSERT INTO subjects (dept, id, name, sem, sf) VALUES ('CMPN', 14, 'Theory of Computer Science', 5, 'TCS');";
            exec(sql);
            sql = "INSERT INTO subjects (dept, id, name, sem, sf) VALUES ('CMPN', 15, 'Department Level Optional Course 1', 5, 'OC 1');";
            exec(sql);
            sql = "INSERT INTO subjects (dept, id, name, sem, sf) VALUES ('CMPN', 16, 'Software Engineering', 6, 'SE');";
            exec(sql);
            sql = "INSERT INTO subjects (dept, id, name, sem, sf) VALUES ('CMPN', 17, 'System Programming and Compiler Construction', 6, 'SPCC');";
            exec(sql);
            sql = "INSERT INTO subjects (dept, id, name, sem, sf) VALUES ('CMPN', 18, 'Data Warehousing & Mining', 6, 'DWM');";
            exec(sql);
            sql = "INSERT INTO subjects (dept, id, name, sem, sf) VALUES ('CMPN', 19, 'Cryptography & System Security', 6, 'CSS');";
            exec(sql);
            sql = "INSERT INTO subjects (dept, id, name, sem, sf) VALUES ('CMPN', 20, 'Department Level Optional Course 2', 6, 'OC 2');";
            exec(sql);
        }

        public static void fillETRX()
        {
            string sql;
            sql = "INSERT INTO subjects (dept, id, name, sem, sf) VALUES ('ETRX', 1, 'Applied Mathematics 3', 3, 'AM3');";
            exec(sql);
            sql = "INSERT INTO subjects (dept, id, name, sem, sf) VALUES ('ETRX', 2, 'Electronic Devices and Circuits 1', 3, 'EDC1');";
            exec(sql);
            sql = "INSERT INTO subjects (dept, id, name, sem, sf) VALUES ('ETRX', 3, 'Digital Circuit Design', 3, 'DCD');";
            exec(sql);
            sql = "INSERT INTO subjects (dept, id, name, sem, sf) VALUES ('ETRX', 4, 'Electrical Network Analysis and Synthesis', 3, 'ENAS');";
            exec(sql);
            sql = "INSERT INTO subjects (dept, id, name, sem, sf) VALUES ('ETRX', 5, 'Electronics Instruments and Measurement', 3, 'EIM');";
            exec(sql);
            sql = "INSERT INTO subjects (dept, id, name, sem, sf) VALUES ('ETRX', 6, 'Applied Mathematics 4', 4, 'AM4');";
            exec(sql);
            sql = "INSERT INTO subjects (dept, id, name, sem, sf) VALUES ('ETRX', 7, 'Electronic Devices and Circuits 2', 4, 'EDC2');";
            exec(sql);
            sql = "INSERT INTO subjects (dept, id, name, sem, sf) VALUES ('ETRX', 8, 'Microprocessors and Applications', 4, 'MP');";
            exec(sql);
            sql = "INSERT INTO subjects (dept, id, name, sem, sf) VALUES ('ETRX', 9, 'Digital System Design', 4, 'DSD');";
            exec(sql);
            sql = "INSERT INTO subjects (dept, id, name, sem, sf) VALUES ('ETRX', 10, 'Principles of Communication Engineering', 4, 'PCE');";
            exec(sql);
            sql = "INSERT INTO subjects (dept, id, name, sem, sf) VALUES ('ETRX', 11, 'Linear Control Systems', 4, 'LCS');";
            exec(sql);
            sql = "INSERT INTO subjects (dept, id, name, sem, sf) VALUES ('ETRX', 12, 'Micro-controllers and Applications', 5, 'MCA');";
            exec(sql);
            sql = "INSERT INTO subjects (dept, id, name, sem, sf) VALUES ('ETRX', 13, 'Digital Communication', 5, 'DC');";
            exec(sql);
            sql = "INSERT INTO subjects (dept, id, name, sem, sf) VALUES ('ETRX', 14, 'Engineering Electromagnetics', 5, 'EE');";
            exec(sql);
            sql = "INSERT INTO subjects (dept, id, name, sem, sf) VALUES ('ETRX', 15, 'Design with Linear Integrated Circuits', 5, 'DLIC');";
            exec(sql);
            sql = "INSERT INTO subjects (dept, id, name, sem, sf) VALUES ('ETRX', 16, 'Department Level Optional courses 1', 5, 'DOC1');";
            exec(sql);
            sql = "INSERT INTO subjects (dept, id, name, sem, sf) VALUES ('ETRX', 17, 'Embedded System and RTOS', 6, 'ES');";
            exec(sql);
            sql = "INSERT INTO subjects (dept, id, name, sem, sf) VALUES ('ETRX', 18, 'Computer Communication Network', 6, 'CN');";
            exec(sql);
            sql = "INSERT INTO subjects (dept, id, name, sem, sf) VALUES ('ETRX', 19, 'VLSI Design', 6, 'VLSI');";
            exec(sql);
            sql = "INSERT INTO subjects (dept, id, name, sem, sf) VALUES ('ETRX', 20, 'Signals and systems', 6, 'SS');";
            exec(sql);
            sql = "INSERT INTO subjects (dept, id, name, sem, sf) VALUES ('ETRX', 21, 'Department Level Optional courses 2', 6, 'DOC2');";
            exec(sql);
        }
        public static void exec(string sql)
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=" + mDbPath + ";Version=3;");
            m_dbConnection.Open();
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            m_dbConnection.Close();
        }
    }
}