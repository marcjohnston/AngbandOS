// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Races;

[Serializable]
internal class DwarfRace : Race
{
    private DwarfRace(Game game) : base(game) { }
    protected override string EnhancementBindingKey => nameof(DwarfRaceItemEnhancement);
    public override string Title => "Dwarf";
    public override int UseDevice => 9;
    public override int SavingThrow => 10;
    public override int Stealth => -1;
    public override int Search => 7;
    public override int BaseSearchFrequency => 10;
    public override int MeleeToHit => 15;
    public override int RangedToHit => 0;
    public override int HitDieBonus => 11;
    public override int ExperienceFactor => 125;
    public override int BaseAge => 35;
    public override int AgeRange => 15;
    public override int Infravision => 5;
    public override uint Choice => 0x4805;
    public override string Description => "Dwarves are short and stocky, and although not noted for\ntheir intelligence or subtlety they are generally very\npious. They are also rather resistant to spells. As natural\nminers, used to feeling their way around in the dark,\ndwarves are immune to all forms of blindness and can learn\nto detect secret doors and traps (at lvl 5).";

    /// <summary>
    /// Dwarf 16->17->18->57->58->59->60->61->End
    /// </summary>
    public override int Chart => 16;
    public override string RacialPowersDescription(int lvl) => lvl < 5 ? "detect doors+traps (racial, unusable until level 5)" : "detect doors+traps (racial, cost 5, WIS based)";
    protected override string? RacialPowerScriptBindingKey => nameof(UseRacialPowerScript);
    public override bool HasRacialPowers => true;

    public override void UpdateRacialAbilities(int level, EffectiveAttributeSet itemCharacteristics)
    {
        itemCharacteristics.Get<OrEffectiveAttributeValue>(nameof(ResBlindAttribute)).Set();
    }
    protected override string GenerateNameSyllableSetName => nameof(DwarvenSyllableSet);
    public override string[]? SelfKnowledge(int level)
    {
        if (level > 4)
        {
            return new string[] { "You can find traps, doors and stairs (cost 5)." };
        }
        return null;
    }

    public override void CalcBonuses()
    {
        Game.HasBlindnessResistance = true;
    }
}
