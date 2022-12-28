using AngbandOS.Core.ItemClasses;
using System.Collections;
using System.Reflection;

namespace AngbandOS.Core
{
    [Serializable]
    internal class ItemClassPropertiesSingleton : IEnumerable<ItemClassProperties>
    {
        List<ItemClassProperties> list = new List<ItemClassProperties>();
        Dictionary<string, ItemClassProperties> instances = new Dictionary<string, ItemClassProperties>();
        public int Count => instances.Count;

        public ItemClassProperties this[int index]
        {
            get
            {
                return list[index];
            }
        }

        public ItemClassProperties Get(Type type)
        {
            return instances[type.Name];
        }

        public IEnumerator<ItemClassProperties> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }

        public ItemClassPropertiesSingleton(SaveGame saveGame)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            foreach (Type type in assembly.GetTypes())
            {
                // Load Commands.
                if (!type.IsAbstract && typeof(ItemClass).IsAssignableFrom(type))
                {
                    ItemClassProperties itemClassProperties = new ItemClassProperties();
                    instances.Add(type.Name, itemClassProperties);
                    list.Add(itemClassProperties);
                }
            }
        }
    }
}
