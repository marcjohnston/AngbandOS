// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.StoreFactories;

[Serializable]
internal class BlackStoreFactory : StoreFactory
{
    private BlackStoreFactory(SaveGame saveGame) : base(saveGame) { }

    public override int MaxInventory => 75;
    public override int MinInventory => 35;
    public override int StoreTurnover => 5;
    public override string FeatureType => "BlackMarket";
    public override ColorEnum Color => ColorEnum.Black;
    protected override string SymbolName => nameof(NumberSevenSymbol);
    public override string Description => "Black Market";

    protected override string[] StoreOwnerNames => new string[]
    {
        nameof(VhassaTheDeadStoreOwner),
        nameof(KynTheTreacherousStoreOwner),
        nameof(BatrachianBelleStoreOwner),
        nameof(CorpselightStoreOwner),
        nameof(ParrishTheBloodthirstyStoreOwner),
        nameof(VileStoreOwner),
        nameof(PrenticeTheTrustedStoreOwner),
        nameof(GriellaHumanslayerStoreOwner),
        nameof(CharityTheNecromancerStoreOwner),
        nameof(PugnaciousThePugilistStoreOwner),
        nameof(FootsoreTheLuckyStoreOwner),
        nameof(SidriaLighfingeredStoreOwner),
        nameof(RiathoTheJugglerStoreOwner),
        nameof(JanaakaTheShiftyStoreOwner),
        nameof(CinaTheRogueStoreOwner),
        nameof(ArunikkiGreatclawStoreOwner),
        nameof(ChaeandThePoorStoreOwner),
        nameof(AfardorfTheBrigandStoreOwner),
        nameof(LathaxlTheGreedyStoreOwner),
        nameof(FalarewynStoreOwner)
    };

    public override StoreStockManifest[]? GetStoreTable() => null;

    /// <summary>
    /// Returns the name of the item matching criteria for any item of value.
    /// </summary>
    protected override string[] ItemFilterNames => new string[]
    {
        nameof(AnythingOfValueItemFilter)
    };

    public override int AdjustPrice(int price, bool trueToMarkDownFalseToMarkUp)
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

    public override Item? CreateItem(Store store)
    {
        int level;
        level = 35 + SaveGame.Rng.RandomLessThan(35);
        ItemFactory itemFactory = SaveGame.RandomItemType(level, false, false);
        if (itemFactory == null)
        {
            return null; ;
        }
        Item qPtr = itemFactory.CreateItem();
        qPtr.ApplyMagic(level, false, false, false, store);
        return qPtr;
    }
    public override int MinimumItemValue => 110;
}
