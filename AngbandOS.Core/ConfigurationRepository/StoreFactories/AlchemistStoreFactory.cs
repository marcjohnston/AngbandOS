// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.StoreFactories;

[Serializable]
internal partial class AlchemistStoreFactory : StoreFactory
{
    private AlchemistStoreFactory(SaveGame saveGame) : base(saveGame) { }

    protected override string[] StoreOwnerNames => new string[]
    {
        nameof(MauserTheChemistStoreOwner),
        nameof(WizzleTheChaoticStoreOwner),
        nameof(KakalrakakalStoreOwner),
        nameof(JalEthTheAlchemistStoreOwner),
        nameof(FanelathTheCautiousStoreOwner),
        nameof(RuncieTheInsaneStoreOwner),
        nameof(GrumbleworthStoreOwner),
        nameof(FlitterStoreOwner),
        nameof(XarillusStoreOwner),
        nameof(EgbertTheOldStoreOwner),
        nameof(ValindraTheProudStoreOwner),
        nameof(TaenTheAlchemistStoreOwner),
        nameof(CaydTheSweetStoreOwner),
        nameof(FulirTheDarkStoreOwner),
        nameof(DomliTheHumbleStoreOwner),
        nameof(YaarjukkaDemonspawnStoreOwner),
        nameof(GelaraldorTheHerbmasterStoreOwner),
        nameof(OlelaldanTheWiseStoreOwner),
        nameof(FthogloTheDemonicistStoreOwner),
        nameof(DridashTheAlchemistStoreOwner)
    };

    public override string FeatureType => "Alchemist";
    public override ColorEnum Color => ColorEnum.Blue;
    protected override string SymbolName => nameof(NumberFiveSymbol);
    public override string Description => "Alchemy Shop";

    public override StoreStockManifest[]? StoreStockManifests => new[]
    {
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(RestoreCharismaPotionItemFactory)), 2),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(RestoreConstitutionPotionItemFactory)), 2),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(RestoreDexterityPotionItemFactory)), 2),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(RestoreIntelligencePotionItemFactory)), 2),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(RestoreStrengthPotionItemFactory)), 2),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(RestoreWisdomPotionItemFactory)), 2),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(DetectInvisibleScrollItemFactory))),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(EnchantArmorScrollItemFactory)), 3),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(EnchantWeaponToDamScrollItemFactory))),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(EnchantWeaponToHitScrollItemFactory))),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(IdentifyScrollItemFactory)), 6),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(LightScrollItemFactory)), 2),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(MagicMappingScrollItemFactory))),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(MonsterConfusionScrollItemFactory))),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(ObjectDetectionScrollItemFactory))),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(PhaseDoorScrollItemFactory)), 2),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(RechargingScrollItemFactory)), 2),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(SatisfyHungerScrollItemFactory)), 4),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(SpecialIdentifyScrollItemFactory)), 2),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(TeleportationScrollItemFactory)), 3),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(TrapDetectionScrollItemFactory))),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(TreasureDetectionScrollItemFactory))),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(WordofRecallScrollItemFactory)), 4),
    };

    /// <summary>
    /// Returns the name of the item matching criteria for scrolls and potions of value.
    /// </summary>
    protected override string[] ItemFilterNames => new string[]
    {
        nameof(ScrollItemFilter),
        nameof(PotionItemFilter)
    };

    protected override string? AdvertisedStoreCommand4Name => nameof(RestorationStoreCommand);
}