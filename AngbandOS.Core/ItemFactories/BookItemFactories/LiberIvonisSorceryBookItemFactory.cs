// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class LiberIvonisSorceryBookItemFactory : BookItemFactory
{
    private LiberIvonisSorceryBookItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(QuestionMarkSymbol);
    public override ColorEnum Color => ColorEnum.Blue;

    /// <summary>
    /// Returns a divisor of 1 because this is the most powerful book for this realm of magic.  Destroying this book provides the most experience.
    /// </summary>
    public override int ExperienceGainDivisorForDestroying => 1;

    public override string Name => "[Liber Ivonis]";
    public override string CodedName => "& Sorcery Spellbook~ $Name$";
    public override string? AlternateCodedName => $"& Book~ of Sorcery $Name$";

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
        nameof(SorcerySpellStasis),
        nameof(SorcerySpellTelekinesis),
        nameof(SorcerySpellYellowSign),
        nameof(SorcerySpellClairvoyance),
        nameof(SorcerySpellEnchantWeapon),
        nameof(SorcerySpellEnchantArmor),
        nameof(SorcerySpellAlchemy),
        nameof(SorcerySpellGlobeOfInvulnerability)
    };
    /// <summary>
    /// Returns just the realm name because Sorcery automatically assumes magic--so we omit the "Magic" suffix from the divine title.
    /// </summary>
    protected override string ItemClassName => nameof(SorcerySpellBooksItemClass);
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.SorceryBook;
    public override bool HatesFire => true;
    public override int PackSort => 7;
}
