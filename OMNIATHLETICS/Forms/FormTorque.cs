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
    public partial class FormTorque : Form
    {
        public FormTorque()
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
                string force = textBoxForce.Text;
                string radius = textBoxRadius.Text;
                string torque = ActiveCalculator.biomechanicsCalculator.Torque(double.Parse(force), double.Parse(radius));
                string labelDesc = "Torque: " + torque;
                labelTorque.Text = (labelDesc);
                //store in local object memory list
                ActiveCalculator.biomechanicsCalculator.SaveToTorqueMemory(force + "," + radius + "," + labelDesc);
                //add to history DB
                ActiveCalculator.calcualtor.SaveToCalculatorHistory(ActiveCalculator.biomechanicsCalculator.ToString(), "Torque", "T = " + force + "*" + radius, labelDesc);
            }           
            catch
            {
                System.Windows.Forms.MessageBox.Show("Invalid Input");
            }
        }

        //goes back through the objects local memory to the previous calculation
        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (ActiveCalculator.biomechanicsCalculator.currentTorqueCalcualtionLoaded > 0)
            {
                string calculationData = ActiveCalculator.biomechanicsCalculator.localTorqueCalculationMemory[ActiveCalculator.biomechanicsCalculator.currentTorqueCalcualtionLoaded - 1];
                string[] calculationFileds = calculationData.Split(',');
                textBoxForce.Text = calculationFileds[0];
                textBoxRadius.Text = calculationFileds[1];
                labelTorque.Text = calculationFileds[2];
                //remove current calculation
                ActiveCalculator.biomechanicsCalculator.localTorqueCalculationMemory.Remove(ActiveCalculator.biomechanicsCalculator.localTorqueCalculationMemory[ActiveCalculator.biomechanicsCalculator.currentTorqueCalcualtionLoaded]);
                ActiveCalculator.biomechanicsCalculator.currentTorqueCalcualtionLoaded--;
            }
        }

        //display info about the equation
        private void buttonAbout_Click(object sender, EventArgs e)
        {
            ActiveCalculator.biomechanicsCalculator.About("Torque");
        }

        //clears text box fields
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            List<TextBox> textBoxes = new List<TextBox>() { textBoxForce, textBoxRadius };
            ActiveCalculator.calcualtor.RefreshFields(textBoxes);
        }
    }
}
