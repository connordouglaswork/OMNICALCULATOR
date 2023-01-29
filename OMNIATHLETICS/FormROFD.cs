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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace OMNIATHLETICS
{
    public partial class FormROFD : Form
    {
        public FormROFD()
        {
            InitializeComponent();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            string force = textBoxPeakForce.Text;
            string time = textBoxTime.Text;
            string rofd = ActiveCalculator.powerCalculator.RateOfForceDevelopment(double.Parse(force), double.Parse(time));
            string labelDesc = "ROFD: " + rofd;
            labelROFD.Text = (labelDesc);
            ActiveCalculator.powerCalculator.SaveToROFDMemory(force + "," + time + "," + labelDesc);
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (ActiveCalculator.powerCalculator.currentROFDCalcualtionLoaded > 0)
            {
                string calculationData = ActiveCalculator.powerCalculator.localROFDCalculationMemory[ActiveCalculator.powerCalculator.currentROFDCalcualtionLoaded - 1];
                string[] calculationFileds = calculationData.Split(',');
                textBoxPeakForce.Text = calculationFileds[0];
                textBoxTime.Text = calculationFileds[1];
                labelROFD.Text = calculationFileds[2];
                //delete it from list when gone
                ActiveCalculator.powerCalculator.localROFDCalculationMemory.Remove(calculationData);
                ActiveCalculator.powerCalculator.currentROFDCalcualtionLoaded--;
            }
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            ActiveCalculator.powerCalculator.About("Rate of Force Development");
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            List<TextBox> textBoxes = new List<TextBox>() { textBoxPeakForce, textBoxTime };
            ActiveCalculator.calcualtor.RefreshFields(textBoxes);
        }
    }
}
