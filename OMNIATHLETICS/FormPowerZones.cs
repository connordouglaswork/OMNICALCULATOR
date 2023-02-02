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
    public partial class FormPowerZones : Form
    {
        public FormPowerZones()
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
                ActiveCalculator.powerCalculator.SaveToZonesMemory(max + "," + type + "," + labelDesc);
            }           
            catch
            {
                System.Windows.Forms.MessageBox.Show("Invalid Input");
            }
        }

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
                //delete it from list when gone
                ActiveCalculator.powerCalculator.localZonesCalculationMemory.Remove(ActiveCalculator.powerCalculator.localZonesCalculationMemory[ActiveCalculator.powerCalculator.currentZonesCalcualtionLoaded]);
                ActiveCalculator.powerCalculator.currentZonesCalcualtionLoaded--;
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            List<TextBox> textBoxes = new List<TextBox>() { textBox1RM };
            ActiveCalculator.calcualtor.RefreshFields(textBoxes);
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            ActiveCalculator.powerCalculator.About("Power Zones");
        }
    }
}
