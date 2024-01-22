// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.StoreFactories;

[Serializable]
internal class AlchemistStoreFactory : StoreFactory
{
    private AlchemistStoreFactory(SaveGame saveGame) : base(saveGame) { }

    public override StoreOwner[] StoreOwners => new StoreOwner[]
    {
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(MauserTheChemistStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(WizzleTheChaoticStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(KakalrakakalStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(JalEthTheAlchemistStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(FanelathTheCautiousStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(RuncieTheInsaneStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(GrumbleworthStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(FlitterStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(XarillusStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(EgbertTheOldStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(ValindraTheProudStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(TaenTheAlchemistStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(CaydTheSweetStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(FulirTheDarkStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(DomliTheHumbleStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(YaarjukkaDemonspawnStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(GelaraldorTheHerbmasterStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(OlelaldanTheWiseStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(FthogloTheDemonicistStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(DridashTheAlchemistStoreOwner))
    };

    public override string FeatureType => "Alchemist";
    public override ColourEnum Colour => ColourEnum.Blue;
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(NumberFiveSymbol));
    public override string Description => "Alchemy Shop";

    public override StockStoreInventoryItem[] GetStoreTable()
    {
        return new[]
        {
            new StockStoreInventoryItem(typeof(RestoreCharismaPotionItemFactory), 2),
            new StockStoreInventoryItem(typeof(RestoreConstitutionPotionItemFactory), 2),
            new StockStoreInventoryItem(typeof(RestoreDexterityPotionItemFactory), 2),
            new StockStoreInventoryItem(typeof(RestoreIntelligencePotionItemFactory), 2),
            new StockStoreInventoryItem(typeof(RestoreStrengthPotionItemFactory), 2),
            new StockStoreInventoryItem(typeof(RestoreWisdomPotionItemFactory), 2),
            new StockStoreInventoryItem(typeof(ScrollDetectInvisible)),
            new StockStoreInventoryItem(typeof(ScrollEnchantArmor), 3),
            new StockStoreInventoryItem(typeof(ScrollEnchantWeaponToDam)),
            new StockStoreInventoryItem(typeof(ScrollEnchantWeaponToHit)),
            new StockStoreInventoryItem(typeof(ScrollIdentify), 6),
            new StockStoreInventoryItem(typeof(ScrollLight), 2),
            new StockStoreInventoryItem(typeof(ScrollMagicMapping)),
            new StockStoreInventoryItem(typeof(ScrollMonsterConfusion)),
            new StockStoreInventoryItem(typeof(ScrollObjectDetection)),
            new StockStoreInventoryItem(typeof(ScrollPhaseDoor), 2),
            new StockStoreInventoryItem(typeof(ScrollRecharging), 2),
            new StockStoreInventoryItem(typeof(ScrollSatisfyHunger), 4),
            new StockStoreInventoryItem(typeof(ScrollSpecialIdentify), 2),
            new StockStoreInventoryItem(typeof(ScrollTeleportation), 3),
            new StockStoreInventoryItem(typeof(ScrollTrapDetection)),
            new StockStoreInventoryItem(typeof(ScrollTreasureDetection)),
            new StockStoreInventoryItem(typeof(ScrollWordOfRecall), 4),
        };
    }

    public override bool ItemMatches(Item item)
    {
        switch (item.Factory)
        {
            case ScrollItemClass _:
            case PotionItemFactory _:
                return item.Value() > 0;
            default:
                return false;
        }
    }
    public override StoreCommand AdvertisedStoreCommand4 => SaveGame.SingletonRepository.StoreCommands.Get(nameof(RestorationStoreCommand));
}