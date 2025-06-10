// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class TakeOffScript : Script, IScript, ICastSpellScript, IGameCommandScript, IStoreCommandScript
{
    private TakeOffScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Returns information about the script, or blank if there is no detailed information.  Returns blank, by default.
    /// </summary>
    public string LearnedDetails => "";

    /// <summary>
    /// Executes the take-off script.  Does not modify any of the store flags.
    /// </summary>
    /// <returns></returns>
    public void ExecuteStoreCommandScript(StoreCommandEvent storeCommandEvent)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Executes the take-off script and returns false.
    /// </summary>
    /// <returns></returns>
    public RepeatableResult ExecuteGameCommandScript()
    {
        ExecuteScript();
        return new RepeatableResult(false);
    }

    /// <summary>
    /// Allows an item to be taken-off from active equipment.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        // Get the item to take off
        if (!Game.SelectItem(out Item? item, "Take off which item? ", true, false, false, null))
        {
            Game.MsgPrint("You are not wearing anything to take off.");
            return;
        }
        if (item == null)
        {
            return;
        }
        // Can't take of cursed items
        RoItemPropertySet mergedCharacteristics = item.GetEffectiveItemProperties();
        if (mergedCharacteristics.IsCursed)
        {
            Game.MsgPrint("Hmmm, it seems to be cursed.");
            return;
        }
        // Take off the item
        Game.EnergyUse = 50;
        item.Takeoff(255);
        Game.SingletonRepository.Get<FlaggedAction>(nameof(RedrawEquippyFlaggedAction)).Set();
    }
}
