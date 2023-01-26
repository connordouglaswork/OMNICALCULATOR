using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMNIATHLETICS
{
    internal class BiomechanicsCalculator : Calculator
    {
        List<string> localCalculatioMemory = new List<string>();

        public int currentCalcualtionLoaded = -1;

        public void SaveToMemory(string calculation)
        {
            localCalculatioMemory.Add(calculation);
            currentCalcualtionLoaded++;
        }

        public BiomechanicsCalculator() { }

        public static string About(string calcualtion)
        {
            string aboutMSG = "";
            if (calcualtion == "Horizontal Projection Velocity")
            {
                aboutMSG = "The horizontal component of the projection velocity = projection velocity COS * projection degrees";
            }
            else if (calcualtion == "Angular Velocity ")
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
        public static string HorizontalProjectionVelocity(double velocity, double angle)
        {
            double horizontalVelocity = velocity * Math.Cos(angle);
            return (horizontalVelocity.ToString() + "m/s");
        }

        //Angular Velocity  - Unit = rad/s
        public static string AngularVelocity(double angleInitial, double angleFinal, double timeInitial, double timeFinal)
        {
            double w = (angleFinal - angleInitial) / (timeFinal - timeInitial);
            double wRads = w * 57.2958;
            return (wRads.ToString() + "rad/s");
        }

        //Angular Acceleration  - Unit = rad/s^2
        public static string AngularAcceleration(double velocityInitial, double velocityFinal, double timeInitial, double timeFinal)
        {
            double a = (velocityInitial - velocityFinal) / (timeFinal - timeInitial);
            double aRads = a * 57.2958;
            return (aRads.ToString() + "rad/s^2");
        }

        //inertia - Unit = kgm^2
        public static string Inertia(double mass, double radius)
        {
            double inertia = mass * (radius * radius);
            return (inertia.ToString() + "kgm^2");
        }

        //torque - Unit = N.m
        public static string Torque(double force, double radius)
        {
            double torque = force * radius;
            return (torque.ToString() + "N.m");
        }

    }
}
