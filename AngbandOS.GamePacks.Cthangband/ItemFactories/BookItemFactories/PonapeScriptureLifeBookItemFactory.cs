// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PonapeScriptureLifeBookItemFactory : ItemFactoryGameConfiguration
{
    public override string SymbolBindingKey => nameof(QuestionMarkSymbol);
    public override ColorEnum Color => ColorEnum.BrightWhite;
    public override string Name => "[Ponape Scripture]";
    public override string? DescriptionSyntax => "Life Spellbook~ $Name$";
    public override string? AlternateDescriptionSyntax => "Book~ of Life Magic $Name$";

    /// <summary>
    /// Returns a divisor of 1 because this is the most powerful book for this realm of magic.  Destroying this book provides the most experience.
    /// </summary>
    public override int ExperienceGainDivisorForDestroying => 1;

    public override int DamageSides => 1;
    public override int LevelNormallyFound => 90;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (90, 3)
    };

    public override string[] SpellBindingKeys => new string[]
    {
        nameof(SpellsEnum.HeroismLifeSpell),
        nameof(SpellsEnum.PrayerLifeSpell),
        nameof(SpellsEnum.BlessWeaponLifeSpell),
        nameof(SpellsEnum.RestorationLifeSpell),
        nameof(SpellsEnum.HealingTrueLifeSpell),
        nameof(SpellsEnum.HolyVisionLifeSpell),
        nameof(SpellsEnum.DivineInterventionLifeSpell),
        nameof(SpellsEnum.HolyInvulnerabilityLifeSpell)
    };
    public override string ItemClassBindingKey => nameof(LifeSpellBooksItemClass);
    public override bool HatesFire => true;
    public override int PackSort => 8;

    /// <summary>
    /// Returns true, because books are magical and should be detected with the detect magic scroll.
    /// </summary>
    public override bool IsMagical => true;

    public override string? ItemEnhancementBindingKey => nameof(PonapeScriptureLifeBookItemFactoryItemEnhancement);
    public override (int, string)[]? MassProduceBindingTuples => new (int, string)[]
    {
        (50, "2d3-2"),
        (500, "1d3-1")
    };
}
