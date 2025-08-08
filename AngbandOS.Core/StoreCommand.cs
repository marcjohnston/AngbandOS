// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal sealed class StoreCommand : IGetKey, IToJson
{
    private readonly Game Game;
    public StoreCommand(Game game, StoreCommandGameConfiguration storeCommandGameConfiguration)
    {
        Game = game;
        Key = storeCommandGameConfiguration.Key ?? storeCommandGameConfiguration.GetType().Name;
        KeyChar = storeCommandGameConfiguration.KeyChar;
        Description = storeCommandGameConfiguration.Description;
        ValidStoreFactoryNames = storeCommandGameConfiguration.ValidStoreFactoryNames;
        ExecuteScriptName = storeCommandGameConfiguration.ExecuteScriptName;
    }

    public string Key { get; }

    public char KeyChar { get; }

    /// <summary>
    /// Returns the store factories that the command is valid for; or null, if the command is valid for all stores.  This property is bound to the 
    /// ValidStoreFactoryNames property during the bind phase.
    /// </summary>
    /// <remarks>
    /// If property is nullable to prevent needing to 
    /// </remarks>
    public StoreFactory[]? ValidStoreFactories { get; private set; }

    public string Description { get; }

    public string GetKey => Key;
    public void Bind()
    {
        // Get the script from the singleton repository.
        ExecuteScript = ExecuteScriptName == null ? null : Game.SingletonRepository.Get<IStoreCommandScript>(ExecuteScriptName);

        if (ValidStoreFactoryNames == null)
        {
            ValidStoreFactories = null;
        }
        else
        {
            List<StoreFactory> storeFactoryList = new();
            foreach (string storeName in ValidStoreFactoryNames)
            {
                storeFactoryList.Add(Game.SingletonRepository.Get<StoreFactory>(storeName));
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
    private string[]? ValidStoreFactoryNames { get; } = null;

    private string? ExecuteScriptName { get; } = null;
    public IStoreCommandScript ExecuteScript { get; private set; }

    public string ToJson()
    {
        StoreCommandGameConfiguration definition = new()
        {
            Key = Key,
            KeyChar = KeyChar,
            Description = Description,
            ValidStoreFactoryNames = ValidStoreFactoryNames,
            ExecuteScriptName = ExecuteScriptName
        };
        return JsonSerializer.Serialize(definition, Game.GetJsonSerializerOptions());
    }
}
