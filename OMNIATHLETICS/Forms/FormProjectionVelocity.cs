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

        //function to close the form
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //calculate button press event function to get field values, calculate equation and store the result
        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            //catch non numerical inputs
            try
            {
                string velocity = textBoxVelocity.Text;
                string angle = textBoxAngle.Text;
                string horVelocity = ActiveCalculator.biomechanicsCalculator.HorizontalProjectionVelocity(double.Parse(velocity), double.Parse(angle));
                string labelDesc = "Velocity: " + horVelocity;
                labelVel.Text = (labelDesc);
                //store in local object memory list
                ActiveCalculator.biomechanicsCalculator.SaveToHorizontalProjectionVelocityMemory(velocity + "," + angle + "," + labelDesc);
                //add to history DB
                ActiveCalculator.calcualtor.SaveToCalculatorHistory(ActiveCalculator.biomechanicsCalculator.ToString(), "Horizontal Projection Velocoty", "velocity = " + velocity + " COS * " + angle, labelDesc);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Invalid Input");
            }
        }

        //goes back through the objects local memory to the previous calculation
        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (ActiveCalculator.biomechanicsCalculator.currentHorizontalProjectionVelocityCalcualtionLoaded > 0)
            {
                string calculationData = ActiveCalculator.biomechanicsCalculator.localHorizontalProjectionVelocityCalculationMemory[ActiveCalculator.biomechanicsCalculator.currentHorizontalProjectionVelocityCalcualtionLoaded - 1];
                string[] calculationFileds = calculationData.Split(',');
                textBoxVelocity.Text = calculationFileds[0];
                textBoxAngle.Text = calculationFileds[1];
                labelVel.Text = calculationFileds[2];
                //remove current calculation
                ActiveCalculator.biomechanicsCalculator.localHorizontalProjectionVelocityCalculationMemory.Remove(ActiveCalculator.biomechanicsCalculator.localHorizontalProjectionVelocityCalculationMemory[ActiveCalculator.biomechanicsCalculator.currentHorizontalProjectionVelocityCalcualtionLoaded]);
                ActiveCalculator.biomechanicsCalculator.currentHorizontalProjectionVelocityCalcualtionLoaded--;
            }
        }

        //display info about the equation
        private void buttonAbout_Click(object sender, EventArgs e)
        {
            ActiveCalculator.biomechanicsCalculator.About("Horizontal Projection Velocity");
        }

        //clears text box fields
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            List<TextBox> textBoxes = new List<TextBox>() { textBoxVelocity, textBoxAngle };
            ActiveCalculator.calcualtor.RefreshFields(textBoxes);
        }
    }
}
