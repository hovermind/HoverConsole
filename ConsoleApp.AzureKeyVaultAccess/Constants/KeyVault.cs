using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.AzureKeyVaultAccess.Constants
{
    public class KeyVault
    {
        private KeyVault() { }

        public const string KeyVaultNameKey = "AzureKeyVaultName";

        public const string AzureSQLDBConnectionStringIdentifier = "AzureSQLDBConnectionStringIdentifier";

        public const string KafkaClusterCaSecretIdentifier = "KafkaClusterCaSecretIdentifier";
        public const string KafkaAdminUserCertSecretIdentifier = "KafkaAdminUserCertSecretIdentifier";
        public const string KafkaAdminUserKeySecretIdentifier = "KafkaAdminUserKeySecretIdentifier";
    }
}
