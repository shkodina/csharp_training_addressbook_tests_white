using System;
using System.Collections.Generic;

using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.InputDevices;
using TestStack.White.WindowsAPI;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.UIItems.WindowItems;

using System.Windows.Automation;

namespace addressbook_tests_white
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager applicationManager) : base (applicationManager)
        {
        }

        public List<GroupData> GetList()
        {
            List<GroupData> grList = new List<GroupData>();

            Tree tree = currentWindow.Get<Tree>("uxAddressTreeView");
            TreeNode root = tree.Nodes[0];
            
            foreach(TreeNode item in root.Nodes)
            {
                grList.Add(new GroupData()
                {
                    Name = item.Text
                }
                );
            }

            CloseGroupsWindow();
            return grList;
        }

        public GroupHelper RemoveAt(int victumIndex)
        {
            // select by index
            // click Delete
            // confirm delete
            /*
            manager.Aux.ControlTreeView(
                   BaseConfigData.AppGrEditorWindowName
                   , ""
                   , "WindowsForms10.SysTreeView32.app.0.2c908d51"
                   , "Select"
                   , "#0|#" + victumIndex
                   , ""
                   );

            manager.Aux.ControlClick(BaseConfigData.AppGrEditorWindowName, "", "WindowsForms10.BUTTON.app.0.2c908d51");

            this.ThreeStepWinActivate("Delete group");

            manager.Aux.ControlClick("Delete group", "", "WindowsForms10.BUTTON.app.0.2c908d53");

            manager.Aux.WinWaitClose("Delete group", "", 10);

            */
            return this;
        }

        public GroupHelper Add(GroupData gr)
        {
            currentWindow.Get<Button>("uxNewAddressButton").Click();
            TextBox tb = (TextBox) currentWindow.Get(SearchCriteria.ByControlType(ControlType.Edit));
            tb.Enter(gr.Name);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            //System.Windows.Forms.SendKeys.Send("{ENTER}");

            // TODO
            //manager.Aux.Send(gr.Name);
            //manager.Aux.Send("{ENTER}");
            return this;

        }

        public GroupHelper CloseGroupsWindow()
        {
            if (currentWindow == null)
                return this;
            currentWindow.Get<Button>("uxCloseAddressButton").Click();
            currentWindow = null;
            return this;
        }

        public GroupHelper OpenGroupsWindow()
        {
            manager.MainWindow.Get<Button>("groupButton").Click();
            currentWindow = manager.MainWindow.ModalWindow(BaseConfigData.AppGrEditorWindowName);
            return this;
        }
    }
}