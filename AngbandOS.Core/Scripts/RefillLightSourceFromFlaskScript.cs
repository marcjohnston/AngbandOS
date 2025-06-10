// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

/// <summary>
/// Refill a light-source using a flask of oil.
/// </summary>
[Serializable]
internal class RefillLightSourceFromFlaskScript : Script, IScriptItem
{
    private RefillLightSourceFromFlaskScript(Game game) : base(game) { }
    public void ExecuteScriptItem(Item item)
    {
        // Get an item if we don't already have one
        if (!Game.SelectItem(out Item? fuelSource, "Refill with which flask? ", false, true, true, Game.SingletonRepository.Get<ItemFilter>(nameof(LanternFuelItemFilter))))
        {
            Game.MsgPrint("You have no flasks of oil.");
            return;
        }

        // Get the item from the inventory or from the floor.
        if (fuelSource == null)
        {
            return;
        }

        // Make sure our item is suitable fuel
        if (!Game.ItemMatchesFilter(fuelSource, Game.SingletonRepository.Get<ItemFilter>(nameof(LanternFuelItemFilter))))
        {
            Game.MsgPrint("You can't refill a lantern from that!");
            return;
        }
        // Refilling takes half a turn
        Game.EnergyUse = 50;

        // Add the fuel
        item.TurnsOfLightRemaining += fuelSource.TurnsOfLightRemaining;
        Game.MsgPrint("You fuel your lamp.");

        // Check for overfilling
        if (item.TurnsOfLightRemaining >= Constants.FuelLamp)
        {
            item.TurnsOfLightRemaining = Constants.FuelLamp;
            Game.MsgPrint("Your lamp is full.");
        }

        // Update the inventory
        fuelSource.ModifyStackCount(-1);
        fuelSource.ItemDescribe();
        fuelSource.ItemOptimize();
        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateTorchRadiusFlaggedAction)).Set();
    }
}
