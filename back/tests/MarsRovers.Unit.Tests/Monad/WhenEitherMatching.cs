using MarsRover.Monad;

namespace MarsRovers.Unit.Tests.Monad
{
    public class WhenEitherMatching
    {
        [Fact]
        public void MatchWithTheErrorSide()
        {
            var eitherWithAnError = Either<Error, Success>.Error(new Error());

            var result = eitherWithAnError.Match<string>(
                onError: error => { error.Should().BeOfType<Error>(); return "error"; },
                onSuccess: _ => throw new Exception("Either fails"));
            
            result.Should().Be("error");
        }

        [Fact]
        public void MatchWithTheSuccessSide()
        {
            var eitherWithAnError = Either<Error, Success>.Success(new Success());

            var result = eitherWithAnError.Match(
                onSuccess: error => { error.Should().BeOfType<Success>(); return "success"; },
                onError: _ => throw new Exception("Either fails"));

            result.Should().Be("success");

        }

        private class Error { }
        public class Success { }
    }
}
