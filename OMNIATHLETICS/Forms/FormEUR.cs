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
    public partial class FormEUR : Form
    {
        public FormEUR()
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
                string CMJ = textBoxCMJ.Text;
                string SJ = textBoxSJ.Text;
                string EUR = ActiveCalculator.strengthCalculator.EccentricUtilisationRatio(Double.Parse(CMJ), int.Parse(SJ));
                string labelDesc = "EUR: " + EUR;
                labelEUR.Text = (labelDesc);
                //store in local object memory list
                ActiveCalculator.strengthCalculator.SaveToEURMemory(CMJ + "," + SJ + "," + labelDesc);
                //add to history DB
                ActiveCalculator.calcualtor.SaveToCalculatorHistory(ActiveCalculator.strengthCalculator.ToString(), "Eccentric Utilisation Ratio","EUR = " + CMJ + " / " + SJ, labelDesc);

            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Invalid Input");
            }
        }

        //goes back through the objects local memory to the previous calculation
        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (ActiveCalculator.strengthCalculator.currentEURCalcualtionLoaded > 0)
            {
                string calculationData = ActiveCalculator.strengthCalculator.localEURCalculatioMemory[ActiveCalculator.strengthCalculator.currentEURCalcualtionLoaded - 1];
                string[] calculationFileds = calculationData.Split(',');
                textBoxCMJ.Text = calculationFileds[0];
                textBoxSJ.Text = calculationFileds[1];
                labelEUR.Text = calculationFileds[2];
                //remove current calculation
                ActiveCalculator.strengthCalculator.localEURCalculatioMemory.Remove(ActiveCalculator.strengthCalculator.localEURCalculatioMemory[ActiveCalculator.strengthCalculator.currentEURCalcualtionLoaded]);
                ActiveCalculator.strengthCalculator.currentEURCalcualtionLoaded--;
            }
        }

        //display info about the equation
        private void buttonAbout_Click(object sender, EventArgs e)
        {
            ActiveCalculator.strengthCalculator.About("Eccentric Utilisation Ratio");
        }

        //clears text box fields
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            List<TextBox> textBoxes = new List<TextBox>() { textBoxSJ, textBoxCMJ };
            ActiveCalculator.calcualtor.RefreshFields(textBoxes);
        }
    }
}
