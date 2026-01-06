using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Model
{
    public abstract class RequestHandler<TRequest, TResult> where TRequest : class where TResult : class
    {
        public Guid RequestId => Guid.NewGuid();

        public async Task<Result<TResult>> ProcessAuthorizedRequestAsync(TRequest request)
        {
            var result = new Result<TResult>(RequestId);
        }
    }
}
