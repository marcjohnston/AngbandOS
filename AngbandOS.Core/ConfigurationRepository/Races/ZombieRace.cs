// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Races;

[Serializable]
internal class ZombieRace : Race
{
    private ZombieRace(SaveGame saveGame) : base(saveGame) { }
    public override string Title => "Zombie";
    public override int[] AbilityBonus => new int[] { 2, -6, -6, 1, 4, -5 };
    public override int BaseDisarmBonus => -5;
    public override int BaseDeviceBonus => -5;
    public override int BaseSaveBonus => 8;
    public override int BaseStealthBonus => -1;
    public override int BaseSearchBonus => -1;
    public override int BaseSearchFrequency => 5;
    public override int BaseMeleeAttackBonus => 15;
    public override int BaseRangedAttackBonus => 0;
    public override int HitDieBonus => 13;
    public override int ExperienceFactor => 135;
    public override int BaseAge => 100;
    public override int AgeRange => 30;
    public override int MaleBaseHeight => 72;
    public override int MaleHeightRange => 6;
    public override int MaleBaseWeight => 100;
    public override int MaleWeightRange => 25;
    public override int FemaleBaseHeight => 66;
    public override int FemaleHeightRange => 4;
    public override int FemaleBaseWeight => 100;
    public override int FemaleWeightRange => 20;
    public override int Infravision => 2;
    public override uint Choice => 0x0001;
    public override string Description => "Zombies are undead creatures. Their decayed flesh resists\nnether and poison, and having their life force drained.\nZombies digest food slowly, and can see invisible monsters.\nThey can learn to restore their life force (at lvl 30).";

    /// <summary>
    /// Zombie 107->108->62->63->64->65->66->End
    /// </summary>
    public override int Chart => 107;

    public override string RacialPowersDescription(int lvl) => lvl < 30 ? "restore life       (racial, unusable until level 30)" : "restore life       (racial, cost 30, WIS based)";
    public override bool HasRacialPowers => true;
    public override void UpdateRacialAbilities(int level, ItemCharacteristics itemCharacteristics)
    {
        itemCharacteristics.SeeInvis = true;
        itemCharacteristics.HoldLife = true;
        itemCharacteristics.ResNether = true;
        itemCharacteristics.ResPois = true;
        itemCharacteristics.SlowDigest = true;
        if (level > 4)
        {
            itemCharacteristics.ResCold = true;
        }
    }
    public override string CreateRandomName() => CreateRandomNameFromSyllables(new HumanSyllables());

    public override string[]? SelfKnowledge(int level)
    {
        if (level > 29)
        {
            return new string[] { "You can restore lost life forces (cost 30)." };
        }
        return null;
    }
    public override void CalcBonuses()
    {
        SaveGame.HasNetherResistance = true;
        SaveGame.HasHoldLife = true;
        SaveGame.HasSeeInvisibility = true;
        SaveGame.HasPoisonResistance = true;
        SaveGame.HasSlowDigestion = true;
        if (SaveGame.ExperienceLevel > 4)
        {
            SaveGame.HasColdResistance = true;
        }
    }
    public override bool RestsTillDuskInsteadOfDawn => true;
    public override void Eat(Item item)
    {
        // This race only gets 1/20th of the food value
        SaveGame.MsgPrint("The food of mortals is poor sustenance for you.");
        SaveGame.SetFood(SaveGame.Food + (item.TypeSpecificValue / 20));
    }
    public override bool CanBleed(int level) => (level > 11);

    public override void UseRacialPower()
    {
        // Skeletons and zombies can restore their life energy
        if (SaveGame.CheckIfRacialPowerWorks(30, 30, Ability.Wisdom, 18))
        {
            SaveGame.MsgPrint("You attempt to restore your lost energies.");
            SaveGame.RunScript(nameof(RestoreLevelScript));
        }
    }

    public override bool OutfitsWithScrollsOfSatisfyHunger => true;
    public override int ChanceOfSanityBlastImmunity(int level) => level + 25;
}