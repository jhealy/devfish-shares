using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SelniumTest01
{
    // next up headless
    class Program
    {
        static IWebDriver m_driverGC;
        static void Main(string[] args)
        {
            if (args.Length==0)
            {
                ConsoleColor oldColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(@"Please pass a url for the target web as a parameter.   Example:  seleniumdockertext.exe http://localhost:32325");
                Console.ForegroundColor = oldColor;
            }

            string targetUrl;
            targetUrl = args[0].ToString();

            Console.WriteLine($"Target Url={targetUrl}");

            try
            {
                ChromeOptions option = new ChromeOptions();
                option.AddArgument("--headless");

                using (m_driverGC = new ChromeDriver(option))
                {
                    //m_driverGC.Navigate().GoToUrl(@"http://localhost:33235");
                    m_driverGC.Navigate().GoToUrl(targetUrl);

                    //TestChromeDriver();
                    string msg = "hello world";
                    Console.WriteLine($"CheckWebElements('{msg}')={CheckWebElements(msg)}");
                    msg = "Matias Bruno";
                    Console.WriteLine($"CheckWebElements('{msg}')={CheckWebElements(msg)}");

                    // Console.WriteLine("tests complete, hit enter to exit");
                    // Console.ReadLine();

                    m_driverGC.Close();
                    m_driverGC.Quit();
                }
            }
            catch ( Exception ex )
            {
                Console.WriteLine("!!!error:" + ex.ToString());
            }
        }

        static public bool CheckWebElements(string msg)
        {
            if (string.IsNullOrWhiteSpace(msg)) return false;
            msg = msg.ToLower();
            return m_driverGC.FindElement(By.Id("myH1")).Text.ToLower().Contains(msg);
        }

        static public bool CheckWebElements2()
        {
            bool retval = true;
            IWebElement element = m_driverGC.FindElement(By.Id("myH1"));
            string elementText = element.Text.ToLower();
            return elementText.Contains("joe healy");
        }

        static public void TestChromeDriver()
        {
            m_driverGC.Navigate().GoToUrl(@"http://localhost:33235");
            m_driverGC.FindElement(By.Id("myText")).SendKeys("probably nothing");
        }
    }
}
