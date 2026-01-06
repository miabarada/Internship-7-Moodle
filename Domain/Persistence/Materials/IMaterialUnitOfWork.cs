using Domain.Persistence.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Persistence.Materials
{
    public interface IMaterialUnitOfWork : IUnitOfWork
    {
        IMaterialRepository Repository { get; }
    }
}
