// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CallOfTheWildNatureBookItemFactory : ItemFactoryGameConfiguration
{
    public override string SymbolBindingKey => nameof(QuestionMarkSymbol);
    public override string Name => "[Call of the Wild]";
    public override string? DescriptionSyntax => "Nature Spellbook~ $Name$";
    public override string? AlternateDescriptionSyntax => "Book~ of Nature Magic $Name$";
    public override int LevelNormallyFound => 10;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (10, 1)
    };

    public override string[] SpellBindingKeys => new string[]
    {
        nameof(SpellsEnum.DetectCreaturesNatureSpell),
        nameof(SpellsEnum.FirstAidNatureSpell),
        nameof(SpellsEnum.DetectDoorsAndTrapsNatureSpell),
        nameof(SpellsEnum.ForagingNatureSpell),
        nameof(SpellsEnum.DaylightNatureSpell),
        nameof(SpellsEnum.AnimalTamingNatureSpell),
        nameof(SpellsEnum.ResistEnvironmentNatureSpell),
        nameof(SpellsEnum.CureWoundsAndPoisonNatureSpell)
    };
    public override string ItemClassBindingKey => nameof(NatureSpellBooksItemClass);

    public override int PackSort => 6;

    /// <summary>
    /// Returns true, because books are magical and should be detected with the detect magic scroll.
    /// </summary>
    public override bool IsMagical => true;

    public override string? ItemEnhancementBindingKey => nameof(CallOfTheWildNatureBookItemFactoryItemEnhancement);

    public override (int, string)[]? MassProduceBindingTuples => new (int, string)[]
    {
        (50, "2d3-2"),
        (500, "1d3-1")
    };

    public override int ExperienceGainDivisorForDestroying => 4;
    public override bool IsGood => true;
}
