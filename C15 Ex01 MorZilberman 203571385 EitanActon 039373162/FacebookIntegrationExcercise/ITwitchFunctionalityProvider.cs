using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookIntegrationExcercise
{
    public interface ITwitchFunctionalityProvider
    {
        bool CheckIfStreamStarted(string i_ChannelName);
        bool CheckIfChannelExists(string i_ChannelName);
    }
}
