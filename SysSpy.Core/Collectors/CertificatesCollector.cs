using System;
using System.Security.Cryptography.X509Certificates;
using SysSpy.Core.Enums;
using SysSpy.Core.Interfaces;
using SysSpy.Core.SystemElements;

namespace SysSpy.Core.Collectors
{
    public class CertificatesCollector : ISystemElementsCollector//<Certificate>
    {
        public SystemElementsCollection<Certificate> Collect()
        {
            var collection = new SystemElementsCollection<Certificate>();

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

        SystemElementsCollection<SystemElement> ISystemElementsCollector.Collect()
            => Collect().
    }
}
