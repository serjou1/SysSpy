//todo do something with firewall rules

//using System;
//using SysSpy.Models.Interfaces;
//using SysSpy.Models.SystemElements;
//using NetFwTypeLib;

//namespace SysSpy.Models.Collectors
//{
//    public class FirewallRulesCollector : ISystemElementsCollector
//    {
//        public SystemElementsCollection Collect()
//        {
//            var collection = new SystemElementsCollection();

//                try
//                {
//                    Type tNetFwPolicy2 = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
//                    INetFwPolicy2 fwPolicy2 = (INetFwPolicy2)Activator.CreateInstance(tNetFwPolicy2);

//                    foreach (INetFwRule rule in fwPolicy2.Rules)
//                    collection.Add(new FirewallRule(rule.Name,
//                        rule.Enabled,
//                        rule.LocalAddresses,
//                        rule.LocalPorts,
//                        rule.RemoteAddresses,
//                        rule.RemotePorts));
//                }

//                catch (System.Runtime.InteropServices.COMException e) { Console.WriteLine(e.Message); }

//            return collection;
//        }
//    }
//}
