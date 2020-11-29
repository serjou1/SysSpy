//TODO: do something with com+ components 

//using SysSpy.Models.SystemElements;
//using SysSpy.Models.Interfaces;
//using COMAdmin;

//namespace SysSpy.Models.Collectors
//{
//    public class COMPlusComponentsCollector : ISystemElementsCollector
//    {
//        public SystemElementsCollection Collect()
//        {
//            var collection = new SystemElementsCollection();

//            var catalog = new COMAdminCatalog();
//            var applications = (COMAdminCatalogCollection)catalog.GetCollection("Applications");
//            applications.Populate();

//            foreach (COMAdminCatalogObject application in applications)
//            {
//                COMAdminCatalogCollection components;
//                components = (COMAdminCatalogCollection)applications.GetCollection("Components", application.Key);
//                try
//                {
//                    components.Populate();
//                }
//                catch (System.Runtime.InteropServices.COMException)
//                {
//                    continue;
//                }

//                string appname = application.Name.ToString();
//                foreach (COMAdminCatalogObject component in components)
//                    collection.Add(new COMPlusComponent(component.Name.ToString(), appname));
//            }

//            return collection;
//        }
//    }
//}
