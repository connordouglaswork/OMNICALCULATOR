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
    public partial class FormAngularAcceleration : Form
    {
        public FormAngularAcceleration()
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
                string velocityInit = textBoxVelocityInit.Text;
                string velocityFinal = textBoxVelocityFinal.Text;
                string timeInit = textBoxTimeInit.Text;
                string timeFinal = textBoxTimeFinal.Text;
                string angularAcceleration = ActiveCalculator.biomechanicsCalculator.AngularAcceleration(double.Parse(velocityInit), double.Parse(velocityFinal), double.Parse(timeInit), double.Parse(timeFinal));
                string labelDesc = "Angular Acceleration: \n" + angularAcceleration;
                labelAngularAcceleration.Text = (labelDesc);
                ActiveCalculator.biomechanicsCalculator.SaveToAngularAccelerationMemory(velocityInit + "," + velocityFinal + "," + timeInit + "," + timeFinal + "," + labelDesc);
                ActiveCalculator.calcualtor.SaveToCalculatorHistory(ActiveCalculator.biomechanicsCalculator.ToString(), "Angular Acceleration", "w = " + velocityFinal + " - " + velocityInit + " / " + timeFinal + "-" + timeInit, labelDesc);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Invalid Input");
            }
        }
        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (ActiveCalculator.biomechanicsCalculator.currentAngularAccelerationCalcualtionLoaded > 0)
            {
                string calculationData = ActiveCalculator.biomechanicsCalculator.localAngularAccelerationCalculationMemory[ActiveCalculator.biomechanicsCalculator.currentAngularAccelerationCalcualtionLoaded - 1];
                string[] calculationFileds = calculationData.Split(',');
                textBoxVelocityInit.Text = calculationFileds[0];
                textBoxVelocityFinal.Text = calculationFileds[1];
                textBoxTimeInit.Text = calculationFileds[0];
                textBoxTimeFinal.Text = calculationFileds[1];
                labelAngularAcceleration.Text = calculationFileds[2];
                //delete it from list when gone
                ActiveCalculator.biomechanicsCalculator.localAngularAccelerationCalculationMemory.Remove(ActiveCalculator.biomechanicsCalculator.localAngularAccelerationCalculationMemory[ActiveCalculator.biomechanicsCalculator.currentAngularAccelerationCalcualtionLoaded]);
                ActiveCalculator.biomechanicsCalculator.currentAngularAccelerationCalcualtionLoaded--;
            }
        }
        private void buttonAbout_Click(object sender, EventArgs e)
        {
            ActiveCalculator.biomechanicsCalculator.About("Angular Acceleration");
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            List<TextBox> textBoxes = new List<TextBox>() { textBoxVelocityInit, textBoxVelocityFinal, textBoxTimeInit, textBoxTimeFinal };
            ActiveCalculator.calcualtor.RefreshFields(textBoxes);
        }
    }
}
