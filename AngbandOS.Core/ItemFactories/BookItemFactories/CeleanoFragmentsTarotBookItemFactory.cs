// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class CeleanoFragmentsTarotBookItemFactory : BookItemFactory
{
    private CeleanoFragmentsTarotBookItemFactory(Game game) : base(game) { } // This object is a singleton.


    /// <summary>
    /// Returns a divisor of 1 because this is the most powerful book for this realm of magic.  Destroying this book provides the most experience.
    /// </summary>
    public override int ExperienceGainDivisorForDestroying => 1;

    protected override string SymbolName => nameof(QuestionMarkSymbol);
    public override ColorEnum Color => ColorEnum.Pink;
    public override string Name => "[Celeano Fragments]";
    protected override string? DescriptionSyntax => "Tarot Spellbook~ $Name$";
    protected override string? AlternateDescriptionSyntax => "Book~ of Tarot Magic $Name$";
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

    public override int Weight => 30;
    public override bool KindIsGood => true;

    protected override string[] SpellNames => new string[]
    {
        nameof(TarotSpellEtherealDivination),
        nameof(TarotSpellAstralLore),
        nameof(TarotSpellSummonUndead),
        nameof(TarotSpellSummonDragon),
        nameof(TarotSpellMassSummons),
        nameof(TarotSpellSummonDemon),
        nameof(TarotSpellSummonAncientDragon),
        nameof(TarotSpellSummonGreaterUndead)
    };
    protected override string ItemClassName => nameof(TarotSpellBooksItemClass);
    public override int PackSort => 3;
    public override bool HatesFire => true;

    /// <summary>
    /// Returns true, because books are magical and should be detected with the detect magic scroll.
    /// </summary>
    public override bool IsMagical => true;

    /// <summary>
    /// Returns true for all books.
    /// </summary>
    public override bool EasyKnow => true;

    protected override (int, string)[]? MassProduceTupleNames => new (int, string)[]
    {
        (50, "2d3-2"),
        (500, "1d3-1")
    };
}
