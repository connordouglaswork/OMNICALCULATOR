using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OMNIATHLETICS
{
    //Parent Class for unique sports calculators that contains base calculator functions 
    public class Calculator
    {
        //Database connection string for calcualtion history
        private string conString = "Data Source=DESKTOP-PGJPJK2\\MSSQLSERVER01;Initial Catalog=OmniCalculationsDB;Integrated Security=True";

        //Save to calcualtion history table in OmniCalculationsDB
        public void SaveToCalculatorHistory(string calculator, string calculation, string equation, string result)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "insert into CalculationData(Calculator,Calculation,Equation,Result)values('" + calculator + "','" + calculation + "','" + equation + "','" + result + "')";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.ExecuteNonQuery();
            }
        }

        //Delete from calcualtion history table in OmniCalculationsDB
        public void DeletefromCalculatorHistory(int id)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "delete from CalculationData where ID='" + id + "'";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.ExecuteNonQuery();
            }
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
            foreach(TextBox feild in feilds)
            {
                feild.Text = "";
            }
        }       

    }
}
