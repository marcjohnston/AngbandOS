// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

/// <summary>
/// Refill a torch from another torch.
/// </summary>
[Serializable]
internal class RefillLightSourceFromTorchScript : Script, IScriptItem
{
    private RefillLightSourceFromTorchScript(Game game) : base(game) { }
    public void ExecuteScriptItem(Item item)
    {
        // Get an item if we don't already have one
        if (!Game.SelectItem(out Item? fuelSource, "Refuel with which torch? ", false, true, true, base.Game.SingletonRepository.Get<ItemFilter>(nameof(ItemFilters.TorchFuelItemFilter))))
        {
            Game.MsgPrint("You have no extra torches.");
            return;
        }
        if (fuelSource == null)
        {
            return;
        }

        // Check that our fuel is suitable
        if (!Game.ItemMatchesFilter(fuelSource, base.Game.SingletonRepository.Get<ItemFilter>(nameof(ItemFilters.TorchFuelItemFilter))))
        {
            Game.MsgPrint("You can't refill a torch with that!");
            return;
        }
        // Refueling takes half a turn
        Game.EnergyUse = 50;

        // Add the fuel
        item.TurnsOfLightRemaining += fuelSource.TurnsOfLightRemaining + 5;
        Game.MsgPrint("You combine the torches.");

        // Check for overfilling
        if (item.TurnsOfLightRemaining >= Constants.FuelTorch)
        {
            item.TurnsOfLightRemaining = Constants.FuelTorch;
            Game.MsgPrint("Your torch is fully fueled.");
        }
        else
        {
            Game.MsgPrint("Your torch glows more brightly.");
        }

        // Update the player's inventory
        fuelSource.ItemIncrease(-1);
        fuelSource.ItemDescribe();
        fuelSource.ItemOptimize();
        base.Game.SingletonRepository.Get<FlaggedAction>(nameof(FlaggedActions.UpdateTorchRadiusFlaggedAction)).Set();
    }
}