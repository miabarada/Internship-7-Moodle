using Domain.Entities;
using Domain.Persistence.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Persistence.Announcements
{
    public interface IAnnouncementUnitOfWork : IUnitOfWork
    {
        IAnnouncementRepository Repository { get; }
    }
}
