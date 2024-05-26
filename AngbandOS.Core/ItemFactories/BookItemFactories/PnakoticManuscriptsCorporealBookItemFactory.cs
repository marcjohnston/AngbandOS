// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class PnakoticManuscriptsCorporealBookItemFactory : BookItemFactory
{
    private PnakoticManuscriptsCorporealBookItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(QuestionMarkSymbol);
    public override ColorEnum Color => ColorEnum.BrightYellow;
    public override string Name => "[Pnakotic Manuscripts]";
    protected override string? DescriptionSyntax => "Corporeal Spellbook~ $Name$";
    protected override string? AlternateDescriptionSyntax => "Book~ of Corporeal Magic $Name$";

    /// <summary>
    /// Returns a divisor of 1 because this is the most powerful book for this realm of magic.  Destroying this book provides the most experience.
    /// </summary>
    public override int ExperienceGainDivisorForDestroying => 1;

    public override int Cost => 100000;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int LevelNormallyFound => 90;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (90, 3)
    };

    /// <summary>
    /// Returns true, because this book is a high level book.
    /// </summary>
    public override bool IsHighLevelBook => true;
    public override int Weight => 30;
    public override bool KindIsGood => true;

    protected override string[] SpellNames => new string[]
    {
        nameof(CorporealSpellHeroism),
        nameof(CorporealSpellWraithform),
        nameof(CorporealSpellAttunement),
        nameof(CorporealSpellRestoreBody),
        nameof(CorporealSpellHealingTrue),
        nameof(CorporealSpellHypnoticEyes),
        nameof(CorporealSpellRestoreSoul),
        nameof(CorporealSpellInvulnerability)
   };
    protected override string ItemClassName => nameof(CorporealSpellBooksItemClass);
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.CorporealBook;
    public override int PackSort => 1;
    public override bool HatesFire => true;
}
