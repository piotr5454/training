﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using InitialTrainingLibrary.Interfaces.chess;

namespace InitialTrainingLibrary.Sito._2
{
    class Coordinates:ICoordinates
    {
        private int x;
        private int y;

        public Coordinates(int x, int y)
        {
            x = PrepareCoordinate(x);
            y = PrepareCoordinate(y);
            this.x = x;
            this.y = y;
        }

        public Coordinates(ICoordinates coordinates )
        {
            this.x = coordinates.GetX();
            this.y = coordinates.GetY();
        }
        public int GetX()
        {
            return x;
        }

        public int GetY()
        {
            return y;
        }

        public bool Equal(Coordinates coorA)
        {
            return this.x==coorA.x&&this.y==coorA.y;
        }

        private int PrepareCoordinate(int i)
        {
            if (i<0)
            {
                i *= -1;
            }
            
                i = i%8;
            
            return i;
        }
    }
}