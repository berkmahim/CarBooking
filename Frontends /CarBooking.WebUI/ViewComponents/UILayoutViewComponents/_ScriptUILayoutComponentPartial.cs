using Microsoft.AspNetCore.Mvc;

namespace CarBooking.WebUI.ViewComponents.UILayoutViewComponents;

public class _ScriptUILayoutComponentPartial : ViewComponent
{
    public ViewComponentResult Invoke()
    {
        return View();
    }
}