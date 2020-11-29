using Microsoft.Windows.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Data;

namespace SysSpy.Desktop.Controls
{
    // todo add comments
    internal class SysSpyDataGrid : DataGrid
    {
        public SysSpyDataGrid() : base()
        {
        }

        protected override void OnItemsSourceChanged(System.Collections.IEnumerable oldValue, System.Collections.IEnumerable newValue)
        {
            base.OnItemsSourceChanged(oldValue, newValue);
            if (newValue != null)
            {
                var enumerator = newValue.GetEnumerator();
                if (enumerator.MoveNext())
                {
                    Columns.Clear();
                    var firstElement = enumerator.Current;
                    var actualType = firstElement.GetType();
                    foreach (var prop in actualType.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(x => x.CanRead))
                    {
                        Columns.Add(new DataGridTextColumn
                        {
                            Header = prop.Name,
                            Binding = new Binding(prop.Name)
                        });
                    }
                }
            }
        }
    }
}
