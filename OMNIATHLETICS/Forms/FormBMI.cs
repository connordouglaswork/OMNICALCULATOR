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
    public partial class FormBMI : Form
    {
        public FormBMI()
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
                string mass = textBoxMass.Text;
                string height = textBoxHeight.Text;
                string bmi = ActiveCalculator.nutritionCalculator.BMI(double.Parse(mass), double.Parse(height));
                string labelDesc = "BMI: " + bmi;
                labelBMI.Text = (labelDesc);
                //store in local object memory list
                ActiveCalculator.nutritionCalculator.SaveToBMIMemory(mass + "," + height + "," + labelDesc);
                //add to history DB
                ActiveCalculator.calcualtor.SaveToCalculatorHistory(ActiveCalculator.nutritionCalculator.ToString(), "BMI", "BMI = " + mass + " / " +  height + "^2", labelDesc);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Invalid Input");
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (ActiveCalculator.nutritionCalculator.currentBMICalcualtionLoaded > 0)
            {
                string calculationData = ActiveCalculator.nutritionCalculator.localBMICalculationMemory[ActiveCalculator.nutritionCalculator.currentBMICalcualtionLoaded - 1];
                string[] calculationFileds = calculationData.Split(',');
                textBoxMass.Text = calculationFileds[0];
                textBoxHeight.Text = calculationFileds[1];
                labelBMI.Text = calculationFileds[2];
                //delete it from list when gone
                ActiveCalculator.nutritionCalculator.localBMICalculationMemory.Remove(ActiveCalculator.nutritionCalculator.localBMICalculationMemory[ActiveCalculator.nutritionCalculator.currentBMICalcualtionLoaded]);
                ActiveCalculator.nutritionCalculator.currentBMICalcualtionLoaded--;
            }
        }

        //goes back through the objects local memory to the previous calculation
        private void buttonAbout_Click(object sender, EventArgs e)
        {
            ActiveCalculator.nutritionCalculator.About("BMI");
        }

        //clears text box fields
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            List<TextBox> textBoxes = new List<TextBox>() { textBoxHeight, textBoxMass };
            ActiveCalculator.calcualtor.RefreshFields(textBoxes);
        }
    }
}
