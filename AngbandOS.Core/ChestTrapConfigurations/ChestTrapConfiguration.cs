// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ChestTrapConfigurations;

[Serializable]
internal abstract class ChestTrapConfiguration : IGetKey
{
    protected Game Game;
    protected ChestTrapConfiguration(Game game)
    {
        Game = game;
    }

    /// <summary>
    /// Returns the entity serialized into a Json string.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        return "";
    }

    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind() { }

    public abstract ChestTrap[] Traps { get; }
    public bool NotTrapped => Traps.Length == 0;
    public bool IsTrapped => Traps.Length > 0;
    public string Description
    {
        get
        {
            if (NotTrapped)
            {
                return "(Locked)";
            }
            else if (Traps.Length > 1)
            {
                return "(Multiple Traps)";
            }
            else
            {
                return Traps[0].Description;
            }
        }
    }
    public void Activate(Game game, Item chestItem)
    {
        foreach (ChestTrap trap in Traps)
        {
            ActivateChestTrapEventArgs eventArgs = new ActivateChestTrapEventArgs(game.MapX, game.MapY);
            trap.Activate(eventArgs);

            if (eventArgs.DestroysContents)
            {
                Game.MsgPrint("Everything inside the chest is destroyed!");
                chestItem.TypeSpecificValue = 0;
            }
        }
    }
}