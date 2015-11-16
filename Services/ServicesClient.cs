using System;
using System.Collections.Generic;
using System.Linq;



namespace Services
{
   public  class ServicesClient
    {
        private static List<Client> listOfClient = new List<Client>();
        public Client Get(int id)
        {
            foreach (Client c in listOfClient)
                if (c.Id == id) return (Client)c.Clone();
            return null;
        }
        public List<Client> Get()
        {
            return listOfClient;
        }
        public Client Add(Client clientForAdd)
        {
            clientForAdd.Id = listOfClient.Any() ? listOfClient.Max(item => item.Id) + 1 : 1;
            listOfClient.Add(clientForAdd);
            return (Client)clientForAdd.Clone();
        }
        public Client Update(Client clientForUpdate)
        {
            var client = this.Get(clientForUpdate.Id);
            if (client == null)
            {
                throw new NullReferenceException();
            }
            client.DateOfBirth = clientForUpdate.DateOfBirth;
            client.DriverLicenseNumber = clientForUpdate.DriverLicenseNumber;
            client.Email = clientForUpdate.Email;
            client.Id = clientForUpdate.Id;
            client.Login = clientForUpdate.Login;
            client.Name = clientForUpdate.Name;
            client.Orders = clientForUpdate.Orders;
            client.PassportNumber = clientForUpdate.PassportNumber;
            client.Password = clientForUpdate.Password;
            client.PhoneNumber = clientForUpdate.PhoneNumber;
            client.Surname = clientForUpdate.Surname;
            return (Client)client.Clone();
        }
        public void Delete(int id)
        {
            Client client = listOfClient.SingleOrDefault(item => item.Id == id);
                         if (client == null) throw new NullReferenceException();
                        listOfClient.Remove(client);

        }
    }
}
