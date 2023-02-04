using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OMNIATHLETICS.ActiveDirectory;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace OMNIATHLETICS
{

    public partial class FormACSMPredictor : Form
    {
        public FormACSMPredictor()
        {
            DoubleBuffered = true;
            InitializeComponent();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                string loading = textBoxLoading.Text;
                string reps = textBoxRepetitions.Text;
                string AcsmPrediction = ActiveCalculator.strengthCalculator.Acsm1rmPredictor(Double.Parse(loading), int.Parse(reps));
                string labelDesc = "1RM: " + AcsmPrediction;
                label1RM.Text = (labelDesc);
                ActiveCalculator.strengthCalculator.SaveToACSMMemory(loading + "," + reps + "," + labelDesc);
                ActiveCalculator.calcualtor.SaveToCalculatorHistory(ActiveCalculator.strengthCalculator.ToString(), "ACSM 1RM Predictor", "1RM = " + loading + " / ((100 – (" + reps + " x 2.5)) / 100)", labelDesc);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Invalid Input");
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            List<TextBox> textBoxes = new List<TextBox>() {textBoxLoading, textBoxRepetitions};
            ActiveCalculator.calcualtor.RefreshFields(textBoxes);
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (ActiveCalculator.strengthCalculator.currentACSMCalcualtionLoaded > 0)
            {
                string calculationData = ActiveCalculator.strengthCalculator.localACSMCalculatioMemory[ActiveCalculator.strengthCalculator.currentACSMCalcualtionLoaded - 1];
                string[] calculationFileds = calculationData.Split(',');
                textBoxLoading.Text = calculationFileds[0];
                textBoxRepetitions.Text = calculationFileds[1];
                label1RM.Text = calculationFileds[2];
                //remove current one its on
                ActiveCalculator.strengthCalculator.localACSMCalculatioMemory.Remove(ActiveCalculator.strengthCalculator.localACSMCalculatioMemory[ActiveCalculator.strengthCalculator.currentACSMCalcualtionLoaded]);
                ActiveCalculator.strengthCalculator.currentACSMCalcualtionLoaded--;
            }
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            ActiveCalculator.strengthCalculator.About("ACSM 1RM Predictor");
        }
    }
}
