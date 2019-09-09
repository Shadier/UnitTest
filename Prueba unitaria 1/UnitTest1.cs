using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Prueba_unitaria_1
{
    [TestClass]
    public class UnitTest1
    {
        public static IWebDriver WebDriver;
        public static string baseURL = "https://fs19.formsite.com/vTUJhX/upkauxsphd/index.html";

        string name = "RESULT_TextField-2";
        string lastname = "RESULT_TextField-3";
        string address = "RESULT_TextField-4";
        string city = "RESULT_TextField-6";
        string province = "RESULT_RadioButton-7";
        string postalCode = "RESULT_TextField-8";
        string phone = "RESULT_TextField-9";
        string email = "RESULT_TextField-10";
        string membership = "label[for='RESULT_RadioButton-11_0']"; 
        string contactWay = "label[for='RESULT_RadioButton-12_1']";
        string terms = "label[for='RESULT_CheckBox-13_0']";
        string signature = "jSignature";
        string submit = "FSsubmit";

        [TestInitialize]
        public void MyTestInitialize()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized");
            WebDriver = new ChromeDriver(options);
            WebDriver.Navigate().GoToUrl(baseURL);
        }

        [TestMethod]
        public void TestMethod1()
        {
            var field_name = WebDriver.FindElement(By.Id(name));
            field_name.Clear();
            field_name.SendKeys("Raúl");

            var field_lastname = WebDriver.FindElement(By.Id(lastname));
            field_lastname.Clear();
            field_lastname.SendKeys("Moreno");

            var field_address = WebDriver.FindElement(By.Id(address));
            field_address.Clear();
            field_address.SendKeys("José Tavera Campos #83");

            var field_city = WebDriver.FindElement(By.Id(city));
            field_city.Clear();
            field_city.SendKeys("Morelia");

            var field_province = WebDriver.FindElement(By.Id(province));
            SelectElement provinceSelect = new SelectElement(field_province);
            provinceSelect.SelectByText("México");

            var field_postalCode = WebDriver.FindElement(By.Id(postalCode));
            field_postalCode.Clear();
            field_postalCode.SendKeys("58120");

            var field_phone = WebDriver.FindElement(By.Id(phone));
            field_phone.Clear();
            field_phone.SendKeys("4431443851");

            var field_email = WebDriver.FindElement(By.Id(email));
            field_email.Clear();
            field_email.SendKeys("raulmoreno899@gmail.com");


            var field_membership = WebDriver.FindElement(By.CssSelector(membership));
            field_membership.Click();

            var field_contactWay = WebDriver.FindElement(By.CssSelector(contactWay));
            field_contactWay.Click();

            var field_Terms = WebDriver.FindElement(By.CssSelector(terms));
            field_Terms.Click();

            IWebElement wbCanvas = WebDriver.FindElement(By.ClassName(signature));
            Actions actionBuilder = new Actions(WebDriver);
            IAction drawOnCanvas = actionBuilder
                .MoveToElement(wbCanvas, 100, 100)
                .ClickAndHold(wbCanvas)
                .MoveByOffset(200, 10)
                .MoveByOffset(0, 0)
                .MoveByOffset(140, 0)
                .Release(wbCanvas)
                .ClickAndHold(wbCanvas)
                .MoveByOffset(80, 30)
                .MoveByOffset(50, 0)
                .MoveByOffset(30, 10)
                .Release(wbCanvas)
                .Build();
            drawOnCanvas.Perform();
            Thread.Sleep(2000);


            var button_submit = WebDriver.FindElement(By.Id(submit));
            button_submit.Click();

            Thread.Sleep(2000);
            WebDriver.Quit();
        }
    }
}
