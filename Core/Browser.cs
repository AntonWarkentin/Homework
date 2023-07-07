﻿using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Core
{
    public class Browser
    {
        private static Browser instance = null;

        public static Browser Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Browser();
                }

                return instance;
            }
        }

        private IWebDriver driver;
        public IWebDriver Driver { get { return driver; } }

        private Browser()
        {
            var implicitWait = JObject.Parse(File.ReadAllText("appdata.json"))["ImplicitWait"].ToObject<double>();
            var downloadPath = JObject.Parse(File.ReadAllText("appdata.json"))["DownloadPath"];

            if (downloadPath != null)
            {
                var chromeOptions = new ChromeOptions();
                chromeOptions.AddUserProfilePreference("download.default_directory", downloadPath.ToString());

                driver = new ChromeDriver(chromeOptions);
            }
            else
            {
                driver = new ChromeDriver();
            }
            
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(implicitWait);
            driver.Manage().Window.Maximize();
        }

        public void CloseBrowser()
        {
            driver?.Dispose();
            instance = null;
        }

        public void NavigateToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public BasePage OpenNewPageByClick(IWebElement element, int secondsToWait = 0, string partToDeleteStartsWith = "")
        {
            element.Click();
            Thread.Sleep(secondsToWait * 1000);

            var finalPath = driver.Url;

            if (partToDeleteStartsWith != string.Empty)
            {
                finalPath = finalPath.Substring(0, finalPath.IndexOf(partToDeleteStartsWith));
            }

            return NavigationHelper.CreatePageObject(finalPath);
        }
    }
}
