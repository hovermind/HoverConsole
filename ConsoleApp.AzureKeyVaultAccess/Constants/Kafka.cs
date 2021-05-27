using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.AzureKeyVaultAccess.Constants
{
    public class Kafka
    {
        private Kafka()
        {

        }

        //
        // librdkafka CONFIGURATION: https://github.com/edenhill/librdkafka/blob/master/CONFIGURATION.md
        //
        public const string KEY_BOOTSTRAP_SERVERS = "bootstrap.servers";
        public const string KEY_SECURITY_PROTOCOL = "security.protocol";
        public const string KEY_SSL_CA_LOCATION = "ssl.ca.location";
        public const string KEY_SSL_CERTIFICATE_LOCATION = "ssl.certificate.location";
        public const string KEY_SSL_KEY_LOCATION = "ssl.key.location";
    }
}
