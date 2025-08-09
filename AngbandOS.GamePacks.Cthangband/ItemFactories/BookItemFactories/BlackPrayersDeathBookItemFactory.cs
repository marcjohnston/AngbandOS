// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BlackPrayersDeathBookItemFactory : ItemFactoryGameConfiguration
{
    public override string SymbolBindingKey => nameof(QuestionMarkSymbol);
    public override ColorEnum Color => ColorEnum.Grey;
    public override string Name => "[Black Prayers]";
    public override string? DescriptionSyntax => "Death Spellbook~ $Name$";
    public override string? AlternateDescriptionSyntax => "Book~ of Death Magic $Name$";
    public override int DamageSides => 1;
    public override int LevelNormallyFound => 10;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (10, 1)
    };

    public override string[] SpellBindingKeys => new string[]
    {
        nameof(SpellsEnum.DetectUnlifeDeathSpell),
        nameof(SpellsEnum.MaledictionDeathSpell),
        nameof(SpellsEnum.DetectEvilDeathSpell),
        nameof(SpellsEnum.StinkingCloudDeathSpell),
        nameof(SpellsEnum.BlackSleepDeathSpell),
        nameof(SpellsEnum.ResistPoisonDeathSpell),
        nameof(SpellsEnum.HorrifyDeathSpell),
        nameof(SpellsEnum.EnslaveUndeadDeathSpell)
    };
    public override string ItemClassBindingKey => nameof(DeathSpellBooksItemClass);
    public override bool HatesFire => true;
    public override int PackSort => 4;

    /// <summary>
    /// Returns true, because books are magical and should be detected with the detect magic scroll.
    /// </summary>
    public override bool IsMagical => true;

    public override string? ItemEnhancementBindingKey => nameof(BlackPrayersDeathBookItemFactoryItemEnhancement);

    public override (int, string)[]? MassProduceBindingTuples => new (int, string)[]
    {
        (50, "2d3-2"),
        (500, "1d3-1")
    };

    public override int ExperienceGainDivisorForDestroying => 4;
}
