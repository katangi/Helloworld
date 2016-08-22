using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using ShoppingMvc.Models;

namespace BussinessLayer
{
  public  class CountryBL
    {
       CountryDL countryDL = new CountryDL();

        public List<Country> GetAllCountry()
        {
            List<Country> countryList = countryDL.GetAllCountry();
            return countryList;
        }
        public int SaveCountry(Country obcountry)
        {
            int a = countryDL.SaveCountry(obcountry);
            return a;
        }
        public int DeleteCountry(Country country)
        {
            int a = countryDL.DeleteCountry(country);
            return a;
        }
        public int UpdateCountry(Country obcountry)
        {
            int a = countryDL.UpdateCountry(obcountry);
            return a;
        }

        public Country GetCountryById(int id)
        {
            Country country = countryDL.GetCountryById(id);
            return country;
        }
    }
}
