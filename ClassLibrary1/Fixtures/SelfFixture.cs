using Juggling.Throws;
using Juggling.Types;

namespace Juggling.Fixtures
{
    public class SelfFixture
    {
        private Self self;

        public SelfFixture New()
        {
            self = new Self();
            return this;
        }

        public SelfFixture Juggler(Juggler.Juggler juggler)
        {
            self.Juggler = juggler;
            return this;
        }

        public SelfFixture WithType(SelfType type)
        {
            self.Type = type;
            return this;
        }

        public Self Build()
        {
            return self;
        }
    }
}