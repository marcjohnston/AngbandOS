﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Repositories;

/// <summary>
/// Represents a list repository but adds a dictionary lookup for O(1) fast singleton access.  The entities must implement the IGetKey interface to return a 
/// primary key (PK) and the IToJson interface to perform serialization.
/// </summary>
/// <typeparam name="TKey"></typeparam>
/// <typeparam name="TValue"></typeparam>
[Serializable]
internal abstract class DictionaryRepository<TKey, TValue> : ListRepository<TValue> where TValue : IGetKey<TKey> where TKey : notnull
{
    private Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();
    protected DictionaryRepository(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Returns the pluralized type name for the TValue generic as the name of this string list repository.
    /// </summary>
    public override string Name => Pluralize(typeof(TValue).Name);

    public bool Contains(TValue item) => dictionary.ContainsKey(item.GetKey);

    /// <summary>
    /// Persist the entities to the core persistent storage medium.  This method is only being used to generate database entities from objects.
    /// </summary>
    /// <param name="corePersistentStorage"></param>
    public override void PersistEntities()
    {
        List<KeyValuePair<string, string>> jsonEntityList = new();
        foreach (TValue entity in this)
        {
            string key = entity.GetKey.ToString(); // TODO: The use of .ToString is because TKey needs to be strings
            string serializedEntity = entity.ToJson();
            jsonEntityList.Add(new KeyValuePair<string, string>(key, serializedEntity));
        }
        SaveGame.CorePersistentStorage.PersistEntities(Name, jsonEntityList.ToArray());
    }

    public override string SerializeEntity(TValue entity)
    {
        return entity.ToJson();
    }

    public TValue Get(TKey key)
    {
        if (!dictionary.TryGetValue(key, out TValue? value))
        {
            throw new Exception($"The {key.ToString()} item is not found.");
        }
        return value;
    }

    /// <summary>
    /// Add a value to the dictionary.
    /// </summary>
    /// <param name="item"></param>
    public override void Add(TValue item)
    {
        TKey key = item.GetKey;
        if (dictionary.TryGetValue(key, out TValue? existingSingletonRepositoryItem))
        {
            throw new Exception($"The {item.GetType().Name} singleton has a duplicate key value of {item.GetKey} with {existingSingletonRepositoryItem.GetType().Name}.");
        }
        dictionary.Add(key, item);
        base.Add(item);
    }

    /// <summary>
    /// Loads the repository with a instance of types that inherit from the TValue type in the assembly.
    /// </summary>
    public override void Load()
    {
        Add(LoadTypesFromAssembly<TValue>());
    }

    /// <summary>
    /// Processes the bind event from the Repository by calling the Loaded event for all items in the collection.  Since this is a dictionary repository, all
    /// items must implement the IGetKey interface which also includes the Loaded event handler.
    /// </summary>
    public override void Bind()
    {
        foreach (TValue item in this)
        {
            item.Bind();
        }
    }
}