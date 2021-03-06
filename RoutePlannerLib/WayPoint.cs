﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Fhnw.Ecnf.RoutePlanner.RoutePlannerLib
{
    public class WayPoint
    {
        public string Name { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public WayPoint()
        {

        }

        public WayPoint(string name, double latitude, double longitude) {
            Name = name;
            Latitude = latitude;
            Longitude = longitude;
        }

        public override string ToString()
        {
            string output = "WayPoint: ";

            if (string.IsNullOrEmpty(this.Name) == false)
            {
                output += string.Format("{0} ", this.Name);
            }
            output += string.Format(CultureInfo.InvariantCulture, "{0:N2}/{1:N2}", this.Latitude, this.Longitude);
            return output;
        }

        public double ConvertToRadians(double angle)
        {
            return (Math.PI / 180) * angle;
        }

        public double Distance(WayPoint target)
        {
            // d = R arccos [sin (φa) •sin(φb) + cos(φa) • cos(φb) • cos(λa - λb)]
            const int R = 6371; // kilometres
            var φ1 = this.ConvertToRadians(this.Latitude);
            var φ2 = this.ConvertToRadians(target.Latitude);
            var Δφ = this.ConvertToRadians(target.Latitude - this.Latitude);
            var Δλ = this.ConvertToRadians(target.Longitude - this.Longitude);

            var a = Math.Sin(Δφ / 2) * Math.Sin(Δφ / 2) +
                Math.Cos(φ1) * Math.Cos(φ2) *
                Math.Sin(Δλ / 2) * Math.Sin(Δλ / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            var distance = (R * c);
            return distance;
        }

        public static WayPoint operator +(WayPoint lhs, WayPoint rhs)
        {
            return new WayPoint(
                lhs.Name, 
                lhs.Latitude + rhs.Latitude,
                lhs.Longitude + rhs.Longitude
            );
        }

        public static WayPoint operator -(WayPoint lhs, WayPoint rhs)
        {
            return new WayPoint(
                lhs.Name,
                lhs.Latitude - rhs.Latitude,
                lhs.Longitude - rhs.Longitude
            );
        }
    }
}
