using MarsRover.Monad;

namespace MarsRovers.Unit.Tests.Monad
{
    public class WhenMatching
    {
        [Fact]
        public void MatchWithTheErrorSide()
        {
            var eitherWithAnError = Either<Error, Success>.Error(new Error());

            eitherWithAnError.Match(
                errorFunc: error => error.Should().BeOfType<Error>(),
                successFunc: _ => throw new Exception("Either fails"));
            

        }

        [Fact]
        public void MatchWithTheSuccessSide()
        {
            var eitherWithAnError = Either<Error, Success>.Success(new Success());

            eitherWithAnError.Match(
                successFunc: error => error.Should().BeOfType<Success>(),
                errorFunc: _ => throw new Exception("Either fails"));

        }

        private class Error { }
        public class Success { }
    }
}
