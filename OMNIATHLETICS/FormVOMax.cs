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
    public partial class FormVOMax : Form
    {
        public FormVOMax()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                bool platau = false;
                if (checkBoxPlatau.Checked)
                {
                    platau = true;
                }
                string blood = textBoxBloodLactate.Text;
                string rer = textBoxRER.Text;
                string rpe = textRPE.Text;
                string hr = textBoxHeartRate.Text;
                string age = textBoxAge.Text;
                string valid = ActiveCalculator.aerobicCalculator.VOMaxValidator(platau, double.Parse(blood), double.Parse(rer), double.Parse(rpe), double.Parse(hr), int.Parse(age));
                string labelDesc = "Valid VO2 Max: " + valid;
                labelValid.Text = (labelDesc);
                ActiveCalculator.aerobicCalculator.SaveToVOMemory(platau.ToString() + "," + blood + "," + rer + "," + rpe + "," + hr + "," + age + "," + labelDesc);
                ActiveCalculator.calcualtor.SaveToCalculatorHistory(ActiveCalculator.aerobicCalculator.ToString(), "VO2 Max Validator", "Platau Observed=" + platau.ToString() + "Blood Lactate=" + blood + "RER" + rer + "RPE=" + rpe + "hr=" + hr + " age=" + age, labelDesc);

            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Invalid Input");
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (ActiveCalculator.aerobicCalculator.currentVOCalcualtionLoaded > 0)
            {
                string calculationData = ActiveCalculator.aerobicCalculator.localVOCalculationMemory[ActiveCalculator.aerobicCalculator.currentVOCalcualtionLoaded - 1];
                string[] calculationFileds = calculationData.Split(',');
                if(calculationFileds[0] == "true")
                {
                    checkBoxPlatau.Checked = true;
                }
                else
                {
                    checkBoxPlatau.Checked = false;
                }
                textBoxBloodLactate.Text = calculationFileds[1];
                textBoxRER.Text = calculationFileds[2];
                textRPE.Text = calculationFileds[3];
                textBoxHeartRate.Text = calculationFileds[4];
                textBoxAge.Text = calculationFileds[5];
                labelValid.Text = calculationFileds[6];
                //delete it from list when gone
                ActiveCalculator.aerobicCalculator.localVOCalculationMemory.Remove(ActiveCalculator.aerobicCalculator.localVOCalculationMemory[ActiveCalculator.aerobicCalculator.currentVOCalcualtionLoaded]);
                ActiveCalculator.aerobicCalculator.currentVOCalcualtionLoaded--;
            }
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            ActiveCalculator.aerobicCalculator.About("VO2 Max Validator");
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            List<TextBox> textBoxes = new List<TextBox>() { textBoxBloodLactate, textBoxRER, textRPE, textBoxHeartRate };
            ActiveCalculator.calcualtor.RefreshFields(textBoxes);
        }
    }
}
