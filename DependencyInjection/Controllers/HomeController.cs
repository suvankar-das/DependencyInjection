using DependencyInjection.Models;
using DependencyInjection.Models.ViewModels;
using DependencyInjection.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        HomeViewModel vm = new HomeViewModel();
        private readonly IMarketForecaster _marketForeCaster;
        public HomeController(IMarketForecaster marketForeCaster)
        {
            _marketForeCaster = marketForeCaster;
        }
        public IActionResult Index()
        {
            MarketResult marketResult = _marketForeCaster.GetMarketPrediction();

            switch (marketResult.MarketCondition)
            {
                case MarketCondition.StableUp:
                    vm.MarketForeCast = "The market is showing steady upward growth. " +
                        "Consider holding or gradually increasing your positions.";
                    break;
                case MarketCondition.StableDown:
                    vm.MarketForeCast = "The market is experiencing a slight decline. " +
                        "It may be wise to hold or monitor for further changes.";
                    break;
                case MarketCondition.Volatile:
                    vm.MarketForeCast = "The market is highly volatile. " +
                        "Exercise caution and avoid making impulsive decisions.";
                    break;
                default:
                    vm.MarketForeCast = "Market conditions are uncertain. " +
                        "Stay informed and proceed with careful planning.";
                    break;
            }

            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
