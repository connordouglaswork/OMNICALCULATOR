using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace OMNIATHLETICS
{
    public class PowerCalculator : Calculator
    {
        public List<string> localZonesCalculationMemory = new List<string>();

        public int currentZonesCalcualtionLoaded = -1;

        public void SaveToZonesMemory(string calculation)
        {
            localZonesCalculationMemory.Add(calculation);
            currentZonesCalcualtionLoaded++;
        }

        public List<string> localROFDCalculationMemory = new List<string>();

        public int currentROFDCalcualtionLoaded = -1;

        public void SaveToROFDMemory(string calculation)
        {
            localROFDCalculationMemory.Add(calculation);
            currentROFDCalcualtionLoaded++;
        }

        public List<string> localPeakCalculationMemory = new List<string>();

        public int currentPeakCalcualtionLoaded = -1;

        public void SaveToPeakMemory(string calculation)
        {
            localPeakCalculationMemory.Add(calculation);
            currentPeakCalcualtionLoaded++;
        }

        public PowerCalculator() { }

        public string About(string calcualtion)
        {
            string aboutMSG = "";
            if (calcualtion == "Power Zones")
            {
                aboutMSG = "Power is defined by the ability of the neuromuscular system to produce force quickly. Maximum power " +
                    "occurs across a ‘bandwidth’ of loads with factors such as fibre types, Individual differences, experience and" +
                    " exercise influence the peak power zone. Many scientific studies including Bourque (2003) conclude the following." +
                    "Peak Power Zones:\r\nLower body \r\n•\t0-40% 1RM for peak power\r\nUpper body\r\n•\t40-70% 1RM for peak power\r\n";
            }
            else if (calcualtion == "Rate of Force Development")
            {
                aboutMSG = "Rate of force development is an expression of explosive strength and is representative of isometric," +
                    " concentric and eccentric contractions within acceleration phases.";
            }
            else if (calcualtion == "Lower Body Peak Power Predictor")
            {
                aboutMSG = "Power is defined by the ability of the neuromuscular system to produce force quickly. Predicting peak " +
                    "power in the lower body is more accurate with squat jumps compared to counter movement jumps. ";
            }
            return aboutMSG;
        }

        //Power Zones - Unit = kg
        public string PowerZones(string movementType, double oneRepMax)
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
        public string RateOfForceDevelopment(double peakForce, double time)
        {
            double ROFD = peakForce / time;
            return (ROFD.ToString() + "N.s^-1");
        }

        //Lower Body Peak Power Predictor - Unit = W
        public string LowerBodyPeakPowerPredictor(double jumpHeight, double bodyMass)
        {
            double power = 60.7 * jumpHeight + 45.3 * bodyMass - 2055;
            return (power.ToString() + "W");
        }
    }
}
