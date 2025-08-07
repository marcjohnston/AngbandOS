// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class YogicMasteryCorporealBookItemFactory : ItemFactoryGameConfiguration
{
    public override string SymbolBindingKey => nameof(QuestionMarkSymbol);
    public override ColorEnum Color => ColorEnum.Yellow;
    public override string Name => "[Yogic Mastery]";
    public override string? DescriptionSyntax => "Corporeal Spellbook~ $Name$";
    public override string? AlternateDescriptionSyntax => "Book~ of Corporeal Magic $Name$";
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override int LevelNormallyFound => 20;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (20, 1)
    };

    public override string[] SpellBindingKeys => new string[]
    {
        nameof(SpellsEnum.BurnResistanceCorporealSpell),
        nameof(SpellsEnum.DetoxifyCorporealSpell),
        nameof(SpellsEnum.CureCriticalWoundsCorporealSpell),
        nameof(SpellsEnum.SeeInvisibleCorporealSpell),
        nameof(SpellsEnum.TeleportCorporealSpell),
        nameof(SpellsEnum.HasteCorporealSpell),
        nameof(SpellsEnum.HealingCorporealSpell),
        nameof(SpellsEnum.ResistTrueCorporealSpell)
    };
    public override string ItemClassBindingKey => nameof(CorporealSpellBooksItemClass);
    public override int PackSort => 1;
    public override bool HatesFire => true;

    /// <summary>
    /// Returns true, because books are magical and should be detected with the detect magic scroll.
    /// </summary>
    public override bool IsMagical => true;

    public override string? ItemEnhancementBindingKey => nameof(YogicMasteryCorporealBookItemFactoryItemEnhancement);

    public override (int, string)[]? MassProduceBindingTuples => new (int, string)[]
    {
        (50, "2d3-2"),
        (500, "1d3-1")
    };

    public override int ExperienceGainDivisorForDestroying => 4;
}
