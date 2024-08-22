// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class WoodenTorchLightSourceItemFactory : ItemFactory
{
    private WoodenTorchLightSourceItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override void EnchantItem(Item item, bool usedOkay, int level, int power)
    {
        if (!usedOkay)
        {
            item.TurnsOfLightRemaining = Constants.FuelTorch / 2;
        }
        else if (item.TurnsOfLightRemaining != 0)
        {
            item.TurnsOfLightRemaining = Game.DieRoll(item.TurnsOfLightRemaining);
        }
    }

    /// <summary>
    /// Returns true because a torch can be used as fuel for another torch.
    /// </summary>
    public override bool IsFuelForTorch => true;

    /// <summary>
    /// Returns 1 because wooden torches consume a single turn of light for every world turn.
    /// </summary>
    public override int BurnRate => 1;

    protected override string SymbolName => nameof(TildeSymbol);
    public override ColorEnum Color => ColorEnum.Brown;
    public override string Name => "Wooden Torch";

    /// <summary>
    /// Returns 5000 because it is the maximum amount of fuel that can be used for a phlogiston.
    /// </summary>
    public override int? MaxPhlogiston => 5000;

    public override int Cost => 2;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override bool EasyKnow => true;
    protected override string? DescriptionSyntax => "Wooden Torch~";
    public override int LevelNormallyFound => 1;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (1, 1)
    };
    public override int InitialTurnsOfLight => 4000;
    public override int Weight => 30;
    /// <summary>
    /// Refill a torch from another torch
    /// </summary>
    /// <param name="itemIndex"> The inventory index of the fuel </param>
    public override void Refill(Item item)
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

    /// <summary>
    /// Returns a radius of 1 for a wooden torch.
    /// </summary>
    public override int Radius => 1;

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
        (new int[] {2}, null, new string[] { nameof(GreatOrbOfLightEnchantmentScript) })
    };

    protected override string BreakageChanceProbabilityExpression => "50/100";
    public override int PackSort => 18;
    public override bool HatesFire => true;

    /// <summary>
    /// Returns true, because all light sources can be worn/wielded.
    /// </summary>
    public override bool IsWearableOrWieldable => true;
}
