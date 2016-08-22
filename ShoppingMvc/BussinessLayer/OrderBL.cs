using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingMvc.Models;
using DataAccessLayer;
using System.Data;

namespace BussinessLayer
{
    
   public class OrderBL
    {
        OrderDL orderDL = new OrderDL();
        public int SaveOrder(Orders order)
        {
            int a = orderDL.SaveOrders(order);
            return a;
        }

        public int SaveCardDetail(Orders order)
        {
            int a = orderDL.SaveCardDetail(order);
            return a;
        }
        public List<Orders> GetAllOrderde()
        {
            List<Orders> orderlist = orderDL.GetAllOrder();
            return orderlist;
        }

        public int MaxId(Orders order)
        {
            int a = orderDL.MaxId();
            return a;
        }
        public int DeleteOrderCart(int orderId)
        {
            int a = orderDL.DeleteOrderCart(orderId);
            return a;
        }

        public int GetOrderId(int pid,int uid)
        {
            int a = orderDL.GetOrderId(pid,uid);
            return a;
        }
    }
}
