using AutoRental.Data.EF.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRental.Data.EF
{
    public class ClientRepository : Repository<Client>,IClientRepository
    {
        public ClientRepository(DataContext context):base(context)
        {

        }
    }
}
