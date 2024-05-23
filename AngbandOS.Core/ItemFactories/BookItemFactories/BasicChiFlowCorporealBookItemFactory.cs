// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class BasicChiFlowCorporealBookItemFactory : BookItemFactory
{
    private BasicChiFlowCorporealBookItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(QuestionMarkSymbol);
    public override ColorEnum Color => ColorEnum.Yellow;
    public override string Name => "[Basic Chi Flow]";

    public override int Cost => 100;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override string FriendlyName => "[Basic Chi Flow]";
    public override string CodedName => "& Corporeal Spellbook~ [Basic Chi Flow]";
    public override int LevelNormallyFound => 10;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (10, 1)
    };
    public override int Weight => 30;
    public override bool KindIsGood => false;

    protected override string[] SpellNames => new string[]
    {
        nameof(CorporealSpellBlink),
        nameof(CorporealSpellBravery),
        nameof(CorporealSpellBatsSense),
        nameof(CorporealSpellEaglesVision),
        nameof(CorporealSpellMindVision),
        nameof(CorporealSpellCureMediumWounds),
        nameof(CorporealSpellCureLightWounds),
        nameof(CorporealSpellSatisfyHunger)
    };
    protected override string ItemClassName => nameof(CorporealSpellBooksItemClass);
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.CorporealBook;
    public override string? CodedDivineName => "& Book~ of Corporeal Magic";

    public override int PackSort => 1;
    public override bool HatesFire => true;
}
