// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CommonPrayerLifeBookItemFactory : ItemFactoryGameConfiguration
{
    public override string SymbolBindingKey => nameof(QuestionMarkSymbol);
    public override string Name => "[Book of Common Prayer]";
    public override string? DescriptionSyntax => "Life Spellbook~ $Name$";
    public override string? AlternateDescriptionSyntax => "Book~ of Life Magic $Name$";
    public override int LevelNormallyFound => 10;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (10, 1)
    };

    public override string[] SpellBindingKeys => new string[]
    {
        nameof(SpellsEnum.DetectEvilLifeSpell),
        nameof(SpellsEnum.CureLightWoundsLifeSpell),
        nameof(SpellsEnum.BlessLifeSpell),
        nameof(SpellsEnum.RemoveFearLifeSpell),
        nameof(SpellsEnum.CallLightLifeSpell),
        nameof(SpellsEnum.DetectTrapsAndSecretDoorsLifeSpell),
        nameof(SpellsEnum.CureMediumWoundsLifeSpell),
        nameof(SpellsEnum.SatisfyHungerLifeSpell)
   };
    public override string ItemClassBindingKey => nameof(LifeSpellBooksItemClass);
    public override int PackSort => 8;

    /// <summary>
    /// Returns true, because books are magical and should be detected with the detect magic scroll.
    /// </summary>
    public override bool IsMagical => true;

    public override string? ItemEnhancementBindingKey => nameof(CommonPrayerLifeBookItemFactoryItemEnhancement);

    public override (int, string)[]? MassProduceBindingTuples => new (int, string)[]
    {
        (50, "2d3-2"),
        (500, "1d3-1")
    };

    public override int ExperienceGainDivisorForDestroying => 4;
    public override bool IsGood => true;
}
