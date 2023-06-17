using Home_14.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_14
{
    public static class DynamicControlsTestCases
    {
        public static void RemoveCheckboxAndAssert(this DynamicControlsPage dynamicControlsPage)
        {
            dynamicControlsPage.AssertCheckboxVisibility(true);
            dynamicControlsPage.ClickCheckBoxButton();
            dynamicControlsPage.AssertCheckboxVisibility(false);
            dynamicControlsPage.AssertCheckBoxMessage("It's gone!");
        }
        
        public static void EnableInputAndAssert(this DynamicControlsPage dynamicControlsPage)
        {
            //dynamicControlsPage.AssertInputIsDisabled(true);
            dynamicControlsPage.ClickTextButton();
            dynamicControlsPage.AssertInputIsDisabled(false);
            dynamicControlsPage.AssertInputMessage("It's enabled!");
        }
    }
}
