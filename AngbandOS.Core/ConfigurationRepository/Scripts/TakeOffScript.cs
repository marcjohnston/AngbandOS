// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class TakeOffScript : Script
{
    private TakeOffScript(SaveGame saveGame) : base(saveGame) { }

    public override bool Execute()
    {
        // Get the item to take off
        if (!SaveGame.SelectItem(out Item? item, "Take off which item? ", true, false, false, null))
        {
            SaveGame.MsgPrint("You are not wearing anything to take off.");
            return false;
        }
        if (item == null)
        {
            return false;
        }
        // Can't take of cursed items
        if (item.IsCursed())
        {
            SaveGame.MsgPrint("Hmmm, it seems to be cursed.");
            return false;
        }
        // Take off the item
        SaveGame.EnergyUse = 50;
        SaveGame.InvenTakeoff(item, 255);
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(RedrawEquippyFlaggedAction)).Set();
        return false;
    }
}
