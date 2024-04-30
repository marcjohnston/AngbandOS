// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class BrassLanternLightSourceItemFactory : LightSourceItemFactory
{
    private BrassLanternLightSourceItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override void ApplyMagic(Item item, int level, int power, Store? store)
    {
        if (store != null)
        {
            item.TurnsOfLightRemaining = Constants.FuelLamp / 2;
        }
        else if (item.TurnsOfLightRemaining != 0)
        {
            item.TurnsOfLightRemaining = Game.DieRoll(item.TurnsOfLightRemaining);
        }
    }

    /// <summary>
    /// Returns an intensity of light provided by the lantern.  2, if the lantern has turns remaining, plus an additional 3
    /// if the lantern is an artifact.
    /// </summary>
    /// <param name="oPtr"></param>
    /// <returns></returns>
    public override int CalculateTorch(Item item)
    {
        return base.CalculateTorch(item) + item.TurnsOfLightRemaining > 0 ? 2 : 0;
    }

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

    public override Symbol Symbol => Game.SingletonRepository.Get<Symbol>(nameof(TildeSymbol));
    public override ColorEnum Color => ColorEnum.BrightBrown;
    public override string Name => "Brass Lantern";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 35;
    public override int Dd => 1;
    public override int Ds => 1;
    public override bool EasyKnow => true;
    public override string FriendlyName => "& Brass Lantern~";
    public override bool IgnoreFire => true;
    public override int LevelNormallyFound => 3;
    public override int[] Locale => new int[] { 3, 0, 0, 0 };
    public override int InitialTurnsOfLight => 7500;
    public override int Weight => 50;

    /// <summary>
    /// Refill a lamp
    /// </summary>
    /// <param name="itemIndex"> The inventory index of the fuel </param>
    public override void Refill(Game game, Item item)
    {
        // Get an item if we don't already have one
        if (!game.SelectItem(out Item? fuelSource, "Refill with which flask? ", false, true, true, Game.SingletonRepository.Get<ItemFilter>(nameof(LanternFuelItemFilter))))
        {
            game.MsgPrint("You have no flasks of oil.");
            return;
        }

        // Get the item from the inventory or from the floor.
        if (fuelSource == null)
        {
            return;
        }

        // Make sure our item is suitable fuel
        if (!game.ItemMatchesFilter(fuelSource, Game.SingletonRepository.Get<ItemFilter>(nameof(LanternFuelItemFilter))))
        {
            game.MsgPrint("You can't refill a lantern from that!");
            return;
        }
        // Refilling takes half a turn
        game.EnergyUse = 50;

        // Add the fuel
        item.TurnsOfLightRemaining += fuelSource.TurnsOfLightRemaining;
        game.MsgPrint("You fuel your lamp.");

        // Check for overfilling
        if (item.TurnsOfLightRemaining >= Constants.FuelLamp)
        {
            item.TurnsOfLightRemaining = Constants.FuelLamp;
            game.MsgPrint("Your lamp is full.");
        }

        // Update the inventory
        fuelSource.ItemIncrease(-1);
        fuelSource.ItemDescribe();
        fuelSource.ItemOptimize();
        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateTorchRadiusFlaggedAction)).Set();
    }
    public override Item CreateItem() => new Item(Game, this);
}
