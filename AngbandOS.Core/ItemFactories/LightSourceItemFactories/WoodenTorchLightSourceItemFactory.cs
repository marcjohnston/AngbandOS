// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class WoodenTorchLightSourceItemFactory : LightSourceItemFactory
{
    private WoodenTorchLightSourceItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override void ApplyMagic(Item item, int level, int power, Store? store)
    {
        if (store != null)
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
    /// Returns an intensity of light provided by the torch.  1, if the torch has turns remaining, plus an optional 3
    /// if the torch is an artifact.
    /// </summary>
    /// <param name="oPtr"></param>
    /// <returns></returns>
    public override int CalculateTorch(Item item)
    {
        return base.CalculateTorch(item) + item.TurnsOfLightRemaining > 0 ? 1 : 0;
    }

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
    public override void Refill(Game game, Item item)
    {
        // Get an item if we don't already have one
        if (!game.SelectItem(out Item? fuelSource, "Refuel with which torch? ", false, true, true, Game.SingletonRepository.Get<ItemFilter>(nameof(TorchFuelItemFilter))))
        {
            game.MsgPrint("You have no extra torches.");
            return;
        }
        if (fuelSource == null)
        {
            return;
        }

        // Check that our fuel is suitable
        if (!game.ItemMatchesFilter(fuelSource, Game.SingletonRepository.Get<ItemFilter>(nameof(TorchFuelItemFilter))))
        {
            game.MsgPrint("You can't refill a torch with that!");
            return;
        }
        // Refueling takes half a turn
        game.EnergyUse = 50;

        // Add the fuel
        item.TurnsOfLightRemaining += fuelSource.TurnsOfLightRemaining + 5;
        game.MsgPrint("You combine the torches.");

        // Check for overfilling
        if (item.TurnsOfLightRemaining >= Constants.FuelTorch)
        {
            item.TurnsOfLightRemaining = Constants.FuelTorch;
            game.MsgPrint("Your torch is fully fueled.");
        }
        else
        {
            game.MsgPrint("Your torch glows more brightly.");
        }

        // Update the player's inventory
        fuelSource.ItemIncrease(-1);
        fuelSource.ItemDescribe();
        fuelSource.ItemOptimize();
        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateTorchRadiusFlaggedAction)).Set();
    }

    /// <summary>
    /// Returns a new WoodenTorchLightSourceItem.
    /// </summary>
    /// <returns></returns>

    /// <summary>
    /// Returns a radius of 1 because a torch provides light shorter than the default 2 radius for a typical light source.
    /// </summary>
    public override int Radius => 1;
}
