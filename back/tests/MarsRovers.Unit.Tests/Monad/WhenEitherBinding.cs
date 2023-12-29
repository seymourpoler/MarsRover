using FluentAssertions;
using MarsRover.Monad;
using Xunit;

namespace MarsRovers.Unit.Tests.Monad;

public class WhenEitherBinding
{
    [Fact]
    public void SynchronouslyYieldInitialError()
    {
        var anEither = Either<string, string>.Error("some error");

        var currentResult = anEither
            .Bind(_ => Either<string, string>.Success("this won't be returned"))
            .Bind(_ => Either<string, string>.Success("neither will this"));

        var actualResult = currentResult.Match(s => s, s => s);
        actualResult.Should().Be("some error");
    }

    [Fact]
    public void SynchronouslyYieldIntermediateError()
    {
        var anEither = Either<string, string>.Success("some success");

        var currentResult = anEither
            .Bind(_ => Either<string, string>.Error("the error"))
            .Bind(_ => Either<string, string>.Success("this won't be returned"));

        var actualResult = currentResult.Match(s => s, s => s);
        actualResult.Should().Be("the error");
    }

    [Fact]
    public void SynchronouslyYieldLatestSuccess()
    {
        var anEither = Either<string, string>.Success("some success");

        var currenResult = anEither
            .Bind(_ => Either<string, string>.Success("another success"))
            .Bind(_ => Either<string, string>.Success("this will be returned"));

        var actualResult = currenResult.Match(s => s, s => s);
        actualResult.Should().Be("this will be returned");
    }
}
