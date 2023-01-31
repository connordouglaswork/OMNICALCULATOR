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
    public partial class FormLowerBodyPeakPowerPredictor : Form
    {
        public FormLowerBodyPeakPowerPredictor()
        {
            InitializeComponent();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            string mass = textBoxJumpHeight.Text;
            string height = textBoxMass.Text;
            string lbPower = ActiveCalculator.powerCalculator.LowerBodyPeakPowerPredictor(double.Parse(height), double.Parse(mass));
            string labelDesc = "Peak Power: " + lbPower;
            labelPower.Text = (labelDesc);
            ActiveCalculator.powerCalculator.SaveToPeakMemory(mass + "," + height + "," + labelDesc);
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (ActiveCalculator.powerCalculator.currentPeakCalcualtionLoaded > 0)
            {
                string calculationData = ActiveCalculator.powerCalculator.localPeakCalculationMemory[ActiveCalculator.powerCalculator.currentPeakCalcualtionLoaded - 1];
                string[] calculationFileds = calculationData.Split(',');
                textBoxMass.Text = calculationFileds[0];
                textBoxMass.Text = calculationFileds[1];
                labelPower.Text = calculationFileds[2];
                //delete it from list when gone
                ActiveCalculator.powerCalculator.localPeakCalculationMemory.Remove(calculationData);
                ActiveCalculator.powerCalculator.currentPeakCalcualtionLoaded--;
            }
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            ActiveCalculator.powerCalculator.About("Lower Body Peak Power Predictor");
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            List<TextBox> textBoxes = new List<TextBox>() { textBoxJumpHeight, textBoxMass };
            ActiveCalculator.calcualtor.RefreshFields(textBoxes);
        }
    }
}
