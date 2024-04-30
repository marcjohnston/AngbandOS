// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System.Text.Json;

namespace AngbandOS.Core.StoreCommands;

[Serializable]
internal abstract class StoreCommand : IGetKey, IToJson
{
    protected Game Game { get; }
    protected StoreCommand(Game game)
    {
        Game = game;
    }

    public virtual string Key => GetType().Name;

    public abstract char KeyChar { get; }

    /// <summary>
    /// Returns the store factories that the command is valid for; or null, if the command is valid for all stores.  This property is bound to the 
    /// ValidStoreFactoryNames property during the bind phase.
    /// </summary>
    /// <remarks>
    /// If property is nullable to prevent needing to 
    /// </remarks>
    public StoreFactory[]? ValidStoreFactories { get; private set; }

    public abstract string Description { get; }

    public string GetKey => Key;
    public void Bind()
    {
        // Get the script from the singleton repository.
        ExecuteScript = ExecuteScriptName == null ? null : (IScriptStore)Game.SingletonRepository.Get<Script>(ExecuteScriptName);

        if (ValidStoreFactoryNames == null)
        {
            ValidStoreFactories = null;
        }
        else
        {
            List<StoreFactory> storeFactoryList = new();
            foreach (string storeName in ValidStoreFactoryNames)
            {
                storeFactoryList.Add(Game.SingletonRepository.StoreFactories.Get(storeName));
            }
            ValidStoreFactories = storeFactoryList.ToArray();
        }
    }

    public bool IsEnabled(StoreFactory storeFactory)
    {
        if (ValidStoreFactories == null)
        {
            return true;
        }
        return ValidStoreFactories.Contains(storeFactory);
    }

    /// <summary>
    /// Returns the names of the store factories that the command is valid in; or null, for all stores.  Returns null, by default.
    /// </summary>
    protected virtual string[]? ValidStoreFactoryNames => null;

    protected virtual string? ExecuteScriptName => null;
    public IScriptStore ExecuteScript { get; private set; }

    public string ToJson()
    {
        StoreCommandDefinition definition = new()
        {
            Key = Key,
            KeyChar = KeyChar,
            Description = Description,
            ValidStoreFactoryNames = ValidStoreFactoryNames,
            ExecuteScriptName = ExecuteScriptName
        };
        return JsonSerializer.Serialize(definition);
    }
}
