using System.Collections;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

namespace AngbandOS.Core
{
    internal class SingletonFactory<T> : IEnumerable<T>
    {
        List<T> instances = new List<T>();

        public T Get<U>()
        {
            foreach (T instance in instances)
            {
                if (typeof(U) == instance.GetType())
                {
                    return instance;
                }
            }
            throw new Exception($"Singleton factory does not have an instance for {typeof(T).Name}.");
        }

        public IEnumerator<T> GetEnumerator()
        {
            return instances.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return instances.GetEnumerator();
        }

        public SingletonFactory()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            foreach (Type type in assembly.GetTypes())
            {
                // Load Commands.
                if (!type.IsAbstract && typeof(T).IsAssignableFrom(type))
                {
                    ConstructorInfo[] constructors = type.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);
                    T command = (T)constructors[0].Invoke(new object[] { });
                    instances.Add(command);
                }
            }
        }
    }
}
