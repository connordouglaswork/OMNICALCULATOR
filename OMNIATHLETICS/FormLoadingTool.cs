using OMNIATHLETICS.ActiveDirectory;
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
    public partial class FormLoadingTool : Form
    {
        public FormLoadingTool()
        {
            InitializeComponent();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            string max = textBox1RM.Text;
            string percent = textBoxPercentage.Text;
            string AcsmPrediction = ActiveCalculator.strengthCalculator.LoadingTool(Double.Parse(percent), Double.Parse(max));
            string labelDesc = "Loading: " + AcsmPrediction;
            labelLoading.Text = (labelDesc);
            ActiveCalculator.strengthCalculator.SaveToLoadingMemory(max + "," + percent + "," + labelDesc);

        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (ActiveCalculator.strengthCalculator.currentLoadingCalcualtionLoaded > 0)
            {
                string calculationData = ActiveCalculator.strengthCalculator.localLoadingCalculatioMemory[ActiveCalculator.strengthCalculator.currentLoadingCalcualtionLoaded - 1];
                string[] calculationFileds = calculationData.Split(',');
                textBox1RM.Text = calculationFileds[0];
                textBoxPercentage.Text = calculationFileds[1];
                labelLoading.Text = calculationFileds[2];
                //delete it from list when gone
                ActiveCalculator.strengthCalculator.localLoadingCalculatioMemory.Remove(calculationData);
                ActiveCalculator.strengthCalculator.currentLoadingCalcualtionLoaded--;
            }
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            ActiveCalculator.strengthCalculator.About("Loading Tool");
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            List<TextBox> textBoxes = new List<TextBox>() { textBox1RM, textBoxPercentage };
            ActiveCalculator.calcualtor.RefreshFields(textBoxes);
        }
    }
}
