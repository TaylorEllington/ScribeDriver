using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO.Ports;
using System.Management;
namespace ScribeDriver
{
    class motorManager
    {

        int microStepsPerStep;


        SerialPort motorSerialPort;
        double Xpos;
        double Ypos;

        public motorManager()
        {
            if( findZaberConnection() == null){
              System.Environment.Exit(999); 
            }


            string[] ports = SerialPort.GetPortNames();
            string portname = findZaberConnection();

            SerialPort serialPort = new SerialPort();
            

            //setup connection to zaber devices
            motorSerialPort = new SerialPort();
            motorSerialPort.PortName = portname;
            motorSerialPort.BaudRate = 115200;
            motorSerialPort.Open();

            //constants
            microStepsPerStep = 64;

            //initalize motors
            motorSerialPort.WriteLine("/set resolution " + microStepsPerStep);
            Xpos = 0;
            Ypos = 0;

            Thread.Sleep(1000);

            int x =  inchesToMicroSteps(2.74224);
            int y = inchesToMicroSteps(2.44789);
            
           

            //Calibrate motor and prepare for scribig
            motorSerialPort.WriteLine("/home");
            Thread.Sleep(4000);
            motorSerialPort.WriteLine("/01 stream 1 setup live 2 1");
            motorSerialPort.WriteLine("/01 stream 1 line abs " + x+ " "+ y);
            Thread.Sleep(4000);
            
            
        }

        public void linearMove(double inchesX, double inchesY)
        {
            int x = inchesToMicroSteps(inchesY);
            int y = inchesToMicroSteps(inchesX);

            
            motorSerialPort.WriteLine("/01 stream 1 line abs " + y + " " + x);
            Thread.Sleep(2000);
            
        }

        public void relLinearMove(double inchesX, double inchesY)
        {
            int x = inchesToMicroSteps(inchesY);
            int y = inchesToMicroSteps(inchesX);

 
            motorSerialPort.WriteLine("/01 stream 1 line rel " + y + " " + x);
            Thread.Sleep(300);

        }

        int inchesToMicroSteps(double inch)
        {            
            int microsteps = (int) (inch * 51200);
            return microsteps;
        }

        public void scribeIn(double inch)
        {
            int steps = inchesToMicroSteps(inch);
            Thread.Sleep(500);
            motorSerialPort.WriteLine("/02 move abs " + steps);
            Thread.Sleep(1500);       
        }

        public void scribeOut()
        {
            Thread.Sleep(500);
            motorSerialPort.WriteLine("/02  move abs 73280");
            Thread.Sleep(1500);
        }

        public void done()
        {
            motorSerialPort.WriteLine("/02 move min");
            Thread.Sleep(1750);
            motorSerialPort.WriteLine("/01 stream 1 line abs 0 0 ");
            Thread.Sleep(1750);
        }


        string findZaberConnection()
        {
            string name = null;

            using (var searcher = new ManagementObjectSearcher
                ("SELECT * FROM WIN32_SerialPort"))
            {
                string[] portnames = SerialPort.GetPortNames();
                var ports = searcher.Get().Cast<ManagementBaseObject>().ToList();
                var tList = (from n in portnames
                             join p in ports on n equals p["DeviceID"].ToString()
                             select n + " - " + p["Caption"]).ToList();

                foreach (string s in tList)
                {
                    if (s.Contains("A-Series USB"))
                    {
                        name = s.Substring(0, 4);
                    }
                }
                return name;
            }
        }

    }
}
