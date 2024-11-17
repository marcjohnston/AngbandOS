// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class MajorMagicksFolkBookItemFactory : ItemFactory
{
    private MajorMagicksFolkBookItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolBindingKey => nameof(QuestionMarkSymbol);
    public override ColorEnum Color => ColorEnum.BrightPurple;
    public override string Name => "[Major Magicks]";
    protected override string? DescriptionSyntax => "Folk Spellbook~ $Name$";
    protected override string? AlternateDescriptionSyntax => "Book~ of Folk Magic $Name$";
    public override int Cost => 1000;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override int LevelNormallyFound => 10;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (10, 1)
    };

    public override int Weight => 30;
    public override bool KindIsGood => true;
    protected override string[] SpellBindingKeys => new string[]
    {
        nameof(FolkSpellResistLightning),
        nameof(FolkSpellResistAcid),
        nameof(FolkSpellCureMediumWounds),
        nameof(FolkSpellTeleport),
        nameof(FolkSpellStoneToMud),
        nameof(FolkSpellRayOfLight),
        nameof(FolkSpellSatisfyHunger),
        nameof(FolkSpellSeeInvisible)
    };
    protected override string ItemClassBindingKey => nameof(FolkSpellBooksItemClass);
    public override int PackSort => 2;
    public override bool HatesFire => true;

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
