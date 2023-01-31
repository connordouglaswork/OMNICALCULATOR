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
    public partial class FormYoyo : Form
    {
        public FormYoyo()
        {
            InitializeComponent();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            string level = textBoxLevel.Text;
            string distance = textBoxDistance.Text;
            string type = "";
            if(distance != "")
            {
                type = "meters";
            }
            string rating = ActiveCalculator.aerobicCalculator.YoyoIntermittentRecoveryTest(double.Parse(distance), double.Parse(level), type);
            string labelDesc = "Rating: " + rating;
            labelRating.Text = (labelDesc);
            ActiveCalculator.aerobicCalculator.SaveToYoYoMemory(level + "," + distance + "," + labelDesc);
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (ActiveCalculator.aerobicCalculator.currentYoYoCalcualtionLoaded > 0)
            {
                string calculationData = ActiveCalculator.aerobicCalculator.localYoYoCalculationMemory[ActiveCalculator.aerobicCalculator.currentYoYoCalcualtionLoaded - 1];
                string[] calculationFileds = calculationData.Split(',');
                textBoxLevel.Text = calculationFileds[0];
                textBoxDistance.Text = calculationFileds[1];
                labelRating.Text = calculationFileds[2];
                //delete it from list when gone
                ActiveCalculator.aerobicCalculator.localYoYoCalculationMemory.Remove(calculationData);
                ActiveCalculator.aerobicCalculator.currentYoYoCalcualtionLoaded--;
            }
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            ActiveCalculator.aerobicCalculator.About("Yoyo Intermittent Recovery Test Level 1");
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            List<TextBox> textBoxes = new List<TextBox>() { textBoxDistance, textBoxLevel };
            ActiveCalculator.calcualtor.RefreshFields(textBoxes);
        }
    }
}
