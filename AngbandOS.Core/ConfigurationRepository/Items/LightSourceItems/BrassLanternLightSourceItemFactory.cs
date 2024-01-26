// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using AngbandOS.Core.ConfigurationRepository.ItemMatchingCriterion;

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class BrassLanternLightSourceItemFactory : LightSourceItemFactory
{
    private BrassLanternLightSourceItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    /// <summary>
    /// Returns 1 because a latern consumes a turn of light for every world turn.
    /// </summary>
    public override int BurnRate => 1;

    /// <summary>
    /// Returns 15000 because it is the maximum amount of fuel that can be used for a phlogiston.
    /// </summary>
    public override int? MaxPhlogiston => 15000;

    /// <summary>
    /// Returns true because a lantern contains oil which is valid as fuel for other lanterns.
    /// </summary>
    public override bool IsFuelForLantern => true;

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(TildeSymbol));
    public override ColourEnum Colour => ColourEnum.BrightBrown;
    public override string Name => "Brass Lantern";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 35;
    public override int Dd => 1;
    public override int Ds => 1;
    public override bool EasyKnow => true;
    public override string FriendlyName => "& Brass Lantern~";
    public override bool IgnoreFire => true;
    public override int Level => 3;
    public override int[] Locale => new int[] { 3, 0, 0, 0 };
    public override int Pval => 7500;
    public override int Weight => 50;

    /// <summary>
    /// Refill a lamp
    /// </summary>
    /// <param name="itemIndex"> The inventory index of the fuel </param>
    public override void Refill(SaveGame saveGame, Item item)
    {
        // Get an item if we don't already have one
        if (!saveGame.SelectItem(out Item? fuelSource, "Refill with which flask? ", false, true, true, SaveGame.SingletonRepository.ItemFilters.Get(nameof(LanternFuelItemFilter))))
        {
            saveGame.MsgPrint("You have no flasks of oil.");
            return;
        }

        // Get the item from the inventory or from the floor.
        if (fuelSource == null)
        {
            return;
        }

        // Make sure our item is suitable fuel
        if (!saveGame.ItemMatchesFilter(fuelSource, SaveGame.SingletonRepository.ItemFilters.Get(nameof(LanternFuelItemFilter))))
        {
            saveGame.MsgPrint("You can't refill a lantern from that!");
            return;
        }
        // Refilling takes half a turn
        saveGame.EnergyUse = 50;

        // Add the fuel
        item.TypeSpecificValue += fuelSource.TypeSpecificValue;
        saveGame.MsgPrint("You fuel your lamp.");

        // Check for overfilling
        if (item.TypeSpecificValue >= Constants.FuelLamp)
        {
            item.TypeSpecificValue = Constants.FuelLamp;
            saveGame.MsgPrint("Your lamp is full.");
        }

        // Update the inventory
        fuelSource.ItemIncrease(-1);
        fuelSource.ItemDescribe();
        fuelSource.ItemOptimize();
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(UpdateTorchRadiusFlaggedAction)).Set();
    }
    public override Item CreateItem() => new BrassLanternLightSourceItem(SaveGame);
}
