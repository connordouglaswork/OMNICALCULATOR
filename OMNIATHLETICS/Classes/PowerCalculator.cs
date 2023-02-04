using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace OMNIATHLETICS
{
    //class for building power calculators capable of managing power calculations
    public class PowerCalculator : Calculator
    {
        //contructs power calculator for use
        public PowerCalculator() { }

        public override string ToString()
        {
            return ("Power Calculator");
        }

        #region MEMORY
        //foreach different calculation type
        //current memory position - currentCalcualtionLoaded
        //local memory - localCalculatioMemory
        //saves equation data to local memory - SaveToMemory
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
        #endregion

        //displays about information for a given equation
        public void About(string calcualtion)
        {
            string aboutMSG = "";
            if (calcualtion == "Power Zones")
            {
                aboutMSG = "Power is defined by the ability of the neuromuscular system to produce force quickly. Maximum power " +
                    "occurs across a ‘bandwidth’ of loads with factors such as fibre types, Individual differences, experience and" +
                    " exercise influence the peak power zone. Many scientific studies including Bourque (2003) conclude the following." +
                    "Peak Power Zones:Lower body 0-40% 1RM for peak power. Upper body 40-70% 1RM for peak power";
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
            System.Windows.Forms.MessageBox.Show(aboutMSG);
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
            return (peakPowerZoneLowerLimit.ToString("0") + "kg - " + peakPowerZoneUpperLimit.ToString("0") + "kg");
        }

        //Rate of Force Development - Unit= N.s^-1 
        public string RateOfForceDevelopment(double peakForce, double time)
        {
            double ROFD = peakForce / time;
            return (ROFD.ToString("0.00") + "N.s^-1");
        }

        //Lower Body Peak Power Predictor - Unit = W
        public string LowerBodyPeakPowerPredictor(double jumpHeight, double bodyMass)
        {
            double power = 60.7 * jumpHeight + 45.3 * bodyMass - 2055;
            return (power.ToString("0.00") + "W");
        }
    }
}
