using System;
using CoreFoundation;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace Ricardo.LaunchDarkly.iOS
{
    partial interface IRequestManagerDelegate { }

    // @interface LDUserModel : NSObject <NSCoding>
    [BaseType(typeof(NSObject))]
    interface LDUserModel : INSCoding
    {
        // @property (nonatomic, setter = key:, strong) NSString * _Nullable key;
        [NullAllowed, Export("key", ArgumentSemantic.Strong)]
        string Key { get; [Bind("key:")] set; }

        // @property (nonatomic, strong) NSString * _Nullable ip;
        [NullAllowed, Export("ip", ArgumentSemantic.Strong)]
        string Ip { get; set; }

        // @property (nonatomic, strong) NSString * _Nullable country;
        [NullAllowed, Export("country", ArgumentSemantic.Strong)]
        string Country { get; set; }

        // @property (nonatomic, strong) NSString * _Nullable name;
        [NullAllowed, Export("name", ArgumentSemantic.Strong)]
        string Name { get; set; }

        // @property (nonatomic, strong) NSString * _Nullable firstName;
        [NullAllowed, Export("firstName", ArgumentSemantic.Strong)]
        string FirstName { get; set; }

        // @property (nonatomic, strong) NSString * _Nullable lastName;
        [NullAllowed, Export("lastName", ArgumentSemantic.Strong)]
        string LastName { get; set; }

        // @property (nonatomic, strong) NSString * _Nullable email;
        [NullAllowed, Export("email", ArgumentSemantic.Strong)]
        string Email { get; set; }

        // @property (nonatomic, strong) NSString * _Nullable avatar;
        [NullAllowed, Export("avatar", ArgumentSemantic.Strong)]
        string Avatar { get; set; }

        // @property (nonatomic, strong) NSDictionary * _Nullable custom;
        [NullAllowed, Export("custom", ArgumentSemantic.Strong)]
        NSDictionary Custom { get; set; }

        // @property (nonatomic, strong) NSDate * _Nullable updatedAt;
        [NullAllowed, Export("updatedAt", ArgumentSemantic.Strong)]
        NSDate UpdatedAt { get; set; }

        // @property (nonatomic, strong) LDFlagConfigModel * _Nullable config;
        [NullAllowed, Export("config", ArgumentSemantic.Strong)]
        LDFlagConfigModel Config { get; set; }

        // @property (assign, nonatomic) BOOL anonymous;
        [Export("anonymous")]
        bool Anonymous { get; set; }

        // @property (nonatomic, strong) NSString * _Nullable device;
        [NullAllowed, Export("device", ArgumentSemantic.Strong)]
        string Device { get; set; }

        // @property (nonatomic, strong) NSString * _Nullable os;
        [NullAllowed, Export("os", ArgumentSemantic.Strong)]
        string Os { get; set; }

        // -(id _Nonnull)initWithDictionary:(NSDictionary * _Nonnull)dictionary;
        [Export("initWithDictionary:")]
        IntPtr Constructor(NSDictionary dictionary);

        // -(NSString * _Nonnull)convertToJson;
        [Export("convertToJson")]
        string ConvertToJson { get; }

        // -(NSDictionary * _Nonnull)dictionaryValue;
        [Export("dictionaryValue")]
        NSDictionary DictionaryValue { get; }

        // -(NSDictionary * _Nonnull)dictionaryValueWithConfig:(BOOL)withConfig;
        [Export("dictionaryValueWithConfig:")]
        NSDictionary DictionaryValueWithConfig(bool withConfig);

        // -(NSObject * _Nonnull)flagValue:(NSString * _Nonnull)keyName;
        [Export("flagValue:")]
        NSObject FlagValue(string keyName);

        // -(BOOL)doesFlagExist:(NSString * _Nonnull)keyName;
        [Export("doesFlagExist:")]
        bool DoesFlagExist(string keyName);
    }

    // @interface LDDataManager : NSObject
    [BaseType(typeof(NSObject))]
    interface LDDataManager
    {
        // +(LDDataManager *)sharedManager;
        [Static]
        [Export("sharedManager")]
        LDDataManager SharedManager { get; }

        // -(void)allEventsJsonArray:(void (^)(NSArray *))completion;
        [Export("allEventsJsonArray:")]
        void AllEventsJsonArray(Action<NSArray> completion);

        // -(NSMutableDictionary *)retrieveUserDictionary;
        [Export("retrieveUserDictionary")]
        NSMutableDictionary RetrieveUserDictionary { get; }

        // -(NSMutableArray *)retrieveEventsArray;
        [Export("retrieveEventsArray")]
        NSMutableArray RetrieveEventsArray { get; }

        // -(LDUserModel *)findUserWithkey:(NSString *)key;
        [Export("findUserWithkey:")]
        LDUserModel FindUserWithkey(string key);

        // -(void)createFeatureEvent:(NSString *)featureKey keyValue:(NSObject *)keyValue defaultKeyValue:(NSObject *)defaultKeyValue;
        [Export("createFeatureEvent:keyValue:defaultKeyValue:")]
        void CreateFeatureEvent(string featureKey, NSObject keyValue, NSObject defaultKeyValue);

        // -(void)createCustomEvent:(NSString *)eventKey withCustomValuesDictionary:(NSDictionary *)customDict;
        [Export("createCustomEvent:withCustomValuesDictionary:")]
        void CreateCustomEvent(string eventKey, NSDictionary customDict);

        // -(void)purgeOldUser:(NSMutableDictionary *)dictionary;
        [Export("purgeOldUser:")]
        void PurgeOldUser(NSMutableDictionary dictionary);

        // -(void)saveUser:(LDUserModel *)user;
        [Export("saveUser:")]
        void SaveUser(LDUserModel user);

        // -(void)saveUserDeprecated:(LDUserModel *)user __attribute__((deprecated("Use saveUser: instead")));
        [Export("saveUserDeprecated:")]
        void SaveUserDeprecated(LDUserModel user);

        // -(void)deleteProcessedEvents:(NSArray *)processedJsonArray;
        [Export("deleteProcessedEvents:")]
        void DeleteProcessedEvents(NSObject[] processedJsonArray);

        // -(void)flushEventsDictionary;
        [Export("flushEventsDictionary")]
        void FlushEventsDictionary();
    }

    // @interface LDConfig : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface LDConfig
    {
        // @property (readonly, nonatomic) NSString * _Nonnull mobileKey;
        [Export("mobileKey")]
        string MobileKey { get; }

        // @property (copy, nonatomic) NSString * _Nullable baseUrl;
        [NullAllowed, Export("baseUrl")]
        string BaseUrl { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable eventsUrl;
        [NullAllowed, Export("eventsUrl")]
        string EventsUrl { get; set; }

        // @property (copy, nonatomic) NSNumber * _Nullable capacity;
        [NullAllowed, Export("capacity", ArgumentSemantic.Copy)]
        NSNumber Capacity { get; set; }

        // @property (copy, nonatomic) NSNumber * _Nullable connectionTimeout;
        [NullAllowed, Export("connectionTimeout", ArgumentSemantic.Copy)]
        NSNumber ConnectionTimeout { get; set; }

        // @property (copy, nonatomic) NSNumber * _Nullable flushInterval;
        [NullAllowed, Export("flushInterval", ArgumentSemantic.Copy)]
        NSNumber FlushInterval { get; set; }

        // @property (copy, nonatomic) NSNumber * _Nullable pollingInterval;
        [NullAllowed, Export("pollingInterval", ArgumentSemantic.Copy)]
        NSNumber PollingInterval { get; set; }

        // @property (copy, nonatomic) NSNumber * _Nullable backgroundFetchInterval;
        [NullAllowed, Export("backgroundFetchInterval", ArgumentSemantic.Copy)]
        NSNumber BackgroundFetchInterval { get; set; }

        // @property (nonatomic) BOOL streaming;
        [Export("streaming")]
        bool Streaming { get; set; }

        // @property (nonatomic) BOOL debugEnabled;
        [Export("debugEnabled")]
        bool DebugEnabled { get; set; }

        // -(instancetype _Nonnull)initWithMobileKey:(NSString * _Nonnull)mobileKey __attribute__((objc_designated_initializer));
        [Export("initWithMobileKey:")]
        [DesignatedInitializer]
        IntPtr Constructor(string mobileKey);
    }

    // @interface LDConfigBuilder : NSObject
    [BaseType(typeof(NSObject))]
    interface LDConfigBuilder
    {
        // @property (nonatomic, strong) LDConfig * _Nonnull config;
        [Export("config", ArgumentSemantic.Strong)]
        LDConfig Config { get; set; }

        // -(LDConfigBuilder * _Nonnull)withMobileKey:(NSString * _Nonnull)mobileKey __attribute__((deprecated("Use `setMobileKey:` on an LDConfig object")));
        [Export("withMobileKey:")]
        LDConfigBuilder WithMobileKey(string mobileKey);

        // -(LDConfigBuilder * _Nonnull)withBaseUrl:(NSString * _Nullable)baseUrl __attribute__((deprecated("Use `setBaseUrl:` on an LDConfig object")));
        [Export("withBaseUrl:")]
        LDConfigBuilder WithBaseUrl([NullAllowed] string baseUrl);

        // -(LDConfigBuilder * _Nonnull)withEventsUrl:(NSString * _Nullable)eventsUrl __attribute__((deprecated("Use `setEventsUrl:` on an LDConfig object")));
        [Export("withEventsUrl:")]
        LDConfigBuilder WithEventsUrl([NullAllowed] string eventsUrl);

        // -(LDConfigBuilder * _Nonnull)withCapacity:(int)capacity __attribute__((deprecated("Use `setCapacity:` on an LDConfig object")));
        [Export("withCapacity:")]
        LDConfigBuilder WithCapacity(int capacity);

        // -(LDConfigBuilder * _Nonnull)withConnectionTimeout:(int)connectionTimeout __attribute__((deprecated("Use `setConnectionTimeout:` on an LDConfig object")));
        [Export("withConnectionTimeout:")]
        LDConfigBuilder WithConnectionTimeout(int connectionTimeout);

        // -(LDConfigBuilder * _Nonnull)withFlushInterval:(int)flushInterval __attribute__((deprecated("Use `setFlushInterval:` on an LDConfig object")));
        [Export("withFlushInterval:")]
        LDConfigBuilder WithFlushInterval(int flushInterval);

        // -(LDConfigBuilder * _Nonnull)withPollingInterval:(int)pollingInterval __attribute__((deprecated("Use `setPollingInterval:` on an LDConfig object")));
        [Export("withPollingInterval:")]
        LDConfigBuilder WithPollingInterval(int pollingInterval);

        // -(LDConfigBuilder * _Nonnull)withBackgroundFetchInterval:(int)backgroundFetchInterval __attribute__((deprecated("Use `setBackgroundFetchInterval:` on an LDConfig object")));
        [Export("withBackgroundFetchInterval:")]
        LDConfigBuilder WithBackgroundFetchInterval(int backgroundFetchInterval);

        // -(LDConfigBuilder * _Nonnull)withStreaming:(BOOL)streamingEnabled __attribute__((deprecated("Use `setStreaming:` on an LDConfig object")));
        [Export("withStreaming:")]
        LDConfigBuilder WithStreaming(bool streamingEnabled);

        // -(LDConfigBuilder * _Nonnull)withDebugEnabled:(BOOL)debugEnabled __attribute__((deprecated("Use `setDebugEnabled:` on an LDConfig object")));
        [Export("withDebugEnabled:")]
        LDConfigBuilder WithDebugEnabled(bool debugEnabled);

        // -(LDConfig * _Nonnull)build;
        [Export("build")]
        LDConfig Build { get; }
    }

    // @interface LDUserBuilder : NSObject
    [BaseType(typeof(NSObject))]
    interface LDUserBuilder
    {
        // @property (copy, nonatomic) NSString * _Nullable key;
        [NullAllowed, Export("key")]
        string Key { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable ip;
        [NullAllowed, Export("ip")]
        string Ip { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable country;
        [NullAllowed, Export("country")]
        string Country { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable name;
        [NullAllowed, Export("name")]
        string Name { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable firstName;
        [NullAllowed, Export("firstName")]
        string FirstName { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable lastName;
        [NullAllowed, Export("lastName")]
        string LastName { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable email;
        [NullAllowed, Export("email")]
        string Email { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable avatar;
        [NullAllowed, Export("avatar")]
        string Avatar { get; set; }

        // @property (nonatomic, strong) NSMutableDictionary * _Nullable customDictionary;
        [NullAllowed, Export("customDictionary", ArgumentSemantic.Strong)]
        NSMutableDictionary CustomDictionary { get; set; }

        // @property (nonatomic) BOOL isAnonymous;
        [Export("isAnonymous")]
        bool IsAnonymous { get; set; }

        // -(void)customString:(NSString * _Nonnull)inputKey value:(NSString * _Nonnull)value;
        [Export("customString:value:")]
        void CustomString(string inputKey, string value);

        // -(void)customBool:(NSString * _Nonnull)inputKey value:(BOOL)value;
        [Export("customBool:value:")]
        void CustomBool(string inputKey, bool value);

        // -(void)customNumber:(NSString * _Nonnull)inputKey value:(NSNumber * _Nonnull)value;
        [Export("customNumber:value:")]
        void CustomNumber(string inputKey, NSNumber value);

        // -(void)customArray:(NSString * _Nonnull)inputKey value:(NSArray * _Nonnull)value;
        [Export("customArray:value:")]
        void CustomArray(string inputKey, NSObject[] value);

        // -(LDUserModel * _Nonnull)build;
        [Export("build")]
        LDUserModel Build { get; }

        // +(LDUserModel * _Nonnull)compareNewBuilder:(LDUserBuilder * _Nonnull)iBuilder withUser:(LDUserModel * _Nonnull)iUser;
        [Static]
        [Export("compareNewBuilder:withUser:")]
        LDUserModel CompareNewBuilder(LDUserBuilder iBuilder, LDUserModel iUser);

        // +(LDUserBuilder * _Nonnull)currentBuilder:(LDUserModel * _Nonnull)iUser;
        [Static]
        [Export("currentBuilder:")]
        LDUserBuilder CurrentBuilder(LDUserModel iUser);

        // +(LDUserBuilder * _Nonnull)retrieveCurrentBuilder:(LDUserModel * _Nonnull)iUser __attribute__((deprecated("User `currentBuilder:` instead")));
        [Static]
        [Export("retrieveCurrentBuilder:")]
        LDUserBuilder RetrieveCurrentBuilder(LDUserModel iUser);

        // -(LDUserBuilder * _Nonnull)withKey:(NSString * _Nonnull)key __attribute__((deprecated("Pass value directly to `key` instead")));
        [Export("withKey:")]
        LDUserBuilder WithKey(string key);

        // -(LDUserBuilder * _Nonnull)withIp:(NSString * _Nullable)ip __attribute__((deprecated("Pass value directly to `ip` instead")));
        [Export("withIp:")]
        LDUserBuilder WithIp([NullAllowed] string ip);

        // -(LDUserBuilder * _Nonnull)withCountry:(NSString * _Nullable)country __attribute__((deprecated("Pass value directly to `country` instead")));
        [Export("withCountry:")]
        LDUserBuilder WithCountry([NullAllowed] string country);

        // -(LDUserBuilder * _Nonnull)withName:(NSString * _Nullable)name __attribute__((deprecated("Pass value directly to `name` instead")));
        [Export("withName:")]
        LDUserBuilder WithName([NullAllowed] string name);

        // -(LDUserBuilder * _Nonnull)withFirstName:(NSString * _Nullable)firstName __attribute__((deprecated("Pass value directly to `firstName` instead")));
        [Export("withFirstName:")]
        LDUserBuilder WithFirstName([NullAllowed] string firstName);

        // -(LDUserBuilder * _Nonnull)withLastName:(NSString * _Nullable)lastName __attribute__((deprecated("Pass value directly to `lastName` instead")));
        [Export("withLastName:")]
        LDUserBuilder WithLastName([NullAllowed] string lastName);

        // -(LDUserBuilder * _Nonnull)withEmail:(NSString * _Nullable)email __attribute__((deprecated("Pass value directly to `email` instead")));
        [Export("withEmail:")]
        LDUserBuilder WithEmail([NullAllowed] string email);

        // -(LDUserBuilder * _Nonnull)withAvatar:(NSString * _Nullable)avatar __attribute__((deprecated("Pass value directly to `avatar` instead")));
        [Export("withAvatar:")]
        LDUserBuilder WithAvatar([NullAllowed] string avatar);

        // -(LDUserBuilder * _Nonnull)withCustomString:(NSString * _Nullable)inputKey value:(NSString * _Nullable)value __attribute__((deprecated("Use `customString:value` instead")));
        [Export("withCustomString:value:")]
        LDUserBuilder WithCustomString([NullAllowed] string inputKey, [NullAllowed] string value);

        // -(LDUserBuilder * _Nonnull)withCustomBool:(NSString * _Nullable)inputKey value:(BOOL)value __attribute__((deprecated("Use `customBool:value` instead")));
        [Export("withCustomBool:value:")]
        LDUserBuilder WithCustomBool([NullAllowed] string inputKey, bool value);

        // -(LDUserBuilder * _Nonnull)withCustomNumber:(NSString * _Nullable)inputKey value:(NSNumber * _Nullable)value __attribute__((deprecated("Use `customNumber:value` instead")));
        [Export("withCustomNumber:value:")]
        LDUserBuilder WithCustomNumber([NullAllowed] string inputKey, [NullAllowed] NSNumber value);

        // -(LDUserBuilder * _Nonnull)withCustomArray:(NSString * _Nullable)inputKey value:(NSArray * _Nullable)value __attribute__((deprecated("Use `customArray:value` instead")));
        [Export("withCustomArray:value:")]
        LDUserBuilder WithCustomArray([NullAllowed] string inputKey, [NullAllowed] NSObject[] value);

        // -(LDUserBuilder * _Nonnull)withCustomDictionary:(NSMutableDictionary * _Nullable)inputDictionary __attribute__((deprecated("Pass value directly to `customDictionary` instead")));
        [Export("withCustomDictionary:")]
        LDUserBuilder WithCustomDictionary([NullAllowed] NSMutableDictionary inputDictionary);

        // -(LDUserBuilder * _Nonnull)withAnonymous:(BOOL)anonymous __attribute__((deprecated("Pass value directly to `isAnonymous` instead")));
        [Export("withAnonymous:")]
        LDUserBuilder WithAnonymous(bool anonymous);
    }

    // @interface LDUtil : NSObject
    [BaseType(typeof(NSObject))]
    interface LDUtil
    {
        // +(void)assertThreadIsNotMain;
        [Static]
        [Export("assertThreadIsNotMain")]
        void AssertThreadIsNotMain();

        // +(NSInteger)getSystemVersionAsAnInteger;
        [Static]
        [Export("getSystemVersionAsAnInteger")]
        nint SystemVersionAsAnInteger { get; }

        // +(NSString *)getDeviceAsString;
        [Static]
        [Export("getDeviceAsString")]
        string DeviceAsString { get; }

        // +(NSString *)getSystemVersionAsString;
        [Static]
        [Export("getSystemVersionAsString")]
        string SystemVersionAsString { get; }

        // +(DarklyLogLevel)logLevel;
        // +(void)setLogLevel:(DarklyLogLevel)value;
        [Static]
        [Export("logLevel")]
        DarklyLogLevel LogLevel { get; set; }

        // +(NSString *)base64EncodeString:(NSString *)unencodedString;
        [Static]
        [Export("base64EncodeString:")]
        string Base64EncodeString(string unencodedString);

        // +(NSString *)base64DecodeString:(NSString *)encodedString;
        [Static]
        [Export("base64DecodeString:")]
        string Base64DecodeString(string encodedString);

        // +(NSString *)base64UrlEncodeString:(NSString *)unencodedString;
        [Static]
        [Export("base64UrlEncodeString:")]
        string Base64UrlEncodeString(string unencodedString);

        // +(NSString *)base64UrlDecodeString:(NSString *)encodedString;
        [Static]
        [Export("base64UrlDecodeString:")]
        string Base64UrlDecodeString(string encodedString);

        // +(void)throwException:(NSString *)name reason:(NSString *)reason;
        [Static]
        [Export("throwException:reason:")]
        void ThrowException(string name, string reason);
    }

    // @protocol ClientDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface ClientDelegate
    {
        // @optional -(void)userDidUpdate;
        [Export("userDidUpdate")]
        void UserDidUpdate();

        // @optional -(void)featureFlagDidUpdate:(NSString *)key;
        [Export("featureFlagDidUpdate:")]
        void FeatureFlagDidUpdate(string key);
    }

    // @interface LDClient : NSObject
    [BaseType(typeof(NSObject))]
    interface LDClient
    {
        // @property (readonly, nonatomic, strong) LDUserModel * ldUser;
        [Export("ldUser", ArgumentSemantic.Strong)]
        LDUserModel LdUser { get; }

        // @property (readonly, nonatomic, strong) LDConfig * ldConfig;
        [Export("ldConfig", ArgumentSemantic.Strong)]
        LDConfig LdConfig { get; }

        [Wrap("WeakDelegate")]
        ClientDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<ClientDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // +(LDClient *)sharedInstance;
        [Static]
        [Export("sharedInstance")]
        LDClient SharedInstance { get; }

        // -(BOOL)start:(LDConfigBuilder *)inputConfigBuilder userBuilder:(LDUserBuilder *)inputUserBuilder __attribute__((deprecated("Use start:withUserBuilder: instead")));
        [Export("start:userBuilder:")]
        bool Start(LDConfigBuilder inputConfigBuilder, LDUserBuilder inputUserBuilder);

        // -(BOOL)start:(LDConfig *)inputConfig withUserBuilder:(LDUserBuilder *)inputUserBuilder;
        [Export("start:withUserBuilder:")]
        bool Start(LDConfig inputConfig, LDUserBuilder inputUserBuilder);

        // -(BOOL)boolVariation:(NSString *)featureKey fallback:(BOOL)fallback;
        [Export("boolVariation:fallback:")]
        bool BoolVariation(string featureKey, bool fallback);

        // -(NSNumber *)numberVariation:(NSString *)featureKey fallback:(NSNumber *)fallback;
        [Export("numberVariation:fallback:")]
        NSNumber NumberVariation(string featureKey, NSNumber fallback);

        // -(NSString *)stringVariation:(NSString *)featureKey fallback:(NSString *)fallback;
        [Export("stringVariation:fallback:")]
        string StringVariation(string featureKey, string fallback);

        // -(NSArray *)arrayVariation:(NSString *)featureKey fallback:(NSArray *)fallback;
        [Export("arrayVariation:fallback:")]
        NSObject[] ArrayVariation(string featureKey, NSObject[] fallback);

        // -(NSDictionary *)dictionaryVariation:(NSString *)featureKey fallback:(NSDictionary *)fallback;
        [Export("dictionaryVariation:fallback:")]
        NSDictionary DictionaryVariation(string featureKey, NSDictionary fallback);

        // -(BOOL)track:(NSString *)eventName data:(NSDictionary *)dataDictionary;
        [Export("track:data:")]
        bool Track(string eventName, NSDictionary dataDictionary);

        // -(BOOL)updateUser:(LDUserBuilder *)builder;
        [Export("updateUser:")]
        bool UpdateUser(LDUserBuilder builder);

        // -(LDUserBuilder *)currentUserBuilder;
        [Export("currentUserBuilder")]
        LDUserBuilder CurrentUserBuilder { get; }

        // -(BOOL)offline;
        [Export("offline")]
        bool Offline { get; }

        // -(BOOL)online;
        [Export("online")]
        bool Online { get; }

        // -(BOOL)flush;
        [Export("flush")]
        bool Flush { get; }

        // -(BOOL)stopClient;
        [Export("stopClient")]
        bool StopClient { get; }
    }

    // @interface LDFlagConfigModel : NSObject <NSCoding>
    [BaseType(typeof(NSObject))]
    interface LDFlagConfigModel : INSCoding
    {
        // @property (nonatomic, strong) NSDictionary * _Nullable featuresJsonDictionary;
        [NullAllowed, Export("featuresJsonDictionary", ArgumentSemantic.Strong)]
        NSDictionary FeaturesJsonDictionary { get; set; }

        // -(id _Nonnull)initWithDictionary:(NSDictionary * _Nonnull)dictionary;
        [Export("initWithDictionary:")]
        IntPtr Constructor(NSDictionary dictionary);

        // -(NSDictionary * _Nonnull)dictionaryValue;
        [Export("dictionaryValue")]
        NSDictionary DictionaryValue { get; }

        // -(NSObject * _Nonnull)configFlagValue:(NSString * _Nonnull)keyName;
        [Export("configFlagValue:")]
        NSObject ConfigFlagValue(string keyName);

        // -(BOOL)doesConfigFlagExist:(NSString * _Nonnull)keyName;
        [Export("doesConfigFlagExist:")]
        bool DoesConfigFlagExist(string keyName);

        // -(BOOL)isEqualToConfig:(LDFlagConfigModel * _Nullable)otherConfig;
        [Export("isEqualToConfig:")]
        bool IsEqualToConfig([NullAllowed] LDFlagConfigModel otherConfig);
    }

    // @protocol RequestManagerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface RequestManagerDelegate
    {
        // @required -(void)processedEvents:(BOOL)success jsonEventArray:(NSArray *)jsonEventArray;
        [Abstract]
        [Export("processedEvents:jsonEventArray:")]
        void ProcessedEvents(bool success, NSObject[] jsonEventArray);

        // @required -(void)processedConfig:(BOOL)success jsonConfigDictionary:(NSDictionary *)jsonConfigDictionary;
        [Abstract]
        [Export("processedConfig:jsonConfigDictionary:")]
        void ProcessedConfig(bool success, NSDictionary jsonConfigDictionary);
    }

    // @interface LDRequestManager : NSObject
    [BaseType(typeof(NSObject))]
    interface LDRequestManager
    {
        // @property (nonatomic) NSString * mobileKey;
        [Export("mobileKey")]
        string MobileKey { get; set; }

        // @property (nonatomic) NSString * baseUrl;
        [Export("baseUrl")]
        string BaseUrl { get; set; }

        // @property (nonatomic) NSString * eventsUrl;
        [Export("eventsUrl")]
        string EventsUrl { get; set; }

        // @property (nonatomic) NSTimeInterval connectionTimeout;
        [Export("connectionTimeout")]
        double ConnectionTimeout { get; set; }

        [Wrap("WeakDelegate")]
        RequestManagerDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<RequestManagerDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // +(LDRequestManager *)sharedInstance;
        [Static]
        [Export("sharedInstance")]
        LDRequestManager SharedInstance { get; }

        // -(void)performFeatureFlagRequest:(NSString *)encodedUser;
        [Export("performFeatureFlagRequest:")]
        void PerformFeatureFlagRequest(string encodedUser);

        // -(void)performEventRequest:(NSArray *)jsonEventArray;
        [Export("performEventRequest:")]
        void PerformEventRequest(NSObject[] jsonEventArray);
    }

    // @interface LDClientManager : NSObject <RequestManagerDelegate, UIApplicationDelegate>
    [BaseType(typeof(NSObject))]
    interface LDClientManager : IRequestManagerDelegate, IUIApplicationDelegate
    {
        // @property (nonatomic) BOOL offlineEnabled;
        [Export("offlineEnabled")]
        bool OfflineEnabled { get; set; }

        // +(LDClientManager *)sharedInstance;
        [Static]
        [Export("sharedInstance")]
        LDClientManager SharedInstance { get; }

        // -(void)syncWithServerForEvents;
        [Export("syncWithServerForEvents")]
        void SyncWithServerForEvents();

        // -(void)syncWithServerForConfig;
        [Export("syncWithServerForConfig")]
        void SyncWithServerForConfig();

        // -(void)processedEvents:(BOOL)success jsonEventArray:(NSArray *)jsonEventArray;
        [Export("processedEvents:jsonEventArray:")]
        void ProcessedEvents(bool success, NSObject[] jsonEventArray);

        // -(void)processedConfig:(BOOL)success jsonConfigDictionary:(NSDictionary *)jsonConfigDictionary;
        [Export("processedConfig:jsonConfigDictionary:")]
        void ProcessedConfig(bool success, NSDictionary jsonConfigDictionary);

        // -(void)startPolling;
        [Export("startPolling")]
        void StartPolling();

        // -(void)stopPolling;
        [Export("stopPolling")]
        void StopPolling();

        // -(void)willEnterBackground;
        [Export("willEnterBackground")]
        void WillEnterBackground();

        // -(void)willEnterForeground;
        [Export("willEnterForeground")]
        void WillEnterForeground();

        // -(void)flushEvents;
        [Export("flushEvents")]
        void FlushEvents();
    }

    // @interface LDEventModel : NSObject <NSCoding>
    [BaseType(typeof(NSObject))]
    interface LDEventModel : INSCoding
    {
        // @property (nonatomic, strong) NSString * _Nullable key;
        [NullAllowed, Export("key", ArgumentSemantic.Strong)]
        string Key { get; set; }

        // @property (nonatomic, strong) NSString * _Nullable kind;
        [NullAllowed, Export("kind", ArgumentSemantic.Strong)]
        string Kind { get; set; }

        // @property (assign, atomic) NSInteger creationDate;
        [Export("creationDate")]
        nint CreationDate { get; set; }

        // @property (nonatomic, strong) NSDictionary * _Nullable data;
        [NullAllowed, Export("data", ArgumentSemantic.Strong)]
        NSDictionary Data { get; set; }

        // @property (nonatomic, strong) LDUserModel * _Nullable user;
        [NullAllowed, Export("user", ArgumentSemantic.Strong)]
        LDUserModel User { get; set; }

        // @property (nonatomic, strong) NSObject * _Nonnull value;
        [Export("value", ArgumentSemantic.Strong)]
        NSObject Value { get; set; }

        // @property (nonatomic, strong) NSObject * _Nonnull isDefault;
        [Export("isDefault", ArgumentSemantic.Strong)]
        NSObject IsDefault { get; set; }

        // -(id _Nonnull)initWithDictionary:(NSDictionary * _Nonnull)dictionary;
        [Export("initWithDictionary:")]
        IntPtr Constructor(NSDictionary dictionary);

        // -(NSDictionary * _Nonnull)dictionaryValue;
        [Export("dictionaryValue")]
        NSDictionary DictionaryValue { get; }

        // -(instancetype _Nonnull)initFeatureEventWithKey:(NSString * _Nonnull)featureKey keyValue:(NSObject * _Nullable)keyValue defaultKeyValue:(NSObject * _Nullable)defaultKeyValue userValue:(LDUserModel * _Nonnull)userValue;
        [Export("initFeatureEventWithKey:keyValue:defaultKeyValue:userValue:")]
        IntPtr Constructor(string featureKey, [NullAllowed] NSObject keyValue, [NullAllowed] NSObject defaultKeyValue, LDUserModel userValue);

        // -(instancetype _Nonnull)initCustomEventWithKey:(NSString * _Nonnull)featureKey andDataDictionary:(NSDictionary * _Nonnull)customData userValue:(LDUserModel * _Nonnull)userValue;
        [Export("initCustomEventWithKey:andDataDictionary:userValue:")]
        IntPtr Constructor(string featureKey, NSDictionary customData, LDUserModel userValue);
    }

    // @interface LDPollingManager : NSObject
    [BaseType(typeof(NSObject))]
    interface LDPollingManager
    {
        // +(id)sharedInstance;
        [Static]
        [Export("sharedInstance")]
        NSObject SharedInstance { get; }

        // @property (assign, atomic) PollingState configPollingState;
        [Export("configPollingState", ArgumentSemantic.Assign)]
        PollingState ConfigPollingState { get; set; }

        // @property (assign, atomic) PollingState eventPollingState;
        [Export("eventPollingState", ArgumentSemantic.Assign)]
        PollingState EventPollingState { get; set; }

        // @property (nonatomic, strong) dispatch_source_t configTimer;
        [Export("configTimer", ArgumentSemantic.Strong)]
        DispatchTime ConfigTimer { get; set; }

        // @property (nonatomic) NSTimeInterval configPollingIntervalMillis;
        [Export("configPollingIntervalMillis")]
        double ConfigPollingIntervalMillis { get; set; }

        // @property (nonatomic, strong) dispatch_source_t eventTimer;
        [Export("eventTimer", ArgumentSemantic.Strong)]
        DispatchTime EventTimer { get; set; }

        // @property (nonatomic) NSTimeInterval eventPollingIntervalMillis;
        [Export("eventPollingIntervalMillis")]
        double EventPollingIntervalMillis { get; set; }

        // -(void)startConfigPolling;
        [Export("startConfigPolling")]
        void StartConfigPolling();

        // -(void)pauseConfigPolling;
        [Export("pauseConfigPolling")]
        void PauseConfigPolling();

        // -(void)suspendConfigPolling;
        [Export("suspendConfigPolling")]
        void SuspendConfigPolling();

        // -(void)resumeConfigPolling;
        [Export("resumeConfigPolling")]
        void ResumeConfigPolling();

        // -(void)stopConfigPolling;
        [Export("stopConfigPolling")]
        void StopConfigPolling();

        // -(void)startEventPolling;
        [Export("startEventPolling")]
        void StartEventPolling();

        // -(void)pauseEventPolling;
        [Export("pauseEventPolling")]
        void PauseEventPolling();

        // -(void)suspendEventPolling;
        [Export("suspendEventPolling")]
        void SuspendEventPolling();

        // -(void)resumeEventPolling;
        [Export("resumeEventPolling")]
        void ResumeEventPolling();

        // -(void)stopEventPolling;
        [Export("stopEventPolling")]
        void StopEventPolling();
    }

    // @interface BVJSONString (NSDictionary)
    [Category]
    [BaseType(typeof(NSDictionary))]
    interface NSDictionary_BVJSONString
    {
        // -(NSString *)ld_jsonString;
        [Export("ld_jsonString")]
        string Ld_jsonString();
    }

    // @interface NullRemovable (NSMutableDictionary)
    [Category]
    [BaseType(typeof(NSMutableDictionary))]
    interface NSMutableDictionary_NullRemovable
    {
        // -(NSMutableDictionary *)removeNullValues;
        [Export("removeNullValues")]
        NSMutableDictionary RemoveNullValues();
    }

    // @interface RemoveWhitespace (NSString)
    [Category]
    [BaseType(typeof(NSString))]
    interface NSString_RemoveWhitespace
    {

        // -(NSString *)stringByRemovingWhitespace;
        [Export("stringByRemovingWhitespace")]
        string StringByRemovingWhitespace();
    }

    [Static]
    partial interface Constants
    {
        // extern const int kUserCacheSize;
        [Field("kUserCacheSize", "__Internal")]
        int kUserCacheSize { get; }

        // extern NSString *const kClientVersion;
        [Field("kClientVersion", "__Internal")]
        NSString kClientVersion { get; }

        // extern NSString *const kBaseUrl;
        [Field("kBaseUrl", "__Internal")]
        NSString kBaseUrl { get; }

        // extern NSString *const kEventsUrl;
        [Field("kEventsUrl", "__Internal")]
        NSString kEventsUrl { get; }

        // extern NSString *const kStreamUrl;
        [Field("kStreamUrl", "__Internal")]
        NSString kStreamUrl { get; }

        // extern NSString *const kNoMobileKeyExceptionName;
        [Field("kNoMobileKeyExceptionName", "__Internal")]
        NSString kNoMobileKeyExceptionName { get; }

        // extern NSString *const kNoMobileKeyExceptionReason;
        [Field("kNoMobileKeyExceptionReason", "__Internal")]
        NSString kNoMobileKeyExceptionReason { get; }

        // extern NSString *const kNilConfigExceptionName;
        [Field("kNilConfigExceptionName", "__Internal")]
        NSString kNilConfigExceptionName { get; }

        // extern NSString *const kNilConfigExceptionReason;
        [Field("kNilConfigExceptionReason", "__Internal")]
        NSString kNilConfigExceptionReason { get; }

        // extern NSString *const kClientNotStartedExceptionName;
        [Field("kClientNotStartedExceptionName", "__Internal")]
        NSString kClientNotStartedExceptionName { get; }

        // extern NSString *const kClientNotStartedExceptionReason;
        [Field("kClientNotStartedExceptionReason", "__Internal")]
        NSString kClientNotStartedExceptionReason { get; }

        // extern NSString *const kClientAlreadyStartedExceptionName;
        [Field("kClientAlreadyStartedExceptionName", "__Internal")]
        NSString kClientAlreadyStartedExceptionName { get; }

        // extern NSString *const kClientAlreadyStartedExceptionReason;
        [Field("kClientAlreadyStartedExceptionReason", "__Internal")]
        NSString kClientAlreadyStartedExceptionReason { get; }

        // extern NSString *const kIphone;
        [Field("kIphone", "__Internal")]
        NSString kIphone { get; }

        // extern NSString *const kIpad;
        [Field("kIpad", "__Internal")]
        NSString kIpad { get; }

        // extern NSString *const kAppleWatch;
        [Field("kAppleWatch", "__Internal")]
        NSString kAppleWatch { get; }

        // extern NSString *const kAppleTV;
        [Field("kAppleTV", "__Internal")]
        NSString kAppleTV { get; }

        // extern NSString *const kMacOS;
        [Field("kMacOS", "__Internal")]
        NSString kMacOS { get; }

        // extern NSString *const kUserDictionaryStorageKey;
        [Field("kUserDictionaryStorageKey", "__Internal")]
        NSString kUserDictionaryStorageKey { get; }

        // extern NSString *const kDeviceIdentifierKey;
        [Field("kDeviceIdentifierKey", "__Internal")]
        NSString kDeviceIdentifierKey { get; }

        // extern NSString *const kLDUserUpdatedNotification;
        [Field("kLDUserUpdatedNotification", "__Internal")]
        NSString kLDUserUpdatedNotification { get; }

        // extern NSString *const kLDFlagConfigChangedNotification;
        [Field("kLDFlagConfigChangedNotification", "__Internal")]
        NSString kLDFlagConfigChangedNotification { get; }

        // extern NSString *const kLDBackgroundFetchInitiated;
        [Field("kLDBackgroundFetchInitiated", "__Internal")]
        NSString kLDBackgroundFetchInitiated { get; }

        // extern const int kCapacity;
        [Field("kCapacity", "__Internal")]
        int kCapacity { get; }

        // extern const int kConnectionTimeout;
        [Field("kConnectionTimeout", "__Internal")]
        int kConnectionTimeout { get; }

        // extern const int kDefaultFlushInterval;
        [Field("kDefaultFlushInterval", "__Internal")]
        int kDefaultFlushInterval { get; }

        // extern const int kMinimumFlushIntervalMillis;
        [Field("kMinimumFlushIntervalMillis", "__Internal")]
        int kMinimumFlushIntervalMillis { get; }

        // extern const int kDefaultPollingInterval;
        [Field("kDefaultPollingInterval", "__Internal")]
        int kDefaultPollingInterval { get; }

        // extern const int kMinimumPollingInterval;
        [Field("kMinimumPollingInterval", "__Internal")]
        int kMinimumPollingInterval { get; }

        // extern const int kDefaultBackgroundFetchInterval;
        [Field("kDefaultBackgroundFetchInterval", "__Internal")]
        int kDefaultBackgroundFetchInterval { get; }

        // extern const int kMinimumBackgroundFetchInterval;
        [Field("kMinimumBackgroundFetchInterval", "__Internal")]
        int kMinimumBackgroundFetchInterval { get; }

        // extern const int kMillisInSecs;
        [Field("kMillisInSecs", "__Internal")]
        int kMillisInSecs { get; }

        // extern NSString *const _Nullable kFeaturesJsonDictionaryKey;
        [Field("kFeaturesJsonDictionaryKey", "__Internal")]
        [NullAllowed]
        NSString kFeaturesJsonDictionaryKey { get; }

        // extern NSString *const kHeaderMobileKey;
        [Field("kHeaderMobileKey", "__Internal")]
        NSString kHeaderMobileKey { get; }

        // extern double LaunchDarklyVersionNumber;
        [Field("LaunchDarklyVersionNumber", "__Internal")]
        double LaunchDarklyVersionNumber { get; }

        // extern const unsigned char [] LaunchDarklyVersionString;
        [Field("LaunchDarklyVersionString", "__Internal")]
        NSString LaunchDarklyVersionString { get; }

        // extern NSString *const MessageEvent;
        [Field("MessageEvent", "__Internal")]
        NSString MessageEvent { get; }

        // extern NSString *const ErrorEvent;
        [Field("ErrorEvent", "__Internal")]
        NSString ErrorEvent { get; }

        // extern NSString *const OpenEvent;
        [Field("OpenEvent", "__Internal")]
        NSString OpenEvent { get; }

        // extern NSString *const ReadyStateEvent;
        [Field("ReadyStateEvent", "__Internal")]
        NSString ReadyStateEvent { get; }

        // extern double DarklyEventSourceVersionNumber;
        [Field("DarklyEventSourceVersionNumber", "__Internal")]
        double DarklyEventSourceVersionNumber { get; }

        // extern const unsigned char [] DarklyEventSourceVersionString;
        [Field("DarklyEventSourceVersionString", "__Internal")]
        NSString DarklyEventSourceVersionString { get; }
    }
    // @interface LDEvent : NSObject
    [BaseType(typeof(NSObject))]
    interface LDEvent
    {
        // @property (nonatomic, strong) id id;
        [Export("id", ArgumentSemantic.Strong)]
        NSObject Id { get; set; }

        // @property (nonatomic, strong) NSString * event;
        [Export("event", ArgumentSemantic.Strong)]
        string Event { get; set; }

        // @property (nonatomic, strong) NSString * data;
        [Export("data", ArgumentSemantic.Strong)]
        string Data { get; set; }

        // @property (assign, nonatomic) LDEventState readyState;
        [Export("readyState", ArgumentSemantic.Assign)]
        LDEventState ReadyState { get; set; }

        // @property (nonatomic, strong) NSError * error;
        [Export("error", ArgumentSemantic.Strong)]
        NSError Error { get; set; }
    }

    // typedef void (^LDEventSourceEventHandler)(LDEvent *);
    delegate void LDEventSourceEventHandler(LDEvent arg0);

    // @interface LDEventSource : NSObject
    [BaseType(typeof(NSObject))]
    interface LDEventSource
    {
        // +(instancetype)eventSourceWithURL:(NSURL *)URL httpHeaders:(NSDictionary<NSString *,NSString *> *)headers;
        [Static]
        [Export("eventSourceWithURL:httpHeaders:")]
        LDEventSource EventSourceWithURL(NSUrl URL, NSDictionary<NSString, NSString> headers);

        // +(instancetype)eventSourceWithURL:(NSURL *)URL httpHeaders:(NSDictionary<NSString *,NSString *> *)headers timeoutInterval:(NSTimeInterval)timeoutInterval;
        [Static]
        [Export("eventSourceWithURL:httpHeaders:timeoutInterval:")]
        LDEventSource EventSourceWithURL(NSUrl URL, NSDictionary<NSString, NSString> headers, double timeoutInterval);

        // -(instancetype)initWithURL:(NSURL *)URL httpHeaders:(NSDictionary<NSString *,NSString *> *)headers;
        [Export("initWithURL:httpHeaders:")]
        IntPtr Constructor(NSUrl URL, NSDictionary<NSString, NSString> headers);

        // -(instancetype)initWithURL:(NSURL *)URL httpHeaders:(NSDictionary<NSString *,NSString *> *)headers timeoutInterval:(NSTimeInterval)timeoutInterval;
        [Export("initWithURL:httpHeaders:timeoutInterval:")]
        IntPtr Constructor(NSUrl URL, NSDictionary<NSString, NSString> headers, double timeoutInterval);

        // -(void)onMessage:(LDEventSourceEventHandler)handler;
        [Export("onMessage:")]
        void OnMessage(LDEventSourceEventHandler handler);

        // -(void)onError:(LDEventSourceEventHandler)handler;
        [Export("onError:")]
        void OnError(LDEventSourceEventHandler handler);

        // -(void)onOpen:(LDEventSourceEventHandler)handler;
        [Export("onOpen:")]
        void OnOpen(LDEventSourceEventHandler handler);

        // -(void)onReadyStateChanged:(LDEventSourceEventHandler)handler;
        [Export("onReadyStateChanged:")]
        void OnReadyStateChanged(LDEventSourceEventHandler handler);

        // -(void)addEventListener:(NSString *)eventName handler:(LDEventSourceEventHandler)handler;
        [Export("addEventListener:handler:")]
        void AddEventListener(string eventName, LDEventSourceEventHandler handler);

        // -(void)close;
        [Export("close")]
        void Close();
    }
}
