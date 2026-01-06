using Domain.Persistence.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Persistence.Enrollments
{
    public interface IEnrollmentUnitOfWOrk : IUnitOfWork
    {
        IEnrollmentRepository Repository { get; }
    }
}
