namespace MarsRover.Monad
{
    public readonly struct Either<TError, TSuccess>
    {
        public readonly TError ErrorValue { get; }
        public readonly TSuccess SuccessValue { get; }

        private Either(TError error)
        {
            ErrorValue = error;
            SuccessValue = default;
        }

        private Either(TSuccess success)
        {
            ErrorValue = default;
            SuccessValue = success;
        }

        public static Either<TError, TSuccess> Error(TError error)
        {
            return new Either<TError, TSuccess>(error);
        }

        public static Either<TError, TSuccess> Success(TSuccess success)
        {
            return new Either<TError, TSuccess>(success);
        }

        public TResult Match<TResult>(Func<TError, TResult> errorFunction, Func<TSuccess, TResult> successFunction)
        {
            if (ErrorValue is null) 
            {
                return successFunction(SuccessValue);
            }
            return errorFunction(ErrorValue);
        }
    }
}
