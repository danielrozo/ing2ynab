using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Ing2Ynab.Csv
{
    internal class CsvWriter
    {
        public void WriteCsv<T>(IEnumerable<T> items, string path)
        {
            Type itemType = typeof(T);
            var props = itemType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                .OrderBy(p => p.Name);

            using (var writer = new StreamWriter(path))
            {
                writer.WriteLine(string.Join(", ", props.Select(p => p.Name)));

                foreach (var item in items)
                {
                    writer.WriteLine(string.Join(", ", props.Select(p => p.GetValue(item, null).ToString().Replace(",", ""))));
                }
            }
        }
    }
}
