using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ShoppingMvc.Models;
using DataAccessLayer;

namespace BussinessLayer
{
  public class CityBL
    {
        CityDL cityDL = new CityDL();
        public List<City> GetCityByStateId(int Id)
        {
            List<City> cityList = cityDL.GetCityByStateId(Id);
            return cityList;
        }
        public int SaveCity(City city)
        {
            int a = cityDL.SaveCity(city);
            return a;
        }
        public int DeleteCity(City city)
        {
            int a = cityDL.DeleteCity(city);
            return a;
        }

        public List<City> GetAllCity()
        {
            List<City> cityList = cityDL.GetAllCity();
            return cityList;
        }
        public int UpdateCity(City city)
        {
            int a = cityDL.UpdateCity(city);
            return a;
        }
        public City GetcityById(int id)
        {
            City city = cityDL.GetCityById(id);
            return city;
        }
    }
}
