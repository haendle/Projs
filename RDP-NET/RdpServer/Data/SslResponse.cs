using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RdpServer.NetworkData
{
    internal class SslResponse
    {
        public string ConnectionString { get; }
        public string Host { get; }
        public string AccessLevel { get; }
        public string Result { get; }

        public SslResponse
        (
            string connectionString,
            string host,
            string access,
            string result
        )
        {
            ConnectionString = connectionString;
            Host = host;
            AccessLevel = access;
            Result = result;
        }
    }
}
