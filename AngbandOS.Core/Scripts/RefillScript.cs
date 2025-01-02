// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class RefillScript : Script, IScript, IRepeatableScript
{
    private RefillScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the refill script and returns false.
    /// </summary>
    /// <returns></returns>
    public RepeatableResult ExecuteRepeatableScript()
    {
        ExecuteScript();
        return new RepeatableResult(false);
    }

    /// <summary>
    /// Executes the refill script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        // Make sure we actually have a light source to refuel.           
        WieldSlot? chosenLightSourceInventorySlot = Game.SingletonRepository.ToWeightedRandom<WieldSlot>(inventorySlot => inventorySlot.ProvidesLight).ChooseOrDefault();

        // Check to ensure there is an inventory slot for light sources.
        if (chosenLightSourceInventorySlot == null)
        {
            Game.MsgPrint("You are not wielding a light.");
            return;
        }

        // Now choose a light source item.
        int? i = chosenLightSourceInventorySlot.WeightedRandom.ChooseOrDefault();
        if (i == null)
        {
            Game.MsgPrint("You are not wielding a light.");
            return;
        }

        Item? lightSource = Game.GetInventoryItem(i.Value);
        if (lightSource == null)
        {
            Game.MsgPrint("You are not wielding a light.");
            return;
        }

        lightSource.Refill();
    }
}
