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
    public partial class FormPhosphateRecovery : Form
    {
        public FormPhosphateRecovery()
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
                string firstSprint = textBoxFirstSprint.Text;
                string lastSprint = textBoxLastSprint.Text;
                string dropOff = ActiveCalculator.anaerobicthCalculator.PhosphateRecoveryTestDropOff(double.Parse(firstSprint), double.Parse(lastSprint));
                string labelDesc = "Drop Off: " + dropOff;
                labelDropOff.Text = (labelDesc);
                ActiveCalculator.anaerobicthCalculator.SaveToPRTMemory(firstSprint + "," + lastSprint + "," + labelDesc);
                ActiveCalculator.calcualtor.SaveToCalculatorHistory(ActiveCalculator.anaerobicthCalculator.ToString(), "Phosphate Recovery Test", "Drop off distance = " + lastSprint + " – " + firstSprint, labelDesc);

            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Invalid Input");
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (ActiveCalculator.anaerobicthCalculator.currentPRTCalcualtionLoaded > 0)
            {
                string calculationData = ActiveCalculator.anaerobicthCalculator.localPRTCalculationMemory[ActiveCalculator.anaerobicthCalculator.currentPRTCalcualtionLoaded - 1];
                string[] calculationFileds = calculationData.Split(',');
                textBoxFirstSprint.Text = calculationFileds[0];
                textBoxLastSprint.Text = calculationFileds[1];
                labelDropOff.Text = calculationFileds[2];
                //delete it from list when gone
                ActiveCalculator.anaerobicthCalculator.localPRTCalculationMemory.Remove(ActiveCalculator.anaerobicthCalculator.localPRTCalculationMemory[ActiveCalculator.anaerobicthCalculator.currentPRTCalcualtionLoaded]);
                ActiveCalculator.anaerobicthCalculator.currentPRTCalcualtionLoaded--;
            }
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            ActiveCalculator.anaerobicthCalculator.About("Phosphate Recovery Test");
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            List<TextBox> textBoxes = new List<TextBox>() { textBoxFirstSprint, textBoxLastSprint };
            ActiveCalculator.calcualtor.RefreshFields(textBoxes);
        }
    }
}