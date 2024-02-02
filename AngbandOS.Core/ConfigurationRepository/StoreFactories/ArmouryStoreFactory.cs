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

    public override StoreStockManifest[]? StoreStockManifests => new[]
    {
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(HardLeatherBootsArmorItemFactory)), 4),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(SoftLeatherBootsArmorItemFactory)), 2),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(GauntletGlovesArmorItemFactory)), 2),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(LeatherGlovesArmorItemFactory)), 3),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(AugmentedChainMailHardArmorItemFactory))),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(BarChainMailHardArmorItemFactory))),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(ChainMailHardArmorItemFactory)), 4),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(DoubleChainMailHardArmorItemFactory))),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(MetalBrigandineHardArmorItemFactory))),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(MetalScaleMailHardArmorItemFactory)), 2),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(HardLeatherCapHelmArmorItemFactory)), 4),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(IronHelmArmorItemFactory))),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(MetalCapHelmArmorFactory))),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(LargeLeatherShieldArmorItemFactory))),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(SmallLeatherShieldArmorItemFactory)), 4),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(SmallMetalShieldArmorItemFactory))),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(HardLeatherSoftArmorItemFactory)), 3),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(HardStuddedLeatherSoftArmorItemFactory)), 2),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(LeatherScaleMailSoftArmorItemFactory)), 3),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(RobeSoftArmorItemFactory)), 3),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(SoftLeatherSoftArmorItemFactory)), 4),
    };

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
