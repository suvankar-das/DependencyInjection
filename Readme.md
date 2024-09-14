IOptions
--
Let's say our application needs , these keys 

```
  "WazeForecast": {
    "ForecastTrackerEnablecr": true
  },
  "Stripe": {
    "SecretKey": "sk_test_WINERWEOF3242391187w1100mx0mMy8",
    "PublishableKey": "pk_test_ct2earmEUGF2342392311EROFoTuuclOr"
  },
  "Twilio": {
    "PhoneNumber": "+122234532",
    "AuthToken": "AC58",
    "AccountSid": "AC557"
  },
  "SendGrid": {
    "SendGridKey": "SengGritl5ampleKey11112222"
  },
```

So I have put that in appsettings.json,

- Now , in order to extract these key values inside our controller , We could use IOption service framework.
- So far that the first thing that we have to do is we have to create classes with the same properties that we see inside each section.
- Now create a folder inside anywhere (good to place inside Utility or etc) and name it AppSettingsClasses or whatever.
- Inside that folder create those 4 classes with property (So with this we have all four of the classes that corresponds to the sections
  and in those classes the property name should match with each key.)
- Now how can we extract these values in display them inside the home controller? For that , The first thing that we have to do is we need 
  to configure our container with the IService collection.

  ```
     public void ConfigureServices(IServiceCollection services)
        {
          // .....
          //GetSection() required a key and The key would be the exact same name that we have in appsettings.json.
            services.Configure<WazeForecast>(Configuration.GetSection("WazeForecast"));
            services.Configure<Stripe>(Configuration.GetSection("Stripe"));
            services.Configure<Twilio>(Configuration.GetSection("Twilio"));
            services.Configure<SendGrid>(Configuration.GetSection("SendGrid"));
        }
  ```
- Then , in order to access in controller 

  ```
    public class HomeController : Controller
    {
        // configs
        private readonly Stripe _stripeSettings;
        private readonly WazeForecast _wazeForecastSettings;
        private readonly Twilio _twilioSettings;
        private readonly SendGrid _sendGridSettings;
       
        public HomeController(
            IOptions<Stripe> stripeSettings,
            IOptions<WazeForecast> wazeForecastSettings,
            IOptions<Twilio> twilioSettings,
            IOptions<SendGrid> sendGridSettings
            )
        {
            // set configuration value
            _stripeSettings = stripeSettings.Value;
            _wazeForecastSettings = wazeForecastSettings.Value;
            _twilioSettings = twilioSettings.Value;
            _sendGridSettings = sendGridSettings.Value;

        }
        
        public IActionResult AllConfigs()
        {
            List<String> allConfigs = new List<String>();
            allConfigs.Add(_wazeForecastSettings.ForecastTrackerEnablecr.ToString());
            
            allConfigs.Add(_stripeSettings.PublishableKey);
            allConfigs.Add(_stripeSettings.SecretKey);
            
            allConfigs.Add(_twilioSettings.PhoneNumber);
            allConfigs.Add(_twilioSettings.AccountSid);

            allConfigs.Add(_sendGridSettings.SendGridKey);



            return View(allConfigs);
        }
    }

   Then on AllConfigs.cshtml, 

    @model List<string>
    @{
        ViewData["Title"] = "Settings";
    }

    <div class="p-4">
        <ul>
            @foreach (string s in Model)
            {
                <li>@s</li>
            }
        </ul>
    </div>
  ```

