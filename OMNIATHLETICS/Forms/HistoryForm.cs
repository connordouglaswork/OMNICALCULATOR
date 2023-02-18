using OMNIATHLETICS.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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

        private void HistoryForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'omniCalculationsDBDataSet.CalculationData' table. You can move, or remove it, as needed.
            this.calculationDataTableAdapter.Fill(this.omniCalculationsDBDataSet.CalculationData);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            //get list of selected rows
            List<DataGridViewRow> rows = dataGridViewHistory.SelectedRows.Cast<DataGridViewRow>().ToList();
            foreach(DataGridViewRow row in rows)
            {
                //get id from each row
                string rowString = row.Cells[0].Value.ToString();
                int id = int.Parse(rowString);
                ActiveCalculator.calcualtor.DeletefromCalculatorHistory(id);
            }
            //refresh gridview
            string conString = "Data Source=DESKTOP-PGJPJK2\\MSSQLSERVER01;Initial Catalog=OmniCalculationsDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string select = "SELECT * from CalculationData";
            SqlDataAdapter da = new SqlDataAdapter(select, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "CalculationData");
            dataGridViewHistory.DataSource = ds;
            dataGridViewHistory.DataMember = "CalculationData";
            con.Close();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string calculatorSelected = comboBoxType.Text;
            if(calculatorSelected=="All Types")
            {
                string conString = "Data Source=DESKTOP-PGJPJK2\\MSSQLSERVER01;Initial Catalog=OmniCalculationsDB;Integrated Security=True";
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string select = "SELECT * from CalculationData";
                SqlDataAdapter da = new SqlDataAdapter(select, con);
                DataSet ds = new DataSet();
                da.Fill(ds, "CalculationData");
                dataGridViewHistory.DataSource = ds;
                dataGridViewHistory.DataMember = "CalculationData";
                con.Close();
            }
            else
            {           
                string conString = "Data Source=DESKTOP-PGJPJK2\\MSSQLSERVER01;Initial Catalog=OmniCalculationsDB;Integrated Security=True";
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string select = "SELECT * from CalculationData WHERE Calculator='" + calculatorSelected + "'";
                SqlDataAdapter da = new SqlDataAdapter(select, con);
                DataSet ds = new DataSet();
                da.Fill(ds, "CalculationData");
                dataGridViewHistory.DataSource = ds;
                dataGridViewHistory.DataMember = "CalculationData";
                con.Close();
            }
        }
    }
}
