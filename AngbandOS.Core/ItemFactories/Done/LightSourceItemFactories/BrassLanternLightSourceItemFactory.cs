// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class BrassLanternLightSourceItemFactory : ItemFactory
{
    private BrassLanternLightSourceItemFactory(Game game) : base(game) { } // This object is a singleton.

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
    public override bool IsLanternFuel => true;

    protected override string SymbolName => nameof(TildeSymbol);
    public override ColorEnum Color => ColorEnum.BrightBrown;
    public override string Name => "Brass Lantern";

    public override int Cost => 35;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override bool EasyKnow => true;
    protected override string? DescriptionSyntax => "Brass Lantern~";
    public override bool IgnoreFire => true;
    public override int LevelNormallyFound => 3;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (3, 1)
    };
    public override int InitialTurnsOfLight => 7500;
    public override int Weight => 50;


    /// <summary>
    /// Returns a radius of 2 for a brass lantern.
    /// </summary>
    public override int Radius => 2;

    /// <summary>
    /// Refill a lamp
    /// </summary>
    /// <param name="itemIndex"> The inventory index of the fuel </param>
    public override void Refill(Item item)
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
        fuelSource.ItemIncrease(-1);
        fuelSource.ItemDescribe();
        fuelSource.ItemOptimize();
        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateTorchRadiusFlaggedAction)).Set();
    }
 
    /// <summary>
    /// Returns the lightsource inventory slot for light sources.
    /// </summary>
    public override int WieldSlot => InventorySlot.Lightsource;
    protected override string ItemClassName => nameof(LightSourcesItemClass);
    public override BaseInventorySlot BaseWieldSlot => Game.SingletonRepository.Get<BaseInventorySlot>(nameof(LightsourceInventorySlot));

    protected override (int, string)[]? MassProduceTupleNames => new (int, string)[]
    {
        (20, "3d5-3")
    };

    protected override (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]? EnchantmentBinders => new (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]
    {
        (new int[] {-1, -2}, null, new string[] { nameof(PoorOrbOfLightEnchantmentScript) }),
        (new int[] {1}, null, new string[] { nameof(GoodOrbOfLightEnchantmentScript) }),
        (new int[] {2}, null, new string[] { nameof(GreatOrbOfLightEnchantmentScript) }),
        (null, true, new string[] { nameof(FillLanternEnchantmentScript) }),
        (null, false, new string[] { nameof(UsedLanternEnchantmentScript) })
    };

    protected override string BreakageChanceProbabilityExpression => "50/100";
    public override int PackSort => 18;
    public override bool HatesFire => true;

    /// <summary>
    /// Returns true, because all light sources can be worn/wielded.
    /// </summary>
    public override bool IsWearableOrWieldable => true;
}