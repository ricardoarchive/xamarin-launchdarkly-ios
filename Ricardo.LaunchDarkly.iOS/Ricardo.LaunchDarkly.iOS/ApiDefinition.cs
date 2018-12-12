using System;
using CoreFoundation;
using Foundation;
using ObjCRuntime;

namespace Ricardo.LaunchDarkly.iOS
{
    partial interface ILDClientInterface { }
    partial interface IRequestManagerDelegate { }

    // @interface LDConfig : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface LDConfig
    {
        // @property (readonly, nonatomic) NSString * _Nonnull mobileKey;
        [Export("mobileKey")]
        string MobileKey { get; }

        // @property (nonatomic, strong) NSDictionary<NSString *,NSString *> * _Nullable secondaryMobileKeys;
        [NullAllowed, Export("secondaryMobileKeys", ArgumentSemantic.Strong)]
        NSDictionary<NSString, NSString> SecondaryMobileKeys { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable baseUrl;
        [NullAllowed, Export("baseUrl")]
        string BaseUrl { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable eventsUrl;
        [NullAllowed, Export("eventsUrl")]
        string EventsUrl { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable streamUrl;
        [NullAllowed, Export("streamUrl")]
        string StreamUrl { get; set; }

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

        // @property (nonatomic, strong) NSArray<NSString *> * _Nullable privateUserAttributes;
        [NullAllowed, Export("privateUserAttributes", ArgumentSemantic.Strong)]
        string[] PrivateUserAttributes { get; set; }

        // @property (assign, nonatomic) BOOL allUserAttributesPrivate;
        [Export("allUserAttributesPrivate")]
        bool AllUserAttributesPrivate { get; set; }

        // @property (assign, nonatomic) BOOL useReport;
        [Export("useReport")]
        bool UseReport { get; set; }

        // @property (assign, nonatomic) BOOL inlineUserInEvents;
        [Export("inlineUserInEvents")]
        bool InlineUserInEvents { get; set; }

        // @property (nonatomic) BOOL debugEnabled;
        [Export("debugEnabled")]
        bool DebugEnabled { get; set; }

        // -(instancetype _Nonnull)initWithMobileKey:(NSString * _Nonnull)mobileKey __attribute__((objc_designated_initializer));
        [Export("initWithMobileKey:")]
        [DesignatedInitializer]
        IntPtr Constructor(string mobileKey);

        // -(BOOL)isFlagRetryStatusCode:(NSInteger)statusCode;
        [Export("isFlagRetryStatusCode:")]
        bool IsFlagRetryStatusCode(nint statusCode);

        // -(NSString *)secondaryMobileKeysDescription;
        [Export("secondaryMobileKeysDescription")]
        string SecondaryMobileKeysDescription { get; }
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

        // @property (nonatomic, strong) NSArray<NSString *> * _Nullable privateAttributes;
        [NullAllowed, Export("privateAttributes", ArgumentSemantic.Strong)]
        string[] PrivateAttributes { get; set; }

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

        // +(LDUserBuilder * _Nonnull)currentBuilder:(LDUserModel * _Nonnull)iUser;
        [Static]
        [Export("currentBuilder:")]
        LDUserBuilder CurrentBuilder(LDUserModel iUser);

        // +(LDUserBuilder * _Nonnull)retrieveCurrentBuilder:(LDUserModel * _Nonnull)iUser __attribute__((deprecated("Use `currentBuilder:` instead")));
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

    // @protocol LDClientInterface <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface LDClientInterface
    {
        // @required @property (readonly, copy, nonatomic) NSString * environmentName;
        [Abstract]
        [Export("environmentName")]
        string EnvironmentName { get; }

        [Wrap("WeakDelegate")]
        ClientDelegate Delegate { get; set; }

        // @required @property (nonatomic, weak) id<ClientDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @required @property (readonly, nonatomic, strong) NSDictionary<NSString *,id> * allFlags;
        [Abstract]
        [Export("allFlags", ArgumentSemantic.Strong)]
        NSDictionary<NSString, NSObject> AllFlags { get; }

        // @required -(BOOL)boolVariation:(NSString *)featureKey fallback:(BOOL)fallback;
        [Abstract]
        [Export("boolVariation:fallback:")]
        bool BoolVariation(string featureKey, bool fallback);

        // @required -(NSNumber *)numberVariation:(NSString *)featureKey fallback:(NSNumber *)fallback;
        [Abstract]
        [Export("numberVariation:fallback:")]
        NSNumber NumberVariation(string featureKey, NSNumber fallback);

        // @required -(double)doubleVariation:(NSString *)featureKey fallback:(double)fallback;
        [Abstract]
        [Export("doubleVariation:fallback:")]
        double DoubleVariation(string featureKey, double fallback);

        // @required -(NSString *)stringVariation:(NSString *)featureKey fallback:(NSString *)fallback;
        [Abstract]
        [Export("stringVariation:fallback:")]
        string StringVariation(string featureKey, string fallback);

        // @required -(NSArray *)arrayVariation:(NSString *)featureKey fallback:(NSArray *)fallback;
        [Abstract]
        [Export("arrayVariation:fallback:")]
        NSObject[] ArrayVariation(string featureKey, NSObject[] fallback);

        // @required -(NSDictionary *)dictionaryVariation:(NSString *)featureKey fallback:(NSDictionary *)fallback;
        [Abstract]
        [Export("dictionaryVariation:fallback:")]
        NSDictionary DictionaryVariation(string featureKey, NSDictionary fallback);

        // @required -(BOOL)track:(NSString *)eventName data:(NSDictionary *)dataDictionary;
        [Abstract]
        [Export("track:data:")]
        bool Track(string eventName, NSDictionary dataDictionary);
    }

    // @protocol ClientDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface ClientDelegate
    {
        // @optional -(void)userDidUpdate;
        [Export("userDidUpdate")]
        void UserDidUpdate();

        // @optional -(void)userUnchanged;
        [Export("userUnchanged")]
        void UserUnchanged();

        // @optional -(void)featureFlagDidUpdate:(NSString *)key;
        [Export("featureFlagDidUpdate:")]
        void FeatureFlagDidUpdate(string key);

        // @optional -(void)serverConnectionUnavailable;
        [Export("serverConnectionUnavailable")]
        void ServerConnectionUnavailable();
    }

    // @interface LDClient : NSObject <LDClientInterface>
    [BaseType(typeof(NSObject))]
    interface LDClient : ILDClientInterface
    {
        // @property (readonly, assign, nonatomic) BOOL isOnline;
        [Export("isOnline")]
        bool IsOnline { get; }

        // @property (readonly, nonatomic, strong) LDUserModel * ldUser;
        [Export("ldUser", ArgumentSemantic.Strong)]
        LDUserModel LdUser { get; }

        // @property (readonly, nonatomic, strong) LDConfig * ldConfig;
        [Export("ldConfig", ArgumentSemantic.Strong)]
        LDConfig LdConfig { get; }

        // @property (readonly, copy, nonatomic) NSString * environmentName;
        [Export("environmentName")]
        string EnvironmentName { get; }

        [Wrap("WeakDelegate")]
        ClientDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<ClientDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @property (readonly, nonatomic, strong) NSDictionary<NSString *,id> * allFlags;
        [Export("allFlags", ArgumentSemantic.Strong)]
        NSDictionary<NSString, NSObject> AllFlags { get; }

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

        // -(void)setOnline:(BOOL)goOnline;
        [Export("setOnline:")]
        void SetOnline(bool goOnline);

        // -(void)setOnline:(BOOL)goOnline completion:(void (^)(void))completion;
        [Export("setOnline:completion:")]
        void SetOnline(bool goOnline, Action completion);

        // -(BOOL)flush;
        [Export("flush")]
        bool Flush { get; }

        // -(BOOL)stopClient;
        [Export("stopClient")]
        bool StopClient { get; }

        // -(BOOL)boolVariation:(NSString *)featureKey fallback:(BOOL)fallback;
        [Export("boolVariation:fallback:")]
        bool BoolVariation(string featureKey, bool fallback);

        // -(NSNumber *)numberVariation:(NSString *)featureKey fallback:(NSNumber *)fallback;
        [Export("numberVariation:fallback:")]
        NSNumber NumberVariation(string featureKey, NSNumber fallback);

        // -(double)doubleVariation:(NSString *)featureKey fallback:(double)fallback;
        [Export("doubleVariation:fallback:")]
        double DoubleVariation(string featureKey, double fallback);

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

        // +(id<LDClientInterface>)environmentForMobileKeyNamed:(NSString *)name;
        [Static]
        [Export("environmentForMobileKeyNamed:")]
        LDClientInterface EnvironmentForMobileKeyNamed(string name);
    }

    [BaseType(typeof(NSObject))]
    interface LDEvent : INSCopying
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

        // +(instancetype)eventSourceWithURL:(NSURL *)URL httpHeaders:(NSDictionary<NSString *,NSString *> *)headers connectMethod:(NSString *)connectMethod connectBody:(NSData *)connectBody;
        [Static]
        [Export("eventSourceWithURL:httpHeaders:connectMethod:connectBody:")]
        LDEventSource EventSourceWithURL(NSUrl URL, NSDictionary<NSString, NSString> headers, string connectMethod, NSData connectBody);

        // +(instancetype)eventSourceWithURL:(NSURL *)URL httpHeaders:(NSDictionary<NSString *,NSString *> *)headers timeoutInterval:(NSTimeInterval)timeoutInterval connectMethod:(NSString *)connectMethod connectBody:(NSData *)connectBody;
        [Static]
        [Export("eventSourceWithURL:httpHeaders:timeoutInterval:connectMethod:connectBody:")]
        LDEventSource EventSourceWithURL(NSUrl URL, NSDictionary<NSString, NSString> headers, double timeoutInterval, string connectMethod, NSData connectBody);

        // -(instancetype)initWithURL:(NSURL *)URL httpHeaders:(NSDictionary<NSString *,NSString *> *)headers;
        [Export("initWithURL:httpHeaders:")]
        IntPtr Constructor(NSUrl URL, NSDictionary<NSString, NSString> headers);

        // -(instancetype)initWithURL:(NSURL *)URL httpHeaders:(NSDictionary<NSString *,NSString *> *)headers connectMethod:(NSString *)connectMethod connectBody:(NSData *)connectBody;
        [Export("initWithURL:httpHeaders:connectMethod:connectBody:")]
        IntPtr Constructor(NSUrl URL, NSDictionary<NSString, NSString> headers, string connectMethod, NSData connectBody);

        // -(instancetype)initWithURL:(NSURL *)URL httpHeaders:(NSDictionary<NSString *,NSString *> *)headers timeoutInterval:(NSTimeInterval)timeoutInterval connectMethod:(NSString *)connectMethod connectBody:(NSData *)connectBody;
        [Export("initWithURL:httpHeaders:timeoutInterval:connectMethod:connectBody:")]
        IntPtr Constructor(NSUrl URL, NSDictionary<NSString, NSString> headers, double timeoutInterval, string connectMethod, NSData connectBody);

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

    // @interface LaunchDarkly (LDConfig)
    [Category]
    [BaseType(typeof(LDConfig))]
    interface LDConfig_LaunchDarkly
    {
        // @property (readonly, nonatomic, strong) NSArray<NSString *> * _Nonnull mobileKeys;
        [Export("mobileKeys", ArgumentSemantic.Strong)]
        string[] MobileKeys();
    }

    // @interface LDDataManager : NSObject
    [BaseType(typeof(NSObject))]
    interface LDDataManager
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull mobileKey;
        [Export("mobileKey")]
        string MobileKey { get; }

        // @property (readonly, nonatomic, strong) LDConfig * _Nonnull config;
        [Export("config", ArgumentSemantic.Strong)]
        LDConfig Config { get; }

        // @property (nonatomic, strong) NSDate * _Nullable lastEventResponseDate;
        [NullAllowed, Export("lastEventResponseDate", ArgumentSemantic.Strong)]
        NSDate LastEventResponseDate { get; set; }

        // +(instancetype _Nullable)dataManagerWithMobileKey:(NSString * _Nonnull)mobileKey config:(LDConfig * _Nonnull)config;
        [Static]
        [Export("dataManagerWithMobileKey:config:")]
        [return: NullAllowed]
        LDDataManager DataManagerWithMobileKey(string mobileKey, LDConfig config);

        // -(instancetype _Nullable)initWithMobileKey:(NSString * _Nonnull)mobileKey config:(LDConfig * _Nonnull)config;
        [Export("initWithMobileKey:config:")]
        IntPtr Constructor(string mobileKey, LDConfig config);

        // +(void)convertToEnvironmentBasedCacheForUser:(LDUserModel *)user config:(LDConfig *)config;
        [Static]
        [Export("convertToEnvironmentBasedCacheForUser:config:")]
        void ConvertToEnvironmentBasedCacheForUser(LDUserModel user, LDConfig config);

        // -(void)saveUser:(LDUserModel * _Nonnull)user;
        [Export("saveUser:")]
        void SaveUser(LDUserModel user);

        // -(LDUserModel * _Nullable)findUserWithKey:(NSString * _Nonnull)key;
        [Export("findUserWithKey:")]
        [return: NullAllowed]
        LDUserModel FindUserWithKey(string key);

        // -(LDFlagConfigModel * _Nullable)retrieveFlagConfigForUser:(LDUserModel * _Nonnull)user;
        [Export("retrieveFlagConfigForUser:")]
        [return: NullAllowed]
        LDFlagConfigModel RetrieveFlagConfigForUser(LDUserModel user);

        // -(void)allEventDictionaries:(void (^)(NSArray * _Nullable))completion;
        [Export("allEventDictionaries:")]
        void AllEventDictionaries(Action<NSArray> completion);

        // -(void)recordFlagEvaluationEventsWithFlagKey:(NSString * _Nonnull)flagKey reportedFlagValue:(id _Nonnull)reportedFlagValue flagConfigValue:(LDFlagConfigValue * _Nullable)flagConfigValue defaultFlagValue:(id _Nonnull)defaultFlagValue user:(LDUserModel * _Nonnull)user;
        [Export("recordFlagEvaluationEventsWithFlagKey:reportedFlagValue:flagConfigValue:defaultFlagValue:user:")]
        void RecordFlagEvaluationEventsWithFlagKey(string flagKey, NSObject reportedFlagValue, [NullAllowed] LDFlagConfigValue flagConfigValue, NSObject defaultFlagValue, LDUserModel user);

        // -(void)recordFeatureEventWithFlagKey:(NSString * _Nonnull)flagKey reportedFlagValue:(id _Nonnull)reportedFlagValue flagConfigValue:(LDFlagConfigValue * _Nullable)flagConfigValue defaultFlagValue:(id _Nonnull)defaultFlagValue user:(LDUserModel * _Nonnull)user;
        [Export("recordFeatureEventWithFlagKey:reportedFlagValue:flagConfigValue:defaultFlagValue:user:")]
        void RecordFeatureEventWithFlagKey(string flagKey, NSObject reportedFlagValue, [NullAllowed] LDFlagConfigValue flagConfigValue, NSObject defaultFlagValue, LDUserModel user);

        // -(void)recordCustomEventWithKey:(NSString * _Nonnull)eventKey customData:(NSDictionary * _Nullable)customData user:(LDUserModel * _Nonnull)user;
        [Export("recordCustomEventWithKey:customData:user:")]
        void RecordCustomEventWithKey(string eventKey, [NullAllowed] NSDictionary customData, LDUserModel user);

        // -(void)recordIdentifyEventWithUser:(LDUserModel * _Nonnull)user;
        [Export("recordIdentifyEventWithUser:")]
        void RecordIdentifyEventWithUser(LDUserModel user);

        // -(void)recordSummaryEventWithTracker:(LDFlagConfigTracker * _Nullable)tracker;
        [Export("recordSummaryEventWithTracker:")]
        void RecordSummaryEventWithTracker([NullAllowed] LDFlagConfigTracker tracker);

        // -(void)recordDebugEventWithFlagKey:(NSString * _Nonnull)flagKey reportedFlagValue:(id _Nonnull)reportedFlagValue flagConfigValue:(LDFlagConfigValue * _Nullable)flagConfigValue defaultFlagValue:(id _Nonnull)defaultFlagValue user:(LDUserModel * _Nonnull)user;
        [Export("recordDebugEventWithFlagKey:reportedFlagValue:flagConfigValue:defaultFlagValue:user:")]
        void RecordDebugEventWithFlagKey(string flagKey, NSObject reportedFlagValue, [NullAllowed] LDFlagConfigValue flagConfigValue, NSObject defaultFlagValue, LDUserModel user);

        // -(void)deleteProcessedEvents:(NSArray * _Nullable)processedJsonArray;
        [Export("deleteProcessedEvents:")]
        void DeleteProcessedEvents([NullAllowed] NSObject[] processedJsonArray);
    }

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

        // @property (nonatomic, strong) LDFlagConfigModel * _Nullable flagConfig;
        [NullAllowed, Export("flagConfig", ArgumentSemantic.Strong)]
        LDFlagConfigModel FlagConfig { get; set; }

        // @property (readonly, nonatomic, strong) LDFlagConfigTracker * _Nullable flagConfigTracker;
        [NullAllowed, Export("flagConfigTracker", ArgumentSemantic.Strong)]
        LDFlagConfigTracker FlagConfigTracker { get; }

        // @property (nonatomic, strong) NSArray<NSString *> * _Nullable privateAttributes;
        [NullAllowed, Export("privateAttributes", ArgumentSemantic.Strong)]
        string[] PrivateAttributes { get; set; }

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

        // -(NSDictionary * _Nonnull)dictionaryValueWithPrivateAttributesAndFlagConfig:(BOOL)includeFlags;
        [Export("dictionaryValueWithPrivateAttributesAndFlagConfig:")]
        NSDictionary DictionaryValueWithPrivateAttributesAndFlagConfig(bool includeFlags);

        // -(NSDictionary * _Nonnull)dictionaryValueWithFlagConfig:(BOOL)includeFlags includePrivateAttributes:(BOOL)includePrivate config:(LDConfig * _Nullable)config;
        [Export("dictionaryValueWithFlagConfig:includePrivateAttributes:config:")]
        NSDictionary DictionaryValueWithFlagConfig(bool includeFlags, bool includePrivate, [NullAllowed] LDConfig config);

        // +(NSArray<NSString *> * _Nonnull)allUserAttributes;
        [Static]
        [Export("allUserAttributes")]
        string[] AllUserAttributes { get; }

        // -(void)resetTracker;
        [Export("resetTracker")]
        void ResetTracker();

        // -(LDUserModel *)copy;
        [Export("copy")]
        LDUserModel Copy { get; }
    }

    // @interface LDEnvironment : NSObject <LDClientInterface>
    [BaseType(typeof(NSObject))]
    interface LDEnvironment : ILDClientInterface
    {
        // @property (readonly, copy, nonatomic) NSString * mobileKey;
        [Export("mobileKey")]
        string MobileKey { get; }

        // @property (readonly, nonatomic, strong) LDConfig * config;
        [Export("config", ArgumentSemantic.Strong)]
        LDConfig Config { get; }

        // @property (readonly, nonatomic, strong) LDUserModel * user;
        [Export("user", ArgumentSemantic.Strong)]
        LDUserModel User { get; }

        // @property (readonly, getter = isStarted, assign, nonatomic) BOOL start;
        [Export("start")]
        bool IsStarted { [Bind("isStarted")] get; }

        // @property (getter = isOnline, assign, nonatomic) BOOL online;
        [Export("online")]
        bool Online { [Bind("isOnline")] get; set; }

        [Wrap("WeakDelegate")]
        ClientDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<ClientDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @property (readonly, nonatomic, strong) NSDictionary<NSString *,id> * allFlags;
        [Export("allFlags", ArgumentSemantic.Strong)]
        NSDictionary<NSString, NSObject> AllFlags { get; }

        // @property (readonly, assign, nonatomic) BOOL isPrimary;
        [Export("isPrimary")]
        bool IsPrimary { get; }

        // @property (readonly, copy, nonatomic) NSString * environmentName;
        [Export("environmentName")]
        string EnvironmentName { get; }

        // +(instancetype)environmentForMobileKey:(NSString *)mobileKey config:(LDConfig *)config user:(LDUserModel *)user;
        [Static]
        [Export("environmentForMobileKey:config:user:")]
        LDEnvironment EnvironmentForMobileKey(string mobileKey, LDConfig config, LDUserModel user);

        // -(instancetype)initForMobileKey:(NSString *)mobileKey config:(LDConfig *)config user:(LDUserModel *)user;
        [Export("initForMobileKey:config:user:")]
        IntPtr Constructor(string mobileKey, LDConfig config, LDUserModel user);

        // -(void)start;
        [Export("start")]
        void Start();

        // -(void)stop;
        [Export("stop")]
        void Stop();

        // -(void)updateUser:(LDUserModel *)newUser;
        [Export("updateUser:")]
        void UpdateUser(LDUserModel newUser);

        // -(BOOL)boolVariation:(NSString *)featureKey fallback:(BOOL)fallback;
        [Export("boolVariation:fallback:")]
        bool BoolVariation(string featureKey, bool fallback);

        // -(NSNumber *)numberVariation:(NSString *)featureKey fallback:(NSNumber *)fallback;
        [Export("numberVariation:fallback:")]
        NSNumber NumberVariation(string featureKey, NSNumber fallback);

        // -(double)doubleVariation:(NSString *)featureKey fallback:(double)fallback;
        [Export("doubleVariation:fallback:")]
        double DoubleVariation(string featureKey, double fallback);

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

        // -(BOOL)flush;
        [Export("flush")]
        bool Flush { get; }
    }

    // @protocol RequestManagerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface RequestManagerDelegate
    {
        // @required -(void)processedEvents:(BOOL)success jsonEventArray:(NSArray * _Nonnull)jsonEventArray responseDate:(NSDate * _Nullable)responseDate;
        [Abstract]
        [Export("processedEvents:jsonEventArray:responseDate:")]
        void ProcessedEvents(bool success, NSObject[] jsonEventArray, [NullAllowed] NSDate responseDate);

        // @required -(void)processedConfig:(BOOL)success jsonConfigDictionary:(NSDictionary * _Nullable)jsonConfigDictionary;
        [Abstract]
        [Export("processedConfig:jsonConfigDictionary:")]
        void ProcessedConfig(bool success, [NullAllowed] NSDictionary jsonConfigDictionary);
    }

    // @interface LDRequestManager : NSObject
    [BaseType(typeof(NSObject))]
    interface LDRequestManager
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull mobileKey;
        [Export("mobileKey")]
        string MobileKey { get; }

        [Wrap("WeakDelegate")]
        [NullAllowed]
        RequestManagerDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<RequestManagerDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // +(instancetype _Nullable)requestManagerForMobileKey:(NSString * _Nonnull)mobileKey config:(LDConfig * _Nonnull)config delegate:(id<RequestManagerDelegate> _Nullable)delegate callbackQueue:(dispatch_queue_t _Nullable)callbackQueue;
        [Static]
        [Export("requestManagerForMobileKey:config:delegate:callbackQueue:")]
        [return: NullAllowed]
        LDRequestManager RequestManagerForMobileKey(string mobileKey, LDConfig config, [NullAllowed] RequestManagerDelegate @delegate, [NullAllowed] DispatchQueue callbackQueue);

        // -(instancetype _Nullable)initForMobileKey:(NSString * _Nonnull)mobileKey config:(LDConfig * _Nonnull)config delegate:(id<RequestManagerDelegate> _Nullable)delegate callbackQueue:(dispatch_queue_t _Nullable)callbackQueue;
        [Export("initForMobileKey:config:delegate:callbackQueue:")]
        IntPtr Constructor(string mobileKey, LDConfig config, [NullAllowed] RequestManagerDelegate @delegate, [NullAllowed] DispatchQueue callbackQueue);

        // -(void)performFeatureFlagRequest:(LDUserModel * _Nullable)user isOnline:(BOOL)isOnline;
        [Export("performFeatureFlagRequest:isOnline:")]
        void PerformFeatureFlagRequest([NullAllowed] LDUserModel user, bool isOnline);

        // -(void)performEventRequest:(NSArray * _Nullable)eventDictionaries isOnline:(BOOL)isOnline;
        [Export("performEventRequest:isOnline:")]
        void PerformEventRequest([NullAllowed] NSObject[] eventDictionaries, bool isOnline);
    }

    // @interface LDEnvironmentController : NSObject <RequestManagerDelegate>
    [BaseType(typeof(NSObject))]
    interface LDEnvironmentController : IRequestManagerDelegate
    {
        // @property (getter = isOnline, assign, nonatomic) BOOL online;
        [Export("online")]
        bool Online { [Bind("isOnline")] get; set; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull mobileKey;
        [Export("mobileKey")]
        string MobileKey { get; }

        // @property (readonly, nonatomic, strong) LDConfig * _Nonnull config;
        [Export("config", ArgumentSemantic.Strong)]
        LDConfig Config { get; }

        // @property (readonly, nonatomic, strong) LDUserModel * _Nonnull user;
        [Export("user", ArgumentSemantic.Strong)]
        LDUserModel User { get; }

        // +(instancetype _Nonnull)controllerWithMobileKey:(NSString * _Nonnull)mobileKey config:(LDConfig * _Nonnull)config user:(LDUserModel * _Nonnull)user dataManager:(LDDataManager * _Nonnull)dataManager;
        [Static]
        [Export("controllerWithMobileKey:config:user:dataManager:")]
        LDEnvironmentController ControllerWithMobileKey(string mobileKey, LDConfig config, LDUserModel user, LDDataManager dataManager);

        // -(instancetype _Nonnull)initWithMobileKey:(NSString * _Nonnull)mobileKey config:(LDConfig * _Nonnull)config user:(LDUserModel * _Nonnull)user dataManager:(LDDataManager * _Nonnull)dataManager;
        [Export("initWithMobileKey:config:user:dataManager:")]
        IntPtr Constructor(string mobileKey, LDConfig config, LDUserModel user, LDDataManager dataManager);

        // -(void)flushEvents;
        [Export("flushEvents")]
        void FlushEvents();
    }

    // @interface EventTypes (LDEvent)
    [Category]
    [BaseType(typeof(LDEvent))]
    interface LDEvent_EventTypes
    {
    }

    // @interface Unauthorized (LDEvent)
    [Category]
    [BaseType(typeof(LDEvent))]
    interface LDEvent_Unauthorized
    {
        // -(BOOL)isUnauthorizedEvent;
        [Export("isUnauthorizedEvent")]
        bool IsUnauthorizedEvent();
    }

    // @interface ReferencedDate (NSDate)
    [Category]
    [BaseType(typeof(NSDate))]
    interface NSDate_ReferencedDate
    {
        // +(NSDate *)dateFromMillisSince1970:(LDMillisecond)millis;
        [Static]
        [Export("dateFromMillisSince1970:")]
        NSDate DateFromMillisSince1970(long millis);

        // -(LDMillisecond)millisSince1970;
        [Export("millisSince1970")]
        long MillisSince1970();

        // -(BOOL)isWithinTimeInterval:(NSTimeInterval)timeInterval ofDate:(NSDate *)otherDate;
        [Export("isWithinTimeInterval:ofDate:")]
        bool IsWithinTimeInterval(double timeInterval, NSDate otherDate);

        // -(BOOL)isEarlierThan:(NSDate *)otherDate;
        [Export("isEarlierThan:")]
        bool IsEarlierThan(NSDate otherDate);

        // -(BOOL)isLaterThan:(NSDate *)otherDate;
        [Export("isLaterThan:")]
        bool IsLaterThan(NSDate otherDate);
    }

    // @interface LDEventModel : NSObject <NSCoding>
    [BaseType(typeof(NSObject))]
    interface LDEventModel : INSCoding
    {
        // @property (nonatomic, strong) NSString * _Nullable kind;
        [NullAllowed, Export("kind", ArgumentSemantic.Strong)]
        string Kind { get; set; }

        // @property (nonatomic, strong) NSString * _Nullable key;
        [NullAllowed, Export("key", ArgumentSemantic.Strong)]
        string Key { get; set; }

        // @property (assign, nonatomic) LDMillisecond creationDate;
        [Export("creationDate")]
        long CreationDate { get; set; }

        // @property (nonatomic, strong) LDUserModel * _Nullable user;
        [NullAllowed, Export("user", ArgumentSemantic.Strong)]
        LDUserModel User { get; set; }

        // @property (assign, nonatomic) BOOL inlineUser;
        [Export("inlineUser")]
        bool InlineUser { get; set; }

        // @property (nonatomic, strong) LDFlagConfigValue * _Nullable flagConfigValue;
        [NullAllowed, Export("flagConfigValue", ArgumentSemantic.Strong)]
        LDFlagConfigValue FlagConfigValue { get; set; }

        // @property (nonatomic, strong) id _Nullable reportedValue;
        [NullAllowed, Export("reportedValue", ArgumentSemantic.Strong)]
        NSObject ReportedValue { get; set; }

        // @property (nonatomic, strong) id _Nullable defaultValue;
        [NullAllowed, Export("defaultValue", ArgumentSemantic.Strong)]
        NSObject DefaultValue { get; set; }

        // @property (nonatomic, strong) NSDictionary * _Nullable data;
        [NullAllowed, Export("data", ArgumentSemantic.Strong)]
        NSDictionary Data { get; set; }

        // @property (assign, nonatomic) LDMillisecond startDateMillis;
        [Export("startDateMillis")]
        long StartDateMillis { get; set; }

        // @property (assign, nonatomic) LDMillisecond endDateMillis;
        [Export("endDateMillis")]
        long EndDateMillis { get; set; }

        // @property (nonatomic, strong) NSDictionary * _Nullable flagRequestSummary;
        [NullAllowed, Export("flagRequestSummary", ArgumentSemantic.Strong)]
        NSDictionary FlagRequestSummary { get; set; }

        // -(NSDictionary * _Nonnull)dictionaryValueUsingConfig:(LDConfig * _Nonnull)config;
        [Export("dictionaryValueUsingConfig:")]
        NSDictionary DictionaryValueUsingConfig(LDConfig config);

        // +(instancetype _Nullable)featureEventWithFlagKey:(NSString * _Nonnull)flagKey reportedFlagValue:(id _Nonnull)reportedFlagValue flagConfigValue:(LDFlagConfigValue * _Nullable)flagConfigValue defaultFlagValue:(id _Nullable)defaultflagValue user:(LDUserModel * _Nonnull)user inlineUser:(BOOL)inlineUser;
        [Static]
        [Export("featureEventWithFlagKey:reportedFlagValue:flagConfigValue:defaultFlagValue:user:inlineUser:")]
        [return: NullAllowed]
        LDEventModel FeatureEventWithFlagKey(string flagKey, NSObject reportedFlagValue, [NullAllowed] LDFlagConfigValue flagConfigValue, [NullAllowed] NSObject defaultflagValue, LDUserModel user, bool inlineUser);

        // -(instancetype _Nullable)initFeatureEventWithFlagKey:(NSString * _Nonnull)flagKey reportedFlagValue:(id _Nonnull)reportedFlagValue flagConfigValue:(LDFlagConfigValue * _Nullable)flagConfigValue defaultFlagValue:(id _Nullable)defaultFlagValue user:(LDUserModel * _Nonnull)user inlineUser:(BOOL)inlineUser;
        [Export("initFeatureEventWithFlagKey:reportedFlagValue:flagConfigValue:defaultFlagValue:user:inlineUser:")]
        IntPtr Constructor(string flagKey, NSObject reportedFlagValue, [NullAllowed] LDFlagConfigValue flagConfigValue, [NullAllowed] NSObject defaultFlagValue, LDUserModel user, bool inlineUser);

        // +(instancetype _Nullable)customEventWithKey:(NSString * _Nonnull)featureKey customData:(NSDictionary * _Nonnull)customData userValue:(LDUserModel * _Nonnull)userValue inlineUser:(BOOL)inlineUser;
        [Static]
        [Export("customEventWithKey:customData:userValue:inlineUser:")]
        [return: NullAllowed]
        LDEventModel CustomEventWithKey(string featureKey, NSDictionary customData, LDUserModel userValue, bool inlineUser);

        // -(instancetype _Nullable)initCustomEventWithKey:(NSString * _Nonnull)featureKey customData:(NSDictionary * _Nonnull)customData userValue:(LDUserModel * _Nonnull)userValue inlineUser:(BOOL)inlineUser;
        [Export("initCustomEventWithKey:customData:userValue:inlineUser:")]
        IntPtr Constructor(string featureKey, NSDictionary customData, LDUserModel userValue, bool inlineUser);

        // +(instancetype _Nullable)identifyEventWithUser:(LDUserModel * _Nonnull)user;
        [Static]
        [Export("identifyEventWithUser:")]
        [return: NullAllowed]
        LDEventModel IdentifyEventWithUser(LDUserModel user);

        // -(instancetype _Nullable)initIdentifyEventWithUser:(LDUserModel * _Nonnull)user;
        [Export("initIdentifyEventWithUser:")]
        IntPtr Constructor(LDUserModel user);

        // +(instancetype _Nullable)summaryEventWithTracker:(LDFlagConfigTracker * _Nonnull)tracker;
        [Static]
        [Export("summaryEventWithTracker:")]
        [return: NullAllowed]
        LDEventModel SummaryEventWithTracker(LDFlagConfigTracker tracker);

        // -(instancetype _Nullable)initSummaryEventWithTracker:(LDFlagConfigTracker * _Nonnull)tracker;
        [Export("initSummaryEventWithTracker:")]
        IntPtr Constructor(LDFlagConfigTracker tracker);

        // +(instancetype _Nullable)debugEventWithFlagKey:(NSString * _Nonnull)flagKey reportedFlagValue:(id _Nonnull)reportedFlagValue flagConfigValue:(LDFlagConfigValue * _Nullable)flagConfigValue defaultFlagValue:(id _Nullable)defaultFlagValue user:(LDUserModel * _Nonnull)user;
        [Static]
        [Export("debugEventWithFlagKey:reportedFlagValue:flagConfigValue:defaultFlagValue:user:")]
        [return: NullAllowed]
        LDEventModel DebugEventWithFlagKey(string flagKey, NSObject reportedFlagValue, [NullAllowed] LDFlagConfigValue flagConfigValue, [NullAllowed] NSObject defaultFlagValue, LDUserModel user);

        // -(instancetype _Nullable)initDebugEventWithFlagKey:(NSString * _Nonnull)flagKey reportedFlagValue:(id _Nonnull)reportedFlagValue flagConfigValue:(LDFlagConfigValue * _Nullable)flagConfigValue defaultFlagValue:(id _Nullable)defaultFlagValue user:(LDUserModel * _Nonnull)user;
        [Export("initDebugEventWithFlagKey:reportedFlagValue:flagConfigValue:defaultFlagValue:user:")]
        IntPtr Constructor(string flagKey, NSObject reportedFlagValue, [NullAllowed] LDFlagConfigValue flagConfigValue, [NullAllowed] NSObject defaultFlagValue, LDUserModel user);

        // -(NSString * _Nonnull)description;
        [Export("description")]
        string Description { get; }
    }

    // @interface LDEventParser : NSObject
    [BaseType(typeof(NSObject))]
    interface LDEventParser
    {
        // @property (readonly, copy, nonatomic) NSString * eventString;
        [Export("eventString")]
        string EventString { get; }

        // @property (readonly, nonatomic, strong) LDEvent * event;
        [Export("event", ArgumentSemantic.Strong)]
        LDEvent Event { get; }

        // @property (readonly, nonatomic, strong) NSNumber * retryInterval;
        [Export("retryInterval", ArgumentSemantic.Strong)]
        NSNumber RetryInterval { get; }

        // @property (readonly, copy, nonatomic) NSString * remainingEventString;
        [Export("remainingEventString")]
        string RemainingEventString { get; }

        // +(instancetype)eventParserWithEventString:(NSString *)eventString;
        [Static]
        [Export("eventParserWithEventString:")]
        LDEventParser EventParserWithEventString(string eventString);

        // -(instancetype)initWithEventString:(NSString *)eventString;
        [Export("initWithEventString:")]
        IntPtr Constructor(string eventString);
    }

    // @interface LDEventStringAccumulator : NSObject
    [BaseType(typeof(NSObject))]
    interface LDEventStringAccumulator
    {
        // @property (copy, nonatomic) NSString * eventString;
        [Export("eventString")]
        string EventString { get; set; }

        // -(void)accumulateEventStringWithString:(NSString *)eventString;
        [Export("accumulateEventStringWithString:")]
        void AccumulateEventStringWithString(string eventString);

        // -(BOOL)isReadyToParseEvent;
        [Export("isReadyToParseEvent")]
        bool IsReadyToParseEvent { get; }

        // -(void)reset;
        [Export("reset")]
        void Reset();
    }

    // @interface LDEventTrackingContext : NSObject <NSCoding>
    [BaseType(typeof(NSObject))]
    interface LDEventTrackingContext : INSCoding
    {
        // @property (assign, nonatomic) BOOL trackEvents;
        [Export("trackEvents")]
        bool TrackEvents { get; set; }

        // @property (nonatomic, strong) NSDate * _Nullable debugEventsUntilDate;
        [NullAllowed, Export("debugEventsUntilDate", ArgumentSemantic.Strong)]
        NSDate DebugEventsUntilDate { get; set; }

        // +(instancetype _Nullable)contextWithObject:(id _Nullable)object;
        [Static]
        [Export("contextWithObject:")]
        [return: NullAllowed]
        LDEventTrackingContext ContextWithObject([NullAllowed] NSObject @object);

        // -(instancetype _Nullable)initWithObject:(id _Nullable)object;
        [Export("initWithObject:")]
        IntPtr Constructor([NullAllowed] NSObject @object);

        // -(NSDictionary * _Nonnull)dictionaryValue;
        [Export("dictionaryValue")]
        NSDictionary DictionaryValue { get; }

        // -(NSString * _Nonnull)description;
        [Export("description")]
        string Description { get; }
    }

    // @interface LDFlagConfigModel : NSObject <NSCoding>
    [BaseType(typeof(NSObject))]
    interface LDFlagConfigModel : INSCoding
    {
        // @property (nonatomic, strong) NSDictionary<NSString *,LDFlagConfigValue *> * _Nullable featuresJsonDictionary;
        [NullAllowed, Export("featuresJsonDictionary", ArgumentSemantic.Strong)]
        NSDictionary<NSString, LDFlagConfigValue> FeaturesJsonDictionary { get; set; }

        // @property (readonly, nonatomic, strong) NSDictionary<NSString *,id> * _Nullable allFlagValues;
        [NullAllowed, Export("allFlagValues", ArgumentSemantic.Strong)]
        NSDictionary<NSString, NSObject> AllFlagValues { get; }

        // -(id _Nullable)initWithDictionary:(NSDictionary * _Nullable)dictionary;
        [Export("initWithDictionary:")]
        IntPtr Constructor([NullAllowed] NSDictionary dictionary);

        // -(NSDictionary * _Nullable)dictionaryValue;
        [NullAllowed, Export("dictionaryValue")]
        NSDictionary DictionaryValue { get; }

        // -(NSDictionary * _Nullable)dictionaryValueIncludeNulls:(BOOL)includeNulls;
        [Export("dictionaryValueIncludeNulls:")]
        [return: NullAllowed]
        NSDictionary DictionaryValueIncludeNulls(bool includeNulls);

        // -(BOOL)containsFlagKey:(NSString * _Nonnull)flagKey;
        [Export("containsFlagKey:")]
        bool ContainsFlagKey(string flagKey);

        // -(LDFlagConfigValue * _Nullable)flagConfigValueForFlagKey:(NSString * _Nonnull)flagKey;
        [Export("flagConfigValueForFlagKey:")]
        [return: NullAllowed]
        LDFlagConfigValue FlagConfigValueForFlagKey(string flagKey);

        // -(id _Nullable)flagValueForFlagKey:(NSString * _Nonnull)flagKey;
        [Export("flagValueForFlagKey:")]
        [return: NullAllowed]
        NSObject FlagValueForFlagKey(string flagKey);

        // -(NSInteger)flagModelVersionForFlagKey:(NSString * _Nonnull)flagKey;
        [Export("flagModelVersionForFlagKey:")]
        nint FlagModelVersionForFlagKey(string flagKey);

        // -(void)addOrReplaceFromDictionary:(NSDictionary * _Nullable)eventDictionary;
        [Export("addOrReplaceFromDictionary:")]
        void AddOrReplaceFromDictionary([NullAllowed] NSDictionary eventDictionary);

        // -(void)deleteFromDictionary:(NSDictionary * _Nullable)eventDictionary;
        [Export("deleteFromDictionary:")]
        void DeleteFromDictionary([NullAllowed] NSDictionary eventDictionary);

        // -(BOOL)isEqualToConfig:(LDFlagConfigModel * _Nullable)otherConfig;
        [Export("isEqualToConfig:")]
        bool IsEqualToConfig([NullAllowed] LDFlagConfigModel otherConfig);

        // -(NSArray<NSString *> *)differingFlagKeysFromConfig:(LDFlagConfigModel * _Nullable)otherConfig;
        [Export("differingFlagKeysFromConfig:")]
        string[] DifferingFlagKeysFromConfig([NullAllowed] LDFlagConfigModel otherConfig);

        // -(BOOL)hasFeaturesEqualToDictionary:(NSDictionary * _Nullable)otherDictionary;
        [Export("hasFeaturesEqualToDictionary:")]
        bool HasFeaturesEqualToDictionary([NullAllowed] NSDictionary otherDictionary);

        // -(void)updateEventTrackingContextFromConfig:(LDFlagConfigModel * _Nullable)otherConfig;
        [Export("updateEventTrackingContextFromConfig:")]
        void UpdateEventTrackingContextFromConfig([NullAllowed] LDFlagConfigModel otherConfig);

        // -(LDFlagConfigModel *)copy;
        [Export("copy")]
        LDFlagConfigModel Copy { get; }

        // -(NSString * _Nonnull)description;
        [Export("description")]
        string Description { get; }
    }

    // @interface LDFlagConfigTracker : NSObject
    [BaseType(typeof(NSObject))]
    interface LDFlagConfigTracker
    {
        // @property (readonly, assign, nonatomic) LDMillisecond startDateMillis;
        [Export("startDateMillis")]
        long StartDateMillis { get; }

        // @property (readonly, assign, nonatomic) BOOL hasTrackedEvents;
        [Export("hasTrackedEvents")]
        bool HasTrackedEvents { get; }

        // +(instancetype _Nonnull)tracker;
        [Static]
        [Export("tracker")]
        LDFlagConfigTracker Tracker();

        // -(void)logRequestForFlagKey:(NSString * _Nonnull)flagKey reportedFlagValue:(id _Nonnull)reportedFlagValue flagConfigValue:(LDFlagConfigValue * _Nullable)flagConfigValue defaultValue:(id _Nullable)defaultValue;
        [Export("logRequestForFlagKey:reportedFlagValue:flagConfigValue:defaultValue:")]
        void LogRequestForFlagKey(string flagKey, NSObject reportedFlagValue, [NullAllowed] LDFlagConfigValue flagConfigValue, [NullAllowed] NSObject defaultValue);

        // -(NSDictionary<NSString *,NSDictionary *> * _Nonnull)flagRequestSummary;
        [Export("flagRequestSummary")]
        NSDictionary<NSString, NSDictionary> FlagRequestSummary { get; }

        // -(NSString * _Nonnull)description;
        [Export("description")]
        string Description { get; }
    }

    // @interface LDFlagConfigValue : NSObject
    [BaseType(typeof(NSObject))]
    interface LDFlagConfigValue : INativeObject
    {
        // @property (nonatomic, strong) id _Nullable value;
        [NullAllowed, Export("value", ArgumentSemantic.Strong)]
        NSObject Value { get; set; }

        // @property (assign, nonatomic) NSInteger modelVersion;
        [Export("modelVersion")]
        nint ModelVersion { get; set; }

        // @property (assign, nonatomic) NSInteger variation;
        [Export("variation")]
        nint Variation { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable flagVersion;
        [NullAllowed, Export("flagVersion", ArgumentSemantic.Strong)]
        NSNumber FlagVersion { get; set; }

        // @property (nonatomic, strong) LDEventTrackingContext * _Nullable eventTrackingContext;
        [NullAllowed, Export("eventTrackingContext", ArgumentSemantic.Strong)]
        LDEventTrackingContext EventTrackingContext { get; set; }

        // +(instancetype _Nullable)flagConfigValueWithObject:(id _Nullable)object;
        [Static]
        [Export("flagConfigValueWithObject:")]
        [return: NullAllowed]
        LDFlagConfigValue FlagConfigValueWithObject([NullAllowed] NSObject @object);

        // -(instancetype _Nullable)initWithObject:(id _Nullable)object;
        [Export("initWithObject:")]
        IntPtr Constructor([NullAllowed] NSObject @object);

        // -(void)encodeWithCoder:(NSCoder * _Nonnull)encoder;
        [Export("encodeWithCoder:")]
        void EncodeWithCoder(NSCoder encoder);

        // -(id _Nullable)initWithCoder:(NSCoder * _Nonnull)decoder;
        [Export("initWithCoder:")]
        IntPtr Constructor(NSCoder decoder);

        // -(NSDictionary * _Nonnull)dictionaryValue;
        [Export("dictionaryValue")]
        NSDictionary DictionaryValue { get; }

        // -(NSDictionary * _Nonnull)dictionaryValueUseFlagVersionForVersion:(BOOL)useFlagVersion includeEventTrackingContext:(BOOL)includeEventTrackingContext;
        [Export("dictionaryValueUseFlagVersionForVersion:includeEventTrackingContext:")]
        NSDictionary DictionaryValueUseFlagVersionForVersion(bool useFlagVersion, bool includeEventTrackingContext);

        // -(BOOL)isEqualToFlagConfigValue:(LDFlagConfigValue * _Nullable)other;
        [Export("isEqualToFlagConfigValue:")]
        bool IsEqualToFlagConfigValue([NullAllowed] LDFlagConfigValue other);

        // -(BOOL)isEqual:(id _Nullable)object;
        [Export("isEqual:")]
        bool IsEqual([NullAllowed] NSObject @object);

        // -(BOOL)hasPropertiesMatchingDictionary:(NSDictionary * _Nullable)dictionary;
        [Export("hasPropertiesMatchingDictionary:")]
        bool HasPropertiesMatchingDictionary([NullAllowed] NSDictionary dictionary);

        // -(NSString * _Nonnull)description;
        [Export("description")]
        string Description { get; }
    }

    // @interface LDFlagCounter : NSObject
    [BaseType(typeof(NSObject))]
    interface LDFlagCounter
    {
        // @property (readonly, nonatomic, strong) NSString * _Nonnull flagKey;
        [Export("flagKey", ArgumentSemantic.Strong)]
        string FlagKey { get; }

        // @property (nonatomic, strong) id _Nonnull defaultValue;
        [Export("defaultValue", ArgumentSemantic.Strong)]
        NSObject DefaultValue { get; set; }

        // @property (readonly, assign, nonatomic) BOOL hasLoggedRequests;
        [Export("hasLoggedRequests")]
        bool HasLoggedRequests { get; }

        // +(instancetype _Nonnull)counterWithFlagKey:(NSString * _Nonnull)flagKey defaultValue:(id _Nonnull)defaultValue;
        [Static]
        [Export("counterWithFlagKey:defaultValue:")]
        LDFlagCounter CounterWithFlagKey(string flagKey, NSObject defaultValue);

        // -(instancetype _Nonnull)initWithFlagKey:(NSString * _Nonnull)flagKey defaultValue:(id _Nonnull)defaultValue;
        [Export("initWithFlagKey:defaultValue:")]
        IntPtr Constructor(string flagKey, NSObject defaultValue);

        // -(void)logRequestWithFlagConfigValue:(LDFlagConfigValue * _Nullable)flagConfigValue reportedFlagValue:(id _Nonnull)reportedFlagValue;
        [Export("logRequestWithFlagConfigValue:reportedFlagValue:")]
        void LogRequestWithFlagConfigValue([NullAllowed] LDFlagConfigValue flagConfigValue, NSObject reportedFlagValue);

        // -(NSDictionary * _Nonnull)dictionaryValue;
        [Export("dictionaryValue")]
        NSDictionary DictionaryValue { get; }

        // -(NSString * _Nonnull)description;
        [Export("description")]
        string Description { get; }
    }

    // @interface LDFlagValueCounter : NSObject
    [BaseType(typeof(NSObject))]
    interface LDFlagValueCounter
    {
        // @property (nonatomic, strong) id _Nonnull reportedFlagValue;
        [Export("reportedFlagValue", ArgumentSemantic.Strong)]
        NSObject ReportedFlagValue { get; set; }

        // @property (readonly, nonatomic, strong) LDFlagConfigValue * _Nullable flagConfigValue;
        [NullAllowed, Export("flagConfigValue", ArgumentSemantic.Strong)]
        LDFlagConfigValue FlagConfigValue { get; }

        // @property (readonly, getter = isKnown, assign, nonatomic) BOOL known;
        [Export("known")]
        bool Known { [Bind("isKnown")] get; }

        // @property (assign, nonatomic) NSInteger count;
        [Export("count")]
        nint Count { get; set; }

        // +(instancetype _Nonnull)counterWithFlagConfigValue:(LDFlagConfigValue * _Nullable)flagConfigValue reportedFlagValue:(id _Nonnull)reportedFlagValue;
        [Static]
        [Export("counterWithFlagConfigValue:reportedFlagValue:")]
        LDFlagValueCounter CounterWithFlagConfigValue([NullAllowed] LDFlagConfigValue flagConfigValue, NSObject reportedFlagValue);

        // -(instancetype _Nonnull)initWithFlagConfigValue:(LDFlagConfigValue * _Nullable)flagConfigValue reportedFlagValue:(id _Nonnull)reportedFlagValue;
        [Export("initWithFlagConfigValue:reportedFlagValue:")]
        IntPtr Constructor([NullAllowed] LDFlagConfigValue flagConfigValue, NSObject reportedFlagValue);

        // -(NSDictionary * _Nonnull)dictionaryValue;
        [Export("dictionaryValue")]
        NSDictionary DictionaryValue { get; }

        // -(NSString * _Nonnull)description;
        [Export("description")]
        string Description { get; }
    }

    // @interface LDPollingManager : NSObject
    [BaseType(typeof(NSObject))]
    interface LDPollingManager
    {
        // +(LDPollingManager *)sharedInstance;
        [Static]
        [Export("sharedInstance")]
        LDPollingManager SharedInstance { get; }

        // @property (readonly, assign, atomic) PollingState flagConfigPollingState;
        [Export("flagConfigPollingState", ArgumentSemantic.Assign)]
        PollingState FlagConfigPollingState { get; }

        // @property (readonly, assign, atomic) PollingState eventPollingState;
        [Export("eventPollingState", ArgumentSemantic.Assign)]
        PollingState EventPollingState { get; }

        // @property (readonly, nonatomic, strong) dispatch_source_t flagConfigTimer;
        [Export("flagConfigTimer", ArgumentSemantic.Strong)]
        DispatchTime FlagConfigTimer { get; }

        // @property (readonly, nonatomic, strong) dispatch_source_t eventTimer;
        [Export("eventTimer", ArgumentSemantic.Strong)]
        DispatchTime EventTimer { get; }

        // @property (readonly, nonatomic, strong) LDConfig * config;
        [Export("config", ArgumentSemantic.Strong)]
        LDConfig Config { get; }

        // -(void)startFlagConfigPollingUsingConfig:(LDConfig *)config isOnline:(BOOL)isOnline;
        [Export("startFlagConfigPollingUsingConfig:isOnline:")]
        void StartFlagConfigPollingUsingConfig(LDConfig config, bool isOnline);

        // -(void)suspendFlagConfigPolling;
        [Export("suspendFlagConfigPolling")]
        void SuspendFlagConfigPolling();

        // -(void)resumeFlagConfigPollingWhenIsOnline:(BOOL)isOnline;
        [Export("resumeFlagConfigPollingWhenIsOnline:")]
        void ResumeFlagConfigPollingWhenIsOnline(bool isOnline);

        // -(void)stopFlagConfigPolling;
        [Export("stopFlagConfigPolling")]
        void StopFlagConfigPolling();

        // -(void)startEventPollingUsingConfig:(LDConfig *)config isOnline:(BOOL)isOnline;
        [Export("startEventPollingUsingConfig:isOnline:")]
        void StartEventPollingUsingConfig(LDConfig config, bool isOnline);

        // -(void)suspendEventPolling;
        [Export("suspendEventPolling")]
        void SuspendEventPolling();

        // -(void)resumeEventPollingWhenIsOnline:(BOOL)isOnline;
        [Export("resumeEventPollingWhenIsOnline:")]
        void ResumeEventPollingWhenIsOnline(bool isOnline);

        // -(void)stopEventPolling;
        [Export("stopEventPolling")]
        void StopEventPolling();
    }

    // @interface LDThrottler : NSObject
    [BaseType(typeof(NSObject))]
    interface LDThrottler
    {
        // @property (readonly, assign, nonatomic) NSTimeInterval maxDelayInterval;
        [Export("maxDelayInterval")]
        double MaxDelayInterval { get; }

        // @property (readonly, assign, nonatomic) NSUInteger runAttempts;
        [Export("runAttempts")]
        nuint RunAttempts { get; }

        // @property (readonly, assign, nonatomic) NSTimeInterval delayInterval;
        [Export("delayInterval")]
        double DelayInterval { get; }

        // @property (readonly, nonatomic, strong) NSDate * _Nullable timerStartDate;
        [NullAllowed, Export("timerStartDate", ArgumentSemantic.Strong)]
        NSDate TimerStartDate { get; }

        // @property (readonly, nonatomic, strong) NSTimer * _Nullable delayTimer;
        [NullAllowed, Export("delayTimer", ArgumentSemantic.Strong)]
        NSTimer DelayTimer { get; }

        // -(instancetype _Nullable)initWithMaxDelayInterval:(NSTimeInterval)maxDelaySeconds;
        [Export("initWithMaxDelayInterval:")]
        IntPtr Constructor(double maxDelaySeconds);

        // -(void)runThrottled:(void (^ _Nonnull)(void))completion;
        [Export("runThrottled:")]
        void RunThrottled(Action completion);
    }

    // @interface LDURLCache : NSURLCache
    [BaseType(typeof(NSUrlCache))]
    interface LDURLCache
    {
        // +(NSURLCache * _Nonnull)urlCacheForConfig:(LDConfig * _Nonnull)config usingCache:(NSURLCache * _Nonnull)baseCache;
        [Static]
        [Export("urlCacheForConfig:usingCache:")]
        NSUrlCache UrlCacheForConfig(LDConfig config, NSUrlCache baseCache);

        // +(BOOL)shouldUseLDURLCacheForConfig:(LDConfig * _Nonnull)config;
        [Static]
        [Export("shouldUseLDURLCacheForConfig:")]
        bool ShouldUseLDURLCacheForConfig(LDConfig config);

        // -(void)storeCachedResponse:(NSCachedURLResponse * _Nonnull)cachedResponse forDataTask:(NSURLSessionDataTask * _Nonnull)dataTask;
        [Export("storeCachedResponse:forDataTask:")]
        void StoreCachedResponse(NSCachedUrlResponse cachedResponse, NSUrlSessionDataTask dataTask);

        // -(void)storeCachedResponse:(NSCachedURLResponse * _Nonnull)cachedResponse forRequest:(NSURLRequest * _Nonnull)request;
        [Export("storeCachedResponse:forRequest:")]
        void StoreCachedResponse(NSCachedUrlResponse cachedResponse, NSUrlRequest request);

        // -(void)getCachedResponseForDataTask:(NSURLSessionDataTask * _Nonnull)dataTask completionHandler:(void (^ _Nonnull)(NSCachedURLResponse * _Nonnull))completionHandler;
        [Export("getCachedResponseForDataTask:completionHandler:")]
        void GetCachedResponseForDataTask(NSUrlSessionDataTask dataTask, Action<NSCachedUrlResponse> completionHandler);

        // -(NSCachedURLResponse * _Nonnull)cachedResponseForRequest:(NSURLRequest * _Nonnull)request;
        [Export("cachedResponseForRequest:")]
        NSCachedUrlResponse CachedResponseForRequest(NSUrlRequest request);
    }

    // @interface LDUserEnvironment : NSObject <NSCoding>
    [BaseType(typeof(NSObject))]
    interface LDUserEnvironment : INSCoding
    {
        // @property (readonly, nonatomic, strong) NSString * _Nonnull userKey;
        [Export("userKey", ArgumentSemantic.Strong)]
        string UserKey { get; }

        // @property (readonly, nonatomic, strong) NSDate * _Nullable lastUpdated;
        [NullAllowed, Export("lastUpdated", ArgumentSemantic.Strong)]
        NSDate LastUpdated { get; }

        // +(instancetype _Nullable)userEnvironmentForUserWithKey:(NSString * _Nonnull)userKey environments:(NSDictionary<NSString *,LDUserModel *> * _Nullable)environments;
        [Static]
        [Export("userEnvironmentForUserWithKey:environments:")]
        [return: NullAllowed]
        LDUserEnvironment UserEnvironmentForUserWithKey(string userKey, [NullAllowed] NSDictionary<NSString, LDUserModel> environments);

        // -(instancetype _Nullable)initForUserWithKey:(NSString * _Nonnull)userKey environments:(NSDictionary<NSString *,LDUserModel *> * _Nonnull)environments;
        [Export("initForUserWithKey:environments:")]
        IntPtr Constructor(string userKey, NSDictionary<NSString, LDUserModel> environments);

        // -(instancetype _Nullable)initWithDictionary:(NSDictionary * _Nullable)dictionary;
        [Export("initWithDictionary:")]
        IntPtr Constructor([NullAllowed] NSDictionary dictionary);

        // -(NSDictionary * _Nullable)dictionaryValue;
        [NullAllowed, Export("dictionaryValue")]
        NSDictionary DictionaryValue { get; }

        // -(LDUserModel * _Nullable)userForMobileKey:(NSString * _Nonnull)mobileKey;
        [Export("userForMobileKey:")]
        [return: NullAllowed]
        LDUserModel UserForMobileKey(string mobileKey);

        // -(void)setUser:(LDUserModel * _Nonnull)user mobileKey:(NSString * _Nonnull)mobileKey;
        [Export("setUser:mobileKey:")]
        void SetUser(LDUserModel user, string mobileKey);

        // -(void)removeUserForMobileKey:(NSString * _Nonnull)mobileKey;
        [Export("removeUserForMobileKey:")]
        void RemoveUserForMobileKey(string mobileKey);
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

    // @interface LDEventSource (NSArray)
    [Category]
    [BaseType(typeof(NSArray))]
    interface NSArray_LDEventSource
    {
        // -(NSUInteger)indexOfFirstEmptyLine;
        [Export("indexOfFirstEmptyLine")]
        nuint IndexOfFirstEmptyLine();

        // -(NSArray *)subArrayFromIndex:(NSUInteger)index;
        [Export("subArrayFromIndex:")]
        NSObject[] SubArrayFromIndex(nuint index);
    }

    // @interface JsonHeader (NSDateFormatter)
    [Category]
    [BaseType(typeof(NSDateFormatter))]
    interface NSDateFormatter_JsonHeader
    {
        // +(instancetype)jsonHeaderDateFormatter;
        [Static]
        [Export("jsonHeaderDateFormatter")]
        NSDateFormatter JsonHeaderDateFormatter();
    }

    // @interface LDUserModel (NSDateFormatter)
    [Category]
    [BaseType(typeof(NSDateFormatter))]
    interface NSDateFormatter_LDUserModel
    {
        // +(instancetype)userDateFormatter;
        [Static]
        [Export("userDateFormatter")]
        NSDateFormatter UserDateFormatter();
    }

    // @interface LaunchDarkly (NSDictionary)
    [Category]
    [BaseType(typeof(NSDictionary))]
    interface NSDictionary_LaunchDarkly
    {
        // -(NSString * _Nullable)jsonString;
        [NullAllowed, Export("jsonString")]
        string JsonString();

        // -(NSDictionary * _Nonnull)compactMapUsingBlock:(id (^ _Nullable)(id _Nonnull))mappingBlock;
        [Export("compactMapUsingBlock:")]
        NSDictionary CompactMapUsingBlock([NullAllowed] Func<NSObject, NSObject> mappingBlock);
    }

    // @interface LaunchDarkly (NSHTTPURLResponse)
    [Category]
    [BaseType(typeof(NSHttpUrlResponse))]
    interface NSHTTPURLResponse_LaunchDarkly
    {
        // @property (readonly, assign, nonatomic) BOOL isOk;
        [Export("isOk")]
        bool IsOk();

        // @property (readonly, assign, nonatomic) BOOL isNotModified;
        [Export("isNotModified")]
        bool IsNotModified();

        // @property (readonly, copy, nonatomic) NSString * etag;
        [Export("etag")]
        string Etag();

        // -(BOOL)isUnauthorizedHTTPResponse;
        [Export("isUnauthorizedHTTPResponse")]
        bool IsUnauthorizedHTTPResponse();

        // -(NSDate *)headerDate;
        [Export("headerDate")]
        NSDate HeaderDate();
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

    // @interface LaunchDarkly (NSNumber)
    [Category]
    [BaseType(typeof(NSNumber))]
    interface NSNumber_LaunchDarkly
    {
        // -(LDMillisecond)ldMillisecondValue;
        [Export("ldMillisecondValue")]
        long LdMillisecondValue();

        // -(uint64_t)nanoSecondValue;
        [Export("nanoSecondValue")]
        ulong NanoSecondValue();
    }

    // @interface LDEventSource (NSString)
    [Category]
    [BaseType(typeof(NSString))]
    interface NSString_LDEventSource
    {
        // @property (readonly, assign, nonatomic) BOOL hasEventPrefix;
        [Export("hasEventPrefix")]
        bool HasEventPrefix();

        // @property (readonly, assign, nonatomic) BOOL hasEventTerminator;
        [Export("hasEventTerminator")]
        bool HasEventTerminator();

        // -(NSArray<NSString *> *)lines;
        [Export("lines")]
        string[] Line();
    }

    // @interface LaunchDarkly (NSString)
    [Category]
    [BaseType(typeof(NSString))]
    interface NSString_LaunchDarkly
    {
        // +(instancetype _Nonnull)stringWithBool:(BOOL)boolValue;
        [Static]
        [Export("stringWithBool:")]
        NSString StringWithBool(bool boolValue);
    }

    // @interface MainExecutable (NSThread)
    [Category]
    [BaseType(typeof(NSThread))]
    interface NSThread_MainExecutable
    {
        // +(void)performOnMainThread:(void (^)(void))executionBlock waitUntilDone:(BOOL)wait;
        [Static]
        [Export("performOnMainThread:waitUntilDone:")]
        void PerformOnMainThread(Action executionBlock, bool wait);
    }

    // @interface LaunchDarkly (NSURLResponse)
    [Category]
    [BaseType(typeof(NSUrlResponse))]
    interface NSURLResponse_LaunchDarkly
    {
        // @property (readonly, assign, nonatomic) BOOL isOk;
        [Export("isOk")]
        bool IsOk();

        // @property (readonly, assign, nonatomic) BOOL isNotModified;
        [Export("isNotModified")]
        bool IsNotModified();

        // @property (readonly, copy, nonatomic) NSString * etag;
        [Export("etag")]
        string Etag();

        // -(BOOL)isUnauthorizedHTTPResponse;
        [Export("isUnauthorizedHTTPResponse")]
        bool IsUnauthorizedHTTPResponse();

        // -(NSDate *)headerDate;
        [Export("headerDate")]
        NSDate HeaderDate();
    }

    // @interface LaunchDarkly (NSURLSession)
    [Category]
    [BaseType(typeof(NSUrlSession))]
    interface NSURLSession_LaunchDarkly
    {
        // +(void)setSharedLDSessionForConfig:(LDConfig * _Nonnull)config;
        [Static]
        [Export("setSharedLDSessionForConfig:")]
        void SetSharedLDSessionForConfig(LDConfig config);

        // +(NSURLSession * _Nonnull)sharedLDSession;
        [Static]
        [Export("sharedLDSession")]
        NSUrlSession SharedLDSession();
    }

    [Static]
    partial interface Constants
    {
        // extern NSString *const kClientVersion;
        [Field("kClientVersion", "__Internal")]
        NSString kClientVersion { get; }

        // extern NSString *const kLDPrimaryEnvironmentName;
        [Field("kLDPrimaryEnvironmentName", "__Internal")]
        NSString kLDPrimaryEnvironmentName { get; }

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

        // extern NSString *const kHeaderMobileKey;
        [Field("kHeaderMobileKey", "__Internal")]
        NSString kHeaderMobileKey { get; }

        // extern NSString *const kHTTPMethodReport;
        [Field("kHTTPMethodReport", "__Internal")]
        NSString kHTTPMethodReport { get; }

        // extern NSString *const kLDUserUpdatedNotification;
        [Field("kLDUserUpdatedNotification", "__Internal")]
        NSString kLDUserUpdatedNotification { get; }

        // extern NSString *const kLDUserNoChangeNotification;
        [Field("kLDUserNoChangeNotification", "__Internal")]
        NSString kLDUserNoChangeNotification { get; }

        // extern NSString *const kLDFeatureFlagsChangedNotification;
        [Field("kLDFeatureFlagsChangedNotification", "__Internal")]
        NSString kLDFeatureFlagsChangedNotification { get; }

        // extern NSString *const kLDServerConnectionUnavailableNotification;
        [Field("kLDServerConnectionUnavailableNotification", "__Internal")]
        NSString kLDServerConnectionUnavailableNotification { get; }

        // extern NSString *const kLDClientUnauthorizedNotification;
        [Field("kLDClientUnauthorizedNotification", "__Internal")]
        NSString kLDClientUnauthorizedNotification { get; }

        // extern NSString *const kLDFlagConfigTimerFiredNotification;
        [Field("kLDFlagConfigTimerFiredNotification", "__Internal")]
        NSString kLDFlagConfigTimerFiredNotification { get; }

        // extern NSString *const kLDEventTimerFiredNotification;
        [Field("kLDEventTimerFiredNotification", "__Internal")]
        NSString kLDEventTimerFiredNotification { get; }

        // extern NSString *const kLDBackgroundFetchInitiated;
        [Field("kLDBackgroundFetchInitiated", "__Internal")]
        NSString kLDBackgroundFetchInitiated { get; }

        // extern NSString *const kLDNotificationUserInfoKeyMobileKey;
        [Field("kLDNotificationUserInfoKeyMobileKey", "__Internal")]
        NSString kLDNotificationUserInfoKeyMobileKey { get; }

        // extern NSString *const kLDNotificationUserInfoKeyFlagKeys;
        [Field("kLDNotificationUserInfoKeyFlagKeys", "__Internal")]
        NSString kLDNotificationUserInfoKeyFlagKeys { get; }

        // extern const int kCapacity;
        [Field("kCapacity", "__Internal")]
        int kCapacity { get; }

        // extern const int kConnectionTimeout;
        [Field("kConnectionTimeout", "__Internal")]
        int kConnectionTimeout { get; }

        // extern const int kDefaultFlushInterval;
        [Field("kDefaultFlushInterval", "__Internal")]
        int kDefaultFlushInterval { get; }

        // extern const int kMinimumFlushInterval;
        [Field("kMinimumFlushInterval", "__Internal")]
        int kMinimumFlushInterval { get; }

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

        // extern const NSInteger kHTTPStatusCodeOk;
        [Field("kHTTPStatusCodeOk", "__Internal")]
        nint kHTTPStatusCodeOk { get; }

        // extern const NSInteger kHTTPStatusCodeNotModified;
        [Field("kHTTPStatusCodeNotModified", "__Internal")]
        nint kHTTPStatusCodeNotModified { get; }

        // extern const NSInteger kHTTPStatusCodeBadRequest;
        [Field("kHTTPStatusCodeBadRequest", "__Internal")]
        nint kHTTPStatusCodeBadRequest { get; }

        // extern const NSInteger kHTTPStatusCodeUnauthorized;
        [Field("kHTTPStatusCodeUnauthorized", "__Internal")]
        nint kHTTPStatusCodeUnauthorized { get; }

        // extern const NSInteger kHTTPStatusCodeMethodNotAllowed;
        [Field("kHTTPStatusCodeMethodNotAllowed", "__Internal")]
        nint kHTTPStatusCodeMethodNotAllowed { get; }

        // extern const NSInteger kHTTPStatusCodeNotImplemented;
        [Field("kHTTPStatusCodeNotImplemented", "__Internal")]
        nint kHTTPStatusCodeNotImplemented { get; }

        // extern const NSInteger kErrorCodeUnauthorized;
        [Field("kErrorCodeUnauthorized", "__Internal")]
        nint kErrorCodeUnauthorized { get; }

        // extern const NSUInteger kNSURLCacheMemoryCapacity;
        [Field("kNSURLCacheMemoryCapacity", "__Internal")]
        nuint kNSURLCacheMemoryCapacity { get; }

        // extern const NSUInteger kNSURLCacheDiskCapacity;
        [Field("kNSURLCacheDiskCapacity", "__Internal")]
        nuint kNSURLCacheDiskCapacity { get; }

        // extern const NSTimeInterval kMaxThrottlingDelayInterval;
        [Field("kMaxThrottlingDelayInterval", "__Internal")]
        double kMaxThrottlingDelayInterval { get; }

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

        // extern NSString *const kLDEventTypePing;
        [Field("kLDEventTypePing", "__Internal")]
        NSString kLDEventTypePing { get; }

        // extern NSString *const kLDEventTypePut;
        [Field("kLDEventTypePut", "__Internal")]
        NSString kLDEventTypePut { get; }

        // extern NSString *const kLDEventTypePatch;
        [Field("kLDEventTypePatch", "__Internal")]
        NSString kLDEventTypePatch { get; }

        // extern NSString *const kLDEventTypeDelete;
        [Field("kLDEventTypeDelete", "__Internal")]
        NSString kLDEventTypeDelete { get; }

        // extern NSString *const _Nonnull kLDFlagConfigValueKeyValue;
        [Field("kLDFlagConfigValueKeyValue", "__Internal")]
        NSString kLDFlagConfigValueKeyValue { get; }

        // extern NSString *const _Nonnull kLDFlagConfigValueKeyVersion;
        [Field("kLDFlagConfigValueKeyVersion", "__Internal")]
        NSString kLDFlagConfigValueKeyVersion { get; }

        // extern NSString *const _Nonnull kLDFlagConfigValueKeyFlagVersion;
        [Field("kLDFlagConfigValueKeyFlagVersion", "__Internal")]
        NSString kLDFlagConfigValueKeyFlagVersion { get; }

        // extern NSString *const _Nonnull kLDFlagConfigValueKeyVariation;
        [Field("kLDFlagConfigValueKeyVariation", "__Internal")]
        NSString kLDFlagConfigValueKeyVariation { get; }

        // extern const NSInteger kLDFlagConfigValueItemDoesNotExist;
        [Field("kLDFlagConfigValueItemDoesNotExist", "__Internal")]
        nint kLDFlagConfigValueItemDoesNotExist { get; }

        // extern NSString *const _Nonnull kUserAttributeIp;
        [Field("kUserAttributeIp", "__Internal")]
        NSString kUserAttributeIp { get; }

        // extern NSString *const _Nonnull kUserAttributeCountry;
        [Field("kUserAttributeCountry", "__Internal")]
        NSString kUserAttributeCountry { get; }

        // extern NSString *const _Nonnull kUserAttributeName;
        [Field("kUserAttributeName", "__Internal")]
        NSString kUserAttributeName { get; }

        // extern NSString *const _Nonnull kUserAttributeFirstName;
        [Field("kUserAttributeFirstName", "__Internal")]
        NSString kUserAttributeFirstName { get; }

        // extern NSString *const _Nonnull kUserAttributeLastName;
        [Field("kUserAttributeLastName", "__Internal")]
        NSString kUserAttributeLastName { get; }

        // extern NSString *const _Nonnull kUserAttributeEmail;
        [Field("kUserAttributeEmail", "__Internal")]
        NSString kUserAttributeEmail { get; }

        // extern NSString *const _Nonnull kUserAttributeAvatar;
        [Field("kUserAttributeAvatar", "__Internal")]
        NSString kUserAttributeAvatar { get; }

        // extern NSString *const _Nonnull kUserAttributeCustom;
        [Field("kUserAttributeCustom", "__Internal")]
        NSString kUserAttributeCustom { get; }
        // extern NSString *const LDEventSourceErrorDomain;
        [Field("LDEventSourceErrorDomain", "__Internal")]
        NSString LDEventSourceErrorDomain { get; }    // @interface LDEvent : NSObject <NSCopying>
    }
}



