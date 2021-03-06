﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Net;
using System.IO;

namespace FacebookIntegrationExcercise
{
    public class TwitchAPIWrapper : ITwitchFunctionalityProvider
    {
        /// <summary>
        /// The object used to deserialize a Twitch stream.
        /// The only thing we request is to check if the stream object is null or not, so we don't need to extend
        /// usability beyond that for our application's purposes.
        /// </summary>
        public class TwitchStream
        {
            public object _links { get; set; }
            public object stream { get; set; }

            public TwitchStream()
            {
            }
        }

        private bool m_IsStreamRunning = false;

        /// <summary>
        /// The address of the stream api branch we need to use to check if the stream is running.
        /// </summary>
        public const string TwitchAPIStreamPath = "https://api.twitch.tv/kraken/streams/";
           
        /// <summary>
        /// The address of the twitch homepage
        /// </summary>
        public const string TwitchBaseAddress = "http://www.twitch.tv/";

        private TwitchAPIWrapper()
        {
        }

        /// <summary>
        /// Checks if the channel named i_ChannelName has just started a stream on Twitch.tv
        /// </summary>
        /// <param name="i_ChannelName">Channel name</param>
        /// <returns>true if stream started, false if it was already caught as running during the current stream or if not streaming</returns>
        /// <Todo>Add threading for the HTTP request to make it async, once we learn it in class.</Todo>
        public bool CheckIfStreamStarted(string i_ChannelName)
        {
            bool streamStarted = false;

            try
            {
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
            }
            catch (WebException webEx)
            {
                streamStarted = false;
            }

            return streamStarted;
        }

        public bool CheckIfChannelExists(string i_ChannelName)
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
