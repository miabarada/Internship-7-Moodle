using Domain.Common.Validation;

namespace Application.Common.Model
{
    public abstract class RequestHandler<TRequest, TResult> where TRequest : class where TResult : class
    {
        public Guid RequestId => Guid.NewGuid();

        public async Task<Result<TResult>> ProcessAuthorizedRequestAsync(TRequest request)
        {
            var result = new Result<TResult>(RequestId);

            try
            {
                var validationResult = await ValidateAsync(request);
                if (validationResult != null)
                {
                    result.SetValidationResult(validationResult);

                    if (result.HasError)
                        return result;
                }

                var isAuthorized = await IsAuthorizedAsync(request);
                if(!isAuthorized)
                {
                    result.SetUnauthorizedResult();
                    return result;
                }

                await HandleRequestAsync(request, result);
                await CacheAsync(request, result);
            }
            catch
            {
                result.SetValidationResult(ValidationResult.Error("UNEXPECTED_ERROR", "An unexpected error"));
            }
            return result;
        }

        protected Task<ValidationResult?> ValidateAsync(TRequest request)
        {
            return Task.FromResult<ValidationResult?>(null);
        }
        protected abstract Task<Result<TResult>> HandleRequestAsync(TRequest request, Result<TResult> result);
        protected Task<bool> IsAuthorizedAsync(TRequest request)
        {
            return Task.FromResult(true);
        }
        protected Task CacheAsync(TRequest request, Result<TResult> result)
        {
            return Task.CompletedTask;
        }
    }
}
