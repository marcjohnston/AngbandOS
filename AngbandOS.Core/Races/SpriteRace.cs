namespace AngbandOS.Core.Races;

[Serializable]
internal class SpriteRace : Race
{
    private SpriteRace(SaveGame saveGame) : base(saveGame) { }
    public override string Title => "Sprite";
    public override int[] AbilityBonus => new int[] { -4, 3, 3, 3, -2, 2 };
    public override int BaseDisarmBonus => 10;
    public override int BaseDeviceBonus => 10;
    public override int BaseSaveBonus => 10;
    public override int BaseStealthBonus => 4;
    public override int BaseSearchBonus => 10;
    public override int BaseSearchFrequency => 10;
    public override int BaseMeleeAttackBonus => -12;
    public override int BaseRangedAttackBonus => 0;
    public override int HitDieBonus => 7;
    public override int ExperienceFactor => 175;
    public override int BaseAge => 50;
    public override int AgeRange => 25;
    public override int MaleBaseHeight => 32;
    public override int MaleHeightRange => 2;
    public override int MaleBaseWeight => 75;
    public override int MaleWeightRange => 2;
    public override int FemaleBaseHeight => 29;
    public override int FemaleHeightRange => 2;
    public override int FemaleBaseWeight => 65;
    public override int FemaleWeightRange => 2;
    public override int Infravision => 4;
    public override uint Choice => 0xBE5E;
    public override string Description => "Sprites are tiny fairies, distantly related to elves. They\nshare their relatives' resistance to light based attacks,\nand their wings both protect them from falling damage and\nallow them to move progressively faster if unencumbered.\nSprites glow in the dark and can learn to throw fairy dust\nto send their enemies to sleep (at lvl 12).";

    /// <summary>
    /// Sprite 124->125->126->127->128->End
    /// </summary>
    public override int Chart => 124;

    public override string RacialPowersDescription(int lvl) => lvl < 12 ? "sleeping dust      (racial, unusable until level 12)" : "sleeping dust      (racial, cost 12, INT based)";
    public override bool HasRacialPowers => true;
    public override void UpdateRacialAbilities(int level, ItemCharacteristics itemCharacteristics)
    {
        itemCharacteristics.ResLight = true;
        itemCharacteristics.Feather = true;
        if (level > 9)
        {
            itemCharacteristics.Speed = true;
        }
    }
    public override string CreateRandomName() => CreateRandomNameFromSyllables(new ElvishSyllables());

    public override string[]? SelfKnowledge(int level)
    {
        if (level > 11)
        {
            return new string[] { "You can throw magic dust which induces sleep (cost 12)." };
        }
        return null;
    }
    public override void CalcBonuses(SaveGame saveGame)
    {
        saveGame.Player.HasFeatherFall = true;
        saveGame.Player.HasGlow = true;
        saveGame.Player.HasLightResistance = true;
        saveGame.Player.Speed += saveGame.Player.Level / 10;
    }

    public override void UseRacialPower(SaveGame saveGame)
    {
        // Sprites can sleep monsters
        if (saveGame.CheckIfRacialPowerWorks(12, 12, Ability.Intelligence, 15))
        {
            saveGame.MsgPrint("You throw some magic dust...");
            if (saveGame.Player.Level < 25)
            {
                saveGame.SleepMonstersTouch();
            }
            else
            {
                saveGame.SleepMonsters();
            }
        }
    }
}