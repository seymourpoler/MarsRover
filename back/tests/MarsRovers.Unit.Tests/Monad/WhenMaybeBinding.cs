using FluentAssertions;
using MarsRover.Monad;
using Xunit;

namespace MarsRovers.Unit.Tests.Monad;

public class WhenMaybeBinding
{
    [Fact]
    public void BindWithTheErrorSide()
    {
        var manybeNothing = Maybe<Thing>.Nothing();
        var executed = false;

        manybeNothing.Bind(
            action: _ => executed = true);

        executed.Should().BeFalse();
    }

    [Fact]
    public void BindWithTheSuccessSide()
    {
        var maybeWithSomething = Maybe<Thing>.Just(new Thing());
        var executed = false;

        maybeWithSomething.Bind(
            action: _ => executed = true);

        executed.Should().BeTrue();
    }

    private class Thing { }
}
