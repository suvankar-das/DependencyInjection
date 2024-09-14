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
