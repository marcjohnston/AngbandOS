// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class InventoryScript : Script, IScript, ICastSpellScript, IGameCommandScript, IStoreCommandScript
{
    private InventoryScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Returns information about the script, or blank if there is no detailed information.  Returns blank, by default.
    /// </summary>
    public string LearnedDetails => "";

    /// <summary>
    /// Executes the inventory script.  Does not modify any of the store flags.
    /// </summary>
    /// <returns></returns>
    public void ExecuteStoreCommandScript(StoreCommandEvent storeCommandEvent)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Executes the inventory script and returns false.
    /// </summary>
    /// <returns></returns>
    public RepeatableResultEnum ExecuteGameCommandScript()
    {
        ExecuteScript();
        return RepeatableResultEnum.False;
    }

    /// <summary>
    /// Executes the inventory script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        // We're not viewing equipment
        Game.ViewingEquipment = false;
        ScreenBuffer savedScreen = Game.Screen.Clone();
        // We want to see everything
        bool inventoryShown = Game.ShowInven(_inventorySlot => !_inventorySlot.IsEquipment, null);
        if (!inventoryShown)
        {
            Game.MsgPrint("You have nothing.");
            return;
        }
        // Get a new command
        string outVal = $"Inventory: carrying {Game.WeightCarried / 10}.{Game.WeightCarried % 10} pounds ({Game.WeightCarried * 100 / (Game.StrengthAbility.StrCarryingCapacity * 100 / 2)}% of capacity). Command: ";
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
            // If the player selected a command that needs to select an item, it will automatically
            // show the inventory
            Game.ViewingItemList = true;
        }
    }
}
