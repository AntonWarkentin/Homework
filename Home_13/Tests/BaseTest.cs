﻿using Core;

namespace Home_13
{
    public class BaseTest
    {
        [TearDown]
        public void TearDown()
        {
            Browser.Instance.CloseBrowser();
        }
    }
}
