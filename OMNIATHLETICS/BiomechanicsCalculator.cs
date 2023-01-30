using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMNIATHLETICS
{
    public class BiomechanicsCalculator : Calculator
    {
        public List<string> localHorizontalProjectionVelocityCalculationMemory = new List<string>();

        public int currentHorizontalProjectionVelocityCalcualtionLoaded = -1;

        public void SaveToHorizontalProjectionVelocityMemory(string calculation)
        {
            localHorizontalProjectionVelocityCalculationMemory.Add(calculation);
            currentHorizontalProjectionVelocityCalcualtionLoaded++;
        }

        public List<string> localAngularVelocityCalculationMemory = new List<string>();

        public int currentAngularVelocityCalcualtionLoaded = -1;

        public void SaveToAngularVelocityMemory(string calculation)
        {
            localAngularVelocityCalculationMemory.Add(calculation);
            currentAngularVelocityCalcualtionLoaded++;
        }

        public List<string> localAngularAccelerationCalculationMemory = new List<string>();

        public int currentAngularAccelerationCalcualtionLoaded = -1;

        public void SaveToAngularAccelerationMemory(string calculation)
        {
            localAngularAccelerationCalculationMemory.Add(calculation);
            currentAngularAccelerationCalcualtionLoaded++;
        }

        public List<string> localInertiaCalculationMemory = new List<string>();

        public int currentInertiaCalcualtionLoaded = -1;

        public void SaveInertiaToMemory(string calculation)
        {
            localInertiaCalculationMemory.Add(calculation);
            currentInertiaCalcualtionLoaded++;
        }

        public List<string> localTorqueCalculationMemory = new List<string>();

        public int currentTorqueCalcualtionLoaded = -1;

        public void SaveToTorqueMemory(string calculation)
        {
            localTorqueCalculationMemory.Add(calculation);
            currentTorqueCalcualtionLoaded++;
        }
      
        public BiomechanicsCalculator() { }

        public string About(string calcualtion)
        {
            string aboutMSG = "";
            if (calcualtion == "Horizontal Projection Velocity")
            {
                aboutMSG = "The horizontal component of the projection velocity = projection velocity COS * projection degrees";
            }
            else if (calcualtion == "Angular Velocity")
            {
                aboutMSG = "w = anglef -anglei / tf - ti";
            }
            else if (calcualtion == "Angular Acceleration")
            {
                aboutMSG = "ω f - ω I / tf - ti ";
            }
            else if (calcualtion == "Inertia")
            {
                aboutMSG = "I = mr2";
            }
            else if (calcualtion == "Torque")
            {
                aboutMSG = "Torque = F x r";
            }
            return aboutMSG;
        }

        //Horizontal Projection Velocity - Unit = m/s
        public string HorizontalProjectionVelocity(double velocity, double angle)
        {
            double horizontalVelocity = velocity * Math.Cos(angle);
            return (horizontalVelocity.ToString() + "m/s");
        }

        //Angular Velocity  - Unit = rad/s
        public string AngularVelocity(double angleInitial, double angleFinal, double timeInitial, double timeFinal)
        {
            double w = (angleFinal - angleInitial) / (timeFinal - timeInitial);
            double wRads = w * 57.2958;
            return (wRads.ToString() + "rad/s");
        }

        //Angular Acceleration  - Unit = rad/s^2
        public string AngularAcceleration(double velocityInitial, double velocityFinal, double timeInitial, double timeFinal)
        {
            double a = (velocityInitial - velocityFinal) / (timeFinal - timeInitial);
            double aRads = a * 57.2958;
            return (aRads.ToString() + "rad/s^2");
        }

        //inertia - Unit = kgm^2
        public string Inertia(double mass, double radius)
        {
            double inertia = mass * (radius * radius);
            return (inertia.ToString() + "kgm^2");
        }

        //torque - Unit = N.m
        public string Torque(double force, double radius)
        {
            double torque = force * radius;
            return (torque.ToString() + "N.m");
        }

    }
}
