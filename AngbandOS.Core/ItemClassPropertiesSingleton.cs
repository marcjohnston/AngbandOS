using AngbandOS.Core.ItemClasses;
using System.Collections;
using System.Reflection;

namespace AngbandOS.Core
{
    [Serializable]
    internal class ItemClassPropertiesSingleton : IEnumerable<ItemClassProperties>
    {
        Dictionary<string, ItemClassProperties> instances = new Dictionary<string, ItemClassProperties>();
        public int Count => instances.Count;

        public ItemClassProperties Get(Type type)
        {
            return instances[type.Name];
        }

        public IEnumerator<ItemClassProperties> GetEnumerator()
        {
            return instances.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return instances.Values.GetEnumerator();
        }

        public ItemClassPropertiesSingleton(SaveGame saveGame)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            foreach (Type type in assembly.GetTypes())
            {
                // Load Commands.
                if (!type.IsAbstract && typeof(ItemClass).IsAssignableFrom(type))
                {
                    instances.Add(type.Name, new ItemClassProperties());
                }
            }
        }
    }
}
