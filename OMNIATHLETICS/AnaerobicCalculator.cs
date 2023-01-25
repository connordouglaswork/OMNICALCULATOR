using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMNIATHLETICS
{
    internal class AnaerobicCalculator : Calculator
    {
        string[] localCalculatioMemory = { };

        public AnaerobicCalculator() { }

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
