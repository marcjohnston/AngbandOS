﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Stores;

[Serializable]
internal class BlackStore : Store
{
    private BlackStore(SaveGame saveGame) : base(saveGame) { }

    public override int MaxInventory => 75;
    public override int StoreMinKeep => 35;
    public override int StoreMaxKeep => 65;
    public override int StoreTurnover => 5;
    public override string FeatureType => "BlackMarket";
    public override ColourEnum Colour => ColourEnum.Black;
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<NumberSevenSymbol>();
    public override string Description => "Black Market";

    protected override StoreOwner[] StoreOwners => new StoreOwner[]
    {
        SaveGame.SingletonRepository.StoreOwners.Get<VhassaTheDeadStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<KynTheTreacherousStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<BatrachianBelleStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<CorpselightStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<ParrishTheBloodthirstyStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<VileStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<PrenticeTheTrustedStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<GriellaHumanslayerStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<CharityTheNecromancerStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<PugnaciousThePugilistStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<FootsoreTheLuckyStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<SidriaLighfingeredStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<RiathoTheJugglerStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<JanaakaTheShiftyStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<CinaTheRogueStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<ArunikkiGreatclawStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<ChaeandThePoorStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<AfardorfTheBrigandStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<LathaxlTheGreedyStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<FalarewynStoreOwner>()
    };

    protected override StockStoreInventoryItem[] GetStoreTable()
    {
        return null;
    }

    public override bool ItemMatches(Item item)
    {
        return item.Value() > 0;
    }

    protected override int AdjustPrice(int price, bool trueToMarkDownFalseToMarkUp)
    {
        if (trueToMarkDownFalseToMarkUp == true)
        {
            return price / 2;
        }
        else
        {
            return price * 2;
        }
    }

    protected override Item CreateItem()
    {
        int level;
        level = 35 + SaveGame.Rng.RandomLessThan(35);
        ItemFactory itemType = SaveGame.RandomItemType(level, false, false);
        if (itemType == null)
        {
            return null; ;
        }
        Item qPtr = itemType.CreateItem();
        qPtr.ApplyMagic(level, false, false, false, this);
        return qPtr;
    }
    protected override int MinimumItemValue => 10;
}