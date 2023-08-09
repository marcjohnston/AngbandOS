// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System.Collections;
using System.Reflection;

namespace AngbandOS.Core.RepositoryCollections;

[Serializable]
internal abstract class RepositoryCollection<T> : IEnumerable<T>
{
    protected readonly SaveGame SaveGame;

    protected RepositoryCollection(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }

    public abstract IEnumerator<T> GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    protected T[] LoadTypesFromAssembly<T>()
    {
        List<T> typeList = new List<T>();
        Assembly assembly = Assembly.GetExecutingAssembly();
        Type[] types = assembly.GetTypes();
        foreach (Type type in types)
        {
            // Load Commands.
            if (!type.IsAbstract && typeof(T).IsAssignableFrom(type))
            {
                ConstructorInfo[] constructors = type.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);
                if (constructors.Length == 1)
                {
                    T item = (T)constructors[0].Invoke(new object[] { SaveGame });
                    bool exclude = false;
                    if (typeof(IConfigurationItem).IsAssignableFrom(type))
                    {
                        IConfigurationItem singletonType = (IConfigurationItem)item;
                        exclude = singletonType.ExcludeFromRepository;
                    }
                    if (!exclude)
                    {
                        typeList.Add(item);
                    }
                }
            }
        }
        return typeList.ToArray();
    }

    /// <summary>
    /// Processes the load phase for the configuration repository items.  This phase creates instances of all objects that have a private constructor.  An instance of the SaveGame is
    /// sent to the constructor for every configuration repository item created.  The configuration repository item cannot assume other repository items are available during this phase.
    /// </summary>
    public abstract void Load();

    /// <summary>
    /// Processes the loaded phase for configuration repository items.  This phase allows each object to bind to other configuration repository objects.
    /// </summary>
    public virtual void Loaded() { }
}