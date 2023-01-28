using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OMNIATHLETICS
{
    public class Calculator
    {
        //HISTORY Database

        //Save to history

        //help function
        public override string ToString()
        {
            return ("Omni Athletics Calculator is a sports science ccalculator for athletes, " +
                "coaches, nutritionists and scientist. The calculator features 6 types of " +
                "calculations strength, power, anaerobic, aerobic, nutirion and biomechanics. " +
                "Implementation of this calculator will allow optimsed training protocols.");
        }


        //Reset Feilds
        public void RefreshFields(List<TextBox> feilds)
        {
            foreach(TextBox feild in feilds)
            {
                feild.Text = "";
            }
        }       

    }
}
