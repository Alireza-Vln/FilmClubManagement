using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmClubs.Contracts
{
    public interface UnitOfWork
    {
        Task Begin();
        Task Commit();
        Task Complete();
        Task RollBack();
    }
}
