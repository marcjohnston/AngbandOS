// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CultesdesGoulesDeathBookItemFactory : ItemFactoryGameConfiguration
{
    public override string SymbolBindingKey => nameof(QuestionMarkSymbol);
    public override ColorEnum Color => ColorEnum.Black;
    public override string Name => "[Cultes des Goules]";
    public override string? DescriptionSyntax => "Death Spellbook~ $Name$";
    public override string? AlternateDescriptionSyntax => "Book~ of Death Magic $Name$";
    public override int Cost => 25000;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int LevelNormallyFound => 50;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (50, 1)
    };

    public override int Weight => 30;
    public override string[] SpellBindingKeys => new string[]
    {
        nameof(SpellsEnum.BerserkDeathSpell),
        nameof(SpellsEnum.InvokeSpiritsDeathSpell),
        nameof(SpellsEnum.DarkBoltDeathSpell),
        nameof(SpellsEnum.BattleFrenzyDeathSpell),
        nameof(SpellsEnum.VampirismTrueDeathSpell),
        nameof(SpellsEnum.VampiricBrandingDeathSpell),
        nameof(SpellsEnum.DarknessStormDeathSpell),
        nameof(SpellsEnum.MassCarnageDeathSpell)
    };
    public override string ItemClassBindingKey => nameof(DeathSpellBooksItemClass);
    public override bool HatesFire => true;
    public override int PackSort => 4;

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

    public override int ExperienceGainDivisorForDestroying => 4;
}
