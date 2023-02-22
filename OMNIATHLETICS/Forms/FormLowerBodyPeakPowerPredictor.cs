using OMNIATHLETICS.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
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
            DoubleBuffered = true;
        }

        //function to close the form
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //calculate button press event function to get field values, calculate equation and store the result
        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            //catch non numerical inputs
            try
            {
                string mass = textBoxJumpHeight.Text;
                string height = textBoxMass.Text;
                string lbPower = ActiveCalculator.powerCalculator.LowerBodyPeakPowerPredictor(double.Parse(height), double.Parse(mass));
                string labelDesc = "Peak Power: " + lbPower;
                labelPower.Text = (labelDesc);
                //store in local object memory list
                ActiveCalculator.powerCalculator.SaveToPeakMemory(mass + "," + height + "," + labelDesc);
                //add to history DB
                ActiveCalculator.calcualtor.SaveToCalculatorHistory(ActiveCalculator.powerCalculator.ToString(), "Lower Body Peak Power Predictor", "Power (W) = 60.7 x " + height + " + 45.3 x " + mass + " - 2055.", labelDesc);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Invalid Input");
            }
        }

        //goes back through the objects local memory to the previous calculation
        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (ActiveCalculator.powerCalculator.currentPeakCalcualtionLoaded > 0)
            {
                string calculationData = ActiveCalculator.powerCalculator.localPeakCalculationMemory[ActiveCalculator.powerCalculator.currentPeakCalcualtionLoaded - 1];
                string[] calculationFileds = calculationData.Split(',');
                textBoxMass.Text = calculationFileds[0];
                textBoxMass.Text = calculationFileds[1];
                labelPower.Text = calculationFileds[2];
                //remove current calculation
                ActiveCalculator.powerCalculator.localPeakCalculationMemory.Remove(ActiveCalculator.powerCalculator.localPeakCalculationMemory[ActiveCalculator.powerCalculator.currentPeakCalcualtionLoaded]);
                ActiveCalculator.powerCalculator.currentPeakCalcualtionLoaded--;
            }
        }

        //display info about the equation
        private void buttonAbout_Click(object sender, EventArgs e)
        {
            ActiveCalculator.powerCalculator.About("Lower Body Peak Power Predictor");
        }

        //clears text box fields
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            List<TextBox> textBoxes = new List<TextBox>() { textBoxJumpHeight, textBoxMass };
            ActiveCalculator.calcualtor.RefreshFields(textBoxes);
        }
    }
}
