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
        public double[] xStarts { get; set; }
        public double[] yStarts { get; set; }
        public double[] plunge { get; set; }

        void buildDataString(){
            //for debugging only
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

        public void defaultSettings()
        {
            profileName = "Default Profile";
            vCount = 4;
            hCount = 4;
            hBorder = 1;
            vBorder = .383;
            hSpacing = .332;
            vSpacing = .387;
            chipWidth = .216;
            chipLength = .164;

            xStarts = new double[16] {
                 2.74299,
                 2.72529,
                 2.74232,
                 2.73792,
                 2.18578,
                 2.17176,
                 2.20093,
                 2.20609,
                 1.63605,
                 1.65201,
                 1.64154,
                 1.64902,
                 1.07213,
                 1.08711,
                 1.09402,
                 1.10402
             };

            yStarts = new double[16]{
                2.44789  ,
 			    1.89416  ,
 			    1.33395  ,
 			    0.798102 ,
 			    2.45222  ,
 			    1.88266  ,
 			    1.34453  ,
 			    0.791992 ,
 			    2.43322  ,
 			    1.88687  ,
 			    1.33798  ,
 			    0.790406 ,
 			    2.43066  ,
 			    1.87158  ,
 			    1.32533  ,
 			    0.771992 
            };

            plunge = new double[16]{
				1.8125 ,
				1.8135 ,
				1.827  ,
				1.830  ,
				1.825 ,
				1.825  ,
				1.825 ,
				1.830  ,
				1.825  ,
				1.825 ,
				1.825 ,
				1.8125 ,
				1.8125    ,
				1.8125 ,
				1.8125    ,
				1.8  
            };
        }
    }
}
