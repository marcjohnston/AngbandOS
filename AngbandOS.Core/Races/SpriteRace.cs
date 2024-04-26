// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Races;

[Serializable]
internal class SpriteRace : Race
{
    private SpriteRace(Game game) : base(game) { }
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
    public override void CalcBonuses()
    {
        Game.HasFeatherFall = true;
        Game.HasGlow = true;
        Game.HasLightResistance = true;
        Game.Speed.IntValue += Game.ExperienceLevel.IntValue / 10;
    }

    public override void UseRacialPower()
    {
        // Sprites can sleep monsters
        if (Game.CheckIfRacialPowerWorks(12, 12, Ability.Intelligence, 15))
        {
            Game.MsgPrint("You throw some magic dust...");
            if (Game.ExperienceLevel.IntValue < 25)
            {
                Game.SleepMonstersTouch();
            }
            else
            {
                Game.RunScript(nameof(SleepMonstersScript));
            }
        }
    }
}