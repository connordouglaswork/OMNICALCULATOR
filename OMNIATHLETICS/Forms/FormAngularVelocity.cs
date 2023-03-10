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
                string angleInit = textBoxAngleInit.Text;
                string angleFinal = textBoxAngleFinal.Text;
                string timeInit = textBoxTimeInit.Text;
                string timeFinal = textBoxTimeFinal.Text;
                string angularVelocity = ActiveCalculator.biomechanicsCalculator.AngularVelocity(double.Parse(angleInit), double.Parse(angleFinal), double.Parse(timeInit), double.Parse(timeFinal));
                string labelDesc = "Angular Velocity: " + angularVelocity;
                labelAngularVelocity.Text = (labelDesc);
                //store in local object memory list
                ActiveCalculator.biomechanicsCalculator.SaveToAngularVelocityMemory(angleInit + "," + angleFinal + "," + timeInit + "," + timeFinal + "," + labelDesc);
                //add to history DB
                ActiveCalculator.calcualtor.SaveToCalculatorHistory(ActiveCalculator.biomechanicsCalculator.ToString(), "Angular Velocity", "w = " + angleFinal + " - " + angleInit + " / " + timeFinal + "-" + timeInit, labelDesc);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Invalid Input");
            }
        }

        //goes back through the objects local memory to the previous calculation
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
                //remove current calculation
                ActiveCalculator.biomechanicsCalculator.localAngularVelocityCalculationMemory.Remove(ActiveCalculator.biomechanicsCalculator.localAngularVelocityCalculationMemory[ActiveCalculator.biomechanicsCalculator.currentAngularVelocityCalcualtionLoaded]);
                ActiveCalculator.biomechanicsCalculator.currentAngularVelocityCalcualtionLoaded--;
            }
        }

        //display info about the equation
        private void buttonAbout_Click(object sender, EventArgs e)
        {
            ActiveCalculator.biomechanicsCalculator.About("Angular Velocity");
        }

        //clears text box fields
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            List<TextBox> textBoxes = new List<TextBox>() { textBoxAngleInit, textBoxAngleFinal, textBoxTimeInit, textBoxTimeFinal };
            ActiveCalculator.calcualtor.RefreshFields(textBoxes);
        }
    }
}
