// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Races;

[Serializable]
internal class HalfTitanRace : Race
{
    private HalfTitanRace(Game game) : base(game) { }
    protected override string EnhancementBindingKey => nameof(HalfTitanRaceItemEnhancement);
    public override string Title => "Half Titan";
    public override int BaseDisarmBonus => -5;
    public override int BaseDeviceBonus => 5;
    public override int BaseSaveBonus => 2;
    public override int BaseStealthBonus => -2;
    public override int BaseSearchBonus => 1;
    public override int BaseSearchFrequency => 8;
    public override int BaseMeleeAttackBonus => 25;
    public override int BaseRangedAttackBonus => 0;
    public override int HitDieBonus => 14;
    public override int ExperienceFactor => 255;
    public override int BaseAge => 100;
    public override int AgeRange => 30;
    public override int Infravision => 0;
    public override uint Choice => 0x1F27;
    public override string Description => "Half-Titans are massively strong, being descended from the\npredecessors of the gods that grew from primal chaos. This\nlegacy lets them resist damage from chaos, and half-titans\ncan learn to magically probe their foes to find out their\nstrengths and weaknesses (at lvl 35).";

    /// <summary>
    /// Half-Titan 75->20->2->3->50->51->52->53->End
    /// </summary>
    public override int Chart => 76;

    public override string RacialPowersDescription(int lvl) => lvl < 35 ? "probing            (racial, unusable until level 35)" : "probing            (racial, cost 20, INT based)";
    protected override string? RacialPowerScriptBindingKey => nameof(UseRacialPowerScript);
    public override bool HasRacialPowers => true;

    public override void UpdateRacialAbilities(int level, EffectiveAttributeSet itemCharacteristics)
    {
        itemCharacteristics.SetBoolValue(AttributeEnum.ResChaos, true);
    }
    protected override string GenerateNameSyllableSetName => nameof(HumanSyllableSet);

    public override string[]? SelfKnowledge(int level)
    {
        if (level > 34)
        {
            return new string[] { "You can probe monsters (cost 20)." };
        }
        return null;
    }
    public override void CalcBonuses()
    {
        Game.HasChaosResistance = true;
    }
}