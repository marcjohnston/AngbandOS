// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Races;

[Serializable]
internal class HalfOrcRace : Race
{
    private HalfOrcRace(Game game) : base(game) { }
    protected override string EnhancementBindingKey => nameof(HalfOrcRaceItemEnhancement);
    public override string Title => "Half Orc";
    public override int UseDevice => -3;
    public override int SavingThrow => -3;
    public override int Stealth => -1;
    public override int Search => 0;
    public override int BaseSearchFrequency => 7;
    public override int MeleeToHit => 12;
    public override int RangedToHit => -5;
    public override int HitDieBonus => 10;
    public override int ExperienceFactor => 110;
    public override int BaseAge => 11;
    public override int AgeRange => 4;
    public override int Infravision => 3;
    public override uint Choice => 0x898D;
    public override string Description => "Half-Orcs are stronger than humans, and less dimwitted\ntheir orcish parentage would lead you to assume.\nHalf-Orcs are born of darkness and are resistant to that\nform of attack. They are also able to learn to shrug off\nmagical fear (at lvl 5).";

    /// <summary>
    /// Half-Orc 19->20->2->3->50->51->52->53->End
    /// </summary>
    public override int Chart => 19;

    public override string RacialPowersDescription(int lvl) => lvl < 3 ? "remove fear        (racial, unusable until level 3)" : "remove fear        (racial, cost 5, WIS based)";
    protected override string? RacialPowerScriptBindingKey => nameof(UseRacialPowerScript);
    public override bool HasRacialPowers => true;

    public override void UpdateRacialAbilities(int level, EffectiveAttributeSet itemCharacteristics)
    {
        itemCharacteristics.Get<OrEffectiveAttributeValue>(nameof(ResDarkAttribute)).Set();
    }
    protected override string GenerateNameSyllableSetName => nameof(OrcishSyllableSet);

    public override string[]? SelfKnowledge(int level)
    {
        if (level > 2)
        {
            return new string[] { "You can remove fear (cost 5)." };
        }
        return null;
    }

    public override void CalcBonuses()
    {
        Game.HasDarkResistance = true;
    }
}
