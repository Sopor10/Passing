using Juggling.Throws;
using Juggling.Types;

namespace Juggling.Fixtures
{
    public class ManipulationFixture
    {
        private Manipulation manipulation;


        public ManipulationFixture New()
        {
            manipulation = new Manipulation();
            return this;
        }

        public ManipulationFixture From(Juggler.Juggler from)
        {
            if (@from != null) manipulation.From =  @from;
            return this;
        }

        public ManipulationFixture To(Juggler.Juggler to)
        {
            manipulation.To = to;
            return this;
        }

        public ManipulationFixture WithType(ManipulationType? type)
        {
            if (type != null)
                manipulation.Type = type;
            return this;
        }

        public Manipulation Build()
        {
            return manipulation;
        }
    }
}