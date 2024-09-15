using DependencyInjection.Service.LifeTimeExercise;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace DependencyInjection.Middlewares
{
    public class CustomMiddleware
    {
        public readonly RequestDelegate _next;

        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        // Middleware is a key concept in modern web frameworks, such as ASP.NET Core,
        // which refers to a component that is executed as part of the request-response pipeline
        public async Task InvokeAsync(HttpContext context, TransientService transientService,
            SingletonService singletonService,
            ScopedService scopedService)
        {

            context.Items.Add("CustommiddleWareTransientKey", transientService.GetGuid());
            context.Items.Add("CustommiddleWareScopedKey", scopedService.GetGuid());
            context.Items.Add("CustommiddleWareSingletontKey", singletonService.GetGuid());

            await _next(context);
        }
    }
}
