using System.Collections.Generic;
using System.Linq;

namespace Juggling.Fixtures
{
    public class PatternFixture
    {
        private Pattern pattern;

        public PatternFixture New()
        {
            pattern = new Pattern();
            return this;
        }

        public PatternFixture AddBeat(Beat beat)
        {
            pattern.Beats.Add(beat);
            return this;
        }
        
        public PatternFixture AddBeats(IEnumerable<Beat> beats)
        {
            pattern.Beats.AddRange(beats);
            return this;
        }
        

        public Pattern Build()
        {
            return pattern;
        }

        public PatternFixture WithJugglers(IEnumerable<Juggler.Juggler> jugglers)
        {
            pattern.Jugglers = jugglers.ToList();
            return this;
        }
    }
}