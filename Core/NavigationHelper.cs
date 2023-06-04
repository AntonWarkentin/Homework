﻿using System;
using System.Collections.Generic;

namespace Core
{
    public class NavigationHelper
    {
        private static Dictionary<string, Func<BasePage>> pages;

        public static BasePage CreatePageObject(string url)
        {
            return pages[url]();
        }
    }
}