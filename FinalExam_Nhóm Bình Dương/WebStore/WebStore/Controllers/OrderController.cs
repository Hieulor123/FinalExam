using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebStore.Models;
using WedStore.Models;
using WedStore.Repositories;

namespace WedStore.Controllers
{
    [Authorize(Roles = "Customer")]
    public class OrderController : Controller
    {
        private string userName;
        public OrderController(IHttpContextAccessor httpContextAccessor)
        {
            var userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            userName = userId;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddToCart(OrderItem orderItem)
        {
            if (orderItem == null)
            {
                // Xử lý khi orderItem là null
                return RedirectToAction("Error", "Home");
            }

            bool result1 = OrdersRes.checkOrders(userName); // Kiểm tra có giỏ hàng chưa
            Orders orders = OrdersRes.GetOrdersUserOnStatus(userName, 1);

            if (orders == null)
            {
                // Xử lý khi không tìm thấy đơn hàng
                return RedirectToAction("Error", "Home");
            }

            OrderItem item = OrderItemRes.GetOrderItemWithOrderIDBookID(orders.OrderID, orderItem.BookID);
            if (item != null)
            {
                item.Quantity += orderItem.Quantity;
                item.TotalPrice = item.Quantity * BookRes.BookWithID(orderItem.BookID)?.Price ?? 0;
                OrderItemRes.UpdateOrderItem(item);
            }
            else
            {
                Random rnd = new Random();
                int id = rnd.Next(100000, 999999);
                while (OrderItemRes.GetOrderItemWithID(id.ToString()) != null)
                {
                    id = rnd.Next(100000, 999999);
                }
                orderItem.ItemID = id.ToString();
                orderItem.OrderID = orders.OrderID;
                orderItem.TotalPrice = orderItem.Quantity * BookRes.BookWithID(orderItem.BookID)?.Price ?? 0;
                orderItem.Discount = 0;
                OrderItemRes.CreateOrderItem(orderItem);
            }
            return RedirectToAction("Cart", "Order");
        }

        public ActionResult Cart()
        {
            dynamic dy = new ExpandoObject();
            dy.booktypeNAV = BookTypeRes.GetAllType();

            bool result1 = OrdersRes.checkOrders(userName); // Kiểm tra có giỏ hàng chưa
            Orders orders = OrdersRes.GetOrdersUserOnStatus(userName, 1);

            if (orders == null)
            {
                // Xử lý khi không tìm thấy đơn hàng
                return RedirectToAction("Error", "Home"); // Hoặc xử lý theo cách khác
            }

            List<OrderItem> lstOrderItem = OrderItemRes.GetOrderItemsWithOrderID(orders.OrderID) ?? new List<OrderItem>();

            dy.orderItem = lstOrderItem;
            int totalPrice = 0;
            List<Book> lstBook = new List<Book>();

            if (lstOrderItem.Count > 0)
            {
                foreach (var item in lstOrderItem)
                {
                    totalPrice += item.TotalPrice;
                    orders.OrderPrice = totalPrice;
                    OrdersRes.Orders_Update(orders);
                    var book = BookRes.BookWithID(item.BookID);
                    if (book != null)
                    {
                        lstBook.Add(book);
                    }
                }
            }
            else
            {
                orders.OrderPrice = totalPrice;
                OrdersRes.Orders_Update(orders);
            }

            dy.lstBook = lstBook;
            dy.orders = orders;
            return View(dy);
        }

        public ActionResult Checkout()
        {
            dynamic dy = new ExpandoObject();
            dy.booktypeNAV = BookTypeRes.GetAllType();
            dy.account = AccountRes.GetAccountWithUser(userName);
            //tìm giỏ hàng của user trạng thái =1
            Orders orders = OrdersRes.GetOrdersUserOnStatus(userName, 1);
            if(orders == null)
            {
                return Redirect("/");
            }
            if(orders.OrderPrice == 0)
            {
                return RedirectToAction(nameof(Cart));
            }
            dy.orders = orders;
            dy.totalPrice = orders.OrderPrice + 20000;
            return View(dy);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Checkout(InfoOrder infoOrder)
        {
            Orders orders = OrdersRes.GetOrdersUserOnStatus(userName, 1);

            infoOrder.OrderID = orders.OrderID;
            infoOrder.TotalPrice = orders.OrderPrice + 20000;
            //random id cho thông tin đơn hàng
            Random rnd = new Random();
            int id = rnd.Next(100000, 999999);
            while (InfoOrderRes.InfoOrder_GetInfoOrdersWithID(id.ToString()) != null)
            {
                id = rnd.Next(100000, 999999);
            }
            infoOrder.InfoOrderID = id.ToString();
            //tạo đơn hàng
            InfoOrderRes.InfoOrder_create(infoOrder);
            //cập nhật trạng thái giỏ hàng = 2
            orders.OrderStatus = 2;
            OrdersRes.Orders_Update(orders);
            return Redirect("OrdersList");
        }

        public ActionResult OrdersList()// danh sách đơn hàng
        {
            dynamic dy = new ExpandoObject();
            dy.booktypeNAV = BookTypeRes.GetAllType();
            //lấy danh sách các giỏ hàng của user bằng email
            List<InfoOrder> lstOrder = InfoOrderRes.InfoOrder_GetInfoOrderWithEmail(
                                        AccountRes.GetAccountWithUser(userName).Email);
            dy.lstOrder = lstOrder;
            return View(dy);
        }
        public ActionResult InfoOrderDetail(string id)
        {
            dynamic dy = new ExpandoObject();
            dy.booktypeNAV = BookTypeRes.GetAllType();

            var infoOrder = InfoOrderRes.InfoOrder_GetInfoOrdersWithID(id);
            
            //lấy danh sách item trong giỏ hàng bằng OrderID
            List<OrderItem> lstOrderItem = OrderItemRes.GetOrderItemsWithOrderID(infoOrder.OrderID);
            dy.orderItem = lstOrderItem;


            //tìm thông tin sách từ List OrderItem trong giỏ hàng
            List<Book> lstBook = new List<Book>();
            foreach (var item in lstOrderItem)
            {
                lstBook.Add(BookRes.BookWithID(item.BookID));
            }
            dy.lstBook = lstBook;
            dy.infoOrder = infoOrder;
            return View(dy);
        }
        public ActionResult DeleteItem(string id)
        {
            //xóa item trong giỏ hàng
            OrderItemRes.deleteOrderItem(id);//ItemID
            return RedirectToAction("Cart");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditItem(OrderItem orderItem,string add, string sub)
        {
            //lấy thông tin item bằng ItemID
            OrderItem orderItem1 = OrderItemRes.GetOrderItemWithID(orderItem.ItemID);
            //qiá sản phẩm
            int price = orderItem1.TotalPrice / orderItem1.Quantity;
            //nếu nhấm button "add" thì tăng sản phẩm lên 1 ngược lại "sub"  giảm 1
            if (add != null)
            {
                orderItem1.Quantity ++;
                orderItem1.TotalPrice = price * orderItem1.Quantity;
                OrderItemRes.UpdateOrderItem(orderItem1);
            }
            else if(sub != null)
            {
                orderItem1.Quantity--;
                if(orderItem1.Quantity != 0)
                {
                    orderItem1.TotalPrice = price * orderItem1.Quantity;
                    OrderItemRes.UpdateOrderItem(orderItem1);
                }
                else
                {
                    OrderItemRes.deleteOrderItem(orderItem1.ItemID);
                }
            }
            return RedirectToAction("Cart");
        }
    }
}
