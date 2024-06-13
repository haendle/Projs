using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RdpClient.Data
{
    internal class HostInfo
    {
        public string HostName { get; private set; }
        public string EndpointWAN { get; private set; }
        public string EndpointLAN { get; private set; }
        public string FrameCaptureIntervalInMs { get; private set; }
        public string EnableClipboardRedirect { get; private set; }
        public string EnabledTransports { get; private set; }
        public string EnforceStrongEncryption { get; private set; }
        public string EnableAudioStream { get; private set; }   

        public HostInfo(string[] hostInfo) 
        {
            HostName = hostInfo[0];
            EndpointWAN = hostInfo[1];
            EndpointLAN = hostInfo[2];
            FrameCaptureIntervalInMs = hostInfo[3];
            EnableClipboardRedirect = hostInfo[4];
            EnabledTransports = hostInfo[5];
            EnforceStrongEncryption = hostInfo[6];
            EnableAudioStream = hostInfo[7];
        }
    }
}
