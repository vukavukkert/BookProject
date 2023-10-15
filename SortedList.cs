using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BookProject
{
    public static class SortedList<T>
    {
        
        public static ObservableCollection<T> SearchCollection(string key, ObservableCollection<T> list)
        {
            if (key.Length == 0) return list;

            ObservableCollection<T> SortedList = new ObservableCollection<T>();

            foreach (var item in list)
            {
                Type type = item.GetType();
                PropertyInfo[] properties = type.GetProperties();
                foreach (var property in properties)
                {
                    if (property.PropertyType == typeof(string))
                    {
                        if ((property.GetValue(item) as string).ToLower().Contains(key.ToLower()))
                        {
                            if (!SortedList.Contains(item))
                            {
                                SortedList.Add(item);

                            }

                        }
                    }
                }
            }
            return SortedList;
        }
    }
}
