using System;
using System.Collections.Generic;
using Juggling.Juggler;
using Juggling.Throws;
using Juggling.Types;

namespace Juggling.Fixtures
{
    public class ScrambledVFixture
    {
        private List<BeatFixture> beatFixtures;
        private Passer jugglerA = new Passer {Name = "A"};
        private Passer jugglerB = new Passer {Name = "B"};
        private Passer jugglerC = new Passer {Name = "C"};
        private Manipulator manipulator = new Manipulator {Name = "M"};

        public void New()
        {
            beatFixtures = new List<BeatFixture>();
        }

        private void AddBeatFixture(Func<BeatFixture, BeatFixture> func)
        {
            beatFixtures.Add(func.Invoke(new BeatFixture().New()));
        }

        public IEnumerable<Beat> Build()
        {
            foreach (var beatFixture in beatFixtures)
                yield return beatFixture.Build();
        }

        public ScrambledVFixture AddBeat1Or3(Func<ManipulationFixture, ManipulationFixture> func,
            Func<ManipulationFixture, ManipulationFixture> offBeatFunc)
        {
            AddBeatFixture(x => x
                .AddPass(jugglerA, y => y.To(jugglerB).WithType(PassType.P))
                .AddPass(jugglerB, y => y.To(jugglerA).WithType(PassType.P))
                .AddSingleSelf(jugglerC)
                .AddManipulation(manipulator, func)
            );
            AddBeatFixture(x => x
                .AddSingleSelf(jugglerA)
                .AddSingleSelf(jugglerB)
                .AddSingleSelf(jugglerC)
                .AddManipulation(manipulator, offBeatFunc)
            );
            return this;
        }

        public ScrambledVFixture AddBeat2(Func<ManipulationFixture, ManipulationFixture> func,
            Func<ManipulationFixture, ManipulationFixture> offbeatFunc)
        {
            AddBeatFixture(x => x
                .AddPass(jugglerA, y => y.To(jugglerC).WithType(PassType.P))
                .AddPass(jugglerC, y => y.To(jugglerA).WithType(PassType.P))
                .AddSingleSelf(jugglerB)
                .AddManipulation(manipulator, func)
            );
            AddBeatFixture(x => x
                .AddSingleSelf(jugglerA)
                .AddSingleSelf(jugglerB)
                .AddSingleSelf(jugglerC)
                .AddManipulation(manipulator, offbeatFunc)
            );
            return this;
        }

        public ScrambledVFixture AddBeat1Or3(Passer to, ManipulationType type)
        {
            AddBeat1Or3(y => y.WithType(type).To(to).From(GetFromForBeat1(to, type)),
                x => x.WithType(GetTypeForLinks(type)));
            return this;
        }

        private Juggler.Juggler GetFromForBeat1(Passer to, ManipulationType type)
        {
            if (to == jugglerA)
            {
                switch (type)
                {
                    case ManipulationType.S:
                        return jugglerB;
                    case ManipulationType.I:
                    case ManipulationType.C:
                        return null;
                }
            }
            
            if (to == jugglerB)
            {
                switch (type)
                {
                    case ManipulationType.S:
                        return jugglerA;
                    case ManipulationType.I:
                    case ManipulationType.C:
                        return null;
                }
            }
            if (to == jugglerC)
            {
                switch (type)
                {
                    case ManipulationType.S:
                    case ManipulationType.I:
                    case ManipulationType.C:
                        return null;
                }
            }
            throw new NotSupportedException(
                $"Diese Kombination von {to.Name} und {type.ToString()} sollte es in eine Scrambled V Variante nicht geben");
        }
        private Juggler.Juggler GetFromForBeat2(Passer to, ManipulationType type)
        {
            if (to == jugglerA)
            {
                switch (type)
                {
                    case ManipulationType.S:
                        return jugglerC;
                    case ManipulationType.I:
                    case ManipulationType.C:
                        return null;
                }
            }
            if (to == jugglerB)
            {
                switch (type)
                {
                    case ManipulationType.S:
                    case ManipulationType.I:
                    case ManipulationType.C:
                        return null;
                }
            }
            if (to == jugglerC)
            {
                switch (type)
                {
                    case ManipulationType.S:
                        return jugglerA;
                    case ManipulationType.I:
                    case ManipulationType.C:
                        return null;
                }
            }
            throw new NotSupportedException(
                $"Diese Kombination von {to.Name} und {type.ToString()} sollte es in eine Scrambled V Variante nicht geben");
        }

        public ScrambledVFixture AddBeat2(Passer to, ManipulationType type)
        {
            AddBeat2(y => y.WithType(type).To(to).From(GetFromForBeat2(to,type)), x => x.WithType(GetTypeForLinks(type)));
            return this;
        }

        private ManipulationType? GetTypeForLinks(ManipulationType type)
        {
            switch (type)
            {
                case ManipulationType.I:
                    return null;
                case ManipulationType.C:
                    return ManipulationType.Z;
                case ManipulationType.S:
                    return ManipulationType.Z;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        public ScrambledVFixture New(Passer jugglerA, Passer jugglerB, Passer jugglerC, Manipulator manipulator)
        {
            New();
            this.jugglerA = jugglerA;
            this.jugglerB = jugglerB;
            this.jugglerC = jugglerC;
            this.manipulator = manipulator;
            return this;
        }
    }
}