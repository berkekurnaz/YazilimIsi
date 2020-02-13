using System;
using System.Collections.Generic;
using System.Text;
using YazilimIsi.DataAccess.Abstract;
using YazilimIsi.Entity.Models;

namespace YazilimIsi.DataAccess.Concrete
{
    public class EfUserDal : EfEntityRepositoryBase<User, DbYazilimIsiContext>, IUserDal
    {

    }
}
