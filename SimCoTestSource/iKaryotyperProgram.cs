using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using iKaryotyper.SourceCode.Presentation;
using iKaryotyper.SourceCode.Business.CaseManagement.NavigatorManagement;
using iKaryotyper.SourceCode.Business.CaseManagement;
using iKaryotyper.SourceCode.Business;
using iKaryotyper.iIPL;

namespace iKaryotyper
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            /////////////////////////////////////////////
            IiKaryotyperSession iKaryotyperSession = new iKaryotyperSession();
            MainForm mainForm = new MainForm(iKaryotyperSession);
            iKaryotyperSession.GetNavigatorManager().InitiateNavigator(
                mainForm, mainForm.NavigatorTree, mainForm.NavigatorLabelCaseName);
            iKaryotyperSession.GetCommandExecuter().AddCommandExecuterListener(
                new UndoRedoButtonsToolTipUpdateListener(mainForm.UndoButton, mainForm.RedoButton,
                    mainForm.MainFormToolTip));

            MainFormViewController mainFormViewController = 
                new MainFormViewController(mainForm);
            MainFormCommandDispatcher mainFormCommandDispatcher =
                new MainFormCommandDispatcher(mainForm, iKaryotyperSession);
            mainForm.SetViewController(mainFormViewController);
            mainForm.SetCommandDispatcher(mainFormCommandDispatcher);
            iKaryotyperSession.SetProgamStateChangeRequest(
                mainFormViewController);
            Application.Run(mainForm);
        }
    }
}
