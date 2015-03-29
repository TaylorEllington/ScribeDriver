using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ScribeDriver
{
    class LayoutProfile 
    {
        public String profileName {get; set;}
        public int vCount { get; set; }
        public int hCount { get; set; }
        public double hBorder { get; set; }
        public double vBorder { get; set; }
        public double hSpacing { get; set; }
        public double vSpacing { get; set; }
        public double chipWidth { get; set; }
        public double chipLength { get; set; }
        public string dataString { get; set; }

        void buildDataString(){

            string data;
            data = "Profile Name: " + profileName +"\n";
            data += "vertical Chip Count: " + vCount +"\n";
            data += "horizontal Chip Count: " + hCount +"\n";
            data += "Vertical Edge Border: " + vBorder +"\n";
            data += "Horizontal Edge Border: " + hBorder+"\n";
            data += "Vertical Spacing: " + vSpacing +"\n";
            data += "Horizontal Spacing: " + hSpacing +"\n";
            data += "Package Width: " + chipWidth +"\n";
            data += "Package Length: " + chipLength ;
            dataString = data; 

           

            

            }

        

       


        //for debuging only
        public void defaultSettings()
        {
            profileName = "Default Profile";
            vCount = 9;
            hCount = 9;
            hBorder = 1;
            vBorder = 1;
            hSpacing = .40;
            vSpacing = .40;
            chipWidth = .15;
            chipLength = .12;
            
            buildDataString();


        }
    }
}
