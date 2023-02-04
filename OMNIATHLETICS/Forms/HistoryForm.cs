using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    }
}
