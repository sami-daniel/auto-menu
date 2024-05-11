using System;
using AutoMenu.Infra.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Services.DTO.Responses;

namespace AutoMenu.Infrastructure.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CheckSessionObjectFilter : Attribute, IActionFilter
    {
        public CheckSessionObjectFilter()
        {
            
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var session = context.HttpContext!.Session.GetObject<RestaurantResponse>("User");
            var webHostEnvironment = context.HttpContext.RequestServices.GetService(typeof(IWebHostEnvironment)) as IWebHostEnvironment;
            if (session == null && !webHostEnvironment!.IsDevelopment())
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        { "controller", "Home" },
                        { "action", "" }
                    });
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
