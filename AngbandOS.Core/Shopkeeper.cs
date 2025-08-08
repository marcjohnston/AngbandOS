// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal sealed class Shopkeeper : IGetKey, IToJson
{
    private readonly Game Game;
    public Shopkeeper(Game game, ShopkeeperGameConfiguration shopkeeperGameConfiguration)
    {
        Game = game;
        Key = shopkeeperGameConfiguration.Key ?? shopkeeperGameConfiguration.GetType().Name;
        MaxCost = shopkeeperGameConfiguration.MaxCost;
        MinInflate = shopkeeperGameConfiguration.MinInflate;
        Name = shopkeeperGameConfiguration.Name;
        RaceName = shopkeeperGameConfiguration.RaceName;
    }

    public int MaxCost { get; }

    /// <summary>
    /// Returns the minimum inflation value for this store owner.
    /// </summary>
    public int MinInflate { get; }

    /// <summary>
    /// Returns the name of the owner.  For stores with no owner, this is the name of the store.
    /// </summary>
    public string Name { get; }

    public string Key { get; }

    /// <summary>
    /// Returns the race of the store owner.  Null, if there is no store owner.
    /// </summary>
    public Race? OwnerRace { get; private set; }

    private string? RaceName { get; }

    public string GetKey => Key;

    public void Bind()
    {
        OwnerRace = Game.SingletonRepository.GetNullable<Race>(RaceName);
    }

    public string ToJson()
    {
        ShopkeeperGameConfiguration shopkeeperDefinition = new()
        {
            Key = Key,
            MaxCost = MaxCost,
            MinInflate = MinInflate,
            Name = Name,
            RaceName = OwnerRace?.GetKey
        };
        return JsonSerializer.Serialize(shopkeeperDefinition, Game.GetJsonSerializerOptions());
    }
}
