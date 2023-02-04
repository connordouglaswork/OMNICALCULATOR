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
    public partial class FormAngularVelocity : Form
    {
        public FormAngularVelocity()
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
                string angleInit = textBoxAngleInit.Text;
                string angleFinal = textBoxAngleFinal.Text;
                string timeInit = textBoxTimeInit.Text;
                string timeFinal = textBoxTimeFinal.Text;
                string angularVelocity = ActiveCalculator.biomechanicsCalculator.AngularVelocity(double.Parse(angleInit), double.Parse(angleFinal), double.Parse(timeInit), double.Parse(timeFinal));
                string labelDesc = "Angular Velocity: " + angularVelocity;
                labelAngularVelocity.Text = (labelDesc);
                ActiveCalculator.biomechanicsCalculator.SaveToAngularVelocityMemory(angleInit + "," + angleFinal + "," + timeInit + "," + timeFinal + "," + labelDesc);
                ActiveCalculator.calcualtor.SaveToCalculatorHistory(ActiveCalculator.biomechanicsCalculator.ToString(), "Angular Velocity", "w = " + angleFinal + " - " + angleInit + " / " + timeFinal + "-" + timeInit, labelDesc);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Invalid Input");
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (ActiveCalculator.biomechanicsCalculator.currentAngularVelocityCalcualtionLoaded > 0)
            {
                string calculationData = ActiveCalculator.biomechanicsCalculator.localAngularVelocityCalculationMemory[ActiveCalculator.biomechanicsCalculator.currentAngularVelocityCalcualtionLoaded - 1];
                string[] calculationFileds = calculationData.Split(',');
                textBoxAngleInit.Text = calculationFileds[0];
                textBoxAngleFinal.Text = calculationFileds[1];
                textBoxTimeInit.Text = calculationFileds[2];
                textBoxTimeFinal.Text = calculationFileds[3];
                labelAngularVelocity.Text = calculationFileds[4];
                //delete it from list when gone
                ActiveCalculator.biomechanicsCalculator.localAngularVelocityCalculationMemory.Remove(ActiveCalculator.biomechanicsCalculator.localAngularVelocityCalculationMemory[ActiveCalculator.biomechanicsCalculator.currentAngularVelocityCalcualtionLoaded]);
                ActiveCalculator.biomechanicsCalculator.currentAngularVelocityCalcualtionLoaded--;
            }
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            ActiveCalculator.biomechanicsCalculator.About("Angular Velocity");
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            List<TextBox> textBoxes = new List<TextBox>() { textBoxAngleInit, textBoxAngleFinal, textBoxTimeInit, textBoxTimeFinal };
            ActiveCalculator.calcualtor.RefreshFields(textBoxes);
        }
    }
}
