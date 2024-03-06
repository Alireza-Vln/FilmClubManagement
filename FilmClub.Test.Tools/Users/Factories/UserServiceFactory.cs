using FilmClub.Services.Unit.Test.UsersTest;
using FilmClubManagement.Persistance.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmClub.Test.Tools.Users.Factories
{
   public  static class UserServiceFactory
    {
        public static UserService Create(EFDataContext context)
        {
            return new UserAppService(new EFUserRepository(context), 
                                         new EFUnitOfWork(context));
        }
    }
}
