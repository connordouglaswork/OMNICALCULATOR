using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace OMNIATHLETICS
{
    internal class PowerCalculator : Calculator
    {
        string[] localCalculatioMemory = { };

        public PowerCalculator() { }

        //Power Zones - Unit = kg
        public static string PowerZones(string movementType, double oneRepMax)
        {
            double peakPowerZoneLowerLimit;
            double peakPowerZoneUpperLimit;
            if (movementType == "Upper Body")
            {
                peakPowerZoneLowerLimit = oneRepMax * 0.4;
                peakPowerZoneUpperLimit = oneRepMax * 0.7;
            }
            else
            {
                peakPowerZoneLowerLimit = 0;
                peakPowerZoneUpperLimit = oneRepMax * 0.4;
            }
            return (peakPowerZoneLowerLimit.ToString() + "kg - " + peakPowerZoneUpperLimit.ToString() + "kg");
        }

        //Rate of Force Development - Unit= N.s^-1 
        public static string RateOfForceDevelopment(double peakForce, double time)
        {
            double ROFD = peakForce / time;
            return (ROFD.ToString() + "N.s^-1");
        }

        //Lower Body Peak Power Predictor - Unit = W
        public static string LowerBodyPeakPowerPredictor(double jumpHeight, double bodyMass)
        {
            double power = 60.7 * jumpHeight + 45.3 * bodyMass - 2055;
            return (power.ToString() + "W");
        }
    }
}
