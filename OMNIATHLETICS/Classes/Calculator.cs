using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SQLite;
using System.IO;

namespace OMNIATHLETICS
{
    //Parent Class for unique sports calculators that contains base calculator functions 
    public class Calculator
    {
        //Databse connection string for calcualtion history
        //private static string rconString = "Data Source=OmniCalculationsDB.db; Version = 3; New = True; Compress = True; ";
        //private static string conString = @"URI=file:../OmniCalculationsDB.db";
        SQLiteConnection con;

        //builds table, to be called when form first loads in 
        public SQLiteConnection CheckDB()
        {
            var parentdir = Path.GetDirectoryName(System.Windows.Forms.Application.StartupPath);
            string conString = "Data Source=" + parentdir + "\\OmniCalculationsDB.db;";
            con = new SQLiteConnection(conString);
            // Open the connection:
            try
            {
                con.Open();
                //if table doesn't exist then catch and make one
                try
                {
                    string insertQuery = "select * from CalculationData";
                    SQLiteCommand cmd;
                    cmd = con.CreateCommand();
                    cmd.CommandText = insertQuery;
                    cmd.ExecuteReader();
                }
                catch (Exception)
                {
                    CreateTable(con);

                }
            }
            catch (Exception ex) //if table doesnt exist call to create it
            {
            }
            con.Close();
            return con;
        }

        //initialize connection to DB
        public SQLiteConnection CreateConnection()
        {
            var parentdir = Path.GetDirectoryName(System.Windows.Forms.Application.StartupPath);
            string conString = "Data Source=" + parentdir + "\\OmniCalculationsDB.db;";
            
            
            try
            {
                con = new SQLiteConnection(conString);
                con.Open();
            }
            catch (Exception)
            {
                CreateTable(con);

            }
            
            return con;
        }

        //Save to calcualtion history table in OmniCalculationsDB
        public void SaveToCalculatorHistory(string calculator, string calculation, string equation, string result)
        {
            CreateConnection();
            try
            {
                string insertQuery = "insert into CalculationData(Calculator,Calculation,Equation,Result)values('" + calculator + "','" + calculation + "','" + equation + "','" + result + "')";
                SQLiteCommand cmd;
                cmd = con.CreateCommand();
                cmd.CommandText = insertQuery;
                cmd.ExecuteNonQuery();
            }           
            catch (Exception)
            {
                CreateTable(con);

            }
            con.Close();
        }


        //help/naming ToString override
        public override string ToString()
        {
            return ("Omni Athletics Calculator is a sports science ccalculator for athletes, " +
            "coaches, nutritionists and scientist. The calculator features 6 types of " +
                "calculations strength, power, anaerobic, aerobic, nutirion and biomechanics. " +
                "Implementation of this calculator will allow optimsed training protocols.");
        }

        //Reset calculator Feilds
        public void RefreshFields(List<TextBox> feilds)
        {
            foreach (TextBox feild in feilds)
            {
                feild.Text = "";
            }
        }

        //build calculation history table
        public void CreateTable(SQLiteConnection conn)
        {
            SQLiteCommand cmd;
            string Createsql = @"CREATE TABLE [CalculationData]( 
                                ID INTEGER PRIMARY KEY AUTOINCREMENT,
                                [Calculator] [varchar](50) NULL,
	                            [Calculation] [varchar](50) NULL,
	                            [Equation] [varchar](50) NULL,
	                            [Result] [varchar](50) NULL)";
            cmd = conn.CreateCommand();
            cmd.CommandText = Createsql;
            cmd.ExecuteNonQuery();
        }


        //Delete from calcualtion history table in OmniCalculationsDB
        public void DeletefromCalculatorHistory(int id)
        {
            CreateConnection();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "delete from CalculationData where ID='" + id + "'";
                SQLiteCommand cmd = new SQLiteCommand(q, con);
                cmd.ExecuteNonQuery();
            }
            con.Close();
        }

        //Example to read data
        public void ReadData()
        {
            con.Open();
            SQLiteDataReader reader;
            SQLiteCommand cmd;
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM CalculationData";

            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string data = reader.GetString(0);
                Console.WriteLine(data);
            }
            con.Close();
        }
    }
}


