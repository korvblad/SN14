using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb6
{

    abstract class Solid
    {       
        private double _height;  //En solids höjd
        private double _radius;  //En solids radie
      
        public abstract double BaseArea 
        { 
             get; 
        }
        
        public double Height
        {
            get
            {
                return _height;
            }
            set
            {
                if (_height < 0)
                {
                    throw new ArgumentException();
                }
                _height = value;
            }
        }
        public double HeightSquared
        {
            get
            {
                return _height* _height;
            }
        }
        public double Radius
        {
            get
            {
                return _radius;
            }
            set
            {
                if (_radius < 0)
                {
                    throw new ArgumentException();
                }
                _radius = value;
            }
        }
        public double RadiusSquared
        {
            get
            {
                return _radius * _radius;
            }
        }
        public abstract double SurfaceArea { get; }
        public abstract double Volume { get; }
        
        protected Solid(double radius, double height)
        {
            Radius = radius;
            Height = height;
        }
        public override string ToString()
        {
            return string.Format("{0,-10:}:{1,10:f2}\n{2,-10}:{3,10:f2}\n{4,-10}:{5,10:f2}\n{6,-10}:{7,10:f2}\n{8,-10}:{9,10:f2}\n", "Radie (r)", Radius, "Höjd (h)", Height, "Volym", Volume, "Basarea", BaseArea, "Ytarea", SurfaceArea);
        }

    }
}