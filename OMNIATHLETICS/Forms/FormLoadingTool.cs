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
    public partial class FormLoadingTool : Form
    {
        public FormLoadingTool()
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
                string max = textBox1RM.Text;
                string percent = textBoxPercentage.Text;
                string AcsmPrediction = ActiveCalculator.strengthCalculator.LoadingTool(Double.Parse(percent), Double.Parse(max));
                string labelDesc = "Loading: " + AcsmPrediction;
                labelLoading.Text = (labelDesc);
                //store in local object memory list
                ActiveCalculator.strengthCalculator.SaveToLoadingMemory(max + "," + percent + "," + labelDesc);
                //add to history DB
                ActiveCalculator.calcualtor.SaveToCalculatorHistory(ActiveCalculator.strengthCalculator.ToString(), "Loading Tool", "Loading = " + percent + " / 100 *" + max, labelDesc);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Invalid Input");
            }

        }

        //goes back through the objects local memory to the previous calculation
        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (ActiveCalculator.strengthCalculator.currentLoadingCalcualtionLoaded > 0)
            {
                string calculationData = ActiveCalculator.strengthCalculator.localLoadingCalculatioMemory[ActiveCalculator.strengthCalculator.currentLoadingCalcualtionLoaded - 1];
                string[] calculationFileds = calculationData.Split(',');
                textBox1RM.Text = calculationFileds[0];
                textBoxPercentage.Text = calculationFileds[1];
                labelLoading.Text = calculationFileds[2];
                //remove current calculation
                ActiveCalculator.strengthCalculator.localLoadingCalculatioMemory.Remove(ActiveCalculator.strengthCalculator.localLoadingCalculatioMemory[ActiveCalculator.strengthCalculator.currentLoadingCalcualtionLoaded]);
                ActiveCalculator.strengthCalculator.currentLoadingCalcualtionLoaded--;
            }
        }

        //display info about the equation
        private void buttonAbout_Click(object sender, EventArgs e)
        {
            ActiveCalculator.strengthCalculator.About("Loading Tool");
        }

        //clears text box fields
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            List<TextBox> textBoxes = new List<TextBox>() { textBox1RM, textBoxPercentage };
            ActiveCalculator.calcualtor.RefreshFields(textBoxes);
        }
    }
}
