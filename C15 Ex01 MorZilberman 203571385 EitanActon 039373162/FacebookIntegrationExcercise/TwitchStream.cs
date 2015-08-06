using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookIntegrationExcercise
{
    /// <summary>
    /// The object used to deserialize a Twitch stream.
    /// The only thing we request is to check if the stream object is null or not, so we don't need to extend
    /// usability beyond that for our application's purposes.
    /// </summary>
    class TwitchStream
    {
        public object _links { get; set; }
        public object stream { get; set; }

        public TwitchStream()
        {
        }
    }
}
