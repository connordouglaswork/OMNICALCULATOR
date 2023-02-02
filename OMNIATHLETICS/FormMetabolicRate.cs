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
    public partial class FormMetabolicRate : Form
    {
        public FormMetabolicRate()
        {
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
                ActiveCalculator.nutritionCalculator.SaveToMetabolicRateMemory(mass + "," + height + "," + age + "," + sex + "," + labelDesc);
            }           
            catch
            {
                System.Windows.Forms.MessageBox.Show("Invalid Input");
            }
        }

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
                //delete it from list when gone
                ActiveCalculator.nutritionCalculator.localMetabolicRateCalculationMemory.Remove(ActiveCalculator.nutritionCalculator.localMetabolicRateCalculationMemory[ActiveCalculator.nutritionCalculator.currentMetabolicRateCalcualtionLoaded]);
                ActiveCalculator.nutritionCalculator.currentMetabolicRateCalcualtionLoaded--;
            }
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            ActiveCalculator.nutritionCalculator.About("Metabolic Rate");
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            List<TextBox> textBoxes = new List<TextBox>() { textBoxHeight, textBoxMass, textBoxAge };
            ActiveCalculator.calcualtor.RefreshFields(textBoxes);
        }
    }
}
