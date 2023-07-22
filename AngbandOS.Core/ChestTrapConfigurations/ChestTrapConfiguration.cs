// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ChestTrapConfigurations;

[Serializable]
internal abstract class ChestTrapConfiguration
{
    protected SaveGame SaveGame;
    protected ChestTrapConfiguration(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }

    public abstract BaseChestTrap[] Traps { get; }
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
    public void Activate(SaveGame saveGame, Item chestItem)
    {
        foreach (BaseChestTrap trap in Traps)
        {
            ActivateChestTrapEventArgs eventArgs = new ActivateChestTrapEventArgs(saveGame, saveGame.MapX, saveGame.MapY);
            trap.Activate(eventArgs);

            if (eventArgs.DestroysContents)
            {
                eventArgs.SaveGame.MsgPrint("Everything inside the chest is destroyed!");
                chestItem.TypeSpecificValue = 0;
            }
        }
    }
}