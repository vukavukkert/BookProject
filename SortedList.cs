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
        /// <summary>
        /// Func for searching any lists by key
        /// </summary>
        public static ObservableCollection<T> SearchCollection(string key, ObservableCollection<T> list)
        {
            if (key.Length == 0) return list; // Если длина ключа равна нулю -  на выход

            ObservableCollection<T> SortedList = new ObservableCollection<T>(); // Временный лист

            foreach (var item in list)
            {
                Type type = item.GetType(); // определяем тип объекта
                PropertyInfo[] properties = type.GetProperties();// Достаем его свойства
                foreach (var property in properties) //проходимся через его свойства с помощью foreach
                {
                    if (property.PropertyType == typeof(string)) //если это свойство является строкой
                    {
                        if ((property.GetValue(item) as string).ToLower().Contains(key.ToLower())) //приводим все к нижнему регистру и приравниваем его к ключу
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
