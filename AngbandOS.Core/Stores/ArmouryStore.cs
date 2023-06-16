// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Stores;

[Serializable]
internal class ArmouryStore : Store
{
    public ArmouryStore(SaveGame saveGame) : base(saveGame) { }

    public override StoreType StoreType => StoreType.StoreArmoury;
    protected override StoreOwner[] StoreOwners => new StoreOwner[]
    {
        SaveGame.SingletonRepository.StoreOwners.Get<KonDarTheUglyStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<DargLowTheGrimStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<DecadoTheHandsomeStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<EloDragonscaleStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<DelicatusStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<GruceTheHugeStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<AnimusStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<MalvusStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<SelaxisStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<DeathchillStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<DriosTheFaintStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<BathricTheColdStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<VengellaTheCruelStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<WyranaTheMightyStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<YojoIIStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<RanalarTheSweetStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<HorbagTheUncleanStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<ElelenTheTelepathStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<IsedreliasStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<VegnarOneEyeStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<RodishTheChaoticStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<HesinSwordmasterStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<ElvererithTheCheatStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<ZzathathTheImpStoreOwner>()
    };

    public override string FeatureType => "Armoury";
    public override Colour Colour => Colour.Grey;
    public override char Character => '2';

    protected override StockStoreInventoryItem[] GetStoreTable()
    {
        return new[]
        {
            new StockStoreInventoryItem(typeof(HardLeatherBootsArmorItemFactory), 4),
            new StockStoreInventoryItem(typeof(SoftLeatherBootsArmorItemFactory), 2),
            new StockStoreInventoryItem(typeof(GauntletGlovesArmorItemFactory), 2),
            new StockStoreInventoryItem(typeof(LeatherGlovesArmorItemFactory), 3),
            new StockStoreInventoryItem(typeof(HardArmorAugmentedChainMail)),
            new StockStoreInventoryItem(typeof(HardArmorBarChainMail)),
            new StockStoreInventoryItem(typeof(HardArmorChainMail), 4),
            new StockStoreInventoryItem(typeof(HardArmorDoubleChainMail)),
            new StockStoreInventoryItem(typeof(HardArmorMetalBrigandineArmour)),
            new StockStoreInventoryItem(typeof(HardArmorMetalScaleMail), 2),
            new StockStoreInventoryItem(typeof(HelmHardLeatherCap), 4),
            new StockStoreInventoryItem(typeof(HelmIronHelm)),
            new StockStoreInventoryItem(typeof(HelmMetalCap)),
            new StockStoreInventoryItem(typeof(ShieldLargeLeatherShield)),
            new StockStoreInventoryItem(typeof(ShieldSmallLeatherShield), 4),
            new StockStoreInventoryItem(typeof(ShieldSmallMetalShield)),
            new StockStoreInventoryItem(typeof(SoftArmorHardLeatherArmour), 3),
            new StockStoreInventoryItem(typeof(SoftArmorHardStuddedLeather), 2),
            new StockStoreInventoryItem(typeof(SoftArmorLeatherScaleMail), 3),
            new StockStoreInventoryItem(typeof(SoftArmorRobe), 3),
            new StockStoreInventoryItem(typeof(SoftArmorSoftLeatherArmour), 4),
        };
    }

    public override bool ItemMatches(Item item)
    {
        switch (item.Factory)
        {
            case BootsArmorItemFactory _:
            case GlovesArmorItemFactory _:
            case CrownArmorItemFactory _:
            case HelmItemClass _:
            case ShieldItemClass _:
            case CloakArmorItemFactory _:
            case SoftArmorItemClass _:
            case HardArmorItemClass _:
            case DragonScaleMailArmorItemFactory _:
                return item.Value() > 0;
            default:
                return false;
        }
    }
    protected override BaseStoreCommand AdvertisedStoreCommand4 => SaveGame.SingletonRepository.StoreCommands.Get<EnchantArmorStoreCommand>();
}
