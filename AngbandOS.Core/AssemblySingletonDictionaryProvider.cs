using System.Reflection;

namespace AngbandOS.Core
{
    internal class AssemblySingletonDictionaryProvider<S, T>
    {
        public Dictionary<S, T> Load(SaveGame saveGame, Func<T, S> keyRetriever)
        {
            Dictionary<S, T> dictionary = new Dictionary<S, T>();
            Assembly assembly = Assembly.GetExecutingAssembly();
            foreach (Type type in assembly.GetTypes())
            {
                // Load Commands.
                if (!type.IsAbstract && typeof(T).IsAssignableFrom(type))
                {
                    ConstructorInfo[] constructors = type.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);
                    T command = (T)constructors[0].Invoke(new object[] { saveGame });
                    S keyValue = keyRetriever(command);
                    dictionary.Add(keyValue, command);
                }
            }
            return dictionary;
        }
    }

    
}
