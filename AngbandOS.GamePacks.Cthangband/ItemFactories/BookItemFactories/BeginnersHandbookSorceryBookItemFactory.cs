// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BeginnersHandbookSorceryBookItemFactory : ItemFactoryGameConfiguration
{
    public override string SymbolBindingKey => nameof(QuestionMarkSymbol);
    public override ColorEnum Color => ColorEnum.BrightBlue;
    public override string Name => "[Beginner's Handbook]";
    public override string? DescriptionSyntax => "Sorcery Spellbook~ $Name$";
    public override string? AlternateDescriptionSyntax => "Book~ of Sorcery $Name$";
    public override int LevelNormallyFound => 10;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (10, 1)
    };

    public override string[] SpellBindingKeys => new string[]
    {
        nameof(SpellsEnum.DetectMonstersSorcerySpell),
        nameof(SpellsEnum.PhaseDoorSorcerySpell),
        nameof(SpellsEnum.DetectDoorsAndTrapsSorcerySpell),
        nameof(SpellsEnum.LightAreaSorcerySpell),
        nameof(SpellsEnum.ConfuseMonsterSorcerySpell),
        nameof(SpellsEnum.TeleportSorcerySpell),
        nameof(SpellsEnum.SleepMonsterSorcerySpell),
        nameof(SpellsEnum.RechargingSorcerySpell)
    };
    /// <summary>
    /// Returns just the realm name because Sorcery automatically assumes magic--so we omit the "Magic" suffix from the divine title.
    /// </summary>
    public override string ItemClassBindingKey => nameof(SorcerySpellBooksItemClass);
    public override bool HatesFire => true;
    public override int PackSort => 7;

    /// <summary>
    /// Returns true, because books are magical and should be detected with the detect magic scroll.
    /// </summary>
    public override bool IsMagical => true;

    public override string? ItemEnhancementBindingKey => nameof(BeginnersHandbookSorceryBookItemFactoryItemEnhancement);

    public override (int, string)[]? MassProduceBindingTuples => new (int, string)[]
    {
        (50, "2d3-2"),
        (500, "1d3-1")
    };

    public override int ExperienceGainDivisorForDestroying => 4;
}
