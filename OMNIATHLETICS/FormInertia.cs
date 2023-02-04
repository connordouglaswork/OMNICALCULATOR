﻿using OMNIATHLETICS.ActiveDirectory;
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
    public partial class FormInertia : Form
    {
        public FormInertia()
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
                string mass = textBoxMass.Text;
                string radius = textBoxRadius.Text;
                string inertia = ActiveCalculator.biomechanicsCalculator.Inertia(double.Parse(mass), double.Parse(radius));
                string labelDesc = "Inertia: " + inertia;
                labelInertia.Text = (labelDesc);
                ActiveCalculator.biomechanicsCalculator.SaveInertiaToMemory(mass + "," + radius + "," + labelDesc);
                ActiveCalculator.calcualtor.SaveToCalculatorHistory(ActiveCalculator.biomechanicsCalculator.ToString(), "Inertia", "I = " + mass + "*" + radius + "^2", labelDesc);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Invalid Input");
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (ActiveCalculator.biomechanicsCalculator.currentInertiaCalcualtionLoaded > 0)
            {
                string calculationData = ActiveCalculator.biomechanicsCalculator.localInertiaCalculationMemory[ActiveCalculator.biomechanicsCalculator.currentInertiaCalcualtionLoaded - 1];
                string[] calculationFileds = calculationData.Split(',');
                textBoxMass.Text = calculationFileds[0];
                textBoxRadius.Text = calculationFileds[1];
                labelInertia.Text = calculationFileds[2];
                //delete it from list when gone
                ActiveCalculator.biomechanicsCalculator.localInertiaCalculationMemory.Remove(ActiveCalculator.biomechanicsCalculator.localInertiaCalculationMemory[ActiveCalculator.biomechanicsCalculator.currentInertiaCalcualtionLoaded]);
                ActiveCalculator.biomechanicsCalculator.currentInertiaCalcualtionLoaded--;
            }
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            ActiveCalculator.biomechanicsCalculator.About("Inertia");
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            List<TextBox> textBoxes = new List<TextBox>() { textBoxMass, textBoxRadius };
            ActiveCalculator.calcualtor.RefreshFields(textBoxes);
        }
    }
}
