// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RevelationsOfGlaakiNatureBookItemFactory : ItemFactoryGameConfiguration
{
    public override string SymbolBindingKey => nameof(QuestionMarkSymbol);
    public override ColorEnum Color => ColorEnum.Green;
    public override string Name => "[Revelations of Glaaki]";
    public override string? DescriptionSyntax => "Nature Spellbook~ $Name$";
    public override string? AlternateDescriptionSyntax => "Book~ of Nature Magic $Name$";
    public override int Cost => 25000;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override int LevelNormallyFound => 50;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (50, 1)
    };

    public override int Weight => 30;
    public override string[] SpellBindingKeys => new string[]
    {
        nameof(SpellsEnum.DoorCreationNatureSpell),
        nameof(SpellsEnum.StairBuildingNatureSpell),
        nameof(SpellsEnum.StoneSkinNatureSpell),
        nameof(SpellsEnum.ResistanceTrueNatureSpell),
        nameof(SpellsEnum.AnimalFriendshipNatureSpell),
        nameof(SpellsEnum.StoneTellNatureSpell),
        nameof(SpellsEnum.WallOfStoneNatureSpell),
        nameof(SpellsEnum.ProtectFromCorrosionNatureSpell)
    };
    public override string ItemClassBindingKey => nameof(NatureSpellBooksItemClass);

    public override int PackSort => 6;
    public override bool HatesFire => true;

    /// <summary>
    /// Returns true, because books are magical and should be detected with the detect magic scroll.
    /// </summary>
    public override bool IsMagical => true;

    public override string? ItemEnhancementBindingKey => nameof(EasyKnowIgnoreElementsItemFactoryItemEnhancement);

    public override (int, string)[]? MassProduceBindingTuples => new (int, string)[]
    {
        (50, "2d3-2"),
        (500, "1d3-1")
    };

    public override int ExperienceGainDivisorForDestroying => 4;
}
