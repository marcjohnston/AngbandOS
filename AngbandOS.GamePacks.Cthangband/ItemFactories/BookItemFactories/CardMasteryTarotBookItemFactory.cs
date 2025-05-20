// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CardMasteryTarotBookItemFactory : ItemFactoryGameConfiguration
{
    public override string SymbolBindingKey => nameof(QuestionMarkSymbol);
    public override ColorEnum Color => ColorEnum.BrightPink;
    public override string Name => "[Card Mastery]";
    public override string? DescriptionSyntax => "Tarot Spellbook~ $Name$";
    public override string? AlternateDescriptionSyntax => "Book~ of Tarot Magic $Name$";
    public override int Cost => 1000;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override int LevelNormallyFound => 20;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (20, 1)
    };
    public override int Weight => 30;


    public override string[] SpellBindingKeys => new string[]
    {
        nameof(SpellsEnum.SummonObjectTarotSpell),
        nameof(SpellsEnum.SummonAnimalTarotSpell),
        nameof(SpellsEnum.PhantasmalServantTarotSpell),
        nameof(SpellsEnum.SummonMonsterTarotSpell),
        nameof(SpellsEnum.ConjureElementalTarotSpell),
        nameof(SpellsEnum.TeleportLevelTarotSpell),
        nameof(SpellsEnum.WordOfRecallTarotSpell),
        nameof(SpellsEnum.BanishTarotSpell)
    };
    public override string ItemClassBindingKey => nameof(TarotSpellBooksItemClass);
    public override int PackSort => 3;
    public override bool HatesFire => true;

    /// <summary>
    /// Returns true, because books are magical and should be detected with the detect magic scroll.
    /// </summary>
    public override bool IsMagical => true;

    /// <summary>
    /// Returns true for all books.
    /// </summary>
    public override bool EasyKnow => true;

    public override (int, string)[]? MassProduceBindingTuples => new (int, string)[]
    {
        (50, "2d3-2"),
        (500, "1d3-1")
    };

    public override int ExperienceGainDivisorForDestroying => 4;
}
