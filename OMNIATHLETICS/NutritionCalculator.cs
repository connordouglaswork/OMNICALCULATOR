using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMNIATHLETICS
{
    public class NutritionCalculator : Calculator
    {
        List<string> localCalculatioMemory = new List<string>();

        public int currentCalcualtionLoaded = -1;

        public void SaveToMemory(string calculation)
        {
            localCalculatioMemory.Add(calculation);
            currentCalcualtionLoaded++;
        }

        public NutritionCalculator() { }

        public static string About(string calcualtion)
        {
            string aboutMSG = "";
            if (calcualtion == "FFMI ")
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
            return aboutMSG;
        }

        //FFMI: - Unit = rating
        public static string FFMI(double bodyFat, double mass, double height)
        {
            double leanWeight = (mass * ((100 - bodyFat) / 100));
            double index = (leanWeight / 2.2) * 2.20462 / (height * height);
            return index.ToString();
        }

        //BMI: - Unit = rating
        public static string BMI(double mass, double height)
        {
            double index = mass / height;
            return index.ToString();
        }

        //Protein Index: - Unit = g.kg.d
        public static string ProteinIndex(double mass, string goal)
        {
            string proteinRec = "";
            if(goal == "RDA")
            {
                proteinRec = "0.8 g.kg.d";
            }
            else if (goal == "Athlete")
            {
                proteinRec = "1.2 – 2.0 g.kg.d";
            }
            else if (goal == "Weight loss")
            {
                proteinRec = "2.3 – 3.1 g.kg.d";
            }
            return proteinRec;
        }

        //Metabolic Rate: - Unit = rate
        public static string MetabolicRate(double mass, double height, int age, string sex)
        {
            double BMR = 0;
            if(sex == "male")
            {
                BMR = 66 + (13.7 * mass) + (5 * height) - (6.8 * age);
            }
            else
            {
                BMR = 65 + (9.6 * mass) + (1.8 * height) - (4.7 * age);
            }
            return BMR.ToString();
        }

    }
}
