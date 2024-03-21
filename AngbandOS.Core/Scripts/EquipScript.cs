// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class EquipScript : Script, IScript, IRepeatableScript, IStoreScript
{
    private EquipScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the equip script.  Does not modify any of the store flags.
    /// </summary>
    /// <returns></returns>
    public void ExecuteStoreScript(StoreCommandEvent storeCommandEvent)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Executes the equip script and returns false.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteRepeatableScript()
    {
        ExecuteScript();
        return false;
    }

    /// <summary>
    /// Executes the equip script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        // We're viewing equipment
        SaveGame.ViewingEquipment = true;
        ScreenBuffer savedScreen = SaveGame.Screen.Clone();

        // We're interested in seeing everything
        SaveGame.ShowEquip(null);

        // Get a command
        string outVal = $"Equipment: carrying {SaveGame.WeightCarried / 10}.{SaveGame.WeightCarried % 10} pounds ({SaveGame.WeightCarried * 100 / (SaveGame.AbilityScores[Ability.Strength].StrCarryingCapacity * 100 / 2)}% of capacity). Command: ";
        SaveGame.Screen.PrintLine(outVal, 0, 0);
        char c = SaveGame.Inkey();
        SaveGame.Screen.Restore(savedScreen);

        // Display details if the player wants
        if (c != '\x1b')
        {
            SaveGame._artificialKeyBuffer += c;
        }
        else
        {
            // If the player selects a command that uses getitem, it will automatically show the
            // inventory
            SaveGame.ViewingItemList = true;
        }
    }
}
