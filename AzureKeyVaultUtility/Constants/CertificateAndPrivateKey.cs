using System;
using System.Collections.Generic;
using System.Text;

namespace AzureKeyVaultUtility.Constants
{
    public class CertificateAndPrivateKey
    {
        private CertificateAndPrivateKey()
        {

        }

        public const string BEGIN_CERT = "-----BEGIN CERTIFICATE-----";
        public const string END_CERT = "-----END CERTIFICATE-----";
        public const string BEGIN_PRIVATEKEY = "-----BEGIN PRIVATE KEY-----";
        public const string END_PRIVATEKEY = "-----END PRIVATE KEY-----";

        public const string DefaultCertificateFolderName = "certs";
        public const string DefaultCertificateFileExtension = ".crt";
        public const string DefaultPrivateKeyExtention = ".key";
    }
}
