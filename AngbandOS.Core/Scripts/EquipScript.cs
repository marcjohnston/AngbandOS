// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class EquipScript : Script, IScript, ICastSpellScript, IGameCommandScript, IScriptStore
{
    private EquipScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Executes the equip script.  Does not modify any of the store flags.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScriptStore(StoreCommandEvent storeCommandEvent)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Executes the equip script and returns false.
    /// </summary>
    /// <returns></returns>
    public RepeatableResult ExecuteGameCommandScript()
    {
        ExecuteScript();
        return new RepeatableResult(false);
    }

    /// <summary>
    /// Executes the equip script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        // We're viewing equipment
        Game.ViewingEquipment = true;
        ScreenBuffer savedScreen = Game.Screen.Clone();

        // We're interested in seeing everything
        Game.ShowEquip(null);

        // Get a command
        string outVal = $"Equipment: carrying {Game.WeightCarried / 10}.{Game.WeightCarried % 10} pounds ({Game.WeightCarried * 100 / (Game.AbilityScores[AbilityEnum.Strength].StrCarryingCapacity * 100 / 2)}% of capacity). Command: ";
        Game.Screen.PrintLine(outVal, 0, 0);
        char c = Game.Inkey();
        Game.Screen.Restore(savedScreen);

        // Display details if the player wants
        if (c != '\x1b')
        {
            Game._artificialKeyBuffer += c;
        }
        else
        {
            // If the player selects a command that uses getitem, it will automatically show the
            // inventory
            Game.ViewingItemList = true;
        }
    }
}
