﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Races;

[Serializable]
internal class DraconianRace : Race
{
    private DraconianRace(Game game) : base(game) { }
    public override string Title => "Draconian";
    public override int BaseDisarmBonus => -2;
    public override int BaseDeviceBonus => 5;
    public override int BaseSaveBonus => 3;
    public override int BaseStealthBonus => 0;
    public override int BaseSearchBonus => 1;
    public override int BaseSearchFrequency => 10;
    public override int BaseMeleeAttackBonus => 5;
    public override int BaseRangedAttackBonus => 5;
    public override int HitDieBonus => 11;
    public override int ExperienceFactor => 250;
    public override int BaseAge => 75;
    public override int AgeRange => 33;
    public override int Infravision => 2;
    public override uint Choice => 0xDF57;
    public override string Description => "Draconians are related to dragons and this shows both in\ntheir physical superiority and their legendary arrogance.\nAs well as having a breath weapon, their wings let them\navoid falling damage, and they can learn to resist fire\n(at lvl 5), cold (at lvl 10), acid (at lvl 15), lightning\n(at lvl 20), and poison (at lvl 35).";

    /// <summary>
    /// Draconian 89->90->91->End
    /// </summary>
    public override int Chart => 89;

    public override string RacialPowersDescription(int lvl) => "breath weapon      (racial, cost lvl, dam 2*lvl, CON based)";
    protected override string? RacialPowerScriptBindingKey => nameof(DraconianRacialPowerScript);
    public override bool HasRacialPowers => true;

    public override void UpdateRacialAbilities(int level, RwItemPropertySet itemCharacteristics)
    {
        itemCharacteristics.Feather = true;
        if (level > 4)
        {
            itemCharacteristics.ResFire = true;
        }
        if (level > 9)
        {
            itemCharacteristics.ResCold = true;
        }
        if (level > 14)
        {
            itemCharacteristics.ResAcid = true;
        }
        if (level > 19)
        {
            itemCharacteristics.ResElec = true;
        }
        if (level > 34)
        {
            itemCharacteristics.ResPois = true;
        }
    }
    protected override string GenerateNameSyllableSetName => nameof(GnomishSyllableSet);
    public override string[]? SelfKnowledge(int level)
    {
        return new string[] { $"You can breathe, dam. {2 * level} (cost {level})." };
    }
    public override void CalcBonuses()
    {
        Game.HasFeatherFall = true;
        if (Game.ExperienceLevel.IntValue > 4)
        {
            Game.HasFireResistance = true;
        }
        if (Game.ExperienceLevel.IntValue > 9)
        {
            Game.HasColdResistance = true;
        }
        if (Game.ExperienceLevel.IntValue > 14)
        {
            Game.HasAcidResistance = true;
        }
        if (Game.ExperienceLevel.IntValue > 19)
        {
            Game.HasLightningResistance = true;
        }
        if (Game.ExperienceLevel.IntValue > 34)
        {
            Game.HasPoisonResistance = true;
        }
    }
}