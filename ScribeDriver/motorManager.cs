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

        SerialPort motorSerialPort;
        double Xpos;
        double Ypos;

        public motorManager(string name)
        {
            motorSerialPort = new SerialPort();
            motorSerialPort.PortName = name;
            motorSerialPort.BaudRate = 115200;

            motorSerialPort.Open();
            motorSerialPort.WriteLine("/move min");

            Xpos= 0;

            
        }

        public void linearMove()
        {

        }



    }
}
