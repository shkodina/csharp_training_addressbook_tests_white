using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;

namespace addressbook_tests_white
{
    public class HelperBase
    {
        protected ApplicationManager manager;
        protected Window currentWindow;

        public HelperBase(ApplicationManager applicationManager)
        {
            this.manager = applicationManager;
        }
    }
}