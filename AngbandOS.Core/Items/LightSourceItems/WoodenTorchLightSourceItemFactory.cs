// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class WoodenTorchLightSourceItemFactory : LightSourceItemFactory
{
    private WoodenTorchLightSourceItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    /// <summary>
    /// Returns 1 because wooden torches consume a single turn of light for every world turn.
    /// </summary>
    public override int BurnRate => 1;

    public override char Character => '~';
    public override Colour Colour => Colour.Brown;
    public override string Name => "Wooden Torch";

    /// <summary>
    /// Returns 5000 because it is the maximum amount of fuel that can be used for a phlogiston.
    /// </summary>
    public override int? MaxPhlogiston => 5000;

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 2;
    public override int Dd => 1;
    public override int Ds => 1;
    public override bool EasyKnow => true;
    public override string FriendlyName => "& Wooden Torch~";
    public override int Level => 1;
    public override int[] Locale => new int[] { 1, 0, 0, 0 };
    public override int Pval => 4000;
    public override int? SubCategory => 0;
    public override int Weight => 30;
    /// <summary>
    /// Refill a torch from another torch
    /// </summary>
    /// <param name="itemIndex"> The inventory index of the fuel </param>
    public override void Refill(SaveGame saveGame, Item item)
    {
        // Get an item if we don't already have one
        if (!saveGame.SelectItem(out Item? fuelSource, "Refuel with which torch? ", false, true, true, new TorchFuelItemFilter()))
        {
            saveGame.MsgPrint("You have no extra torches.");
            return;
        }
        if (fuelSource == null)
        {
            return;
        }

        // Check that our fuel is suitable
        if (!saveGame.Player.ItemMatchesFilter(fuelSource, new TorchFuelItemFilter()))
        {
            saveGame.MsgPrint("You can't refill a torch with that!");
            return;
        }
        // Refueling takes half a turn
        saveGame.EnergyUse = 50;

        // Add the fuel
        item.TypeSpecificValue += fuelSource.TypeSpecificValue + 5;
        saveGame.MsgPrint("You combine the torches.");

        // Check for overfilling
        if (item.TypeSpecificValue >= Constants.FuelTorch)
        {
            item.TypeSpecificValue = Constants.FuelTorch;
            saveGame.MsgPrint("Your torch is fully fueled.");
        }
        else
        {
            saveGame.MsgPrint("Your torch glows more brightly.");
        }

        // Update the player's inventory
        fuelSource.ItemIncrease(-1);
        fuelSource.ItemDescribe();
        fuelSource.ItemOptimize();
        saveGame.UpdateTorchRadiusFlaggedAction.Set();
    }

    /// <summary>
    /// Returns a new WoodenTorchLightSourceItem.
    /// </summary>
    /// <returns></returns>
    public override Item CreateItem() => new WoodenTorchLightSourceItem(SaveGame);

    /// <summary>
    /// Returns a radius of 1 because a torch provides light shorter than the default 2 radius for a typical light source.
    /// </summary>
    public override int Radius => 1;
}
