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
    public partial class FormWingate : Form
    {
        public FormWingate()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            ActiveCalculator.anaerobicthCalculator.About("Wingate");
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            List<TextBox> textBoxes = new List<TextBox>() { textBoxDistance, textBoxForce, textBoxTime, textBoxLowestPeakPower, textBoxPeakPower, textBoxPPO1, textBoxPPO2, textBoxPPO3, textBoxPPO4, textBoxPPO5, textBoxPPO6 };
            ActiveCalculator.calcualtor.RefreshFields(textBoxes);
        }

        private void buttonCalculatePPO_Click(object sender, EventArgs e)
        {
            try
            {
                string force = textBoxForce.Text;
                string distance = textBoxDistance.Text;
                string time = textBoxTime.Text;
                string rofd = ActiveCalculator.anaerobicthCalculator.WingatePeakPowerOutput(double.Parse(force), double.Parse(distance), double.Parse(time));
                string labelDesc = "PPO: " + rofd;
                labelPPO.Text = (labelDesc);
                ActiveCalculator.anaerobicthCalculator.SaveToWingatePeakPowerMemory(force + "," + distance + "," + time + "," + labelDesc);
                ActiveCalculator.calcualtor.SaveToCalculatorHistory(ActiveCalculator.anaerobicthCalculator.ToString(), "Wingate Peak Power", "PPO = " + force + " * " + distance + " ÷ " + time, labelDesc);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Invalid Input");
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (ActiveCalculator.anaerobicthCalculator.currentWingatePeakPowerCalcualtionLoaded > 0)
            {
                string calculationData = ActiveCalculator.anaerobicthCalculator.localWingatePeakPowerCalculationMemory[ActiveCalculator.anaerobicthCalculator.currentWingatePeakPowerCalcualtionLoaded - 1];
                string[] calculationFileds = calculationData.Split(',');
                textBoxForce.Text = calculationFileds[0];
                textBoxDistance.Text = calculationFileds[1];
                textBoxTime.Text = calculationFileds[2];
                labelPPO.Text = calculationFileds[3];
                //delete it from list when gone
                ActiveCalculator.anaerobicthCalculator.localWingatePeakPowerCalculationMemory.Remove(ActiveCalculator.anaerobicthCalculator.localWingatePeakPowerCalculationMemory[ActiveCalculator.anaerobicthCalculator.currentWingatePeakPowerCalcualtionLoaded]);
                ActiveCalculator.anaerobicthCalculator.currentWingatePeakPowerCalcualtionLoaded--;
            }
        }

        private void buttonCalculateAnaerboicCapcity_Click(object sender, EventArgs e)
        {
            try
            {
                string ppo1 = textBoxPPO1.Text;
                string ppo2 = textBoxPPO2.Text;
                string ppo3 = textBoxPPO3.Text;
                string ppo4 = textBoxPPO4.Text;
                string ppo5 = textBoxPPO5.Text;
                string ppo6 = textBoxPPO6.Text;
                string ac = ActiveCalculator.anaerobicthCalculator.WingateAnaerobicCapacity(double.Parse(ppo1), double.Parse(ppo2), double.Parse(ppo3), double.Parse(ppo4), double.Parse(ppo5), double.Parse(ppo6));
                string labelDesc = "AC: " + ac;
                labelAnaerobicCapacity.Text = (labelDesc);
                ActiveCalculator.anaerobicthCalculator.SaveToWingatACMemory(ppo1 + "," + ppo2 + "," + ppo3 + "," + ppo4 + "," + ppo5 + "," + ppo6 + "," + labelDesc);
                ActiveCalculator.calcualtor.SaveToCalculatorHistory(ActiveCalculator.anaerobicthCalculator.ToString(), "Wingate Anaerobic Capacity", ppo1 + " + " + ppo2 + " + " + ppo3 + " + " + ppo4 + " + " + ppo5 + " + " + ppo6, labelDesc);

            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Invalid Input");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ActiveCalculator.anaerobicthCalculator.currentWingatACCalcualtionLoaded > 0)
            {
                string calculationData = ActiveCalculator.anaerobicthCalculator.localWingatACCalculationMemory[ActiveCalculator.anaerobicthCalculator.currentWingatACCalcualtionLoaded - 1];
                string[] calculationFileds = calculationData.Split(',');
                textBoxPPO1.Text = calculationFileds[0];
                textBoxPPO2.Text = calculationFileds[1];
                textBoxPPO3.Text = calculationFileds[2];
                textBoxPPO4.Text = calculationFileds[3];
                textBoxPPO5.Text = calculationFileds[4];
                textBoxPPO6.Text = calculationFileds[5];
                labelAnaerobicCapacity.Text = calculationFileds[6];
                //delete it from list when gone
                ActiveCalculator.anaerobicthCalculator.localWingatACCalculationMemory.Remove(ActiveCalculator.anaerobicthCalculator.localWingatACCalculationMemory[ActiveCalculator.anaerobicthCalculator.currentWingatACCalcualtionLoaded]);
                ActiveCalculator.anaerobicthCalculator.currentWingatACCalcualtionLoaded--;
            }
        }

        private void buttonCalcualateFatigue_Click(object sender, EventArgs e)
        {
            try
            {
                string peakPower = textBoxPeakPower.Text;
                string lowestPower = textBoxLowestPeakPower.Text;
                string FI = ActiveCalculator.anaerobicthCalculator.WingateFatigueIndex(double.Parse(peakPower), double.Parse(lowestPower));
                string labelDesc = "FI: " + FI;
                labelFatigue.Text = (labelDesc);
                ActiveCalculator.anaerobicthCalculator.SaveToWingateFIMemory(peakPower + "," + lowestPower + "," + labelDesc);
                ActiveCalculator.calcualtor.SaveToCalculatorHistory(ActiveCalculator.anaerobicthCalculator.ToString(), "Wingate Fatigue Index", "AF = ((" + peakPower + " – " + lowestPower + ") ÷ (" + peakPower +")) * 100", labelDesc);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Invalid Input");
            }
        }

        private void buttonFIback_Click(object sender, EventArgs e)
        {
            if (ActiveCalculator.anaerobicthCalculator.currentWingateFICalcualtionLoaded > 0)
            {
                string calculationData = ActiveCalculator.anaerobicthCalculator.localWingateFICalculationMemory[ActiveCalculator.anaerobicthCalculator.currentWingateFICalcualtionLoaded - 1];
                string[] calculationFileds = calculationData.Split(',');
                textBoxPeakPower.Text = calculationFileds[0];
                textBoxLowestPeakPower.Text = calculationFileds[1];
                labelFatigue.Text = calculationFileds[2];
                //delete it from list when gone
                ActiveCalculator.anaerobicthCalculator.localWingateFICalculationMemory.Remove(ActiveCalculator.anaerobicthCalculator.localWingateFICalculationMemory[ActiveCalculator.anaerobicthCalculator.currentWingateFICalcualtionLoaded]);
                ActiveCalculator.anaerobicthCalculator.currentWingateFICalcualtionLoaded--;
            }
        }
    }
}
