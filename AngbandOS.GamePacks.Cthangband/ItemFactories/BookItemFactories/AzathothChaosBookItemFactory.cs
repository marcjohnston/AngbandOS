// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AzathothChaosBookItemFactory : ItemFactoryGameConfiguration
{
    /// <summary>
    /// Returns a divisor of 1 because this is the most powerful book for this realm of magic.  Destroying this book provides the most experience.
    /// </summary>
    public override int ExperienceGainDivisorForDestroying => 1;
    public override string SymbolBindingKey => nameof(QuestionMarkSymbol);
    public override ColorEnum Color => ColorEnum.Red;
    public override string Name => "[The Book of Azathoth]";
    public override string? DescriptionSyntax => "Chaos Spellbook~ $Name$";
    public override string? AlternateDescriptionSyntax => "Book~ of Chaos Magic $Name$";
    public override int Cost => 100000;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int LevelNormallyFound => 100;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (100, 3)
    };

    public override int Weight => 30;
    public override string[] SpellBindingKeys => new string[]
    {
        nameof(SpellsEnum.ChaosSpellGravityBeam),
        nameof(SpellsEnum.ChaosSpellMeteorSwarm),
        nameof(SpellsEnum.ChaosSpellFlameStrike),
        nameof(SpellsEnum.ChaosSpellCallChaos),
        nameof(SpellsEnum.ChaosSpellShardBall),
        nameof(SpellsEnum.ChaosSpellManaStorm),
        nameof(SpellsEnum.ChaosSpellBreatheChaos),
        nameof(SpellsEnum.ChaosSpellCallTheVoid)
    };
    public override string ItemClassBindingKey => nameof(ChaosSpellBooksItemClass);
    public override int PackSort => 5;
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
}
