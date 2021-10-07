using System;
using System.Linq;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace OpenCartSelenium
{
    class ProductComparison : AStatusBarComponent
    {
        private List<IWebElement> _products;
        private List<double> _prices;
        private List<IWebElement> _removeButtons;
        
        public ProductComparison(IWebDriver driver) : base(driver)
        {
            initProductComparison();
        }

        private void initProductComparison()
        {
            _products = new List<IWebElement>();
            _prices = new List<double>();
            _removeButtons = new List<IWebElement>();

            var elements = driver.FindElements(By.XPath("//*[@id='content']/table/tbody[1]/tr[1]/td"));
            for (int i = 1; i < elements.Count; i++)
                _products.Add(elements[i]);

            elements = driver.FindElements(By.XPath("//*[@id='content']/table/tbody[1]/tr[3]/td"));
            for (int i = 1; i < elements.Count; i++)
            {
                string price = Regex.Replace(elements[i].Text.Trim(new char[] { '$', '€', '£' }), @"\s+", "").Replace('.', ','); 
                _prices.Add(Double.Parse(price));
            }

            foreach (var item in driver.FindElements(By.CssSelector(".btn.btn-danger.btn-block")))
                _removeButtons.Add(item);
        }

        public IEnumerable<string> ProductsName => _products.Select(x => x.Text);
        public IEnumerable<double> Prices => _prices;

        public void ClickRemoveButtonByID(int id)
            => _removeButtons[id].Click();
        public void ClickRemoveButtonByText(string text)
            => _removeButtons.First(x => x.Text == text).Click();
    }
}
