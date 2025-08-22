// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Races;

[Serializable]
internal class MindFlayerRace : Race
{
    private MindFlayerRace(Game game) : base(game) { }
    protected override string EnhancementBindingKey => nameof(MindFlayerRaceItemEnhancement);
    public override string Title => "Mind Flayer";
    public override int BaseDisarmBonus => 10;
    public override int BaseDeviceBonus => 25;
    public override int BaseSaveBonus => 15;
    public override int BaseStealthBonus => 2;
    public override int BaseSearchBonus => 5;
    public override int BaseSearchFrequency => 12;
    public override int BaseMeleeAttackBonus => -10;
    public override int BaseRangedAttackBonus => -5;
    public override int HitDieBonus => 9;
    public override int ExperienceFactor => 140;
    public override int BaseAge => 100;
    public override int AgeRange => 25;
    public override int Infravision => 4;
    public override uint Choice => 0xD746;
    public override string Description => "Mind-Flayers are slimy humanoids with squid-like tentacles\naround their mouths. They are all psychic, and neither\ntheir intelligence nor their wisdom can be reduced. They\ncan learn to see invisible (at lvl 15), blast people's\nminds (at lvl 15), and gain telepathy (at lvl 30).";

    /// <summary>
    /// Mind-Flayer 93->93->End
    /// </summary>
    public override int Chart => 92;

    public override string RacialPowersDescription(int lvl) => lvl < 15 ? "mind blast         (racial, unusable until level 15)" : "mind blast         (racial, cost 12, dam lvl, INT based)";
    protected override string? RacialPowerScriptBindingKey => nameof(UseRacialPowerScript);
    public override bool HasRacialPowers => true;

    public override void UpdateRacialAbilities(int level, EffectivePropertySet itemCharacteristics)
    {
        itemCharacteristics.SustInt = true;
        itemCharacteristics.SustWis = true;
        if (level > 14)
        {
            itemCharacteristics.SeeInvis = true;
        }
        if (level > 29)
        {
            itemCharacteristics.Telepathy = true;
        }
    }
    protected override string GenerateNameSyllableSetName => nameof(CthuloidSyllableSet);
    public override string[]? SelfKnowledge(int level)
    {
        if (level > 14)
        {
            return new string[] { $"You can mind blast your enemies, dam {level} (cost 12)." };
        }
        return null;
    }
    public override void CalcBonuses()
    {
        Game.HasSustainIntelligence = true;
        Game.HasSustainWisdom = true;
        if (Game.ExperienceLevel.IntValue > 14)
        {
            Game.HasSeeInvisibility = true;
        }
        if (Game.ExperienceLevel.IntValue > 29)
        {
            Game.HasTelepathy = true;
        }
    }
    public override int ChanceOfSanityBlastImmunity(int level) => 100;
}