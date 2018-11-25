using System;
using System.Collections.Generic;
using Juggling.Juggler;
using Juggling.Throws;
using Juggling.Types;

namespace Juggling.Fixtures
{
    public class BeatFixture
    {
        private Beat beat;
        private readonly ManipulationFixture manipulationFixture = new ManipulationFixture();
        private readonly PassFixture passFixture = new PassFixture();
        private readonly SelfFixture selfFixture = new SelfFixture();

        public BeatFixture New()
        {
            beat = new Beat
            {
                Manipulations = new Dictionary<Manipulator, Manipulation>(),
                Throws = new Dictionary<Passer, Throw>()
            };
            return this;
        }

        public BeatFixture AddManipulation(Manipulator manipulator, Manipulation manipulation)
        {
            beat.Manipulations.Add(manipulator, manipulation);
            return this;
        }

        public BeatFixture AddPass(Passer passer, Throw @throw)
        {
            beat.Throws.Add(passer, @throw);
            return this;
        }

        public Beat Build()
        {
            return beat;
        }

        public BeatFixture AddManipulation(Manipulator manipulator, Func<ManipulationFixture, ManipulationFixture> func)
        {
            AddManipulation(manipulator, func.Invoke(manipulationFixture.New()).Build());
            return this;
        }

        public BeatFixture AddCarry(Manipulator manipulator, Func<ManipulationFixture, ManipulationFixture> func)
        {
            var fixture = manipulationFixture.New();
            AddManipulation(manipulator, func.Invoke(fixture).WithType(ManipulationType.C).Build());
            return this;
        }

        public BeatFixture AddIntercept(Manipulator manipulator, Func<ManipulationFixture, ManipulationFixture> func)
        {
            var fixture = manipulationFixture.New();
            AddManipulation(manipulator, func.Invoke(fixture).WithType(ManipulationType.I).Build());
            return this;
        }

        public BeatFixture AddSubstitude(Manipulator manipulator, Func<ManipulationFixture, ManipulationFixture> func)
        {
            var fixture = manipulationFixture.New();
            AddManipulation(manipulator, func.Invoke(fixture).WithType(ManipulationType.S).Build());
            return this;
        }

        public BeatFixture AddPass(Passer jugglerA, Func<PassFixture, PassFixture> func)
        {
            beat.Throws.Add(jugglerA, func.Invoke(passFixture.New()).Build());
            return this;
        }

        public BeatFixture AddSelf(Passer passer, Func<SelfFixture, SelfFixture> func)
        {
            beat.Throws.Add(passer, func.Invoke(selfFixture.New().Juggler(passer)).Build());
            return this;
        }

        public BeatFixture AddSingleSelf(Passer juggler)
        {
            AddSelf(juggler, x => x.WithType(SelfType.S));
            return this;
        }
    }
}