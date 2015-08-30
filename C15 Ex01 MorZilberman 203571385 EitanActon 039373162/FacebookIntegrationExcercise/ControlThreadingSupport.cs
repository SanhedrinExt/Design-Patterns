using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacebookIntegrationExcercise
{
    public static class ControlThreadingSupport
    {
        public static void ThreadSafeControlUpdate(this Control i_Control, MethodInvoker i_ActionToPerform)
        {
            if (i_Control.InvokeRequired)
            {
                i_Control.Invoke(i_ActionToPerform);
            }
            else
            {
                i_ActionToPerform();
            }
        }
    }
}
