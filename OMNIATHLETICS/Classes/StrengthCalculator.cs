using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMNIATHLETICS
{
    public class StrengthCalculator : Calculator
    {
        public StrengthCalculator() { }

        public override string ToString()
        {
            return ("Strength Calculator");
        }

        public int currentACSMCalcualtionLoaded = -1;

        public List<string> localACSMCalculatioMemory = new List<string>();

        public void SaveToACSMMemory(string calculation)
        {
            localACSMCalculatioMemory.Add(calculation);
            currentACSMCalcualtionLoaded++;
        }

        public int currentDSICalcualtionLoaded = -1;

        public List<string> localDSICalculatioMemory = new List<string>();

        public void SaveToDSIMemory(string calculation)
        {
            localDSICalculatioMemory.Add(calculation);
            currentDSICalcualtionLoaded++;
        }

        public int currentLoadingCalcualtionLoaded = -1;

        public List<string> localLoadingCalculatioMemory = new List<string>();

        public void SaveToLoadingMemory(string calculation)
        {
            localLoadingCalculatioMemory.Add(calculation);
            currentLoadingCalcualtionLoaded++;
        }

        public int currentEURCalcualtionLoaded = -1;

        public List<string> localEURCalculatioMemory = new List<string>();

        public void SaveToEURMemory(string calculation)
        {
            localEURCalculatioMemory.Add(calculation);
            currentEURCalcualtionLoaded++;
        }
       
        public void About(string calcualtion)
        {
            string aboutMSG = "";
            if (calcualtion == "ACSM 1RM Predictor")
            {
                aboutMSG = "The golden standard assessment for testing athletes’ strength is the 1 rep max test. " +
                    "However, many factors such as time, experience, injury, fatigue, safety and more means that the " +
                    "1 rep max test isn’t always a viable option. This is where strength coaches can supplement 1RM " +
                    "protocols for 1RM predictor protocols. The American College of Sports Medicine outline the ACSM " +
                    "1RM predictor protocol as a viable predictor of 1RM’s in multi joint exercises. " +
                    "1.Establish maximum reps at a load (aim to use a weight that’s around your 10RM)." +
                    "2.Multiply the number of repetitions you can perform on an exercise to failure by 2.5. For example, a load you can lift 10 around." +
                    "3.Subtract that number from 100 to determine the percentage of your 1RM." +
                    "4.Divide the above number by 100 to get a decimal value." +
                    "5.Divide the weight you lifted by the decimal value to get your estimated 1RM.";
            }
            else if (calcualtion == "Dynamic Strength Index")
            {
                aboutMSG = "The dynamic strength index is the ratio between an athlete’s ballistic peak force and their dynamic " +
                    "peak force giving an overall idea of an athlete’s strength potential and their ability to utilize it in " +
                    "ballistic movements. An example of a ballistic peak force test is a maximal force production counter movement" +
                    " jump and a dynamic peak force test could be a 1RM squat." +
                    "1.Perform and measure dynamic peak force test (eg 1RM)" +
                    "2.Perform and measure ballistic peak force test (eg Counter movement jump using a force plate)";
            }
            else if (calcualtion == "Loading Tool")
            {
                aboutMSG = "Strength coaches prescribe different loadings for exercise sets dependent on the movement, athlete, " +
                    "equipment, training goals and more. The loadings are represented as % of 1RM. Therefore multiple percentage " +
                    "equations take place over a given training session making calculation set loadings an important process to streamline. ";
            }
            else if (calcualtion == "Eccentric Utilisation Ratio")
            {
                aboutMSG = "The EUR test is a low fatigue test that examines stretch shortening cycle utilization in athletes. The eccentric " +
                    "utilisation ratio is the ratio between countermovement jump and squat jump heights and is a great indicator of lower-extremity" +
                    " stretch-shortening cycle (SSC) performance in athletes. The EUR is great for exposing an athlete’s lack of ability to utilize the" +
                    " SSC. Note that most athletes should have an EUR greater than 1.";
            }
            System.Windows.Forms.MessageBox.Show(aboutMSG);
        }

        //ACSM 1RM Predictor - Unit = kg
        public string Acsm1rmPredictor(double loading, int reps)
        {
            double oneRepMax = loading / ((100 - (reps * 2.5)) / 100);
            return (oneRepMax.ToString("0.00") + "kg");
        }

        //Dynamic Strength Index - Unit = ratio
        public string DynamicStrengthIndex(double BPF, double DPF)
        {
            double DSI = BPF / DPF;
            return DSI.ToString("0.00");
        }

        //Loading Tool - Unit = kg
        public string LoadingTool(double percent, double oneRepMax)
        {
            double loading = (percent / 100) * oneRepMax;
            return (loading.ToString("0.00") + "kg");
        }

        //Eccentric Utilisation Ratio - Unit = ratio
        public string EccentricUtilisationRatio(double CMJ, double SJ)
        {
            double EUR = CMJ / SJ;
            return EUR.ToString("0.00");
        }
    }
}
