using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace weatherApp.ViewModels
{
    public class Value : Measurement
    {
        public static implicit operator Value(Double d)
        {
            var v = new Value();
            v.Value = d;
            return v;
        }
        public static implicit operator Double(Value v)
        {
            return v.Value;
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}