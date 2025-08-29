// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Races;

[Serializable]
internal class HalfGiantRace : Race
{
    private HalfGiantRace(Game game) : base(game) { }
    protected override string EnhancementBindingKey => nameof(HalfGiantRaceItemEnhancement);
    public override string Title => "Half Giant";
    public override int BaseDisarmBonus => -6;
    public override int BaseDeviceBonus => -8;
    public override int BaseSaveBonus => -6;
    public override int BaseStealthBonus => -2;
    public override int BaseSearchBonus => -1;
    public override int BaseSearchFrequency => 5;
    public override int BaseMeleeAttackBonus => 25;
    public override int BaseRangedAttackBonus => 5;
    public override int HitDieBonus => 13;
    public override int ExperienceFactor => 150;
    public override int BaseAge => 40;
    public override int AgeRange => 10;
    public override int Infravision => 3;
    public override uint Choice => 0x0011;
    public override string Description => "Half-Giants are immensely strong and tough, and their skin\nis stony. They can't have their strength reduced, and they\nresist damage from explosions that throw out shards of\nstone and metal. They can learn to soften rock into mud\n(at lvl 10).";

    /// <summary>
    /// Half-Giant 75->20->2->3->50->51->52->53->End
    /// </summary>
    public override int Chart => 75;

    public override string RacialPowersDescription(int lvl) => lvl < 20 ? "stone to mud       (racial, unusable until level 20)" : "stone to mud       (racial, cost 10, STR based)";
    protected override string? RacialPowerScriptBindingKey => nameof(UseRacialPowerScript);
    public override bool HasRacialPowers => true;
    public override void UpdateRacialAbilities(int level, EffectiveAttributeSet itemCharacteristics)
    {
        itemCharacteristics.SetBoolAttributeValue(AttributeEnum.ResShards, true);
        itemCharacteristics.SetBoolAttributeValue(AttributeEnum.SustStr, true);
    }
    protected override string GenerateNameSyllableSetName => nameof(DwarvenSyllableSet);

    public override string[]? SelfKnowledge(int level)
    {
        if (level > 19)
        {
            return new string[] { "You can break stone walls (cost 10)." };
        }
        return null;
    }

    public override void CalcBonuses()
    {
        Game.HasSustainStrength = true;
        Game.HasShardResistance = true;
    }
}