﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.StoreFactories;

[Serializable]
internal class ArmoryStoreFactory : StoreFactory
{
    private ArmoryStoreFactory(SaveGame saveGame) : base(saveGame) { }

    protected override string[] StoreOwnerNames => new string[]
    {
        nameof(KonDarTheUglyStoreOwner),
        nameof(DargLowTheGrimStoreOwner),
        nameof(DecadoTheHandsomeStoreOwner),
        nameof(EloDragonscaleStoreOwner),
        nameof(DelicatusStoreOwner),
        nameof(GruceTheHugeStoreOwner),
        nameof(AnimusStoreOwner),
        nameof(MalvusStoreOwner),
        nameof(SelaxisStoreOwner),
        nameof(DeathchillStoreOwner),
        nameof(DriosTheFaintStoreOwner),
        nameof(BathricTheColdStoreOwner),
        nameof(VengellaTheCruelStoreOwner),
        nameof(WyranaTheMightyStoreOwner),
        nameof(YojoIIStoreOwner),
        nameof(RanalarTheSweetStoreOwner),
        nameof(HorbagTheUncleanStoreOwner),
        nameof(ElelenTheTelepathStoreOwner),
        nameof(IsedreliasStoreOwner),
        nameof(VegnarOneEyeStoreOwner),
        nameof(RodishTheChaoticStoreOwner),
        nameof(HesinSwordmasterStoreOwner),
        nameof(ElvererithTheCheatStoreOwner),
        nameof(ZzathathTheImpStoreOwner)
    };

    public override string FeatureType => "Armory";
    public override ColorEnum Color => ColorEnum.Grey;
    protected override string SymbolName => nameof(NumberTwoSymbol);

    public override StockStoreInventoryItem[]? GetStoreTable()
    {
        return new[]
        {
            new StockStoreInventoryItem(typeof(HardLeatherBootsArmorItemFactory), 4),
            new StockStoreInventoryItem(typeof(SoftLeatherBootsArmorItemFactory), 2),
            new StockStoreInventoryItem(typeof(GauntletGlovesArmorItemFactory), 2),
            new StockStoreInventoryItem(typeof(LeatherGlovesArmorItemFactory), 3),
            new StockStoreInventoryItem(typeof(AugmentedChainMailHardArmorItemFactory)),
            new StockStoreInventoryItem(typeof(BarChainMailHardArmorItemFactory)),
            new StockStoreInventoryItem(typeof(ChainMailHardArmorItemFactory), 4),
            new StockStoreInventoryItem(typeof(DoubleChainMailHardArmorItemFactory)),
            new StockStoreInventoryItem(typeof(MetalBrigandineHardArmorItemFactory)),
            new StockStoreInventoryItem(typeof(MetalScaleMailHardArmorItemFactory), 2),
            new StockStoreInventoryItem(typeof(HardLeatherCapHelmArmorItemFactory), 4),
            new StockStoreInventoryItem(typeof(IronHelmArmorItemFactory)),
            new StockStoreInventoryItem(typeof(MetalCapHelmArmorFactory)),
            new StockStoreInventoryItem(typeof(LargeLeatherShieldArmorItemFactory)),
            new StockStoreInventoryItem(typeof(SmallLeatherShieldArmorItemFactory), 4),
            new StockStoreInventoryItem(typeof(SmallMetalShieldArmorItemFactory)),
            new StockStoreInventoryItem(typeof(HardLeatherSoftArmorItemFactory), 3),
            new StockStoreInventoryItem(typeof(HardStuddedLeatherSoftArmorItemFactory), 2),
            new StockStoreInventoryItem(typeof(LeatherScaleMailSoftArmorItemFactory), 3),
            new StockStoreInventoryItem(typeof(RobeSoftArmorItemFactory), 3),
            new StockStoreInventoryItem(typeof(SoftLeatherSoftArmorItemFactory), 4),
        };
    }

    /// <summary>
    /// Returns the name of the item matching criteria for shots, bolts, arrows, bows, digging tools, hafted weapons, pole arms and swords of value.
    /// </summary>
    protected override string[] ItemFilterNames => new string[]
{
        nameof(BootsArmorItemFilter),
        nameof(GlovesArmorItemFilter),
        nameof(CrownArmorItemFilter),
        nameof(HelmItemFilter),
        nameof(ShieldItemFilter),
        nameof(CloakArmorItemFilter),
        nameof(SoftArmorItemFilter),
        nameof(HardArmorItemFilter),
        nameof(DragonScaleMailItemFilter)
    };

    protected override string? AdvertisedStoreCommand4Name => nameof(EnchantArmorStoreCommand);
}