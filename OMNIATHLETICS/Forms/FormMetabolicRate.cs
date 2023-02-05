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
    public partial class FormMetabolicRate : Form
    {
        public FormMetabolicRate()
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
                string age = textBoxAge.Text;
                string sex = "Female";
                if (radioButton1.Checked == true)
                {
                    sex = "Male";
                }
                string metabolicRate = ActiveCalculator.nutritionCalculator.MetabolicRate(double.Parse(mass), double.Parse(height), int.Parse(age), sex);
                string labelDesc = "MBR: " + metabolicRate;
                labelMBR.Text = (labelDesc);
                //store in local object memory list
                ActiveCalculator.nutritionCalculator.SaveToMetabolicRateMemory(mass + "," + height + "," + age + "," + sex + "," + labelDesc);
                //add to history DB
                ActiveCalculator.calcualtor.SaveToCalculatorHistory(ActiveCalculator.nutritionCalculator.ToString(), "Metabolic Rate", mass + "," + height + "," + age + "," + sex, labelDesc);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Invalid Input");
            }
        }

        //goes back through the objects local memory to the previous calculation
        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (ActiveCalculator.nutritionCalculator.currentMetabolicRateCalcualtionLoaded > 0)
            {
                string calculationData = ActiveCalculator.nutritionCalculator.localMetabolicRateCalculationMemory[ActiveCalculator.nutritionCalculator.currentMetabolicRateCalcualtionLoaded - 1];
                string[] calculationFileds = calculationData.Split(',');
                textBoxMass.Text = calculationFileds[0];
                textBoxHeight.Text = calculationFileds[1];
                textBoxAge.Text = calculationFileds[2];
                if(calculationFileds[3] == "Male")
                {
                    radioButton1.Checked = true;
                    radioButton2.Checked = false;
                }
                else
                {
                    radioButton2.Checked = true;
                    radioButton1.Checked = false;
                }

                labelMBR.Text = calculationFileds[4];
                //remove current calculation
                ActiveCalculator.nutritionCalculator.localMetabolicRateCalculationMemory.Remove(ActiveCalculator.nutritionCalculator.localMetabolicRateCalculationMemory[ActiveCalculator.nutritionCalculator.currentMetabolicRateCalcualtionLoaded]);
                ActiveCalculator.nutritionCalculator.currentMetabolicRateCalcualtionLoaded--;
            }
        }

        //display info about the equation
        private void buttonAbout_Click(object sender, EventArgs e)
        {
            ActiveCalculator.nutritionCalculator.About("Metabolic Rate");
        }

        //clears text box fields
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            List<TextBox> textBoxes = new List<TextBox>() { textBoxHeight, textBoxMass, textBoxAge };
            ActiveCalculator.calcualtor.RefreshFields(textBoxes);
        }
    }
}
