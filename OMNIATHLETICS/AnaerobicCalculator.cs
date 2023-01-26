using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMNIATHLETICS
{
    internal class AnaerobicCalculator : Calculator
    {
        List<string> localCalculatioMemory = new List<string>();

        public int currentCalcualtionLoaded = -1;

        public void SaveToMemory(string calculation)
        {
            localCalculatioMemory.Add(calculation);
            currentCalcualtionLoaded++;
        }

        public AnaerobicCalculator() { }

        public static string About(string calcualtion)
        {
            string aboutMSG = "";
            if(calcualtion == "Wingate")
            {
                aboutMSG = "Wingate is a 30 second maximal effort anaerobic laboratory test performed " +
                    "on a cycle ergometer commonly using the monarch. The test measures anaerobic power and capacity.";
            }
            else if (calcualtion == "RAST")
            {
                aboutMSG = "Developed at the University of Wolverhampton the Running Based Anaerobic Sprint Test RAST is " +
                    "designed to measure anaerobic power and capacity.";
            }
            else if (calcualtion == "Phosphate Recovery Test")
            {
                aboutMSG = "The Phosphate Recovery Test is an anaerobic fitness test, assessing the ability to recover between" +
                    " sprints and produce the same level of power repeatedly. ";
            }
            return aboutMSG;
        }

        //Wingate Peak Power Output: - Unit = W
        public static string WingatePeakPowerOutput(double force, double distance, double time)
        {
            double PPO = force * distance / time;
            return (PPO.ToString() + "W");
        }

        //Wingate Anaerobic Capacity: - Unit = ?
        public static string WingateAnaerobicCapacity(double peakPowerOne, double peakPowerTwo, double peakPowerThree, double peakPowerFour, double peakPowerFive, double peakPowerSix)
        {
            double AC = peakPowerOne + peakPowerTwo + peakPowerThree + peakPowerFour + peakPowerFive + peakPowerSix;
            return (AC.ToString() + "?");
        }

        //Wingate Fatigue Index: - Unit = index
        public static string WingateFatigueIndex(double PeakPower, double LowestPower)
        {
            double AF = ((PeakPower - LowestPower) / (PeakPower)) * 100;
            return AF.ToString();
        }

        //RAST Anaerobic Capacity: - Unit = ?
        public static string RastAnaerobicCapacity(double peakPowerOne, double peakPowerTwo, double peakPowerThree, double peakPowerFour, double peakPowerFive, double peakPowerSix)
        {
            double AC = peakPowerOne + peakPowerTwo + peakPowerThree + peakPowerFour + peakPowerFive + peakPowerSix;
            return (AC.ToString() + "?");
        }


        //Rast Fatigue Index: - Unit = index
        public static string RastFatigueIndex(double PeakPower, double LowestPower, double time)
        {
            double FI = (PeakPower - LowestPower) / time;
            return FI.ToString();
        }

        //Phosphate Recovery Test Drop Off: - Unit = m
        public static string PhosphateRecoveryTestDropOff(double firstSprintDistance, double lastSprintDistance)
        {
            double dropOffDistance = lastSprintDistance - firstSprintDistance;
            return (dropOffDistance.ToString() + "m");
        }

    }
}
