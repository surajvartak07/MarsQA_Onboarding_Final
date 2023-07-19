using MarsQA_1.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V113.FedCm;
using OpenQA.Selenium.Support.UI;
using RazorEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace MarsQA_1.SpecflowPages.Pages
{
    public class Skills
    {

        IWebElement AddNewSkillButton => Driver.driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
        IWebElement SkillName => Driver.driver.FindElement(By.Name("name"));
        IWebElement SkillLevelDropdown => Driver.driver.FindElement(By.Name("level"));
        IWebElement AddButton => Driver.driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]"));
        IWebElement SkillsTab => Driver.driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
        IWebElement RemoveButton => Driver.driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[2]/i"));
        IWebElement SkillName1 => Driver.driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[1]"));
        IWebElement SkillName2 => Driver.driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[2]/tr/td[1]"));
        IWebElement SkillName3 => Driver.driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[3]/tr/td[1]"));
        IWebElement SkillName4 => Driver.driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[4]/tr/td[1]"));
        IWebElement SkillName5 => Driver.driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[5]/tr/td[1]"));
        IWebElement EditButton => Driver.driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[1]/i"));
        IWebElement UpdateButton => Driver.driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[1]/tr/td/div/span/input[1]"));
        IWebElement CancelButton => Driver.driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[2]"));
        IWebElement Popup => Driver.driver.FindElement(By.ClassName("ns-box-inner"));


        //Duplicate skills cant be added so cleanup the existing skills first 
        public void CleanSkillsTable()
        {
            try
            {
                while (RemoveButton.Displayed) //once all skills are deleted, remove button wont be displayed and loop will end
                {
                    RemoveButton.Click();
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void NavigateToSkillsTab()
        {
            SkillsTab.Click();
            Thread.Sleep(2000);
        }

        public void AddNewSkill(string skillName, string skillLevel)
        {
            //Thread.Sleep(1000);
            AddNewSkillButton.Click();

            SkillName.SendKeys(skillName);
            //Thread.Sleep(2000);
            SkillLevelDropdown.Click();
            //Thread.Sleep(2000);
            var SelectElement = new SelectElement(SkillLevelDropdown);

            SelectElement.SelectByValue(skillLevel);
            //Thread.Sleep(2000);
            AddButton.Click();
        }

        public string ValidateAddedSkill(string skillName)
        {
            switch (skillName)
            {
                case "Cooking":
                    return SkillName1.Text;

                case "Swimming":
                    return SkillName2.Text;

                case "Automation Testing":
                    return SkillName3.Text;

                case "Manual Testing":
                    return SkillName4.Text;

                case "Pet Sitting":
                    return SkillName5.Text;

                default:
                    return string.Empty;

            }

        }

        public void EditSkill()
        {
            EditButton.Click();

            SkillName.Clear();
            SkillName.SendKeys("Edited");

            var SelectLevel = new SelectElement(SkillLevelDropdown);
            SelectLevel.SelectByValue("Intermediate");

            UpdateButton.Click();

            // Thread.Sleep(3000);
        }

        public string ValidateEditedSkill()
        {
            return SkillName1.Text;
        }

        public bool ValidateSkillIsDeleted()
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

        public void AddSkillPartially()
        {
            AddNewSkillButton.Click();
            SkillName.SendKeys("BDD Framework");
            var SelectLevel = new SelectElement(SkillLevelDropdown);
            SelectLevel.SelectByValue("Beginner");

        }
        public void CancelAdding()
        {
            CancelButton.Click();
        }

        public bool ValidateSkillNotAdded()
        {
            if (Driver.driver.PageSource.Contains("BDD Framework"))
            {
                return false;
            }

            else
            {
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
    }
}
