using System;
using System.Collections.Generic;
using System.Text;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;

namespace addressbook_tests_white
{
    public class ApplicationManager
    {
        private GroupHelper grHelper;
        public Window MainWindow 
        {
            get;
            private set;
        }
        public GroupHelper Groups
        {
            get
            {
                return grHelper;
            }
        }
        public ApplicationManager()
        {
            Application app = Application.Launch(BaseConfigData.AppSysPath);
            MainWindow = app.GetWindow(BaseConfigData.AppMainWindowName);

            grHelper = new GroupHelper(this);
        }
        public void Stop()
        {
            MainWindow.Get<Button>("uxExitAddressButton").Click();
        }
    }
}
