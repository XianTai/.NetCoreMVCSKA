using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dotnetCoreMVC_SKA.Controllers
{
    
    public class KeepAccount : Controller
    {
        public static AllOrder Orders = new AllOrder();
        private static List<Order> _orders = new List<Order>();
        
        public IActionResult Index()
        {
            Orders.orders = _orders;
            return View("Index",Orders);
        }

        public async Task<IActionResult> Input(Order order)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", Orders);
            }

            order.InputTime = DateTime.Now;
            _orders.Add(order);

            return RedirectToAction("Index");
        }

        [Route("api/[action]")]
        public JsonResult Records()
        {
            return Json(Orders.orders);
        }
    }

    public class AllOrder
    {
        public List<Order> orders { get; set; }
        public Order Order { get; set; }
    }
    public class Order
    {
        [Required]
        public string Name { get; set; }

        [Required,Range(0, Int32.MaxValue, ErrorMessage = "Price must >= 0")]
        public int? Price { get; set; }
        public string Remark { get; set; }

        public DateTime InputTime { get; set; }
    }
}
