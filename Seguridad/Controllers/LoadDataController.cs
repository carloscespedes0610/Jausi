using Seguridad.Models.DAC;
using System.Web.Mvc;

namespace Seguridad.Controllers
{
    public static class LoadDataController
    {
        public static void GetDefaultData(this ControllerBase controller)
        {
            controller.ViewBag.UsuarioDes = clsAppInfo.UsuarioDes;
            controller.ViewBag.UsuarioFotoPath = clsAppInfo.AppPath + clsAppInfo.UsuarioFotoPath;
        }
    }
}