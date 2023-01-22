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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            customizeDesign();
        }
        private void customizeDesign()
        {
            panelStrengthSubMenu.Visible = false;
            panelPowerSubMenu.Visible = false;
            panelAnaerobicSubMenu.Visible = false;
            panelAerobicSubMenu.Visible = false;
            panelNutritionSubMenu.Visible = false;
            panelBiomechanicsSubMenu.Visible = false;
        }

        private void hideSubMenu()
        {
            if (panelStrengthSubMenu.Visible == true)
            {
                panelStrengthSubMenu.Visible = false;
            }
            if (panelPowerSubMenu.Visible == true)
            {
                panelPowerSubMenu.Visible = false;
            }
            if (panelAnaerobicSubMenu.Visible == true)
            {
                panelAnaerobicSubMenu.Visible = false;
            }
            if (panelAerobicSubMenu.Visible == true)
            {
                panelAerobicSubMenu.Visible = false;
            }
            if (panelNutritionSubMenu.Visible == true)
            {
                panelNutritionSubMenu.Visible = false;
            }
            if (panelBiomechanicsSubMenu.Visible == true)
            {
                panelBiomechanicsSubMenu.Visible = false;
            }
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }


        //Menu Dropdown Buttons
        private void buttonStrength_Click(object sender, EventArgs e)
        {
            showSubMenu(panelStrengthSubMenu);
        }

        private void buttonPower_Click(object sender, EventArgs e)
        {
            showSubMenu(panelPowerSubMenu);
        }

        private void buttonAnaerobic_Click(object sender, EventArgs e)
        {
            showSubMenu(panelAnaerobicSubMenu);
        }

        private void buttonAerobic_Click(object sender, EventArgs e)
        {
            showSubMenu(panelAerobicSubMenu);
        }

        private void buttonNutrition_Click(object sender, EventArgs e)
        {
            showSubMenu(panelNutritionSubMenu);
        }

        private void buttonBiomechanics_Click(object sender, EventArgs e)
        {
            showSubMenu(panelBiomechanicsSubMenu);
        }


        //Menu Buttons

        private void buttonHome_Click(object sender, EventArgs e)
        {
            //null
            if (activeForm != null)
            {
                activeForm.Close();
                activeForm = null;
            }
        }

        private void buttonHistory_Click(object sender, EventArgs e)
        {
            //null
        }

        //Sub Menu Buttons
        //Strength sub menu
        private void button1RMPredictor_Click(object sender, EventArgs e)
        {
            //open form
            openChildForms(new FormACSMPredictor());
        }

        private void buttonDSI_Click(object sender, EventArgs e)
        {
            //open form
            openChildForms(new FormDSI());
        }

        private void buttonLoadingTool_Click(object sender, EventArgs e)
        {
            //open form
            openChildForms(new FormLoadingTool());
        }

        private void buttonEUR_Click(object sender, EventArgs e)
        {
            //open form
            openChildForms(new FormEUR());
        }

        //Power sub menu
        private void buttonPowerZones_Click(object sender, EventArgs e)
        {
            //open form
            openChildForms(new FormPowerZones());
        }

        private void buttonROFD_Click(object sender, EventArgs e)
        {
            //open form
            openChildForms(new FormROFD());
        }

        private void buttonLowerBodyPeakPowerPredictor_Click(object sender, EventArgs e)
        {
            //open form
            openChildForms(new FormLowerBodyPeakPowerPredictor());
        }

        //Anaerobic sub menu
        private void buttonWingate_Click(object sender, EventArgs e)
        {
            //open form
            openChildForms(new FormWingate());
        }

        private void buttonRAST_Click(object sender, EventArgs e)
        {
            //open form
            openChildForms(new FormRAST());
        }

        private void buttonPRT_Click(object sender, EventArgs e)
        {
            //open form
            openChildForms(new FormPhosphateRecovery());
        }

        //Aerobic sub menu
        private void buttonYoyo_Click(object sender, EventArgs e)
        {
            //open form
            openChildForms(new FormYoyo());
        }

        private void buttonVO2Max_Click(object sender, EventArgs e)
        {
            //open form
            openChildForms(new FormVOMax());
        }

        //Nutrition sub menu
        private void buttonFFMI_Click(object sender, EventArgs e)
        {
            //open form
            openChildForms(new FormFFMI());
        }

        private void buttonBMI_Click(object sender, EventArgs e)
        {
            //open form
            openChildForms(new FormBMI());
        }

        private void buttonProteinIndex_Click(object sender, EventArgs e)
        {
            //open form
            openChildForms(new FormProteinIndex());
        }

        private void buttonMetabolicRate_Click(object sender, EventArgs e)
        {
            //open form
            openChildForms(new FormMetabolicRate());
        }

        //Biomechanics sub menu
        private void buttonAngularVelocity_Click(object sender, EventArgs e)
        {
            //open form
            openChildForms(new FormAngularVelocity());
        }

        private void buttonAngularAcceleration_Click(object sender, EventArgs e)
        {
            //open form
            openChildForms(new FormAngularAcceleration());
        }

        private void buttonProjectionVelocity_Click(object sender, EventArgs e)
        {
            //open form
            openChildForms(new FormProjectionVelocity());
        }

        private void buttonInertia_Click(object sender, EventArgs e)
        {
            //open form
            openChildForms(new FormInertia());
        }

        private void buttonTorque_Click(object sender, EventArgs e)
        {
            //open form
            openChildForms(new FormTorque());
        }



        private Form activeForm = null;
        private void openChildForms(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelHomePage.Controls.Add(childForm);
            panelHomePage.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

    }
}
