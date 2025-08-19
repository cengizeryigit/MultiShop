using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailDescriptionComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            // You can pass any model or data to the view if needed
            return View();
        }
    }
}
