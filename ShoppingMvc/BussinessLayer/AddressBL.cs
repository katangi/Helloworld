using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using ShoppingMvc.Models;

namespace BussinessLayer
{
  public  class AddressBL
    {
        AddressDL addressDL = new AddressDL();
        public int SaveAddress(Address obaddress)
        {
            int a = addressDL.SaveAddress(obaddress);
            return a;
        }

        public int UpdateAddress(Address obaddress)
        {
            int a = addressDL.UpdateAddress(obaddress);
            return a;
        }
        public List<Address> GetAddressById(int id)
        {
            List < Address > address = addressDL.GetAddressById(id);
            return address;
        }

        public Address BindAddressById(int id)
        {
            Address address = addressDL.BindAddressById(id);
            return address;
        }
        public List<Address> GetAllAddress()
        {
            List<Address> addressList = addressDL.GetAllAddress();
            return addressList;
        }
    }
}
