using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
namespace ScribeDriver
{
    class motorManager
    {

        int microStepsPerStep;


        SerialPort motorSerialPort;
        double Xpos;
        double Ypos;

        public motorManager(string name)
        {
            //setup connection to zaber devices
            motorSerialPort = new SerialPort();
            motorSerialPort.PortName = name;
            motorSerialPort.BaudRate = 115200;
            motorSerialPort.Open();

            //constants
            microStepsPerStep = 64;

            //initalize motors
            motorSerialPort.WriteLine("/move min");
            motorSerialPort.WriteLine("/set resolution " + microStepsPerStep);
            Xpos = 0;
            Ypos = 0;

            
        }

        public void linearMove(double inchesX, double inchesY)
        {

        }

        int inchesToMicroSteps(double inch)
        {
            
            double steps =  inch * 800;
            int microsteps = (int) (steps / microStepsPerStep);
            return microsteps;
        }



    }
}
