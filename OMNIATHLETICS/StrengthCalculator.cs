using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMNIATHLETICS
{
    internal class StrengthCalculator : Calculator
    {
        string[] localCalculatioMemory = { }; 

        public StrengthCalculator() { }

        //ACSM 1RM Predictor - Unit = kg
        public static string Acsm1rmPredictor(double loading, int reps)
        {
            double oneRepMax = loading / ((100 - (reps * 2.5)) / 100);
            return (oneRepMax.ToString() + "kg");
        }

        //Dynamic Strength Index - Unit = ratio
        public static string DynamicStrengthIndex(double BPF, double DPF)
        {
            double DSI = BPF / DPF;
            return DSI.ToString();
        }

        //Loading Tool - Unit = kg
        public static string LoadingTool(int percent, double oneRepMax)
        {
            double loading = (percent / 100) * oneRepMax;
            return (loading.ToString() + "kg");
        }

        //Eccentric Utilisation Ratio - Unit = ratio
        public static string EccentricUtilisationRatio(double CMJ, double SJ)
        {
            double EUR = CMJ / SJ;
            return EUR.ToString();
        }

    }
}
