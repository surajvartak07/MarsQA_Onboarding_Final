using MarsQA_1.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace MarsQA_1.SpecflowPages.Pages
{
    public class Languages
    {

        IWebElement RemoveButton => Driver.driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[2]/i"));
        
        IWebElement AddLanguageButton => Driver.driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
        
        IWebElement Language => Driver.driver.FindElement(By.Name("name"));
        
        IWebElement LanguageLevelDropdown => Driver.driver.FindElement(By.Name("level"));
        
        IWebElement AddButton => Driver.driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]"));
        
        IWebElement EditButton => Driver.driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i"));
        
        IWebElement LanguageName1 => Driver.driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]"));
        
        IWebElement LanguageName2 => Driver.driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[2]/tr/td[1]"));
        
        IWebElement LanguageName3 => Driver.driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[3]/tr/td[1]"));
        
        IWebElement LanguageName4 => Driver.driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[4]/tr/td[1]"));
        
        IWebElement UpdateButton => Driver.driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]"));
        
        IWebElement EditedLanguageName => Driver.driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]"));
        
        IWebElement CancelButton => Driver.driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[2]"));
        
        IWebElement Popup => Driver.driver.FindElement(By.ClassName("ns-box-inner"));
        
        public void CleanLanguageTable()
        {
            try
            {

                while (RemoveButton.Displayed) //once all languages are deleted, remove button wont be displayed and loop will end
                {
                    RemoveButton.Click();
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            };
        }

        //Add new language 
        public void AddLanguage(String LanguageName, String LanguageLevel)
        {
            AddLanguageButton.Click();

            Language.SendKeys(LanguageName);
            LanguageLevelDropdown.Click();
            var SelectElement = new SelectElement(LanguageLevelDropdown);

            SelectElement.SelectByValue(LanguageLevel);

            AddButton.Click();

        }

        public string ValidateAddedLanguage(string languageName)
        {
            switch (languageName)
            {
                case "Marathi":
                    return LanguageName1.Text;

                case "Sanskrit":
                    return LanguageName2.Text;

                case "English":
                    return LanguageName3.Text;

                case "Hindi":
                    return LanguageName4.Text;
                default:
                    return string.Empty;

            }

        }

        public void AddFourLanguages()
        {

            string[] languages = { "Marathi", "English", "Hindi", "Sanskrit" };

            foreach (var lang in languages)
            {
                AddLanguage(lang, "Fluent");
            }
        }
        public bool ValidateMaxLanguageLimit()
        {

            try
            {
                AddLanguageButton.Click();
                return false;
            }

            catch (Exception ex)
            {
                return true;
            }

        }

        //Edit existing language
        public void EditLanguage()
        {
            EditButton.Click();

            Language.Clear();
            Language.SendKeys("MarathiEdited");

            var SelectLevel = new SelectElement(LanguageLevelDropdown);
            SelectLevel.SelectByValue("Fluent");

            UpdateButton.Click();

            Thread.Sleep(3000);
        }

        public string ValidateEditedLanguage()
        {
            return EditedLanguageName.Text;
        }

        public void DeleteLanguage()
        {
            RemoveButton.Click();
        }
        //If remove button element is not found, it means no language exists in list, so we have deleted the language successfully 
        public bool ValidateLanguageIsDeleted()
        {
            try
            {
                RemoveButton.Click();
                return false;
            }
            catch
            {
                return true;
            }

        }

        public void AddLanguagePartially()
        {
            AddLanguageButton.Click();
            Language.SendKeys("Hindi");
            var SelectLevel = new SelectElement(LanguageLevelDropdown);
            SelectLevel.SelectByValue("Fluent");

        }
        public void CancelAdding()
        {
            CancelButton.Click();
        }

        public bool ValidateNotAdded()
        {
            try
            {
                return RemoveButton.Displayed;
            }
            catch (Exception ex)
            {
                //Return true if remove button does not exist
                return true;
            }
        }

        public string ValidatePopup()
        {
            try
            {

                return Popup.Text;
            }
            catch (Exception ex)
            {
                return "Popup element not found";
            }
        }

        public void AddLanguageWithoutLevel()
        {
            AddLanguageButton.Click();
            Language.SendKeys("English");
            AddButton.Click();
        }

        public void AddLanguageWithoutName()
        {
            AddLanguageButton.Click();
            var SelectLevel = new SelectElement(LanguageLevelDropdown);
            SelectLevel.SelectByValue("Fluent");
            AddButton.Click();
        }
        public void AddLanguageWithSpaceAsLanguageName()
        {
            AddLanguageButton.Click();
            Language.SendKeys("   ");
            var SelectLevel = new SelectElement(LanguageLevelDropdown);
            SelectLevel.SelectByValue("Fluent");
            AddButton.Click();
            Thread.Sleep(3000);
        }


        public string ValidateAddedBadLanguage(string badlanguageName)
        {
            switch (badlanguageName)
            {
                case "abcabcabcabcabcabcskmseklnmseklvsnskslkmslksskvjlnsdkj":
                    return LanguageName1.Text;

                case "123%^*&#23JDSSS svsvnsi2378463":
                    return LanguageName2.Text;
                default:
                    return string.Empty;

            }
        }
    }
}
