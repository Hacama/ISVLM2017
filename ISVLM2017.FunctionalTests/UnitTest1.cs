//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting; /* We use .NET UnitTest Fwk, but any unit test fwk can be used */
////using AppiumTests.Helpers;
////using AppiumTest.Framework;


//using OpenQA.Selenium; /* Appium is based on Selenium, we need to include it */
//using OpenQA.Selenium.Appium; /* This is Appium */
//using OpenQA.Selenium.Appium.Interfaces; /* Not needed for commands shown here. It might be needed in single tests for automation */
//using OpenQA.Selenium.Appium.MultiTouch; /* Not needed for commands shown here. It might be needed in single tests for automation */
//using OpenQA.Selenium.Interactions; /* Not needed for commands shown here. It might be needed in single tests for automation */
//using OpenQA.Selenium.Remote;

//namespace ISVLM2017.FunctionalTests
//{
//    [TestClass]
//    public class UnitTest1
//    {
//        private AppiumDriver driver;

//        private static Uri testServerAddress = new Uri(TestServers.Server1);
//        private static TimeSpan INIT_TIMEOUT_SEC = TimeSpan.FromSeconds(180); /* Change this to a more reasonable value */
//        private static TimeSpan IMPLICIT_TIMEOUT_SEC = TimeSpan.FromSeconds(10); /* Change this to a more reasonable value */
//        [TestInitialize]
//        public void BeforeAll()
//        {
//            DesiredCapabilities capabilities = new DesiredCapabilities();
//            TestCapabilities testCapabilities = new TestCapabilities();

//            testCapabilities.App = "";
//            testCapabilities.AutoWebView = true;
//            testCapabilities.AutomationName = "";
//            testCapabilities.BrowserName = String.Empty; // Leave empty otherwise you test on browsers
//            testCapabilities.DeviceName = "Needed if testing on IOS on a specific device. This will be the UDID";
//            testCapabilities.FwkVersion = "1.0"; // Not really needed
//            testCapabilities.Platform = TestCapabilities.DevicePlatform.Android; // Or IOS
//            testCapabilities.PlatformVersion = String.Empty; // Not really needed

//            testCapabilities.AssignAppiumCapabilities(ref capabilities);
//            driver = new AppiumDriver(testServerAddress, capabilities, INIT_TIMEOUT_SEC);
//            driver.Manage().Timeouts().ImplicitlyWait(IMPLICIT_TIMEOUT_SEC);
//        }

//        [TestCleanup]
//        public void AfterAll()
//        {
//            driver.Quit(); // Always quit, if you don't, next test session will fail
//        }

//        /// 
//        /// Just a simple test to heck out Appium environment.
//        /// 
//        [TestMethod]
//        public void CheckTestEnvironment()
//        {
//            var context = driver.GetContext();
//            Assert.IsNotNull(context);
//        }
//    }
//}
//public static class TestServers
//{
//    public static string Server1 { get { return "http://192.168.2.23:3445/wd/hub"; } }
//    public static string Server2 { get { return "http://192.168.2.24:3446/wd/hub"; } }
//    public static string Server3 { get { return "http://192.168.2.36:3432/wd/hub"; } }
//    public static string Server4 { get { return "http://192.168.2.36:3436/wd/hub"; } }
//    public static string Server5 { get { return "http://192.168.2.38:3445/wd/hub"; } }
//    public static string Server6 { get { return "http://192.168.2.39:3445/wd/hub"; } }
//}
//public sealed class TestCapabilities { 
//  /// Tracking platforms  
//  public enum DevicePlatform {
//    Undefined,
//    Windows,
//    IOS,
//    Android
//  }

//  public string BrowserName      { get; set; }
//  public string FwkVersion       { get; set; }
//  public DevicePlatform Platform { get; set; }
//  public string PlatformVersion  { get; set; }
//  public string DeviceName       { get; set; }
//  public string App              { get; set; }
//  public bool   AutoWebView      { get; set; }
//  public string AutomationName   { get; set; }

//  public TestCapabilities() {
//    this.BrowserName     = String.Empty;
//    this.FwkVersion      = String.Empty;
//    this.Platform        = DevicePlatform.Undefined;
//    this.PlatformVersion = String.Empty;
//    this.DeviceName      = String.Empty;
//    this.App             = String.Empty;
//    this.AutoWebView     = false;
//    this.AutomationName  = String.Empty;
//  }

//  public void AssignAppiumCapabilities(ref DesiredCapabilities appiumCapabilities) {
//    appiumCapabilities.SetCapability("browserName",     this.BrowserName);
//    appiumCapabilities.SetCapability("appium-version",  this.FwkVersion);
//    appiumCapabilities.SetCapability("platformName",    this.Platform2String(this.Platform));
//    appiumCapabilities.SetCapability("platformVersion", this.PlatformVersion);
//    appiumCapabilities.SetCapability("deviceName",      this.DeviceName);
//    appiumCapabilities.SetCapability("autoWebview",     this.AutoWebView);

//    // App push (will be covered later)
//    if (this.App != String.Empty)
//      appiumCapabilities.SetCapability("app", this.App);
//  }

//  /// Converting to string the platform (for Appium)
//  private string Platform2String(DevicePlatform value) {
//    switch (value) {
//    case DevicePlatform.Windows:
//      return "win"; /* TODO: Need to write your own extension of Appium for this */
//    case DevicePlatform.IOS:
//      return "iOS";
//    case DevicePlatform.Android:
//      return "Android";
//    default:
//      return "";
//    }
//  }

//  public sealed class TestCapabilities
//  {
//      /// Tracking platforms  
//      public enum DevicePlatform
//      {
//          Undefined,
//          Windows,
//          IOS,
//          Android
//      }

//      public string BrowserName { get; set; }
//      public string FwkVersion { get; set; }
//      public DevicePlatform Platform { get; set; }
//      public string PlatformVersion { get; set; }
//      public string DeviceName { get; set; }
//      public string App { get; set; }
//      public bool AutoWebView { get; set; }
//      public string AutomationName { get; set; }

//      public TestCapabilities()
//      {
//          this.BrowserName = String.Empty;
//          this.FwkVersion = String.Empty;
//          this.Platform = DevicePlatform.Undefined;
//          this.PlatformVersion = String.Empty;
//          this.DeviceName = String.Empty;
//          this.App = String.Empty;
//          this.AutoWebView = false;
//          this.AutomationName = String.Empty;
//      }

//      public void AssignAppiumCapabilities(ref DesiredCapabilities appiumCapabilities)
//      {
//          appiumCapabilities.SetCapability("browserName", this.BrowserName);
//          appiumCapabilities.SetCapability("appium-version", this.FwkVersion);
//          appiumCapabilities.SetCapability("platformName", this.Platform2String(this.Platform));
//          appiumCapabilities.SetCapability("platformVersion", this.PlatformVersion);
//          appiumCapabilities.SetCapability("deviceName", this.DeviceName);
//          appiumCapabilities.SetCapability("autoWebview", this.AutoWebView);

//          // App push (will be covered later)
//          if (this.App != String.Empty)
//              appiumCapabilities.SetCapability("app", this.App);
//      }

//      /// Converting to string the platform (for Appium)
//      private string Platform2String(DevicePlatform value)
//      {
//          switch (value)
//          {
//              case DevicePlatform.Windows:
//                  return "win"; /* TODO: Need to write your own extension of Appium for this */
//              case DevicePlatform.IOS:
//                  return "iOS";
//              case DevicePlatform.Android:
//                  return "Android";
//              default:
//                  return "";
//          }
//      }
//  }
//}