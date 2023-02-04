using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMNIATHLETICS
{
    //class for building aerobic calculators capable of managing aerobic calculations
    public class AerobicCalculator : Calculator
    {
        //contructs aerobic calculator for use
        public AerobicCalculator() { }

        public override string ToString()
        {
            return ("Aerobic Calculator");
        }

        #region MEMORY
        //foreach different calculation type
        //current memory position - currentCalcualtionLoaded
        //local memory - localCalculatioMemory
        //saves equation data to local memory - SaveToMemory
        public List<string> localYoYoCalculationMemory = new List<string>();

        public int currentYoYoCalcualtionLoaded = -1;

        public void SaveToYoYoMemory(string calculation)
        {
            localYoYoCalculationMemory.Add(calculation);
            currentYoYoCalcualtionLoaded++;
        }

        public List<string> localVOCalculationMemory = new List<string>();

        public int currentVOCalcualtionLoaded = -1;

        public void SaveToVOMemory(string calculation)
        {
            localVOCalculationMemory.Add(calculation);
            currentVOCalcualtionLoaded++;
        }
        #endregion

        //displays about information for a given equation
        public void About(string calcualtion)
        {
            string aboutMSG = "";
            if (calcualtion == "Yoyo Intermittent Recovery Test Level 1")
            {
                aboutMSG = "The Yo-Yo test is a maximal aerobic endurance fitness test, involving running " +
                    "between markers placed 20 meters apart, at increasing speeds, until exhaustion. ";
            }
            else if (calcualtion == "VO2 Max Validator")
            {
                aboutMSG = "The use of V02MAX as a measure of cardiorespiratory fitness is widespread throughout the fields" +
                    " of exercise physiology, physiology and medicine. VO2MAX is described as the maximal rate of oxygen " +
                    "consumption and is validified by a plateau of oxygen consumption (VO2). Important validity criteria include" +
                    " blood lactate (La) >8mmol/L, a respiratory exchange ratio (RER) >1.15, a rating of perceived exertion (RPE) > 17," +
                    " and an age-predicted maximal heart rate (APMHR) ±10 beats/min from predicted using 220-age. ";
            }
            System.Windows.Forms.MessageBox.Show(aboutMSG);
        }

        //Yoyo Intermittent Recovery Test Level 1: - Unit = Rating
        public string YoyoIntermittentRecoveryTest(double meters, double level, string method)
        {
            string rating = "";
            if(method == "meters")
            {
                if(meters >= 2400)
                {
                    rating = "Elite";
                }
                else if(meters >= 1960 && meters < 2400)
                {
                    rating = "Excellent";
                }
                else if (meters >= 1480 && meters < 1960)
                {
                    rating = "Good";
                }
                else if (meters >= 1000 && meters < 1480)
                {
                    rating = "Average";
                }
                else if (meters >= 520 && meters < 1000)
                {
                    rating = "Below Average";
                }
                else
                {
                    rating = "Poor";
                }
            }
            else
            {
                if (level >= 20.1)
                {
                    rating = "Elite";
                }
                else if (level >= 18.7 && level < 20.1)
                {
                    rating = "Excellent";
                }
                else if (level >= 17.3 && level < 18.7)
                {
                    rating = "Good";
                }
                else if (level >= 15.7 && level < 17.3)
                {
                    rating = "Average";
                }
                else if (level >= 14.2 && level < 15.7)
                {
                    rating = "Below Average";
                }
                else
                {
                    rating = "Poor";
                }
            }

            return rating;
        }

        //VO2 Max Validator: - Unit = Rating
        public string VOMaxValidator(bool platau, double bloodLactate, double RER, double RPE, double BPM, int age)
        {
            string validStatus = "Not Valid";
            if(platau && bloodLactate > 8 && RER > 1.15 && RPE > 17 && BPM > (age - 30))
            {
                validStatus = "Valid";
            }
            return validStatus;
        }
    }
}
