using Juggling.Throws;
using Juggling.Types;

namespace Juggling.Fixtures
{
    public class PassFixture
    {
        private Pass pass;


        public PassFixture New()
        {
            pass = new Pass();
            return this;
        }

        public PassFixture To(Juggler.Juggler to)
        {
            pass.To = to;
            return this;
        }

        public PassFixture WithType(PassType type)
        {
            pass.Type = type;
            return this;
        }

        public Pass Build()
        {
            return pass;
        }
    }
}