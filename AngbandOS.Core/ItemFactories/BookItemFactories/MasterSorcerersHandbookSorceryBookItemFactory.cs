// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class MasterSorcerersHandbookSorceryBookItemFactory : ItemFactory
{
    private MasterSorcerersHandbookSorceryBookItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolBindingKey => nameof(QuestionMarkSymbol);
    public override ColorEnum Color => ColorEnum.BrightBlue;
    public override string Name => "[Master Sorcerer's Handbook]";
    protected override string? DescriptionSyntax => "Sorcery Spellbook~ $Name$";
    protected override string? AlternateDescriptionSyntax => "Book~ of Sorcery $Name$";
    public override int Cost => 1000;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override int LevelNormallyFound => 20;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (20, 1)
    };
    public override int Weight => 30;

    protected override string[] SpellBindingKeys => new string[]
    {
        nameof(SorcerySpellMagicMapping),
        nameof(SorcerySpellIdentify),
        nameof(SorcerySpellSlowMonster),
        nameof(SorcerySpellMassSleep),
        nameof(SorcerySpellTeleportAway),
        nameof(SorcerySpellHasteSelf),
        nameof(SorcerySpellDetectionTrue),
        nameof(SorcerySpellIdentifyTrue)
    };
    /// <summary>
    /// Returns just the realm name because Sorcery automatically assumes magic--so we omit the "Magic" suffix from the divine title.
    /// </summary>
    protected override string ItemClassBindingKey => nameof(SorcerySpellBooksItemClass);
    public override bool HatesFire => true;
    public override int PackSort => 7;

    /// <summary>
    /// Returns true, because books are magical and should be detected with the detect magic scroll.
    /// </summary>
    public override bool IsMagical => true;

    /// <summary>
    /// Returns true for all books.
    /// </summary>
    public override bool EasyKnow => true;

    protected override (int, string)[]? MassProduceBindingTuples => new (int, string)[]
    {
        (50, "2d3-2"),
        (500, "1d3-1")
    };

    public override int ExperienceGainDivisorForDestroying => 4;
}