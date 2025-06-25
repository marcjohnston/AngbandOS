// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class ChestTrapCombination : IGetKey, IToJson
{
    protected Game Game;
    public ChestTrapCombination(Game game, ChestTrapCombinationGameConfiguration chestTrapGameConfiguration)
    {
        Game = game;
        Key = chestTrapGameConfiguration.Key ?? chestTrapGameConfiguration.GetType().Name;
        ChestTrapBindingKeys = chestTrapGameConfiguration.ChestTrapBindingKeys;
    }

    /// <summary>
    /// Returns the entity serialized into a Json string.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        ChestTrapCombinationGameConfiguration dateWidgetGameConfiguration = new ChestTrapCombinationGameConfiguration()
        {
            Key = Key,
            ChestTrapBindingKeys = ChestTrapBindingKeys,
        };
        return JsonSerializer.Serialize(dateWidgetGameConfiguration, Game.GetJsonSerializerOptions());
    }

    public virtual string Key { get; }

    public string GetKey => Key;
    public void Bind()
    {
        ChestTraps = Game.SingletonRepository.Get<ChestTrap>(ChestTrapBindingKeys);
    }

    public ChestTrap[] ChestTraps { get; private set; }
    public virtual string[] ChestTrapBindingKeys { get; }
    public bool NotTrapped => ChestTraps.Length == 0;
    public bool IsTrapped => ChestTraps.Length > 0;
}