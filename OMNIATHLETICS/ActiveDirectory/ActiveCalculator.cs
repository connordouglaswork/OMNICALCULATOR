using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMNIATHLETICS.ActiveDirectory
{
    public class ActiveCalculator
    {
        public static Calculator calcualtor = new Calculator();
        public static StrengthCalculator strengthCalculator = new StrengthCalculator();
        public static PowerCalculator powerCalculator = new PowerCalculator();
        public static AnaerobicCalculator anaerobicthCalculator = new AnaerobicCalculator();
        public static AerobicCalculator aerobicCalculator = new AerobicCalculator();
        public static NutritionCalculator nutritionCalculator = new NutritionCalculator();
        public static BiomechanicsCalculator biomechanicsCalculator = new BiomechanicsCalculator();
    }
}
