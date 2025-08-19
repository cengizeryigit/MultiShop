using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.ShoppingCartViewComponents
{
    public class _ShoppingCartProductListComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            // Here you can retrieve the shopping cart items from a service or database
            // For demonstration, we will return a simple view
            return View();
        }

    }
}
