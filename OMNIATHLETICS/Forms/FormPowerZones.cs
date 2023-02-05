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
    public partial class FormPowerZones : Form
    {
        public FormPowerZones()
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
                string type = "";
                if (radioButton3.Checked)
                {
                    type = "Upper Body";
                }
                else if (radioButton2.Checked)
                {
                    type = "Lower Body";
                }
                string zone = ActiveCalculator.powerCalculator.PowerZones(type, double.Parse(max));
                string labelDesc = "Peak Power Zone: " + zone;
                labelPeakPowerZone.Text = (labelDesc);
                //store in local object memory list
                ActiveCalculator.powerCalculator.SaveToZonesMemory(max + "," + type + "," + labelDesc);
                //add to history DB
                ActiveCalculator.calcualtor.SaveToCalculatorHistory(ActiveCalculator.powerCalculator.ToString(), "Power Zones", "1RM = " + max , labelDesc);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Invalid Input");
            }
        }

        //goes back through the objects local memory to the previous calculation
        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (ActiveCalculator.powerCalculator.currentZonesCalcualtionLoaded > 0)
            {
                string calculationData = ActiveCalculator.powerCalculator.localZonesCalculationMemory[ActiveCalculator.powerCalculator.currentZonesCalcualtionLoaded - 1];
                string[] calculationFileds = calculationData.Split(',');
                textBox1RM.Text = calculationFileds[0];
                if(calculationFileds[1] == "Upper Body")
                {
                    radioButton3.Checked = true;
                    radioButton2.Checked = false;
                }
                else
                {
                    radioButton3.Checked = false;
                    radioButton2.Checked = true;
                }

                labelPeakPowerZone.Text = calculationFileds[2];
                //remove current calculation
                ActiveCalculator.powerCalculator.localZonesCalculationMemory.Remove(ActiveCalculator.powerCalculator.localZonesCalculationMemory[ActiveCalculator.powerCalculator.currentZonesCalcualtionLoaded]);
                ActiveCalculator.powerCalculator.currentZonesCalcualtionLoaded--;
            }
        }

        //clears text box fields
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            List<TextBox> textBoxes = new List<TextBox>() { textBox1RM };
            ActiveCalculator.calcualtor.RefreshFields(textBoxes);
        }

        //display info about the equation
        private void buttonAbout_Click(object sender, EventArgs e)
        {
            ActiveCalculator.powerCalculator.About("Power Zones");
        }
    }
}
