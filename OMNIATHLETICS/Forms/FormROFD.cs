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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace OMNIATHLETICS
{
    public partial class FormROFD : Form
    {
        public FormROFD()
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
                string force = textBoxPeakForce.Text;
                string time = textBoxTime.Text;
                string rofd = ActiveCalculator.powerCalculator.RateOfForceDevelopment(double.Parse(force), double.Parse(time));
                string labelDesc = "ROFD: " + rofd;
                labelROFD.Text = (labelDesc);
                //store in local object memory list
                ActiveCalculator.powerCalculator.SaveToROFDMemory(force + "," + time + "," + labelDesc);
                //add to history DB
                ActiveCalculator.calcualtor.SaveToCalculatorHistory(ActiveCalculator.powerCalculator.ToString(), "Rate of Force Development", "Average RFD = " + force + " / " + time, labelDesc);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Invalid Input");
            }
        }

        //goes back through the objects local memory to the previous calculation
        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (ActiveCalculator.powerCalculator.currentROFDCalcualtionLoaded > 0)
            {
                string calculationData = ActiveCalculator.powerCalculator.localROFDCalculationMemory[ActiveCalculator.powerCalculator.currentROFDCalcualtionLoaded - 1];
                string[] calculationFileds = calculationData.Split(',');
                textBoxPeakForce.Text = calculationFileds[0];
                textBoxTime.Text = calculationFileds[1];
                labelROFD.Text = calculationFileds[2];
                //remove current calculation
                ActiveCalculator.powerCalculator.localROFDCalculationMemory.Remove(ActiveCalculator.powerCalculator.localROFDCalculationMemory[ActiveCalculator.powerCalculator.currentROFDCalcualtionLoaded]);
                ActiveCalculator.powerCalculator.currentROFDCalcualtionLoaded--;
            }
        }

        //display info about the equation
        private void buttonAbout_Click(object sender, EventArgs e)
        {
            ActiveCalculator.powerCalculator.About("Rate of Force Development");
        }

        //clears text box fields
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            List<TextBox> textBoxes = new List<TextBox>() { textBoxPeakForce, textBoxTime };
            ActiveCalculator.calcualtor.RefreshFields(textBoxes);
        }
    }
}
