// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System.Text.Json;

namespace AngbandOS.Core.StoreCommands;

[Serializable]
internal abstract class StoreCommand : IGetKey<string>, IToJson
{
    protected SaveGame SaveGame { get; }
    protected StoreCommand(SaveGame saveGame)
    {
        SaveGame = saveGame;
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
        Script? script = SaveGame.SingletonRepository.Scripts.Get(ExecuteScriptName);

        if (script == null)
        {
            throw new Exception($"The {ExecuteScriptName} script specified by the {GetType().Name} store script does not exist.");
        }
        if (!typeof(IStoreScript).IsInstanceOfType(script))
        {
            throw new Exception($"The {ExecuteScriptName} script specified by the {GetType().Name} store script does not implement the {nameof(IStoreScript)} interface.");
        }
        ExecuteScript = (IStoreScript)script;

        if (ValidStoreNames == null)
        {
            ValidStoreFactories = null;
        }
        else
        {
            List<StoreFactory> storeFactoryList = new();
            foreach (string storeName in ValidStoreNames)
            {
                storeFactoryList.Add(SaveGame.SingletonRepository.StoreFactories.Get(storeName));
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
    protected virtual string[]? ValidStoreNames => null;

    protected abstract string ExecuteScriptName { get; }
    private IStoreScript ExecuteScript;
    public void Execute(StoreCommandEvent storeCommandEvent)
    {
        ExecuteScript.ExecuteStoreScript(storeCommandEvent);
    }

    public string ToJson()
    {
        StoreCommandDefinition definition = new()
        {
            Key = Key,
            KeyChar = KeyChar,
            Description = Description,
            ValidStoreNames = ValidStoreNames,
            ExecuteScriptName = ExecuteScriptName
        };
        return JsonSerializer.Serialize(definition);
    }
}
