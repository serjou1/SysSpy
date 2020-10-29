using SysSpy.Models;
using SysSpy.Models.SystemElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SysSpy.Snapshots
{
    public class SnapshotsComparator
    {
        public void CompareSnapshots(
            Snapshot oldSnapshot,
            Snapshot newSnapshot,
            out List<SystemElementsCollection> addedElementsCollections,
            out List<SystemElementsCollection> removedElementsCollections)
        {
            addedElementsCollections = new List<SystemElementsCollection>();
            removedElementsCollections = new List<SystemElementsCollection>();
            for (var i = 0; i < oldSnapshot.Collections.Count; i++)
            {
                var name = oldSnapshot.Collections[i].Name;

                var addedElementsList = oldSnapshot.Collections[i].Except(newSnapshot.Collections[i]).ToList();
                var addedElements = new SystemElementsCollection(name);
                addedElements.AddRange(addedElementsList);
                addedElementsCollections.Add(addedElements);

                var removedElementsList = newSnapshot.Collections[i].Except(oldSnapshot.Collections[i]).ToList();
                var removedElements = new SystemElementsCollection(name);
                removedElements.AddRange(removedElementsList);
                removedElementsCollections.Add(removedElements);
            }
        }
    }
}
