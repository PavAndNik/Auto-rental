using System;
using System.Collections.Generic;
using System.Text;


namespace Services
{
    class ServicesClient
    {
        private static List<Client> listOfClient = new List<Client>();
        public Client Get(int id)
        {
            return listOfClient.SingleOrDefault(item => item.Id == id);
        }
        public List<Client> Get()
        {
            return listOfClient;
        }
        public Client Add(Client clientForAdd)
        {
            clientForAdd.Id = listOfClient.Any() ? listOfClient.Max(item => item.Id) + 1 : 1;
            listOfClient.Add(clientForAdd);
            return clientForAdd;
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
            return client;
        }
        public void Delete(int id)
        {
            var client = this.Get(id);
            if (client == null)
            {
                throw new NullReferenceException();
            }
            listOfClient.Remove(client);
        }
    }
}
