using AutoRental.Audit;
using AutoRental.Data.Common;
using AutoRental.Data.EF;
using AutoRental.Services.Common;
using Services.Services_Async;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Services_Async
{
   public class ServicesClientAsync : DomainServiceAsync<Client>
    {
        private readonly List<Client> entities = new List<Client>();
        
        public ServicesClientAsync(ClientRepository repository): base(repository)
        {

        }
    }
}
