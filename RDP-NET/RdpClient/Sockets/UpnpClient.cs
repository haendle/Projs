using Mono.Nat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RdpClient.Sockets
{
    internal class UpnpClient
    {
        private INatDevice _device;

        public UpnpClient() 
        {
            NatUtility.DeviceFound += DeviceFound;
            NatUtility.StartDiscovery();
        }

        public void CreatePortMapping(int interPort, int exterPort)
        {
            var mapping = new Mapping(Protocol.Tcp, interPort, exterPort);
            _device.CreatePortMap(mapping);
        }

        public void DeletePortMapping(int interPort)
        {
            if (interPort != 0)
            {
                var mappings = _device.GetAllMappings();

                foreach (Mapping mp in mappings)
                {
                    if (mp.PrivatePort == interPort)
                    {
                        _device.DeletePortMap(mp);
                    }
                }
            }
        }

        private void DeviceFound(object sender, DeviceEventArgs args)
        {
            _device = args.Device;
        }
    }
}
