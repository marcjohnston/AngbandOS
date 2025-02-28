// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Races;

[Serializable]
internal class CyclopsRace : Race
{
    private CyclopsRace(Game game) : base(game) { }
    public override string Title => "Cyclops";
    public override int[] AbilityBonus => new int[] { 4, -3, -3, -3, 4, -6 };
    public override int BaseDisarmBonus => -4;
    public override int BaseDeviceBonus => -5;
    public override int BaseSaveBonus => -5;
    public override int BaseStealthBonus => -2;
    public override int BaseSearchBonus => -2;
    public override int BaseSearchFrequency => 5;
    public override int BaseMeleeAttackBonus => 20;
    public override int BaseRangedAttackBonus => 12;
    public override int HitDieBonus => 13;
    public override int ExperienceFactor => 130;
    public override int BaseAge => 50;
    public override int AgeRange => 24;
    public override int MaleBaseHeight => 92;
    public override int MaleHeightRange => 10;
    public override int MaleBaseWeight => 255;
    public override int MaleWeightRange => 60;
    public override int FemaleBaseHeight => 80;
    public override int FemaleHeightRange => 8;
    public override int FemaleBaseWeight => 235;
    public override int FemaleWeightRange => 60;
    public override int Infravision => 1;
    public override uint Choice => 0x0005;
    public override string Description => "Cyclopes are one eyed giants, often seen as freaks by the\nother races. They can learn to throw boulders (at lvl 20)\nand although they have weak eyesight their hearing is very\nkeen and hard to damage, so they are resistant to sound\nbased attacks.";

    /// <summary>
    /// Cyclops 77->109->110->111->112->End
    /// </summary>
    public override int Chart => 77;

    public override string RacialPowersDescription(int lvl) => lvl < 20 ? "throw boulder      (racial, unusable until level 20)" : "throw boulder      (racial, cost 15, dam 3*lvl, STR based)";
    public override bool HasRacialPowers => true;

    public override void UpdateRacialAbilities(int level, ItemCharacteristics itemCharacteristics)
    {
        itemCharacteristics.ResSound = true;
    }

    protected override string GenerateNameSyllableSetName => nameof(DwarvenSyllableSet);

    public override string[]? SelfKnowledge(int level)
    {
        if (level > 19)
        {
            return new string[] { $"You can throw a boulder, dam. {3 * level} (cost 15)." };
        }
        return null;
    }
    public override void CalcBonuses()
    {
        Game.HasSoundResistance = true;
    }

    public override void UseRacialPower()
    {
        // Cyclopes can throw boulders
        if (Game.CheckIfRacialPowerWorks(20, 15, AbilityEnum.Strength, 12))
        {
            if (Game.GetDirectionWithAim(out int direction))
            {
                Game.MsgPrint("You throw a huge boulder.");
                Game.FireBolt(Game.SingletonRepository.Get<Projectile>(nameof(MissileProjectile)), direction, 3 * Game.ExperienceLevel.IntValue / 2);
            }
        }
    }
}