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
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            string force = textBoxForce.Text;
            string radius = textBoxRadius.Text;
            string torque = ActiveCalculator.biomechanicsCalculator.Torque(double.Parse(force), double.Parse(radius));
            string labelDesc = "Inertia: " + torque;
            labelTorque.Text = (labelDesc);
            ActiveCalculator.biomechanicsCalculator.SaveToTorqueMemory(force + "," + radius + "," + labelDesc);
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (ActiveCalculator.biomechanicsCalculator.currentTorqueCalcualtionLoaded > 0)
            {
                string calculationData = ActiveCalculator.biomechanicsCalculator.localTorqueCalculationMemory[ActiveCalculator.biomechanicsCalculator.currentTorqueCalcualtionLoaded - 1];
                string[] calculationFileds = calculationData.Split(',');
                textBoxForce.Text = calculationFileds[0];
                textBoxRadius.Text = calculationFileds[1];
                labelTorque.Text = calculationFileds[2];
                //delete it from list when gone
                ActiveCalculator.biomechanicsCalculator.localTorqueCalculationMemory.Remove(calculationData);
                ActiveCalculator.biomechanicsCalculator.currentTorqueCalcualtionLoaded--;
            }
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            ActiveCalculator.biomechanicsCalculator.About("Torque");
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            List<TextBox> textBoxes = new List<TextBox>() { textBoxForce, textBoxRadius };
            ActiveCalculator.calcualtor.RefreshFields(textBoxes);
        }
    }
}
