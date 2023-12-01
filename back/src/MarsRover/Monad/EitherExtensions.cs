namespace MarsRover.Monad
{
    public static class EitherExtensions
    {
        public static Either<TError, TOtherSuccess> Bind<TError, TSuccess, TOtherSuccess>(this Either<TError, TSuccess> self, Func<TSuccess, Either<TError, TOtherSuccess>> bindFunction)
        {
            if (self.SuccessValue is null)
            {
                return Either<TError, TOtherSuccess>.Error(self.ErrorValue);
            }

            return bindFunction(self.SuccessValue);
        }
    }
}
