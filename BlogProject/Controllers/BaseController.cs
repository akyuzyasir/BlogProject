using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.UI.Controllers
{
    public class BaseController : Controller
    {
        protected INotyfService NotfyService => HttpContext.RequestServices.GetService(typeof(INotyfService)) as INotyfService;
        protected void NotifySuccess(string message) => NotfyService.Success(message);
        protected void NotifyError(string message) => NotfyService.Error(message);
        protected void NotifyWarning(string message) => NotfyService.Warning(message);
    }
}
