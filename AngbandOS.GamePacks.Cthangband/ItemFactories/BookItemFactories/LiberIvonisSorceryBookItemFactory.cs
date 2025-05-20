// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LiberIvonisSorceryBookItemFactory : ItemFactoryGameConfiguration
{
    public override string SymbolBindingKey => nameof(QuestionMarkSymbol);
    public override ColorEnum Color => ColorEnum.Blue;

    /// <summary>
    /// Returns a divisor of 1 because this is the most powerful book for this realm of magic.  Destroying this book provides the most experience.
    /// </summary>
    public override int ExperienceGainDivisorForDestroying => 1;

    public override string Name => "[Liber Ivonis]";
    public override string? DescriptionSyntax => "Sorcery Spellbook~ $Name$";
    public override string? AlternateDescriptionSyntax => "Book~ of Sorcery $Name$";
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
    public override string[] SpellBindingKeys => new string[]
    {
        nameof(SpellsEnum.StasisSorcerySpell),
        nameof(SpellsEnum.TelekinesisSorcerySpell),
        nameof(SpellsEnum.YellowSignSorcerySpell),
        nameof(SpellsEnum.ClairvoyanceSorcerySpell),
        nameof(SpellsEnum.EnchantWeaponSorcerySpell),
        nameof(SpellsEnum.EnchantArmorSorcerySpell),
        nameof(SpellsEnum.AlchemySorcerySpell),
        nameof(SpellsEnum.GlobeOfInvulnerabilitySorcerySpell)
    };
    /// <summary>
    /// Returns just the realm name because Sorcery automatically assumes magic--so we omit the "Magic" suffix from the divine title.
    /// </summary>
    public override string ItemClassBindingKey => nameof(SorcerySpellBooksItemClass);
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

    public override (int, string)[]? MassProduceBindingTuples => new (int, string)[]
    {
        (50, "2d3-2"),
        (500, "1d3-1")
    };
}
