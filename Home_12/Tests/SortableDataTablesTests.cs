using OpenQA.Selenium;

namespace Home_12.Tests
{
    public class SortableDataTablesTests : BaseTest
    {
        [TestCase("1", "2")]
        [TestCase("2", "3")]
        public void SortableDataTablesTest(string tableNum, string rowNum)
        {
            NavigationHelper.NavigateAndAssertPage("Sortable Data Tables", chrome);

            var initialElementsTable = chrome.FindElements(By.XPath($"//table[{tableNum}]//tr//td[{rowNum}]")).Select(x => x.Text).ToList();
            var sortButtonTable = chrome.FindElement(By.XPath($"//table[{tableNum}]//th[{rowNum}]"));
            sortButtonTable.Click();

            var sortedElementsTable1 = chrome.FindElements(By.XPath($"//table[{tableNum}]//tr//td[{rowNum}]")).Select(x => x.Text).ToList();

            initialElementsTable.Sort();
            CollectionAssert.AreEqual(initialElementsTable, sortedElementsTable1);
        }
    }
}