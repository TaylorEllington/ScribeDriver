using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace ScribeDriver
{
    class scribingProcessManager
    {
        bool runFlag;
        int ding;

        public scribingProcessManager() {
            ding = 10;
        }
        // public functions for ordering specific numbers
        void drawZero() {
            engage(1);
            south(4);
            east(2);
            north(4);
            west(2);
            disengage(1);
            nextDigit();
        }

        void drawOne() {
            engage(1);
            east(1);
            south(4);
            disengage(1);
            west(1);
            engage(1);
            east(2);
            disengage(1);
            nextDigit();
        }

        void drawTwo() {
            engage(1);
            east(2);
            south(2);
            west(2);
            south(2);
            east(2);
            disengage(1);
            nextDigit();
        }

        void drawThree() {
            engage(1);
            east(2);
            south(4);
            west(2);
            disengage(1);
            north(2);
            engage(1);
            east(2);
            disengage(1);
            nextDigit();
        }

        void drawFour() {
            engage(1);
            south(2);
            east(2);
            disengage(1);
            north(2);
            engage(1);
            south(4);
            disengage(1);
            nextDigit();
        }

        void drawFive() {
            east(2);
            engage(1);
            west(2);
            south(2);
            east(2);
            south(2);
            west(2);
            disengage(1);
            nextDigit();
        }

        void drawSix() {
            east(2);
            engage(1);
            west(2);
            south(4);
            east(2);
            north(2);
            west(2);
            disengage(1);
            nextDigit();
        }

        void drawSeven() {
            engage(1);
            east(2);
            south(4);
            disengage(1);
            nextDigit();
        }

        void drawEight() {
            engage(1);
            south(4);
            east(2);
            north(2);
            west(2);
            disengage(2);
            south(2);
            engage(1);
            east(2);
            disengage(1);
            nextDigit();
        }

        void drawNine() {
            south(4);
            east(2);
            engage(1);
            north(4);
            west(2);
            south(2);
            east(2);
            disengage(1);
            nextDigit();
        }

        void drawA() {
            south(4);
            engage(1);
            north(3);
            northEast(1);
            southEast(1);
            south(3);
            disengage(1);
            north(2);
            engage(1);
            west(2);
            disengage(1);
            nextDigit();
        }

        void drawB() {
            engage(1);
            east(1);
            southEast(1);
            south(3);
            west(2);
            north(4);
            disengage(1);
            south(2);
            engage(1);
            east(2);
            disengage(1);
            nextDigit();
        }

        void drawC() {
            east(2);
            engage(1);
            west(2);
            south(4);
            east(2);
            disengage(1);
            nextDigit();
        }

        void drawD() {
            engage(1);
            east(1);
            southEast(1);
            south(2);
            southWest(1);
            west(1);
            north(4);
            disengage(1);
            nextDigit();
        }

        void drawE() {
            east(2);
            engage(1);
            west(2);
            south(4);
            east(2);
            disengage(1);
            north(2);
            engage(1);
            west(2);
            disengage(1);
            nextDigit();
        }

        void drawF() {
            east(2);
            engage(1);
            west(2);
            south(4);
            disengage(1);
            north(2);
            engage(1);
            east(2);
            disengage(1);
            north(2);
        
        }
        
        //public control functions
        public void stopRun() { }
        public void run() {

            for (int i = 0; i < 100; i++)
            {
                Debug.WriteLine(ding.ToString() );
                ding++;
                Thread.Sleep(1000);
            }
        }

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
