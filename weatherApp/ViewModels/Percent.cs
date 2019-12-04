using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace weatherApp.ViewModels
{
    public class Percent : Measurement
    {
        // operators for easy casting
        public static implicit operator Percent(Double d)
        {
            var p = new Percent();
            p.Percent = d;
            return p;
        }
        public static implicit operator Double(Percent p)
        {
            return p.Percent;
        }

        public override string ToString()
        {
            return this.Percent.ToString();

        }
    }
}