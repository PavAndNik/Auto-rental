using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRental.Services
{
    class ServicesClient
    {
        private List<Client> ListOfClient = new List<Client>();
        public void AddClient(Client NewClient)
        {
            NewClient.Id = ListOfClient.Last<Client>().Id + 1;
            ListOfClient.Add(NewClient);
        }
        public Client GetClient(string ID)
        {
            foreach (Client p in ListOfClient)
            {
                if (p.Id == ID)
                    return p;
            }
            return null;
        }
        public void DeleteClient(string ID)
        {
            foreach (Client p in ListOfClient)
            {
                if (p.Id == ID)
                    ListOfClient.Remove(p);
            }
        }
        public void UpdateClient(Client P)
        {
            int index = ListOfClient.IndexOf(P);
            if (index != -1)
            {
                ListOfClient[index] = P;
            }
            else AddClient(P);
        }
    }
}
