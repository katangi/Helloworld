using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingMvc.Models;
using DataAccessLayer;


namespace BussinessLayer
{
   public class OrderDetailsBL
    {
       OrderDetailsDL orderdetailDL = new OrderDetailsDL();
        public int SaveOrderDetail(OrderDetails orderdetail)
        {

            int a = orderdetailDL.SaveOrderDetails(orderdetail);
            return a;
        }

        public List<OrderDetails> GetCartById(int Id)
        {
            List<OrderDetails> orderList = new List<OrderDetails>();
            orderList = orderdetailDL.GetCartById(Id);
            return orderList;
        }
        public int UpdateOrderDetail(OrderDetails orderdetail)
        {

            int a = orderdetailDL.UpdateOrderdetails(orderdetail);
            return a;
        }
        public OrderDetails GetOrderDetailById(int id)
        {
            OrderDetails orderdetail = orderdetailDL.GetOrderdetailsById(id);
            return orderdetail;
        }
        public List<OrderDetails>GetAllOrderdetail()
        {
            List<OrderDetails> orderdetaillist = orderdetailDL.GetAllOrderDetail();
            return orderdetaillist;
        }

        public int DeleteCart(int pid,int uid)
        {
            int a = orderdetailDL.DeleteCart(pid,uid);
            return a;
        }
    }
}
