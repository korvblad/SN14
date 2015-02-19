using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb6

{
    class CircularCone : Solid
    {
        public override double Volume
        {
            get
            {
                return (1.00 / 3.00) * Math.PI * RadiusSquared * Height;
            }
        }
        public override double BaseArea
        {
            get
            {
                return Math.PI * RadiusSquared;
            }
        }
        public override double SurfaceArea
        {
            get
            {
                return Math.PI * Radius * (Radius + Math.Sqrt(Height + Radius));
            }
        }
     
        public CircularCone(double radius, double height)
            : base(radius, height)
        {}
    }
}