// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CantripsForBeginnersFolkBookItemFactory : ItemFactoryGameConfiguration
{
    public override string SymbolBindingKey => nameof(QuestionMarkSymbol);
    public override ColorEnum Color => ColorEnum.BrightPurple;
    public override string Name => "[Cantrips for Beginners]";
    public override string? DescriptionSyntax => "Folk Spellbook~ $Name$";
    public override string? AlternateDescriptionSyntax => "Book~ of Folk Magic $Name$";
    public override int DamageSides => 1;
    public override int LevelNormallyFound => 10;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (10, 1)
    };
    public override string[] SpellBindingKeys => new string[]
    {
        nameof(SpellsEnum.ZapFolkSpell),
        nameof(SpellsEnum.WizardLockFolkSpell),
        nameof(SpellsEnum.DetectInvisibilityFolkSpell),
        nameof(SpellsEnum.DetectMonstersFolkSpell),
        nameof(SpellsEnum.BlinkFolkSpell),
        nameof(SpellsEnum.LightAreaFolkSpell),
        nameof(SpellsEnum.TrapAndDoorDestructionFolkSpell),
        nameof(SpellsEnum.CureLightWoundsFolkSpell),
    };
    public override string ItemClassBindingKey => nameof(FolkSpellBooksItemClass);
    public override int PackSort => 2;
    public override bool HatesFire => true;

    /// <summary>
    /// Returns true, because books are magical and should be detected with the detect magic scroll.
    /// </summary>
    public override bool IsMagical => true;

    public override string? ItemEnhancementBindingKey => nameof(CantripsForBeginnersFolkBookItemFactoryItemEnhancement);

    public override (int, string)[]? MassProduceBindingTuples => new (int, string)[]
    {
        (50, "2d3-2"),
        (500, "1d3-1")
    };

    public override int ExperienceGainDivisorForDestroying => 4;
}
