// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PnakoticManuscriptsCorporealBookItemFactory : ItemFactoryGameConfiguration
{
    public override string SymbolBindingKey => nameof(QuestionMarkSymbol);
    public override ColorEnum Color => ColorEnum.BrightYellow;
    public override string Name => "[Pnakotic Manuscripts]";
    public override string? DescriptionSyntax => "Corporeal Spellbook~ $Name$";
    public override string? AlternateDescriptionSyntax => "Book~ of Corporeal Magic $Name$";

    /// <summary>
    /// Returns a divisor of 1 because this is the most powerful book for this realm of magic.  Destroying this book provides the most experience.
    /// </summary>
    public override int ExperienceGainDivisorForDestroying => 1;

    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override int LevelNormallyFound => 90;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (90, 3)
    };

    public override string[] SpellBindingKeys => new string[]
    {
        nameof(SpellsEnum.HeroismCorporealSpell),
        nameof(SpellsEnum.WraithformCorporealSpell),
        nameof(SpellsEnum.AttunementCorporealSpell),
        nameof(SpellsEnum.RestoreBodyCorporealSpell),
        nameof(SpellsEnum.HealingTrueCorporealSpell),
        nameof(SpellsEnum.HypnoticEyesCorporealSpell),
        nameof(SpellsEnum.RestoreSoulCorporealSpell),
        nameof(SpellsEnum.InvulnerabilityCorporealSpell)
   };
    public override string ItemClassBindingKey => nameof(CorporealSpellBooksItemClass);
    public override int PackSort => 1;
    public override bool HatesFire => true;

    /// <summary>
    /// Returns true, because books are magical and should be detected with the detect magic scroll.
    /// </summary>
    public override bool IsMagical => true;

    public override string? ItemEnhancementBindingKey => nameof(PnakoticManuscriptsCorporealBookItemFactoryItemEnhancement);

    public override (int, string)[]? MassProduceBindingTuples => new (int, string)[]
    {
        (50, "2d3-2"),
        (500, "1d3-1")
    };
}
