LaunchDarkly SDK for Xamarin
================

Xamarin.iOS binding library for [Launchdarkly SDK](https://github.com/launchdarkly/ios-client).

For more information on LaunchDarkly see the iOS SDK [reference](https://docs.launchdarkly.com/v2.0/docs/ios-sdk-reference).

This binding library is available on [Nuget](https://www.nuget.org/packages/Ricardo.LaunchDarkly.iOS/).

Documentation
=============

    public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            // Instantiate a new LDClient with your mobile key and user
            LDConfig config = new LDConfig("YOUR_MOBILE_KEY");

            LDUserBuilder user = new LDUserBuilder();
            user.Key = "aa0ceb";

            LDClient.SharedInstance.Start(config, user);

            return true;
        }


See the Ricardo.LaunchDarkly.iOS.Sample app.

License
=======

- xamarin-launchdarkly-ios is licensed under [MIT](http://opensource.org/licenses/mit-license)
