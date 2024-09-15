using DependencyInjection.Models;
using DependencyInjection.Models.ViewModels;
using DependencyInjection.Service;
using DependencyInjection.Utility.AppSettingsClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
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

        // configs
        private readonly WazeForecast _wazeForecastSettings;

        public HomeController(IMarketForecaster marketForeCaster,IOptions<WazeForecast> wazeForecastSettings)
        {
            _marketForeCaster = marketForeCaster;

            // set configuration value
            _wazeForecastSettings = wazeForecastSettings.Value;

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


        public IActionResult AllConfigs([FromServices] IOptions<Stripe> stripeSettings,
            [FromServices] IOptions<Twilio> twilioSettings,
            [FromServices] IOptions<SendGrid> sendGridSettings
            )
        {
            List<String> allConfigs = new List<String>();
            allConfigs.Add(_wazeForecastSettings.ForecastTrackerEnablecr.ToString());

            allConfigs.Add(stripeSettings.Value.PublishableKey);
            allConfigs.Add(stripeSettings.Value.SecretKey);

            allConfigs.Add(twilioSettings.Value.PhoneNumber);
            allConfigs.Add(twilioSettings.Value.AccountSid);

            allConfigs.Add(sendGridSettings.Value.SendGridKey);



            return View(allConfigs);
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
