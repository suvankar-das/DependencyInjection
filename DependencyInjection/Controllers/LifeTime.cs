using DependencyInjection.Service.LifeTimeExercise;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DependencyInjection.Controllers
{
    public class LifeTime : Controller
    {
        private readonly TransientService _transientService;
        private readonly SingletonService _singletonService;
        private readonly ScopedService _scopedService;

        public LifeTime(TransientService transientService, ScopedService scopedService, SingletonService singletonService)
        {
            _transientService = transientService;
            _scopedService = scopedService;
            _singletonService = singletonService;
        }
        public IActionResult Index()
        {
            var message = new List<string>()
            {
                // compare GUID between constructor and middleware
                HttpContext.Items["CustommiddleWareTransientKey"].ToString(),
                $"Transient Controller - {_transientService.GetGuid()}",
                HttpContext.Items["CustommiddleWareScopedKey"].ToString(),
                $"Scoped Controller - {_scopedService.GetGuid()}",
                HttpContext.Items["CustommiddleWareSingletontKey"].ToString(),
                $"Singleton Controller - {_singletonService.GetGuid()}",
            };

            return View(message);
        }
    }
}
