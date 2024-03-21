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
    private MindFlayerRace(SaveGame saveGame) : base(saveGame) { }
    public override string Title => "Mind Flayer";
    public override int[] AbilityBonus => new int[] { -3, 4, 4, 0, -2, -5 };
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
    public override int MaleBaseHeight => 68;
    public override int MaleHeightRange => 6;
    public override int MaleBaseWeight => 142;
    public override int MaleWeightRange => 15;
    public override int FemaleBaseHeight => 63;
    public override int FemaleHeightRange => 6;
    public override int FemaleBaseWeight => 112;
    public override int FemaleWeightRange => 10;
    public override int Infravision => 4;
    public override uint Choice => 0xD746;
    public override string Description => "Mind-Flayers are slimy humanoids with squid-like tentacles\naround their mouths. They are all psychic, and neither\ntheir intelligence nor their wisdom can be reduced. They\ncan learn to see invisible (at lvl 15), blast people's\nminds (at lvl 15), and gain telepathy (at lvl 30).";

    /// <summary>
    /// Mind-Flayer 93->93->End
    /// </summary>
    public override int Chart => 92;

    public override string RacialPowersDescription(int lvl) => lvl < 15 ? "mind blast         (racial, unusable until level 15)" : "mind blast         (racial, cost 12, dam lvl, INT based)";
    public override bool HasRacialPowers => true;

    public override void UpdateRacialAbilities(int level, ItemCharacteristics itemCharacteristics)
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
    public override string CreateRandomName() => CreateRandomNameFromSyllables(new CthuloidSyllables());
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
        SaveGame.HasSustainIntelligence = true;
        SaveGame.HasSustainWisdom = true;
        if (SaveGame.ExperienceLevel.Value > 14)
        {
            SaveGame.HasSeeInvisibility = true;
        }
        if (SaveGame.ExperienceLevel.Value > 29)
        {
            SaveGame.HasTelepathy = true;
        }
    }

    public override void UseRacialPower()
    {
        // Mind Flayers can shoot psychic bolts
        if (SaveGame.CheckIfRacialPowerWorks(15, 12, Ability.Intelligence, 14))
        {
            if (SaveGame.GetDirectionWithAim(out int direction))
            {
                SaveGame.MsgPrint("You concentrate and your eyes glow red...");
                SaveGame.FireBolt(SaveGame.SingletonRepository.Projectiles.Get(nameof(PsiProjectile)), direction, SaveGame.ExperienceLevel.Value);
            }
        }
    }
    public override int ChanceOfSanityBlastImmunity(int level) => 100;
}