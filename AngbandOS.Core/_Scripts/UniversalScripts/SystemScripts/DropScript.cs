// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class DropScript : UniversalScript, IGetKey
{
    private DropScript(Game game) : base(game) { }

    /// <summary>
    /// Returns the entity serialized into a Json string.  Returns an empty string by default.
    /// </summary>
    /// <returns></returns>

    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind() { }

    /// <summary>
    /// Executes the drop script and disposes of the successful result.
    /// </summary>
    /// <returns></returns>
    public override void ExecuteScript()
    {
        int amount = 1;
        // Get an item from the inventory/equipment
        if (!Game.SelectItem(out Item? item, "Drop which item? ", true, true, false, null))
        {
            Game.MsgPrint("You have nothing to drop.");
            return;
        }
        if (item == null)
        {
            return;
        }
        // Can't drop a cursed item
        if (item.IsInEquipment && item.EffectiveItemPropertySet.IsCursed)
        {
            Game.MsgPrint("Hmmm, it seems to be cursed.");
            return;
        }
        // It's a stack, so find out how many to drop
        if (item.StackCount > 1)
        {
            amount = Game.GetQuantity(item.StackCount, true);
            if (amount <= 0)
            {
                return;
            }
        }
        // Dropping things takes half a turn
        Game.EnergyUse = 50;
        // Drop it
        Game.InvenDrop(item, amount);
        Game.SingletonRepository.Get<FlaggedAction>(nameof(RedrawEquippyFlaggedAction)).Set();
    }
}
