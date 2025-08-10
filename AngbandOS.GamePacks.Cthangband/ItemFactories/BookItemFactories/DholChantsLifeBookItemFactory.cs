// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DholChantsLifeBookItemFactory : ItemFactoryGameConfiguration
{
    public override string SymbolBindingKey => nameof(QuestionMarkSymbol);
    public override ColorEnum Color => ColorEnum.BrightWhite;
    public override string Name => "[Dhol Chants]";
    public override string? DescriptionSyntax => "Life Spellbook~ $Name$";
    public override string? AlternateDescriptionSyntax => "Book~ of Life Magic $Name$";
    public override int DiceSides => 1;
    public override int LevelNormallyFound => 40;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (40, 1)
    };

    public override string[] SpellBindingKeys => new string[]
    {
        nameof(SpellsEnum.ExorcismLifeSpell),
        nameof(SpellsEnum.DispelCurseLifeSpell),
        nameof(SpellsEnum.DispelUndeadAndDemonsLifeSpell),
        nameof(SpellsEnum.DayOfTheDoveLifeSpell),
        nameof(SpellsEnum.DispelEvilLifeSpell),
        nameof(SpellsEnum.BanishLifeSpell),
        nameof(SpellsEnum.HolyWordLifeSpell),
        nameof(SpellsEnum.WardingTrueLifeSpell)
    };
    public override string ItemClassBindingKey => nameof(LifeSpellBooksItemClass);
    public override bool HatesFire => true;
    public override int PackSort => 8;

    /// <summary>
    /// Returns true, because books are magical and should be detected with the detect magic scroll.
    /// </summary>
    public override bool IsMagical => true;

    public override string? ItemEnhancementBindingKey => nameof(DholChantsLifeBookItemFactoryItemEnhancement);

    public override (int, string)[]? MassProduceBindingTuples => new (int, string)[]
    {
        (50, "2d3-2"),
        (500, "1d3-1")
    };

    public override int ExperienceGainDivisorForDestroying => 4;
}
