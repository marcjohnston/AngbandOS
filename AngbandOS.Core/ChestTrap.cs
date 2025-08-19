// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

/// <summary>
/// Represents a trap on a chest.  Can be layered with multiple traps.  The base class implements the layering.  Derived classes only
/// need concern themselves with their own implementation and not sub-traps.
/// </summary>
[Serializable]
internal class ChestTrap : IGetKey, IToJson
{
    protected readonly Game Game;
    public ChestTrap(Game game, ChestTrapGameConfiguration chestTrapGameConfiguration)
    {
        Game = game;
        Key = chestTrapGameConfiguration.Key ?? chestTrapGameConfiguration.GetType().Name;
        Description = chestTrapGameConfiguration.Description;
        ActivationGridTileScriptBindingKey = chestTrapGameConfiguration.ActivationGridTileScriptBindingKey;
    }

    /// <summary>
    /// Returns the entity serialized into a Json string.
    /// </summary>
    /// <returns></returns>    public string ToJson()
    {
        ChestTrapGameConfiguration definition = new()
        {
            Key = Key,
            Description = Description,
            ActivationGridTileScriptBindingKey = ActivationGridTileScriptBindingKey,
        };
        return JsonSerializer.Serialize(definition, Game.GetJsonSerializerOptions());
    }

    public virtual string Key { get; set; }

    public string GetKey => Key;
    public void Bind()
    {
        ActivationGridTileScript = Game.SingletonRepository.Get<GridTileScript>(ActivationGridTileScriptBindingKey);
    }

    private string ActivationGridTileScriptBindingKey { get; }
    public GridTileScript ActivationGridTileScript { get; private set; }
    /// <summary>
    /// Activate the trap.
    /// </summary>
    /// <param name="game"></param>
    public virtual string Description { get; }
}
