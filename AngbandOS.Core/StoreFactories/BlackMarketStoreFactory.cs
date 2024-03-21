// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.StoreFactories;

[Serializable]
internal class BlackMarketStoreFactory : StoreFactory
{
    private BlackMarketStoreFactory(Game game) : base(game) { }

    public override int MaxInventory => 78; // Should be 18
    public override int MinInventory => 36; // Should be 6
    public override int StoreTurnover => 5;
    protected override string TileName => nameof(BlackMarketStoreTile);

    protected override string[] ShopkeeperNames => new string[]
    {
        nameof(VhassaTheDeadShopkeeper),
        nameof(KynTheTreacherousShopkeeper),
        nameof(BatrachianBelleShopkeeper),
        nameof(CorpselightShopkeeper),
        nameof(ParrishTheBloodthirstyShopkeeper),
        nameof(VileShopkeeper),
        nameof(PrenticeTheTrustedShopkeeper),
        nameof(GriellaHumanslayerShopkeeper),
        nameof(CharityTheNecromancerShopkeeper),
        nameof(PugnaciousThePugilistShopkeeper),
        nameof(FootsoreTheLuckyShopkeeper),
        nameof(SidriaLighfingeredShopkeeper),
        nameof(RiathoTheJugglerShopkeeper),
        nameof(JanaakaTheShiftyShopkeeper),
        nameof(CinaTheRogueShopkeeper),
        nameof(ArunikkiGreatclawShopkeeper),
        nameof(ChaeandThePoorShopkeeper),
        nameof(AfardorfTheBrigandShopkeeper),
        nameof(LathaxlTheGreedyShopkeeper),
        nameof(FalarewynShopkeeper)
    };

    /// <summary>
    /// Returns the name of the item matching criteria for any item of value.
    /// </summary>
    protected override string[] ItemFilterNames => new string[]
    {
        nameof(AnythingOfValueItemFilter)
    };

    public override int MarkdownRate => 50;
    public override int MarkupRate => 200;

    /// <summary>
    /// Returns 35 as the base level for the black market to create a random item.
    /// </summary>
    public override int? LevelForRandomItemCreation => 35;

    public override int MinimumItemValue => 110;
}
