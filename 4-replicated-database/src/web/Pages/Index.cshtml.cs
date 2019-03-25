using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Store.Entities;
using Store.Model;

namespace Store.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly StoreContext _context;

        public IEnumerable<Product> Products { get; private set; }

        public IndexModel(StoreContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Products = _context.Products.OrderBy(x=>x.Id).ToList();
        }
    }
}
