// AngbandOS: 2022 Marc Johnston
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

    public override StoreStockManifest[]? GetStoreTable()
    {
        return new[]
        {
            new StoreStockManifest(typeof(HardLeatherBootsArmorItemFactory), 4),
            new StoreStockManifest(typeof(SoftLeatherBootsArmorItemFactory), 2),
            new StoreStockManifest(typeof(GauntletGlovesArmorItemFactory), 2),
            new StoreStockManifest(typeof(LeatherGlovesArmorItemFactory), 3),
            new StoreStockManifest(typeof(AugmentedChainMailHardArmorItemFactory)),
            new StoreStockManifest(typeof(BarChainMailHardArmorItemFactory)),
            new StoreStockManifest(typeof(ChainMailHardArmorItemFactory), 4),
            new StoreStockManifest(typeof(DoubleChainMailHardArmorItemFactory)),
            new StoreStockManifest(typeof(MetalBrigandineHardArmorItemFactory)),
            new StoreStockManifest(typeof(MetalScaleMailHardArmorItemFactory), 2),
            new StoreStockManifest(typeof(HardLeatherCapHelmArmorItemFactory), 4),
            new StoreStockManifest(typeof(IronHelmArmorItemFactory)),
            new StoreStockManifest(typeof(MetalCapHelmArmorFactory)),
            new StoreStockManifest(typeof(LargeLeatherShieldArmorItemFactory)),
            new StoreStockManifest(typeof(SmallLeatherShieldArmorItemFactory), 4),
            new StoreStockManifest(typeof(SmallMetalShieldArmorItemFactory)),
            new StoreStockManifest(typeof(HardLeatherSoftArmorItemFactory), 3),
            new StoreStockManifest(typeof(HardStuddedLeatherSoftArmorItemFactory), 2),
            new StoreStockManifest(typeof(LeatherScaleMailSoftArmorItemFactory), 3),
            new StoreStockManifest(typeof(RobeSoftArmorItemFactory), 3),
            new StoreStockManifest(typeof(SoftLeatherSoftArmorItemFactory), 4),
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
