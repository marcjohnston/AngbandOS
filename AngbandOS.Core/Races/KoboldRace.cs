// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Races;

[Serializable]
internal class KoboldRace : Race
{
    private KoboldRace(Game game) : base(game) { }
    public override string Title => "Kobold";
    public override int BaseDisarmBonus => -2;
    public override int BaseDeviceBonus => -3;
    public override int BaseSaveBonus => -2;
    public override int BaseStealthBonus => -1;
    public override int BaseSearchBonus => 1;
    public override int BaseSearchFrequency => 8;
    public override int BaseMeleeAttackBonus => 10;
    public override int BaseRangedAttackBonus => -8;
    public override int HitDieBonus => 9;
    public override int ExperienceFactor => 125;
    public override int BaseAge => 11;
    public override int AgeRange => 3;
    public override int Infravision => 3;
    public override uint Choice => 0xC009;
    public override string Description => "Kobolds are small reptillian creatures whose claims to be\nrelated to dragons are generally not taken seriously. They\nare resistant to poison, and can learn to throw poison\ndarts (at lvl 9).";

    /// <summary>
    /// Kobold 82->83->24->25->26->End
    /// </summary>
    public override int Chart => 82;

    public override string RacialPowersDescription(int lvl) => lvl < 12 ? "poison dart        (racial, unusable until level 12)" : "poison dart        (racial, cost 8, dam lvl, DEX based)";
    protected override string? RacialPowerScriptBindingKey => nameof(UseRacialPowerScript);
    public override bool HasRacialPowers => true;

    public override void UpdateRacialAbilities(int level, RwItemPropertySet itemCharacteristics)
    {
        itemCharacteristics.ResPois = true;
    }
    protected override string GenerateNameSyllableSetName => nameof(HobbitSyllableSet);
    public override string[]? SelfKnowledge(int level)
    {
        if (level > 11)
        {
            return new string[] { $"You can throw a dart of poison, dam. {level} (cost 8)." };
        }
        return null;
    }
    public override void CalcBonuses()
    {
        Game.HasPoisonResistance = true;
    }
}