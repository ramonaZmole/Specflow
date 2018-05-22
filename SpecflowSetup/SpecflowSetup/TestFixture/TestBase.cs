﻿using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecflowSetup.Pages;
using SpecflowSetup.Steps;
using TechTalk.SpecFlow;

namespace SpecflowSetup.TestFixture
{
    [Binding]
    [SetUpFixture]
    public class TestBase
    {
        public static IWebDriver Driver;

        public static IWebDriver TestBaseinit => Driver;

        [BeforeScenario]
        public static void SetUpDriver()
        {
            var options = new ChromeOptions();
            options.AddArguments("start-maximized");
            Driver = new ChromeDriver(options);
            Driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 2);

            AbstractPage.SetupDriver(Driver);

        }

        [AfterScenario]
        public static void TeardownEditorDriver()
        {
            Driver.Close();
            Driver.Quit();
        }
    }
}
