using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMNIATHLETICS
{
    public class NutritionCalculator : Calculator
    {
        public override string ToString()
        {
            return ("Nutrition Calculator");
        }

        public List<string> localFFMICalculationMemory = new List<string>();

        public int currentFFMICalcualtionLoaded = -1;

        public void SaveToFFMIMemory(string calculation)
        {
            localFFMICalculationMemory.Add(calculation);
            currentFFMICalcualtionLoaded++;
        }

        public List<string> localBMICalculationMemory = new List<string>();

        public int currentBMICalcualtionLoaded = -1;

        public void SaveToBMIMemory(string calculation)
        {
            localBMICalculationMemory.Add(calculation);
            currentBMICalcualtionLoaded++;
        }

        public List<string> localProteinIndexCalculationMemory = new List<string>();

        public int currentProteinIndexCalcualtionLoaded = -1;

        public void SaveToProteinIndexMemory(string calculation)
        {
            localProteinIndexCalculationMemory.Add(calculation);
            currentProteinIndexCalcualtionLoaded++;
        }

        public List<string> localMetabolicRateCalculationMemory = new List<string>();

        public int currentMetabolicRateCalcualtionLoaded = -1;

        public void SaveToMetabolicRateMemory(string calculation)
        {
            localMetabolicRateCalculationMemory.Add(calculation);
            currentMetabolicRateCalcualtionLoaded++;
        }

        public NutritionCalculator() { }

        public void About(string calcualtion)
        {
            string aboutMSG = "";
            if (calcualtion == "FFMI")
            {
                aboutMSG = "FFMI (Fat-free mass index) is a body composition measure capable of quantifying the" +
                    " amount of muscle mass on your body relative to height and accounting for exclusion of body fat.";
            }
            else if (calcualtion == "BMI")
            {
                aboutMSG = "Body mass index is a body composition tool for analysing total body size with the value derived from the mass and height of a person.";
            }
            else if (calcualtion == "Protein Index")
            {
                aboutMSG = "RDA (amount required to avoid deficiency) = 0.8 g.kg.d\r\nAthletes = 1.2 – 2.0 g.kg.d\r\nWeight loss = 2.3 – 3.1 g.kg.d\r\n ";
            }
            else if (calcualtion == "Metabolic Rate")
            {
                aboutMSG = "The caloric demand (also known as the calorie requirement or kcal requirement) is the number of calories that must be supplied daily through food. The energy provided" +
                    " in meals must be adequate for energy expenditures caused by basic metabolic processes, such as respiration and digestion. ";
            }
            System.Windows.Forms.MessageBox.Show(aboutMSG);
        }

        //FFMI: - Unit = rating
        public string FFMI(double bodyFat, double mass, double height)
        {
            double bodyFatPercent = bodyFat / 100;
            double leanWeight = mass - (mass * bodyFatPercent);
            double index = leanWeight  / (height * height);
            return index.ToString("0.00");
        }

        //BMI: - Unit = rating
        public string BMI(double mass, double height)
        {
            double index = mass / (height * height);
            return index.ToString("0.00");
        }

        //Protein Index: - Unit = g.kg.d
        public string ProteinIndex(double mass, string goal)
        {
            string proteinRec = "";
            double maxprotein = 0;
            double minprotein = 0;
            if (goal == "RDA")
            {
                proteinRec = "0.8 g.kg.d";
                maxprotein = mass * 0.8;
                minprotein = mass * 0.8;
            }
            else if (goal == "Athlete")
            {
                proteinRec = "1.2 – 2.0 g.kg.d";
                maxprotein = mass * 2.0;
                minprotein = mass * 1.2;
            }
            else if (goal == "Weight Loss")
            {
                proteinRec = "2.3 – 3.1 g.kg.d";
                maxprotein = mass * 3.1;
                minprotein = mass * 2.3;
            }
            proteinRec = proteinRec + "\n" + minprotein.ToString("0.00") + "g - " + maxprotein.ToString("0.00") + "g";

            return proteinRec;
        }

        //Metabolic Rate: - Unit = rate
        public string MetabolicRate(double mass, double height, int age, string sex)
        {
            double BMR = 0;
            if(sex == "Male")
            {
                BMR = 66 + (13.7 * mass) + (5 * height) - (6.8 * age);
            }
            else
            {
                BMR = 65 + (9.6 * mass) + (1.8 * height) - (4.7 * age);
            }
            return BMR.ToString("0.00");
        }

    }
}
