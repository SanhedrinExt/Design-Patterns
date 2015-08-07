using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Net;
using System.IO;

namespace FacebookIntegrationExcercise
{
    static class TwitchAPIWrapper
    {
        private static bool m_IsStreamRunning = false;

        /// <summary>
        /// The address of the stream api branch we need to use to check if the stream is running.
        /// </summary>
        public static string TwitchAPIStreamPath
        {
            get
            {
                return "https://api.twitch.tv/kraken/streams/";
            }
        }

        /// <summary>
        /// The address of the twitch homepage
        /// </summary>
        public static string TwitchBaseAddress
        {
            get
            {
                return "http://www.twitch.tv/";
            }
        }

        /// <summary>
        /// Checks if the channel named i_ChannelName has just started a stream on Twitch.tv
        /// </summary>
        /// <param name="i_ChannelName">Channel name</param>
        /// <returns>true if stream started, false if it was already caught as running during the current stream or if not streaming</returns>
        /// <Todo>Add threading for the HTTP request to make it async, once we learn it in class.</Todo>
        public static bool CheckIfStreamStarted(string i_ChannelName)
        {
            bool streamStarted = false;

            using (Stream responseStream = WebRequest.Create(string.Format("{0}{1}", TwitchAPIStreamPath, i_ChannelName)).GetResponse().GetResponseStream())
            {
                string apiResponse = new StreamReader(responseStream).ReadToEnd();
                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                TwitchStream twitchStreamObject = jsonSerializer.Deserialize<TwitchStream>(apiResponse);

                if (twitchStreamObject.stream != null && !m_IsStreamRunning)
                {
                    streamStarted = true;
                    m_IsStreamRunning = true;
                }
                else if (twitchStreamObject.stream == null)
                {
                    m_IsStreamRunning = false;
                }
            }

            return streamStarted;
        }

        public static bool CheckIfChannelExists(string i_ChannelName)
        {
            bool channelExists = true;

            try
            {
                WebRequest.Create(string.Format("{0}{1}", TwitchAPIStreamPath, i_ChannelName)).GetResponse();
            }
            catch (WebException webException)
            {
                channelExists = false;
            }
            
            return channelExists;
        }
    }
}
