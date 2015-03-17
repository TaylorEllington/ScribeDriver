using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScribeDriver
{
    class scribingProcessManager
    {
        bool runFlag;

        scribingProcessManager() { }
        // public functions for ordering specific numbers
        void drawZero() { }
        void drawOne() { }
        void drawTwo() { }
        void drawThree() { }
        void drawFour() { }
        void drawFive() { }
        void drawSix() { }
        void drawSeven() { }
        void drawEight() { }
        void drawNine() { }
        void drawA() { }
        void drawB() { }
        void drawC() { }
        void drawD() { }
        void drawE() { }
        void drawF() { }
        
        //public control functions
        void stopRun() { }
        void run() { }
        void nextDigit() { }

        //private scribe control functions - use only from inside draw functions
        //accepts a "distance" unit. digts are 2 units wide, and 4 units tall
        //  |--2--|  
        //   __ __    _____          N
        //  |     |     |            | 
        //  |__ __|     4         W-- --E
        //  |     |     |            |
        //  |__ __|   __|__          S
        //
        //The scribe will move the given distance in the direction indicated
        //we use the compass analogy to avoid confusion with moving up (north) and
        //moving the scribe up (disengage)

        private void north(int distance) { }
        private void east(int distance) { }
        private void south(int distance) { }
        private void west(int distance) { }

        private void northEast(int distance) { }
        private void southEast(int distance) { }
        private void northWest(int distance) { }
        private void southWest(int distance) { }

        private void engage(int distance) { }
        private void disengage(int distance) { }

    }
}
