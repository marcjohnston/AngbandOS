// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Races;

[Serializable]
internal class HalfOgreRace : Race
{
    private HalfOgreRace(Game game) : base(game) { }
    protected override string EnhancementBindingKey => nameof(HalfOgreRaceItemEnhancement);
    public override string Title => "Half Ogre";
    public override int BaseDisarmBonus => -3;
    public override int BaseDeviceBonus => -5;
    public override int BaseSaveBonus => -5;
    public override int BaseStealthBonus => -2;
    public override int BaseSearchBonus => -1;
    public override int BaseSearchFrequency => 5;
    public override int BaseMeleeAttackBonus => 20;
    public override int BaseRangedAttackBonus => 0;
    public override int HitDieBonus => 12;
    public override int ExperienceFactor => 130;
    public override int BaseAge => 40;
    public override int AgeRange => 10;
    public override int Infravision => 3;
    public override uint Choice => 0x0C07;
    public override string Description => "Half-Ogres are both strong and naturally magical, although\nthey don't usually have the intelligence to make the most\nof their magic. They resist darkness and can't have their\nstrength reduced. They can also can enter a berserk\nrage (at lvl 8).";

    /// <summary>
    /// Half-Ogre 74->20->2->3->50->51->52->53->End
    /// </summary>
    public override int Chart => 74;

    public override string RacialPowersDescription(int lvl) => lvl < 25 ? "Yellow Sign     (racial, unusable until level 25)" : "Yellow Sign     (racial, cost 35, INT based)";
    protected override string? RacialPowerScriptBindingKey => nameof(UseRacialPowerScript);
    public override bool HasRacialPowers => true;

    public override void UpdateRacialAbilities(int level, EffectiveAttributeSet itemCharacteristics)
    {
        itemCharacteristics.SustStr = true;
        itemCharacteristics.ResDark = true;
    }
    protected override string GenerateNameSyllableSetName => nameof(OrcishSyllableSet);

    public override string[]? SelfKnowledge(int level)
    {
        if (level > 24)
        {
            return new string[] { "You can set an Yellow Sign (cost 35)." };
        }
        return null;
    }

    public override void CalcBonuses()
    {
        Game.HasDarkResistance = true;
        Game.HasSustainStrength = true;
    }
}