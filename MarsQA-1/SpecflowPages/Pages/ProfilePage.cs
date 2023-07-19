using MarsQA_1.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarsQA_1.SpecflowPages.Pages
{
    public class ProfilePage
    {
        public string ValidateProfilePage()
        {
            Thread.Sleep(3000);
            String title = Driver.driver.Title;
            Console.WriteLine(title);
            return title;
        }

    }
}
