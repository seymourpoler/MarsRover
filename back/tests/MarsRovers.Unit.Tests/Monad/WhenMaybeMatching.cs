using MarsRover.Monad;

namespace MarsRovers.Unit.Tests.Monad
{
    public class WhenMaybeMatching
    {
        [Fact]
        public void MatchWithTheErrorSide()
        {
            var manybeNothing = Maybe<Thing>.Nothing();

            var result = manybeNothing.Match<string>(
                nothing: () => { return "nothing"; },
                just : _ => throw new Exception("Maybe with something"));

            result.Should().Be("nothing");
        }

        [Fact]
        public void MatchWithTheSuccessSide()
        {
            var maybeWithSomething = Maybe<Thing>.Just(new Thing());

            var result = maybeWithSomething.Match(
                just: something => { return "something"; },
                nothing: () => throw new Exception("Either fails"));

            result.Should().Be("something");

        }

        private class Thing { }
    }
}
