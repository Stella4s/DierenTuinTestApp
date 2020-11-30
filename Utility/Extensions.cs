using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace DierenTuinWPF.Utility
{
    static class Extensions
    {
        public static void Sort<TSource, TKey>(this ObservableCollection<TSource> collection, Func<TSource, TKey> keySelector, bool Ascending)
        {
            List<TSource> sorted = collection.OrderBy(keySelector).ToList();
            if (!Ascending)
                sorted.Reverse();
            for (int i = 0; i < sorted.Count(); i++)
                collection.Move(collection.IndexOf(sorted[i]), i);
        }
    }
}
