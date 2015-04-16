using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Windows.Controls;

namespace ScribeDriver
{
    class scribingProcessManager
    {

        motorManager motor;
        double plunge;
        

        public scribingProcessManager() {
            motor = new motorManager();
         
        }
        public void setPlunge(double newPlunge){
            plunge = newPlunge;
        }

        public void chipAndDigitSet(double X, double Y)
        {
            motor.linearMove(X, Y);
        }
        public void finish()
        {
            motor.done();
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
            north(4);
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

        public void scribe(char digit){

            switch(digit){
                case '0': drawZero();
                    break;

                case '1': drawOne();
                    break;

                case '2': drawTwo();
                    break;

                case '3': drawThree();
                    break;

                case '4': drawFour();
                    break;

                case '5': drawFive();
                    break;

                case '6': drawSix();
                    break;

                case '7': drawSeven();
                    break;

                case '8': drawEight();
                    break;

                case '9': drawNine();
                    break;

                case 'A': drawA();
                    break;

                case 'B': drawB();
                    break;

                case 'C': drawC();
                    break;

                case 'D': drawD();
                    break;

                case 'E': drawE();
                    break;

                case 'F': drawF();
                    break;
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

        private void north(int distance) {
            motor.relLinearMove((distance * .02), 0 );
        }
        private void east(int distance) {
            motor.relLinearMove(0, -(distance * .02));
        }
        private void south(int distance) {
            motor.relLinearMove( -(distance * .02), 0);
        }
        private void west(int distance) {
            motor.relLinearMove(0, (distance * .02));
        }

        private void northEast(int distance) {
            motor.relLinearMove( (distance * .02), -(distance * .02));
        }
        private void southEast(int distance) {
            motor.relLinearMove(-(distance * .02), -(distance * .02));
        }
        private void northWest(int distance) {
            motor.relLinearMove((distance * .02), (distance * .02));    
        }
        private void southWest(int distance) {
            motor.relLinearMove( -(distance * .02),(distance * .02));
        }

        private void engage(int distance) {
            motor.scribeIn(plunge);

        }
        private void disengage(int distance) {
            motor.scribeOut();
        }

        

    }
}
