// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MagicksOfMasteryFolkBookItemFactory : ItemFactoryGameConfiguration
{
    public override string SymbolBindingKey => nameof(QuestionMarkSymbol);
    public override string Name => "[Magicks of Mastery]";
    public override string? DescriptionSyntax => "Folk Spellbook~ $Name$";
    public override string? AlternateDescriptionSyntax => "Book~ of Folk Magic $Name$";

    /// <summary>
    /// Returns a divisor of 1 because this is the most powerful book for this realm of magic.  Destroying this book provides the most experience.
    /// </summary>
    public override int ExperienceGainDivisorForDestroying => 1;

    public override int LevelNormallyFound => 20;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (20, 1)
    };

    public override string[] SpellBindingKeys => new string[]
    {
        nameof(SpellsEnum.RechargingFolkSpell),
        nameof(SpellsEnum.TeleportLevelFolkSpell),
        nameof(SpellsEnum.IdentifyFolkSpell),
        nameof(SpellsEnum.TeleportAwayFolkSpell),
        nameof(SpellsEnum.ElementalBallFolkSpell),
        nameof(SpellsEnum.DetectionFolkSpell),
        nameof(SpellsEnum.WordOfRecallFolkSpell),
        nameof(SpellsEnum.ClairvoyanceFolkSpell)
    };
    public override string ItemClassBindingKey => nameof(FolkSpellBooksItemClass);
    public override int PackSort => 2;

    /// <summary>
    /// Returns true, because books are magical and should be detected with the detect magic scroll.
    /// </summary>
    public override bool IsMagical => true;

    public override string? ItemEnhancementBindingKey => nameof(MagicksOfMasteryFolkBookItemFactoryItemEnhancement);

    public override (int, string)[]? MassProduceBindingTuples => new (int, string)[]
    {
        (50, "2d3-2"),
        (500, "1d3-1")
    };
    public override bool IsGood => true;
    public override ColorEnum Color => ColorEnum.BrightPurple;
}
