using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using ShoppingMvc.Models;

namespace BussinessLayer
{
  public class StateBL
    {
        StateDL stateDL = new StateDL();
   
        public List<State> GetStateByCountryId(int Id)
        {
            List<State> stateList = new List<State>();
            stateList = stateDL.GetStateByCountryId(Id);
            return stateList;
        }

        public int DeleteState(State state)
        {
            int a = stateDL.DeleteState(state);
            return a;
        }


        public State GetStateById(int id)
        {
            State state = stateDL.GetStateById(id);
            return state;
        }
      
        public int SaveState(State state)
        {
            int a = stateDL.SaveState(state);
            return a;
        }
        public List<State>GetAllState()
        {
           List<State>stateList = stateDL.GetAllState();

            return stateList;
        }
        public int UpdateState(State state)
        {
            int a = stateDL.UpdateState(state);
            return a;
        }

    }
}
