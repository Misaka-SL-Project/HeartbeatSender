using System;
using System.Net.Http;
using System.Threading;
using Exiled.API.Features;

namespace HeartbeatSender
{
    public class Plugin : Plugin<Config>
    {
        private Thread heartbeatThread;
        public override void OnEnabled()
        {
            heartbeatThread = new Thread(new ThreadStart(HeartbeatThread));
            heartbeatThread.Start();
            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            heartbeatThread.Abort();
            base.OnDisabled();
        }

        private void HeartbeatThread()
        {
            if (string.IsNullOrEmpty(Config.URL))
            {
                heartbeatThread.Abort();
            }

            HttpClient client = new HttpClient();
            for (; ; )
            {
                try
                {
                    client.SendAsync(new HttpRequestMessage(HttpMethod.Post, Config.URL));
                    Log.Debug("Heartbeat message sent");
                } catch (Exception e)
                {
                    Log.Error("HeartbeatSender throws an exception: " + e);
                }

                Thread.Sleep(Config.Period * 1000);
            }
        }
    }
}
