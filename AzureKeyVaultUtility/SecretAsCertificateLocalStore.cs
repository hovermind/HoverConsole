using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using static AzureKeyVaultUtility.Constants.CertificateAndPrivateKey;

namespace AzureKeyVaultUtility
{
    public class SecretAsCertificateLocalStore
    {
        private SecretAsCertificateLocalStore()
        {

        }

        private static string CertificateFolderUri { get; set; } = string.Empty;

        private static void EnsureCertFolder()
        {

            if (!string.IsNullOrEmpty(CertificateFolderUri))
            {
                return;
            }

            string projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            CertificateFolderUri = Path.Combine(projectPath, DefaultCertificateFolderName);

            try
            {
                Directory.CreateDirectory(CertificateFolderUri);
            }
            catch (Exception)
            {
                // handle them here
            }
        }


        public static string SaveCertificateAndGetFileUri(IConfiguration configuration, string certificateSecretName, string certificateFileExtension = DefaultCertificateFileExtension)
        {
            EnsureCertFolder();

            var certFileUri = $"{CertificateFolderUri}\\{certificateSecretName}{certificateFileExtension}";

            var secretValue = configuration[certificateSecretName];

            var base64String = $"{BEGIN_CERT}\n{secretValue}\n{END_CERT}";

            using (StreamWriter sw = File.CreateText(certFileUri))
            {
                sw.Write(base64String);
            }

            return certFileUri;
        }

        public static string SaveCertificateAndGetFileUri(SecretClient secretClient, string certSecretName, string certFileExtension = DefaultCertificateFileExtension)
        {
            EnsureCertFolder();

            var certFileUri = $"{CertificateFolderUri}\\{certSecretName}{certFileExtension}";

            var secret = secretClient.GetSecret(certSecretName);

            var base64String = $"{BEGIN_CERT}\n{secret.Value.Value}\n{END_CERT}";

            using (StreamWriter sw = File.CreateText(certFileUri))
            {
                sw.Write(base64String);
            }

            return certFileUri;
        }

        public static string SavePrivateKeyAndGetFileUri(IConfiguration configuration, string privateKeySecretName, string keyFileExtension = DefaultPrivateKeyExtention)
        {
            EnsureCertFolder();

            var privateKeyFileUri = $"{CertificateFolderUri}\\{privateKeySecretName}{keyFileExtension}";

            var secretValue = configuration[privateKeySecretName];

            var base64String = $"{BEGIN_PRIVATEKEY}\n{secretValue}\n{END_PRIVATEKEY}";

            using (StreamWriter sw = File.CreateText(privateKeyFileUri))
            {
                sw.Write(base64String);
            }

            return privateKeyFileUri;
        }

        public static string SavePrivateKeyAndGetFileUri(SecretClient secretClient, string privateKeySecretName, string keyFileExtension = DefaultPrivateKeyExtention)
        {
            EnsureCertFolder();

            var privateKeyFileUri = $"{CertificateFolderUri}\\{privateKeySecretName}{keyFileExtension}";

            var secret = secretClient.GetSecret(privateKeySecretName);

            var base64String = $"{BEGIN_PRIVATEKEY}\n{secret.Value.Value}\n{END_PRIVATEKEY}";

            using (StreamWriter sw = File.CreateText(privateKeyFileUri))
            {
                sw.Write(base64String);
            }

            return privateKeyFileUri;
        }
    }
}
