using AutoMenu.Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace AutoMenu.Infrastructure.Convetions
{
    public class ApplyCheckSessionObjectFilterConvention : IApplicationModelConvention
    {
        public void Apply(ApplicationModel application)
        {
            var controllerName = application.Controllers.First(c => c.ControllerName == "Interface").ControllerType.Name;

            if (controllerName == "InterfaceController")
            {
                application.Filters.Add(new CheckSessionObjectFilter());
            }
        }
    }
}
