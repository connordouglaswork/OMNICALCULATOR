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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace OMNIATHLETICS
{
    public partial class FormRAST : Form
    {
        public FormRAST()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        //function to close the form
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //display info about the equation
        private void buttonAbout_Click(object sender, EventArgs e)
        {
            ActiveCalculator.anaerobicthCalculator.About("RAST");
        }

        //clears text box fields
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            List<TextBox> textBoxes = new List<TextBox>() { textBoxLowestPeakPower, textBoxPeakPower, textBoxTime, textBoxPPO1, textBoxPPO2, textBoxPPO3, textBoxPPO4, textBoxPPO5, textBoxPPO6};
            ActiveCalculator.calcualtor.RefreshFields(textBoxes);
        }

        //calculate button press event function to get field values, calculate equation and store the result
        private void buttonCalcualateFatigue_Click(object sender, EventArgs e)
        {
            //catch non numerical inputs
            try
            {
                string peakPower = textBoxPeakPower.Text;
                string LowestPower = textBoxLowestPeakPower.Text;
                string time = textBoxTime.Text;
                string FI = ActiveCalculator.anaerobicthCalculator.RastFatigueIndex(double.Parse(peakPower), double.Parse(LowestPower), double.Parse(time));
                string labelDesc = "FI: " + FI;
                labelFatigue.Text = (labelDesc);
                //store in local object memory list
                ActiveCalculator.anaerobicthCalculator.SaveToRASTFIMemory(peakPower + "," + LowestPower + "," + time + "," + labelDesc);
                //add to history DB
                ActiveCalculator.calcualtor.SaveToCalculatorHistory(ActiveCalculator.anaerobicthCalculator.ToString(), "RAST Fatigue Index", "FI = (" + peakPower +" – " + LowestPower + ") / " + time, labelDesc);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Invalid Input");
            }
        }

        //goes back through the objects local memory to the previous calculation
        private void button2_Click(object sender, EventArgs e)
        {
            if (ActiveCalculator.anaerobicthCalculator.currentRASTFICalcualtionLoaded > 0)
            {
                string calculationData = ActiveCalculator.anaerobicthCalculator.localRASTFICalculationMemory[ActiveCalculator.anaerobicthCalculator.currentRASTFICalcualtionLoaded - 1];
                string[] calculationFileds = calculationData.Split(',');
                textBoxPeakPower.Text = calculationFileds[0];
                textBoxLowestPeakPower.Text = calculationFileds[1];
                textBoxTime.Text = calculationFileds[2];
                labelFatigue.Text = calculationFileds[3];
                //remove current calculation
                ActiveCalculator.anaerobicthCalculator.localRASTFICalculationMemory.Remove(ActiveCalculator.anaerobicthCalculator.localRASTFICalculationMemory[ActiveCalculator.anaerobicthCalculator.currentRASTFICalcualtionLoaded]);
                ActiveCalculator.anaerobicthCalculator.currentRASTFICalcualtionLoaded--;
            }
        }

        //calculate button press event function to get field values, calculate equation and store the result
        private void buttonCalculateAnaerboicCapcity_Click(object sender, EventArgs e)
        {
            //catch non numerical inputs
            try
            {
                string ppo1 = textBoxPPO1.Text;
                string ppo2 = textBoxPPO2.Text;
                string ppo3 = textBoxPPO3.Text;
                string ppo4 = textBoxPPO4.Text;
                string ppo5 = textBoxPPO5.Text;
                string ppo6 = textBoxPPO6.Text;
                string AC = ActiveCalculator.anaerobicthCalculator.RastAnaerobicCapacity(double.Parse(ppo1), double.Parse(ppo2), double.Parse(ppo3), double.Parse(ppo4), double.Parse(ppo5), double.Parse(ppo6));
                string labelDesc = "AC: " + AC;
                labelAnaerobicCapacity.Text = (labelDesc);
                //store in local object memory list
                ActiveCalculator.anaerobicthCalculator.SaveToRASTACMemory(ppo1 + "," + ppo2 + "," + ppo3 + "," + ppo4 + "," + ppo5 + "," + ppo6 + "," + labelDesc);
                //add to history DB
                ActiveCalculator.calcualtor.SaveToCalculatorHistory(ActiveCalculator.anaerobicthCalculator.ToString(), "RAST Anaerobic Capacity", ppo1 + " + " + ppo2 + " + " + ppo3 + " + " + ppo4 + " + " + ppo5 + " + " + ppo6, labelDesc);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Invalid Input");
            }
        }

        //goes back through the objects local memory to the previous calculation
        private void button1_Click(object sender, EventArgs e)
        {
            if (ActiveCalculator.anaerobicthCalculator.currentRASTACCalcualtionLoaded > 0)
            {
                string calculationData = ActiveCalculator.anaerobicthCalculator.localRASTACCalculationMemory[ActiveCalculator.anaerobicthCalculator.currentRASTACCalcualtionLoaded - 1];
                string[] calculationFileds = calculationData.Split(',');
                textBoxPPO1.Text = calculationFileds[0];
                textBoxPPO2.Text = calculationFileds[1];
                textBoxPPO3.Text = calculationFileds[2];
                textBoxPPO4.Text = calculationFileds[3];
                textBoxPPO5.Text = calculationFileds[4];
                textBoxPPO6.Text = calculationFileds[5];
                labelAnaerobicCapacity.Text = calculationFileds[6];
                //remove current calculation
                ActiveCalculator.anaerobicthCalculator.localRASTACCalculationMemory.Remove(ActiveCalculator.anaerobicthCalculator.localRASTACCalculationMemory[ActiveCalculator.anaerobicthCalculator.currentRASTACCalcualtionLoaded]);
                ActiveCalculator.anaerobicthCalculator.currentRASTACCalcualtionLoaded--;
            }
        }
    }
}
