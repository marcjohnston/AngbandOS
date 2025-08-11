// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class EltdownShardsTarotBookItemFactory : ItemFactoryGameConfiguration
{
    public override string SymbolBindingKey => nameof(QuestionMarkSymbol);
    public override string Name => "[Eltdown Shards]";
    public override string? DescriptionSyntax => "Tarot Spellbook~ $Name$";
    public override string? AlternateDescriptionSyntax => "Book~ of Tarot Magic $Name$";
    public override int LevelNormallyFound => 40;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (40, 1)
    };

    public override string[] SpellBindingKeys => new string[]
    {
        nameof(SpellsEnum.TheFoolTarotSpell),
        nameof(SpellsEnum.SummonSpidersTarotSpell),
        nameof(SpellsEnum.SummonReptilesTarotSpell),
        nameof(SpellsEnum.SummonHoundsTarotSpell),
        nameof(SpellsEnum.AstralBrandingTarotSpell),
        nameof(SpellsEnum.ExtraDimensionalBeingTarotSpell),
        nameof(SpellsEnum.DeathDealingTarotSpell),
        nameof(SpellsEnum.SummonReaverTarotSpell)
    };
    public override string ItemClassBindingKey => nameof(TarotSpellBooksItemClass);
    public override int PackSort => 3;
    public override bool HatesFire => true;

    /// <summary>
    /// Returns true, because books are magical and should be detected with the detect magic scroll.
    /// </summary>
    public override bool IsMagical => true;

    public override string? ItemEnhancementBindingKey => nameof(EltdownShardsTarotBookItemFactoryItemEnhancement);

    public override (int, string)[]? MassProduceBindingTuples => new (int, string)[]
    {
        (50, "2d3-2"),
        (500, "1d3-1")
    };

    public override int ExperienceGainDivisorForDestroying => 4;
}
