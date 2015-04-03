using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
           // motorSerialPort.WriteLine("/move min");
            motorSerialPort.WriteLine("/set resolution " + microStepsPerStep);
            Xpos = 0;
            Ypos = 0;

            Thread.Sleep(1000);

            int x =  272002 ;
            int y =  277122;
            
           

            //motorSerialPort.WriteLine("/01 move min");
            motorSerialPort.WriteLine("/home");
            Thread.Sleep(4000);
            motorSerialPort.WriteLine("/01 stream 1 setup live 2 1");
            motorSerialPort.WriteLine("/01 stream 1 line abs " + y+ " "+ x);
            Thread.Sleep(4000);
            //motorSerialPort.WriteLine("/01 stream 1 setup disable");
            
        }

        public void linearMove(double inchesX, double inchesY)
        {
            int x = inchesToMicroSteps(inchesY);
            int y = inchesToMicroSteps(inchesX);

            //motorSerialPort.WriteLine("/01 stream 1 setup live 2 1");
            motorSerialPort.WriteLine("/01 stream 1 line abs " + y + " " + x);
            Thread.Sleep(2000);
            //motorSerialPort.WriteLine("/01 stream 1 setup disable");
        }

        public void relLinearMove(double inchesX, double inchesY)
        {
            int x = inchesToMicroSteps(inchesY);
            int y = inchesToMicroSteps(inchesX);

            //motorSerialPort.WriteLine("/01 stream 1 setup live 2 1");
            motorSerialPort.WriteLine("/01 stream 1 line rel " + y + " " + x);
            Thread.Sleep(2000);

        }

        int inchesToMicroSteps(double inch)
        {
            
            
            int microsteps = (int) (inch * 51200);
            return microsteps;
        }

        public void scribeIn()
        {
            motorSerialPort.WriteLine("/02 move abs 128660");
            Thread.Sleep(1500);
            motorSerialPort.WriteLine("/02  move abs 33280");
            Thread.Sleep(1500);
            
        }


    }
}
