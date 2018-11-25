using System;
using System.Collections;
using System.Collections.Generic;
using Juggling.Juggler;
using Juggling.Throws;

namespace Juggling
{
    public class Beat
    {
        public Dictionary<Passer, Throw> Throws { get; set; }
        public Dictionary<Manipulator, Manipulation> Manipulations { get; set; }

        public string ToLatex(Juggler.Juggler juggler)
        {
            var result = String.Empty;
            if (juggler.GetType() == typeof(Passer) && Throws.ContainsKey((Passer) juggler))
                return Throws[(Passer) juggler].ToLatex();
            if (juggler.GetType() == typeof(Manipulator) && Manipulations.ContainsKey((Manipulator) juggler))
                return Manipulations[(Manipulator) juggler].ToLatex();
            return result;
        }
        public string ToHtml(Juggler.Juggler juggler)
        {
            var result = string.Empty;
            if (juggler.GetType() == typeof(Passer) && Throws.ContainsKey((Passer) juggler))
                return Throws[(Passer) juggler].ToHtml();
            if (juggler.GetType() == typeof(Manipulator) && Manipulations.ContainsKey((Manipulator) juggler))
                return Manipulations[(Manipulator) juggler].ToHtml();
            return result;
        }
    }
}