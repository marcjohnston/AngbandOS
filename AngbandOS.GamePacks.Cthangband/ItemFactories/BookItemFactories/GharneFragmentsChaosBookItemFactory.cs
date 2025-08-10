// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GharneFragmentsChaosBookItemFactory : ItemFactoryGameConfiguration
{
    public override string SymbolBindingKey => nameof(QuestionMarkSymbol);
    public override ColorEnum Color => ColorEnum.Red;
    public override string Name => "[G'harne Fragments]";
    public override string? DescriptionSyntax => "Chaos Spellbook~ $Name$";
    public override string? AlternateDescriptionSyntax => "Book~ of Chaos Magic $Name$";
    public override int LevelNormallyFound => 50;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (50, 1)
    };

    public override string[] SpellBindingKeys => new string[]
    {
        nameof(SpellsEnum.PolymorphOtherChaosSpell),
        nameof(SpellsEnum.ChainLightningChaosSpell),
        nameof(SpellsEnum.ArcaneBindingChaosSpell),
        nameof(SpellsEnum.DisintegrateChaosSpell),
        nameof(SpellsEnum.AlterRealityChaosSpell),
        nameof(SpellsEnum.PolymorphSelfChaosSpell),
        nameof(SpellsEnum.ChaosBrandingChaosSpell),
        nameof(SpellsEnum.SummonDemonChaosSpell)
    };
    public override string ItemClassBindingKey => nameof(ChaosSpellBooksItemClass);
    public override int PackSort => 5;
    public override bool HatesFire => true;

    /// <summary>
    /// Returns true, because books are magical and should be detected with the detect magic scroll.
    /// </summary>
    public override bool IsMagical => true;

    public override string? ItemEnhancementBindingKey => nameof(GharneFragmentsChaosBookItemFactoryItemEnhancement);

    public override (int, string)[]? MassProduceBindingTuples => new (int, string)[]
    {
        (50, "2d3-2"),
        (500, "1d3-1")
    };

    public override int ExperienceGainDivisorForDestroying => 4;
}
