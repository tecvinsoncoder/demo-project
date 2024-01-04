using System;

namespace DemoProject.Shared
{
    public class Result
    {
        protected internal Result(bool isSuccess, Error error)
        {
            if(isSuccess && error != Error.None || 
                !isSuccess && error == Error.None)
            {
                throw new ArgumentException("Invalid error", nameof(error));
            }

            IsSuccess = isSuccess;
            Error = error;
        }
        public bool IsSuccess { get; }
        public bool IsFailure => IsFailure;
        public Error Error { get; }
        public static Result Success() => new (true, Error.None);
        public static Result Failure(Error error) => new (false, error);
    }
}