// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class CommonPrayerLifeBookItemFactory : BookItemFactory
{
    private CommonPrayerLifeBookItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(QuestionMarkSymbol);
    public override string Name => "[Book of Common Prayer]";
    protected override string? DescriptionSyntax => "Life Spellbook~ $Name$";
    protected override string? AlternateDescriptionSyntax => "Book~ of Life Magic $Name$";
    public override int Cost => 100;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override int LevelNormallyFound => 10;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (10, 1)
    };
    public override int Weight => 30;
    public override bool KindIsGood => false;

    protected override string[] SpellNames => new string[]
    {
        nameof(LifeSpellDetectEvil),
        nameof(LifeSpellCureLightWounds),
        nameof(LifeSpellBless),
        nameof(LifeSpellRemoveFear),
        nameof(LifeSpellCallLight),
        nameof(LifeSpellDetectTrapsAndSecretDoors),
        nameof(LifeSpellCureMediumWounds),
        nameof(LifeSpellSatisfyHunger)
   };
    protected override string ItemClassName => nameof(LifeSpellBooksItemClass);
    public override bool HatesFire => true;
    public override int PackSort => 8;

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

    public override int ExperienceGainDivisorForDestroying => 4;
}
