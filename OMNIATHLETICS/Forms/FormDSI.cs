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
    public partial class FormDSI : Form
    {
        public FormDSI()
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
                string BPF = textBoxBPF.Text;
                string DPF = textBoxDPF.Text;
                string DSI = ActiveCalculator.strengthCalculator.DynamicStrengthIndex(Double.Parse(BPF), Double.Parse(DPF));
                string labelDesc = "DSI: " + DSI;
                labelDSI.Text = (labelDesc);
                //store in local object memory list
                ActiveCalculator.strengthCalculator.SaveToDSIMemory(BPF + "," + DPF + "," + labelDesc);
                //add to history DB
                ActiveCalculator.calcualtor.SaveToCalculatorHistory(ActiveCalculator.strengthCalculator.ToString(), "Dynamic Strength Index", "DSI = " + BPF + " / " + DPF, labelDesc);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Invalid Input");
            }
        }

        //display info about the equation
        private void buttonAbout_Click(object sender, EventArgs e)
        {
            ActiveCalculator.strengthCalculator.About("Dynamic Strength Index");
        }

        //goes back through the objects local memory to the previous calculation
        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (ActiveCalculator.strengthCalculator.currentDSICalcualtionLoaded > 0)
            {
                string calculationData = ActiveCalculator.strengthCalculator.localDSICalculatioMemory[ActiveCalculator.strengthCalculator.currentDSICalcualtionLoaded - 1];
                string[] calculationFileds = calculationData.Split(',');
                textBoxBPF.Text = calculationFileds[0];
                textBoxDPF.Text = calculationFileds[1];
                labelDSI.Text = calculationFileds[2];
                //remove current calculation
                ActiveCalculator.strengthCalculator.localDSICalculatioMemory.Remove(ActiveCalculator.strengthCalculator.localDSICalculatioMemory[ActiveCalculator.strengthCalculator.currentDSICalcualtionLoaded]);
                ActiveCalculator.strengthCalculator.currentDSICalcualtionLoaded--;
            }
        }

        //clears text box fields
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            List<TextBox> textBoxes = new List<TextBox>() { textBoxBPF, textBoxDPF };
            ActiveCalculator.calcualtor.RefreshFields(textBoxes);
        }
    }
}
