namespace MarsRover.Monad
{
    public readonly struct Either<TError, TSuccess>
    {
        private readonly TError ErrorValue;
        private readonly TSuccess SuccessValue;

        private Either(TError errorValue)
        {
            ErrorValue = errorValue;
            SuccessValue = default;
            IsSuccess = false;
            IsError = true;
        }

        private Either(TSuccess successValue)
        {
            ErrorValue = default;
            SuccessValue = successValue;
            IsSuccess = true;
            IsError = false;
        }

        public static Either<TError, TSuccess> Error(TError error) => new(error);

        public static Either<TError, TSuccess> Success(TSuccess success) => new(success);

        public bool IsSuccess { get; }

        public bool IsError { get; }

        public TResult Match<TResult>(Func<TError, TResult> errorFunc, Func<TSuccess, TResult> successFunc) =>
            IsSuccess
                ? successFunc(SuccessValue)
                : errorFunc(ErrorValue);

        public Task<TResult> MatchAsync<TResult>(Func<TError, TResult> errorFunc, Func<TSuccess, Task<TResult>> successFunc) =>
            IsSuccess
                ? successFunc(SuccessValue)
                : Task.FromResult(errorFunc(ErrorValue));

        public Task<TResult> MatchAsync<TResult>(Func<TError, Task<TResult>> errorFunc, Func<TSuccess, TResult> successFunc) =>
           IsSuccess
               ? Task.FromResult(successFunc(SuccessValue))
               : errorFunc(ErrorValue);

        public Task<TResult> MatchAsync<TResult>(Func<TError, Task<TResult>> errorFunc, Func<TSuccess, Task<TResult>> successFunc) =>
          IsSuccess
              ? successFunc(SuccessValue)
              : errorFunc(ErrorValue);

    }
}
