// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CthaatAquadingenNatureBookItemFactory : ItemFactoryGameConfiguration
{
    public override string SymbolBindingKey => nameof(QuestionMarkSymbol);
    public override ColorEnum Color => ColorEnum.Green;

    /// <summary>
    /// Returns a divisor of 1 because this is the most powerful book for this realm of magic.  Destroying this book provides the most experience.
    /// </summary>
    public override int ExperienceGainDivisorForDestroying => 1;

    public override string Name => "[Cthaat Aquadingen]";
    public override string? DescriptionSyntax => "Nature Spellbook~ $Name$";
    public override string? AlternateDescriptionSyntax => "Book~ of Nature Magic $Name$";
    public override int Cost => 100000;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override int LevelNormallyFound => 80;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (80, 2)
    };

    public override int Weight => 30;
    public override string[] SpellBindingKeys => new string[]
    {
        nameof(SpellsEnum.EarthquakeNatureSpell),
        nameof(SpellsEnum.WhirlwindAttackNatureSpell),
        nameof(SpellsEnum.BlizzardNatureSpell),
        nameof(SpellsEnum.LightningStormNatureSpell),
        nameof(SpellsEnum.WhirlpoolNatureSpell),
        nameof(SpellsEnum.CallSunlightNatureSpell),
        nameof(SpellsEnum.ElementalBrandingNatureSpell),
        nameof(SpellsEnum.NaturesWrathNatureSpell)
    };
    public override string ItemClassBindingKey => nameof(NatureSpellBooksItemClass);

    public override int PackSort => 6;
    public override bool HatesFire => true;

    /// <summary>
    /// Returns true, because books are magical and should be detected with the detect magic scroll.
    /// </summary>
    public override bool IsMagical => true;

    public override string? ItemEnhancementBindingKey => nameof(EasyKnowIgnoreElementsItemFactoryItemEnhancement);

    public override (int, string)[]? MassProduceBindingTuples => new (int, string)[]
    {
        (50, "2d3-2"),
        (500, "1d3-1")
    };
}
