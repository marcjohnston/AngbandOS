using AngbandOS.Core.Syllables;

namespace AngbandOS.Core.Races
{
    [Serializable]
    internal class HalfOgreRace : Race
    {
        public override string Title => "Half Ogre";
        public override int[] AbilityBonus => new int[] { 3, -1, -1, -1, 3, -3 };
        public override int BaseDisarmBonus => -3;
        public override int BaseDeviceBonus => -5;
        public override int BaseSaveBonus => -5;
        public override int BaseStealthBonus => -2;
        public override int BaseSearchBonus => -1;
        public override int BaseSearchFrequency => 5;
        public override int BaseMeleeAttackBonus => 20;
        public override int BaseRangedAttackBonus => 0;
        public override int HitDieBonus => 12;
        public override int ExperienceFactor => 130;
        public override int BaseAge => 40;
        public override int AgeRange => 10;
        public override int MaleBaseHeight => 92;
        public override int MaleHeightRange => 10;
        public override int MaleBaseWeight => 255;
        public override int MaleWeightRange => 60;
        public override int FemaleBaseHeight => 80;
        public override int FemaleHeightRange => 8;
        public override int FemaleBaseWeight => 235;
        public override int FemaleWeightRange => 60;
        public override int Infravision => 3;
        public override uint Choice => 0x0C07;
        public override string Description => "Half-Ogres are both strong and naturally magical, although\nthey don't usually have the intelligence to make the most\nof their magic. They resist darkness and can't have their\nstrength reduced. They can also can enter a berserk\nrage (at lvl 8).";

        /// <summary>
        /// Half-Ogre 74->20->2->3->50->51->52->53->End
        /// </summary>
        public override int Chart => 74;

        public override string RacialPowersDescription(int lvl) => lvl < 25 ? "Yellow Sign     (racial, unusable until level 25)" : "Yellow Sign     (racial, cost 35, INT based)";
        public override bool HasRacialPowers => true;

        public override void UpdateRacialAbilities(int level, ItemCharacteristics itemCharacteristics)
        {
            itemCharacteristics.SustStr = true;
            itemCharacteristics.ResDark = true;
        }
        public override string CreateRandomName() => CreateRandomNameFromSyllables(new OrcishSyllables());

        public override string[]? SelfKnowledge(int level)
        {
            if (level > 24)
            {
                return new string[] { "You can set an Yellow Sign (cost 35)." };
            }
            return null;
        }

        public override void CalcBonuses(SaveGame saveGame)
        {
            saveGame.Player.HasDarkResistance = true;
            saveGame.Player.HasSustainStrength = true;
        }

        public override void UseRacialPower(SaveGame saveGame)
        {
            // Half-Ogres can go berserk
            if (saveGame.CheckIfRacialPowerWorks(8, 10, Ability.Wisdom, saveGame.Player.ProfessionIndex == CharacterClass.Warrior ? 6 : 12))
            {
                saveGame.MsgPrint("Raaagh!");
                saveGame.Player.TimedFear.SetTimer(0);
                saveGame.Player.TimedSuperheroism.SetTimer(saveGame.Player.TimedSuperheroism.TimeRemaining + 10 + Program.Rng.DieRoll(saveGame.Player.Level));
                saveGame.Player.RestoreHealth(30);
            }
        }
    }
}