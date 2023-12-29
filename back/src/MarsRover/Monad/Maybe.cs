namespace MarsRover.Monad;

public struct Maybe<T>
{
    private readonly T value;

    private Maybe(T value)
    {
        this.value = value;
    }

    public static Maybe<T> Nothing() => new Maybe<T>();

    public static Maybe<T> Just(T value) => new Maybe<T>(value);

    public TResult Match<TResult>(Func<TResult> nothing, Func<T, TResult> just)
    {
        return value is null 
            ? nothing()
            : just(value);
    }

    public void Bind(Action<T> action)
    {
        if (value is null)
            return;

        action(value);
    }
}
