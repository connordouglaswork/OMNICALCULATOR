using OMNIATHLETICS.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OMNIATHLETICS
{
    public partial class HistoryForm : Form
    {
        public HistoryForm()
        {
            InitializeComponent();           
        }

        //initialze form
        private void HistoryForm_Load(object sender, EventArgs e)
        {
            try
            {
                // This line of code loads data into the 'omniCalculationsDBDataSet.CalculationData' table. You can move, or remove it, as needed.
                var parentdir = Path.GetDirectoryName(System.Windows.Forms.Application.StartupPath);
                string conString = "Data Source=" + parentdir + "\\OmniCalculationsDB.db;";
                SQLiteConnection con = new SQLiteConnection(conString);
                con.Open();
                string select = "SELECT * from CalculationData";
                string calculatorSelected = comboBoxType.Text;
                if (calculatorSelected != "All Types")
                {
                    select = "SELECT * from CalculationData WHERE Calculator='" + calculatorSelected + "'";
                }

                SQLiteCommand cmd;
                SQLiteDataAdapter da;
                cmd = con.CreateCommand();
                cmd.CommandText = select;
                da = new SQLiteDataAdapter(select, con);
                DataSet ds = new DataSet();
                da.Fill(ds, "CalculationData");
                dataGridViewHistory.DataSource = ds;
                dataGridViewHistory.DataMember = "CalculationData";
                con.Close();
            }
            catch
            {
                MessageBox.Show("No Calculator History. Perform a Calculation.");
            }
        }

        //remove highlighted table line
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //get list of selected rows
                List<DataGridViewRow> rows = dataGridViewHistory.SelectedRows.Cast<DataGridViewRow>().ToList();
                foreach (DataGridViewRow row in rows)
                {
                    //get id from each row
                    string rowString = row.Cells[0].Value.ToString();
                    int id = int.Parse(rowString);
                    ActiveCalculator.calcualtor.DeletefromCalculatorHistory(id);
                }
                //refresh gridview
                var parentdir = Path.GetDirectoryName(System.Windows.Forms.Application.StartupPath);
                string conString = "Data Source=" + parentdir + "\\OmniCalculationsDB.db;";
                SQLiteConnection con = new SQLiteConnection(conString);
                con.Open();
                string calculatorSelected = comboBoxType.Text;
                string select = "SELECT * from CalculationData";
                //make sure grid is refreshed with correct SELECT statement
                if (calculatorSelected != "All Types")
                {
                    select = "SELECT * from CalculationData WHERE Calculator='" + calculatorSelected + "'";
                }
                SQLiteDataAdapter da = new SQLiteDataAdapter(select, con);
                DataSet ds = new DataSet();
                da.Fill(ds, "CalculationData");
                dataGridViewHistory.DataSource = ds;
                dataGridViewHistory.DataMember = "CalculationData";
                con.Close();
            }
            catch
            {
                MessageBox.Show("No Calculator History. Perform a Calculation.");
            }          
        }

        //change the gridview based on calcualtor type
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string calculatorSelected = comboBoxType.Text;
                if (calculatorSelected == "All Types")
                {
                    var parentdir = Path.GetDirectoryName(System.Windows.Forms.Application.StartupPath);
                    string conString = "Data Source=" + parentdir + "\\OmniCalculationsDB.db;";
                    SQLiteConnection con = new SQLiteConnection(conString);
                    con.Open();
                    string select = "SELECT * from CalculationData";
                    SQLiteDataAdapter da = new SQLiteDataAdapter(select, con);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "CalculationData");
                    dataGridViewHistory.DataSource = ds;
                    dataGridViewHistory.DataMember = "CalculationData";
                    con.Close();
                }
                else
                {
                    var parentdir = Path.GetDirectoryName(System.Windows.Forms.Application.StartupPath);
                    string conString = "Data Source=" + parentdir + "\\OmniCalculationsDB.db;";
                    SQLiteConnection con = new SQLiteConnection(conString);
                    con.Open();
                    string select = "SELECT * from CalculationData WHERE Calculator='" + calculatorSelected + "'";
                    SQLiteDataAdapter da = new SQLiteDataAdapter(select, con);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "CalculationData");
                    dataGridViewHistory.DataSource = ds;
                    dataGridViewHistory.DataMember = "CalculationData";
                    con.Close();
                }
            }
            catch
            {
                MessageBox.Show("No Calculator History. Perform a Calculation.");
            }        
        }
    }
}
