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
    public partial class FormEUR : Form
    {
        public FormEUR()
        {
            InitializeComponent();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                string CMJ = textBoxCMJ.Text;
                string SJ = textBoxSJ.Text;
                string EUR = ActiveCalculator.strengthCalculator.EccentricUtilisationRatio(Double.Parse(CMJ), int.Parse(SJ));
                string labelDesc = "EUR: " + EUR;
                labelEUR.Text = (labelDesc);
                ActiveCalculator.strengthCalculator.SaveToEURMemory(CMJ + "," + SJ + "," + labelDesc);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Invalid Input");
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (ActiveCalculator.strengthCalculator.currentEURCalcualtionLoaded > 0)
            {
                string calculationData = ActiveCalculator.strengthCalculator.localEURCalculatioMemory[ActiveCalculator.strengthCalculator.currentEURCalcualtionLoaded - 1];
                string[] calculationFileds = calculationData.Split(',');
                textBoxCMJ.Text = calculationFileds[0];
                textBoxSJ.Text = calculationFileds[1];
                labelEUR.Text = calculationFileds[2];
                //delete it from list when gone
                ActiveCalculator.strengthCalculator.localEURCalculatioMemory.Remove(ActiveCalculator.strengthCalculator.localEURCalculatioMemory[ActiveCalculator.strengthCalculator.currentEURCalcualtionLoaded]);
                ActiveCalculator.strengthCalculator.currentEURCalcualtionLoaded--;
            }
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            ActiveCalculator.strengthCalculator.About("Eccentric Utilisation Ratio");
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            List<TextBox> textBoxes = new List<TextBox>() { textBoxSJ, textBoxCMJ };
            ActiveCalculator.calcualtor.RefreshFields(textBoxes);
        }
    }
}
