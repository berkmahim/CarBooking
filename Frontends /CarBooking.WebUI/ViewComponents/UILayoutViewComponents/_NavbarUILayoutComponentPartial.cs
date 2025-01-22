using Microsoft.AspNetCore.Mvc;

namespace CarBooking.WebUI.ViewComponents.UILayoutViewComponents;

public class _NavbarUILayoutComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}