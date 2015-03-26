using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public double chipHeight { get; set; }


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
            chipHeight = .12;
        }
    }
}
