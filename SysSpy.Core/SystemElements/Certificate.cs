﻿using System.Security.Cryptography.X509Certificates;
using SysSpy.Core.Enums;

namespace SysSpy.Core.SystemElements
{
    /// <summary>
    /// Describes X509 certificate.
    /// </summary>
    class Certificate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Certificate"/> class.
        /// </summary>
        /// <param name="root">The root where certificate is located.</param>
        /// <param name="certificate">Source certificate.</param>
        public Certificate(CertificateRoot root, X509Certificate2 certificate)
        {
            SourceCertificate = certificate;
            Root = root;

            IssuedTo = GetIssuedTo();
        }

        /// <summary>
        /// Certificate's root.
        /// </summary>
        public CertificateRoot Root { get; }

        /// <summary>
        /// Source certificate.
        /// </summary>
        public X509Certificate2 SourceCertificate { get; }

        /// <summary>
        /// "User's" or "Machine's" certificate's hive.
        /// </summary>
        public ElementsHive Hive { get; set; }

        /// <summary>
        /// Certificate's subject.
        /// </summary>
        public string Subject => SourceCertificate.Subject;

        /// <summary>
        /// Certificate's issuer.
        /// </summary>
        public string Issuer => SourceCertificate.Issuer;

        /// <summary>
        /// Certificate's friendly name.
        /// </summary>
        public string FriendlyName => SourceCertificate.FriendlyName;

        /// <summary>
        /// To whom the certificate was issued.
        /// </summary>
        public string IssuedTo { get; }

        private string GetIssuedTo()
        {
            string issuedTo = Subject;
            issuedTo = issuedTo.Replace("CN=", "");
            try
            {
                issuedTo = issuedTo.Remove(issuedTo.IndexOf(","));
            }
            catch { }
            return issuedTo;
        }
    }
}
