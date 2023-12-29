namespace MarsRover.Monad
{
    public readonly struct Either<TError, TSuccess>
    {
        private readonly TError error { get; }
        private readonly TSuccess success { get; }

        private Either(TError error)
        {
            this.error = error;
            success = default;
        }

        private Either(TSuccess success)
        {
            error = default;
            this.success = success;
        }

        public static Either<TError, TSuccess> Error(TError error)
        {
            return new Either<TError, TSuccess>(error);
        }

        public static Either<TError, TSuccess> Success(TSuccess success)
        {
            return new Either<TError, TSuccess>(success);
        }

        public Either<TError, TOtherSuccess> Bind<TOtherSuccess>(Func<TSuccess, Either<TError, TOtherSuccess>> onSuccess)
        {
            if (success is null)
                return Either<TError, TOtherSuccess>.Error(error);
            return onSuccess(success);
        }

        public TResult Match<TResult>(Func<TError, TResult> onError, Func<TSuccess, TResult> onSuccess)
        {
            if (error is null) 
            {
                return onSuccess(success);
            }
            return onError(error);
        }
    }
}
