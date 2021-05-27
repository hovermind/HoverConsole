using AzureKeyVaultUtility;
using Microsoft.Extensions.Configuration;
using System;
using static ConsoleApp.AzureKeyVaultAccess.Constants.KeyVault;
using static System.Diagnostics.Debug;
using static ConsoleApp.AzureKeyVaultAccess.Constants.Kafka;
using System.Collections.Generic;
using Confluent.Kafka;

namespace ConsoleApp.AzureKeyVaultAccess
{
    public class EntryPoint
    {
        private readonly IConfiguration _configuration;

        public EntryPoint(IConfiguration config)
        {
            _configuration = config;
        }

        public void Run(String[] args)
        {

            #region DB Connection String from Azure KeyVault

            //
            // DB Connection String
            //
            var dbConnectionString = _configuration[_configuration[AzureSQLDBConnectionStringIdentifier]];

            WriteLine("\n\n\n\n\n");
            WriteLine("======================================= DB Connection String ==========================================\n\n");
            WriteLine(dbConnectionString);
            WriteLine("\n\n=================================================================================");
            WriteLine("\n\n\n\n\n");

            #endregion

            #region Kafka Consumer / Producer

            var clusterCaLocation = SecretAsCertificateLocalStore.SaveCertificateAndGetFileUri(configuration: _configuration, certificateSecretName: _configuration[KafkaClusterCaSecretIdentifier]);
            var adminUserCertificateLocation = SecretAsCertificateLocalStore.SaveCertificateAndGetFileUri(configuration: _configuration, certificateSecretName: _configuration[KafkaAdminUserCertSecretIdentifier]);
            var adminUserKeyLocation = SecretAsCertificateLocalStore.SavePrivateKeyAndGetFileUri(configuration: _configuration, privateKeySecretName: _configuration[KafkaAdminUserKeySecretIdentifier]);
            var kafkaBootstrapServer = "";
            var kafkaClientCommunicationProtocol = "SSL";

            //
            // Create kafka producer / consumer
            //
            var configProperties = new Dictionary<string, string>
            {
                [KEY_BOOTSTRAP_SERVERS] = kafkaBootstrapServer,
                [KEY_SECURITY_PROTOCOL] = kafkaClientCommunicationProtocol,
                [KEY_SSL_CA_LOCATION] = clusterCaLocation,
                [KEY_SSL_CERTIFICATE_LOCATION] = adminUserCertificateLocation,
                [KEY_SSL_KEY_LOCATION] = adminUserKeyLocation
            };

            var producerConfig = new ProducerConfig(configProperties);

            #endregion

        }
    }
}
