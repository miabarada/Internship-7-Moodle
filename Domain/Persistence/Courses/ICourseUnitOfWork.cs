using Domain.Persistence.Common;
using Domain.Persistence.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Persistence.Courses
{
    public interface ICourseUnitOfWork : IUnitOfWork
    {
        ICourseRepository Repository { get; }
    }
}
