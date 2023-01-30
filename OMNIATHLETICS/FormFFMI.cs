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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace OMNIATHLETICS
{
    public partial class FormFFMI : Form
    {
        public FormFFMI()
        {
            InitializeComponent();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            string mass = textBoxMass.Text;
            string bodyfat = textBoxBodyfat.Text;
            string height = textBoxHeight.Text;
            string ffmi = ActiveCalculator.nutritionCalculator.FFMI(double.Parse(bodyfat), double.Parse(mass), double.Parse(height));
            string labelDesc = "FFMI: " + ffmi;
            labelFFMI.Text = (labelDesc);
            ActiveCalculator.nutritionCalculator.SaveToFFMIMemory(mass + "," + bodyfat + "," + height + "," + labelDesc);
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (ActiveCalculator.nutritionCalculator.currentFFMICalcualtionLoaded > 0)
            {
                string calculationData = ActiveCalculator.nutritionCalculator.localFFMICalculationMemory[ActiveCalculator.nutritionCalculator.currentFFMICalcualtionLoaded - 1];
                string[] calculationFileds = calculationData.Split(',');
                textBoxMass.Text = calculationFileds[0];
                textBoxBodyfat.Text = calculationFileds[1];
                textBoxHeight.Text = calculationFileds[2];
                labelFFMI.Text = calculationFileds[3];
                //delete it from list when gone
                ActiveCalculator.nutritionCalculator.localFFMICalculationMemory.Remove(calculationData);
                ActiveCalculator.nutritionCalculator.currentFFMICalcualtionLoaded--;
            }
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            ActiveCalculator.nutritionCalculator.About("FFMI");
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            List<TextBox> textBoxes = new List<TextBox>() { textBoxBodyfat, textBoxHeight, textBoxMass };
            ActiveCalculator.calcualtor.RefreshFields(textBoxes);
        }
    }
}
