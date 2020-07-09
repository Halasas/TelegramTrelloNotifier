using System;
using System.Collections.Generic;
using System.Linq;
using Nancy.Extensions;

namespace TrelloTelegramAlarm
{
    public static class Reflection
    {
        public static List<Type> GetAllTypesImplemented<T>()
        {
            var type = typeof(T);
            var allTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p))
                .Where(c => !c.IsAbstract && !c.IsInterface);

            return new List<Type>(allTypes);
        }

        public static List<T> GetInstances<T>(List<Type> all)
        {
            var instancesList = new List<T>();
            foreach (var type in all) instancesList.Add(type.CreateInstance<T>());
            return instancesList;
        }
    }
}