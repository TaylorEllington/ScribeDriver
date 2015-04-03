using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScribeDriver
{
    class incrementalCounter
    {
        private int startValue;
        private int currentValue;
        
        public void seedCounter(int seed){
            //Accepts the first value (inclusive) to be scribed
            startValue = seed;
            currentValue = seed;
        }
        public string getValueAsHexString(){
            //returns a Hex representation of the current value to be scribed
            return currentValue.ToString("X3");
        }
        public int getValueAsInt(){
             
            return currentValue;
        }
        public void next(){
            //Increments the counter
            currentValue++;
        }
        public void skip(int numberOfSkips){
            //Used only for resuming. This serves as a reset for currentValue
            currentValue = startValue + numberOfSkips;
        }

    }
}
