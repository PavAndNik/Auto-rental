using AutoRental.Data;
using AutoRental.Data.EF;
using AutoRental.Data.Model;
using AutoRental.Services.Common;

namespace Services.Services_Async
{
    public class ServicesClientAsync : DomainServiceAsync<Client>
    {       
        public ServicesClientAsync(IClientRepository repository): base(repository)
        {

        }
    }
}
