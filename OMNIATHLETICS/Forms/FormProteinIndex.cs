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
    public partial class FormProteinIndex : Form
    {
        public FormProteinIndex()
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
                string trainingType = comboBoxType.Text;
                string protein = ActiveCalculator.nutritionCalculator.ProteinIndex(double.Parse(mass), trainingType);
                string labelDesc = "Protein Requirements: \n" + protein;
                labelProtein.Text = (labelDesc);
                //store in local object memory list
                ActiveCalculator.nutritionCalculator.SaveToProteinIndexMemory(mass + "," + trainingType + "," + labelDesc);
                //add to history DB
                ActiveCalculator.calcualtor.SaveToCalculatorHistory(ActiveCalculator.nutritionCalculator.ToString(), "Protein Index", mass + "," + trainingType, labelDesc);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Invalid Input");
            }

        }

        //goes back through the objects local memory to the previous calculation
        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (ActiveCalculator.nutritionCalculator.currentProteinIndexCalcualtionLoaded > 0)
            {
                string calculationData = ActiveCalculator.nutritionCalculator.localProteinIndexCalculationMemory[ActiveCalculator.nutritionCalculator.currentProteinIndexCalcualtionLoaded - 1];
                string[] calculationFileds = calculationData.Split(',');
                textBoxMass.Text = calculationFileds[0];
                comboBoxType.Text = calculationFileds[1];
                labelProtein.Text = calculationFileds[2];
                //remove current calculation
                ActiveCalculator.nutritionCalculator.localProteinIndexCalculationMemory.Remove(ActiveCalculator.nutritionCalculator.localProteinIndexCalculationMemory[ActiveCalculator.nutritionCalculator.currentProteinIndexCalcualtionLoaded]);
                ActiveCalculator.nutritionCalculator.currentProteinIndexCalcualtionLoaded--;
            }
        }

        //display info about the equation
        private void buttonAbout_Click(object sender, EventArgs e)
        {
            ActiveCalculator.nutritionCalculator.About("Protein Index");
        }

        //clears text box fields
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            List<TextBox> textBoxes = new List<TextBox>() { textBoxMass };
            ActiveCalculator.calcualtor.RefreshFields(textBoxes);
        }
    }
}
