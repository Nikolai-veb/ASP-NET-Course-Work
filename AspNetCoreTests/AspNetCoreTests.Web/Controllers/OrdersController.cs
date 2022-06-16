using System.Threading.Tasks;
using AspNetCoreTests.Web.Models;
using AspNetCoreTests.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreTests.Web.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _orderService.List();

            return View(orders);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return BadRequest();
            }

            var model = await _orderService.GetOrder(id.Value);
            if(model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderModel model)
        {
            return await SaveOrder(model);
        }

        // [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var model = await _orderService.GetOrder(id.Value);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(OrderModel model)
        {
            return await SaveOrder(model);
        }

        [NonAction]
        private async Task<IActionResult> SaveOrder(OrderModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            await _orderService.SaveOrder(model);

            return RedirectToAction(nameof(OrdersController.Index));
        }
    }
}