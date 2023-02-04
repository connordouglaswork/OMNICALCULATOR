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
    public partial class FormProjectionVelocity : Form
    {
        public FormProjectionVelocity()
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
                string velocity = textBoxVelocity.Text;
                string angle = textBoxAngle.Text;
                string horVelocity = ActiveCalculator.biomechanicsCalculator.HorizontalProjectionVelocity(double.Parse(velocity), double.Parse(angle));
                string labelDesc = "Velocity: " + horVelocity;
                labelVel.Text = (labelDesc);
                ActiveCalculator.biomechanicsCalculator.SaveToHorizontalProjectionVelocityMemory(velocity + "," + angle + "," + labelDesc);
                ActiveCalculator.calcualtor.SaveToCalculatorHistory(ActiveCalculator.biomechanicsCalculator.ToString(), "Horizontal Projection Velocoty", "The horizontal component of the projection velocity = " + velocity + " COS * " + angle, labelDesc);

            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Invalid Input");
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (ActiveCalculator.biomechanicsCalculator.currentHorizontalProjectionVelocityCalcualtionLoaded > 0)
            {
                string calculationData = ActiveCalculator.biomechanicsCalculator.localHorizontalProjectionVelocityCalculationMemory[ActiveCalculator.biomechanicsCalculator.currentHorizontalProjectionVelocityCalcualtionLoaded - 1];
                string[] calculationFileds = calculationData.Split(',');
                textBoxVelocity.Text = calculationFileds[0];
                textBoxAngle.Text = calculationFileds[1];
                labelVel.Text = calculationFileds[2];
                //delete it from list when gone
                ActiveCalculator.biomechanicsCalculator.localHorizontalProjectionVelocityCalculationMemory.Remove(ActiveCalculator.biomechanicsCalculator.localHorizontalProjectionVelocityCalculationMemory[ActiveCalculator.biomechanicsCalculator.currentHorizontalProjectionVelocityCalcualtionLoaded]);
                ActiveCalculator.biomechanicsCalculator.currentHorizontalProjectionVelocityCalcualtionLoaded--;
            }
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            ActiveCalculator.biomechanicsCalculator.About("Horizontal Projection Velocity");
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            List<TextBox> textBoxes = new List<TextBox>() { textBoxVelocity, textBoxAngle };
            ActiveCalculator.calcualtor.RefreshFields(textBoxes);
        }
    }
}
