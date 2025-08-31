// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Races;

[Serializable]
internal class HalfTrollRace : Race
{
    private HalfTrollRace(Game game) : base(game) { }
    protected override string EnhancementBindingKey => nameof(HalfTrollRaceItemEnhancement);
    public override string Title => "Half Troll";
    public override int BaseDeviceBonus => -8;
    public override int BaseSaveBonus => -8;
    public override int BaseStealthBonus => -2;
    public override int BaseSearchBonus => -1;
    public override int BaseSearchFrequency => 5;
    public override int BaseMeleeAttackBonus => 20;
    public override int BaseRangedAttackBonus => -10;
    public override int HitDieBonus => 12;
    public override int ExperienceFactor => 137;
    public override int BaseAge => 20;
    public override int AgeRange => 10;
    public override int Infravision => 3;
    public override uint Choice => 0x0805;
    public override string Description => "Half-Trolls make up for their stupidity by being almost\npure muscle, as strong as creatures much larger than they.\nThey can't have their strength reduced, and as they grow\nstronger they can go into a berserk rage (at lvl 10),\nregenerate wounds (at lvl 15), and survive on less food\n(at lvl 15).";

    /// <summary>
    /// Half-Troll 22->23->62->63->64->65->66->End
    /// </summary>
    public override int Chart => 22;

    public override string RacialPowersDescription(int lvl) => lvl < 10 ? "berserk            (racial, unusable until level 10)" : "berserk            (racial, cost 12, WIS based)";
    protected override string? RacialPowerScriptBindingKey => nameof(UseRacialPowerScript);
    public override bool HasRacialPowers => true;

    public override void UpdateRacialAbilities(int level, EffectiveAttributeSet itemCharacteristics)
    {
        itemCharacteristics.SetBoolAttributeValue(AttributeEnum.SustStr, true);
        if (level > 14)
        {
            itemCharacteristics.SetBoolAttributeValue(AttributeEnum.Regen, true);
            itemCharacteristics.SetBoolAttributeValue(AttributeEnum.SlowDigest, true);
        }
    }
    protected override string GenerateNameSyllableSetName => nameof(OrcishSyllableSet);

    public override string[]? SelfKnowledge(int level)
    {
        if (level > 9)
        {
            return new string[] { "You enter berserk fury (cost 12)." };
        }
        return null;
    }

    public override void CalcBonuses()
    {
        Game.HasSustainStrength = true;
        if (Game.ExperienceLevel.IntValue > 14)
        {
            Game.HasRegeneration = true;
            Game.HasSlowDigestion = true;
        }
    }
}
