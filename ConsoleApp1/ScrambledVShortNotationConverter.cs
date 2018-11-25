using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Juggling;
using Juggling.Fixtures;
using Juggling.Juggler;
using Juggling.Types;

namespace ConsoleApp1
{
    public class ScrambledVShortNotationConverter
    {
        private string pattern = "[csi][ABC] [csi][ABC] [csi][ABC]";
        private List< string> patterns = new List<string>
        {
            "[c][ABC] [s][ABC] [i][ABC]",
            "[i][ABC] [c][ABC] [s][ABC]",
            "[s][ABC] [i][ABC] [c][ABC]"
        };
        List<Juggler> juggler = new List<Juggler>();



        public bool Validate(string shortNotation)
        {
            return patterns.Any(x => Regex.IsMatch(shortNotation, x));
        }

        public string GetLongNotationLatex(string shortNotation)
        {
            return LongNotation(shortNotation).ToLatexTable();
        }
        public string GetLongNotationHtml(string shortNotation)
        {
            return LongNotation(shortNotation).ToHtmlTable();
        }

        private Pattern LongNotation(string shortNotation)
        {
            if (Validate(shortNotation))
            {
                var array = shortNotation.Split(" ");
                Passer jugglerA = new Passer {Name = "A"};
                Passer jugglerB = new Passer {Name = "B"};
                Passer jugglerC = new Passer {Name = "C"};

                Manipulator manipulator = new Manipulator {Name = "M"};
                juggler.AddRange(new Juggler[] {jugglerA, jugglerB, jugglerC, manipulator});
                var variation = new ScrambledVFixture().New(jugglerA, jugglerB, jugglerC, manipulator)
                    .AddBeat1Or3(GetJuggler(array[0]), GetManipulationType(array[0]))
                    .AddBeat2(GetJuggler(array[1]), GetManipulationType(array[1]))
                    .AddBeat1Or3(GetJuggler(array[2]), GetManipulationType(array[2]))
                    .Build();
                return new PatternFixture().New().WithJugglers(juggler).AddBeats(variation).Build();
            }

            throw new NotSupportedException();
        }

        private ManipulationType GetManipulationType(string s)
        {
            Enum.TryParse(s.ToUpper().First().ToString(),out ManipulationType type);
            return type;
        }

        private Passer GetJuggler(string s)
        {
            var juggler = this.juggler.Where(x => x.Name.Equals(s.ToUpper().Last().ToString()));
            return juggler.Single() as Passer;
        }
    }
}