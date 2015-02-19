using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb6
{
    class Cylinder : Solid
    {

        public override double Volume
        {
            get
            {
                return Math.PI * RadiusSquared * Height;
            }
        }

        public override double BaseArea
        {
            get
            {
                return RadiusSquared * Math.PI;
            }
        }
        public override double SurfaceArea
        {
            get
            {
               return 2 * Math.PI * Radius * (Radius + Height );
            }
        }
    
        public Cylinder(double radius, double height)
            : base(radius, height) 
        { }
    }
}