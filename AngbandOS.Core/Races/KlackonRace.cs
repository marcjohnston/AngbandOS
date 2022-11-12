using AngbandOS.Core.Syllables;
using AngbandOS.Enumerations;
using AngbandOS.Projection;

namespace AngbandOS.Core.Races
{
    [Serializable]
    internal class KlackonRace : Race
    {
        public override string Title => "Klackon";
        public override int[] AbilityBonus => new int[] { 2, -1, -1, 1, 2, -2 };
        public override int BaseDisarmBonus => 10;
        public override int BaseDeviceBonus => 5;
        public override int BaseSaveBonus => 5;
        public override int BaseStealthBonus => 0;
        public override int BaseSearchBonus => -1;
        public override int BaseSearchFrequency => 10;
        public override int BaseMeleeAttackBonus => 5;
        public override int BaseRangedAttackBonus => 5;
        public override int HitDieBonus => 12;
        public override int ExperienceFactor => 135;
        public override int BaseAge => 20;
        public override int AgeRange => 3;
        public override int MaleBaseHeight => 60;
        public override int MaleHeightRange => 3;
        public override int MaleBaseWeight => 80;
        public override int MaleWeightRange => 4;
        public override int FemaleBaseHeight => 54;
        public override int FemaleHeightRange => 3;
        public override int FemaleBaseWeight => 70;
        public override int FemaleWeightRange => 4;
        public override int Infravision => 2;
        public override uint Choice => 0xC011;
        public override int Index => RaceId.Klackon;
        public override string Description => "Klackons are humanoid insects. Although most stay safe in\ntheir hive cities, a small number venture forth in search\nof adventure. The chitin of a klackon resists acid, and\ntheir ordered minds cannot be confused. They can learn to\nspit acid (at lvl 9) and they get progressively faster if\nunencumbered by armour.";

        /// <summary>
        /// Klackon 84->85->86->End
        /// </summary>
        public override int Chart => 84;

        public override string RacialPowersDescription(int lvl) => lvl < 9 ? "spit acid          (racial, unusable until level 9)" : "spit acid          (racial, cost 9, dam lvl, DEX based)";
        public override bool HasRacialPowers => true;
        public override void UpdateRacialAbilities(int level, ItemCharacteristics itemCharacteristics)
        {
            if (level > 9)
            {
                itemCharacteristics.Speed = true;
            }
            itemCharacteristics.ResConf = true;
            itemCharacteristics.ResAcid = true;
        }
        public override string CreateRandomName() => CreateRandomNameFromSyllables(new KlackonSyllables());
        public override string[]? SelfKnowledge(int level)
        {
            if (level > 8)
            {
                return new string[] { $"You can spit acid, dam. {level} (cost 9)." };
            }
            return null;
        }
        public override void CalcBonuses(SaveGame saveGame)
        {
            saveGame.Player.HasConfusionResistance = true;
            saveGame.Player.HasAcidResistance = true;
        }
        public override void UseRacialPower(SaveGame saveGame)
        {
            // Klackons can spit acid
            if (saveGame.CheckIfRacialPowerWorks(9, 9, Ability.Dexterity, 14))
            {
                TargetEngine targetEngine = new TargetEngine(saveGame);
                if (targetEngine.GetDirectionWithAim(out int direction))
                {
                    saveGame.MsgPrint("You spit acid.");
                    if (saveGame.Player.Level < 25)
                    {
                        saveGame.FireBolt(new ProjectAcid(saveGame), direction, saveGame.Player.Level);
                    }
                    else
                    {
                        saveGame.FireBall(new ProjectAcid(saveGame), direction, saveGame.Player.Level, 2);
                    }
                }
            }
        }
    }
}