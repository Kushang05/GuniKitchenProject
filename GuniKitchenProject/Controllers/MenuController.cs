using GuniKitchenProject.Data;
using Microsoft.AspNetCore.Mvc;
//using GuniKitchenProject.ViewModles;
using GuniKitchenProject.Models;
using System.Threading.Tasks;
using GuniKitchenProject.ViewModel;
using System.Linq;

namespace GuniKitchenProject.Controllers
{
    public class MenuController : Controller
    {
        public readonly ApplicationDbContext _context;

        public MenuController(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var viewmodel = new ProductViewModel();

            var product = _context.Products.SingleOrDefault(x => x.ProductId == product.ProductId);
            if(product == null)
            {
                viewmodel.ProductName = product.Name;
                viewmodel.ProductDescription = product.Description;
                viewmodel.Category = product.Category;
                viewmodel.ProductPrice = product.Price;
                viewmodel.ProductSize = product.Size;
            }
            return View(viewmodel);
        }
    }
}
