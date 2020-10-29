using System;
using System.Security.Cryptography.X509Certificates;
using SysSpy.Models.Enums;
using SysSpy.Models.Interfaces;
using SysSpy.Models.SystemElements;

namespace SysSpy.Models.Collectors
{
    public class CertificatesCollector : ISystemElementsCollector
    {
        public SystemElementsCollection Collect()
        {
            var collection = new SystemElementsCollection("Certificates");

            foreach (CertificateRoot root in Enum.GetValues(typeof(CertificateRoot)))
            {
                var store = new X509Store(root.ToString(), StoreLocation.CurrentUser);
                try
                {
                    store.Open(OpenFlags.ReadOnly);
                    foreach (X509Certificate2 mCert in store.Certificates)
                        collection.Add(new Certificate(root, mCert) { Hive = ElementsHive.Users });
                }
                finally
                {
                    store.Close();
                }

                store = new X509Store(root.ToString(), StoreLocation.LocalMachine);
                try
                {
                    store.Open(OpenFlags.ReadOnly);
                    foreach (X509Certificate2 mCert in store.Certificates)
                        collection.Add(new Certificate(root, mCert) { Hive = ElementsHive.Machines });
                }
                finally
                {
                    store.Close();
                }
            }

            return collection;
        }
    }
}
