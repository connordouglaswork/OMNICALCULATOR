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
    public partial class FormDSI : Form
    {
        public FormDSI()
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
                string BPF = textBoxBPF.Text;
                string DPF = textBoxDPF.Text;
                string DSI = ActiveCalculator.strengthCalculator.DynamicStrengthIndex(Double.Parse(BPF), Double.Parse(DPF));
                string labelDesc = "DSI: " + DSI;
                labelDSI.Text = (labelDesc);
                ActiveCalculator.strengthCalculator.SaveToDSIMemory(BPF + "," + DPF + "," + labelDesc);
            }           
            catch
            {
                System.Windows.Forms.MessageBox.Show("Invalid Input");
            }
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            ActiveCalculator.strengthCalculator.About("Dynamic Strength Index");
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (ActiveCalculator.strengthCalculator.currentDSICalcualtionLoaded > 0)
            {
                string calculationData = ActiveCalculator.strengthCalculator.localDSICalculatioMemory[ActiveCalculator.strengthCalculator.currentDSICalcualtionLoaded - 1];
                string[] calculationFileds = calculationData.Split(',');
                textBoxBPF.Text = calculationFileds[0];
                textBoxDPF.Text = calculationFileds[1];
                labelDSI.Text = calculationFileds[2];
                //delete it from list when gone
                ActiveCalculator.strengthCalculator.localDSICalculatioMemory.Remove(ActiveCalculator.strengthCalculator.localDSICalculatioMemory[ActiveCalculator.strengthCalculator.currentDSICalcualtionLoaded]);
                ActiveCalculator.strengthCalculator.currentDSICalcualtionLoaded--;
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            List<TextBox> textBoxes = new List<TextBox>() { textBoxBPF, textBoxDPF };
            ActiveCalculator.calcualtor.RefreshFields(textBoxes);
        }
    }
}
