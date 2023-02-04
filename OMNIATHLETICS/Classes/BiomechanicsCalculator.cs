using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMNIATHLETICS
{
    //class for building biomechanics calculators capable of managing biomechanics calculations
    public class BiomechanicsCalculator : Calculator
    {
        //contructs biomechanics calculator for use
        public BiomechanicsCalculator() { }

        public override string ToString()
        {
            return ("Biomechanics Calculator");
        }

        #region MEMORY
        //foreach different calculation type
        //current memory position - currentCalcualtionLoaded
        //local memory - localCalculatioMemory
        //saves equation data to local memory - SaveToMemory
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
        #endregion

        //displays about information for a given equation
        public void About(string calcualtion)
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
            System.Windows.Forms.MessageBox.Show(aboutMSG);
        }

        //Horizontal Projection Velocity - Unit = m/s
        public string HorizontalProjectionVelocity(double velocity, double angle)
        {
            double angleComponenet = Math.Cos(angle * Math.PI / 180);
            double horizontalVelocity = velocity * angleComponenet;
            return (horizontalVelocity.ToString("0.00") + "m/s");
        }

        //Angular Velocity  - Unit = rad/s
        public string AngularVelocity(double angleInitial, double angleFinal, double timeInitial, double timeFinal)
        {
            double w = (angleFinal - angleInitial) / (timeFinal - timeInitial);
            double wRads = w * 57.2958;
            return (wRads.ToString("0.00") + "rad/s");
        }

        //Angular Acceleration  - Unit = rad/s^2
        public string AngularAcceleration(double velocityInitial, double velocityFinal, double timeInitial, double timeFinal)
        {
            double a = (velocityFinal - velocityInitial) / (timeFinal - timeInitial);
            double aRads = a * 57.2958;
            return (aRads.ToString("0.00") + "rad/s^2");
        }

        //inertia - Unit = kgm^2
        public string Inertia(double mass, double radius)
        {
            double inertia = mass * (radius * radius);
            return (inertia.ToString("0.00") + "kgm^2");
        }

        //torque - Unit = N.m
        public string Torque(double force, double radius)
        {
            double torque = force * radius;
            return (torque.ToString("0.00") + "N.m");
        }
    }
}
