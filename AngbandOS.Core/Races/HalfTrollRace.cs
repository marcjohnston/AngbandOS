using AngbandOS.Core.Syllables;

namespace AngbandOS.Core.Races
{
    [Serializable]
    internal class HalfTrollRace : Race
    {
        public override string Title => "Half Troll";
        public override int[] AbilityBonus => new int[] { 4, -4, -2, -4, 3, -6 };
        public override int BaseDisarmBonus => -5;
        public override int BaseDeviceBonus => -8;
        public override int BaseSaveBonus => -8;
        public override int BaseStealthBonus => -2;
        public override int BaseSearchBonus => -1;
        public override int BaseSearchFrequency => 5;
        public override int BaseMeleeAttackBonus => 20;
        public override int BaseRangedAttackBonus => -10;
        public override int HitDieBonus => 12;
        public override int ExperienceFactor => 137;
        public override int BaseAge => 20;
        public override int AgeRange => 10;
        public override int MaleBaseHeight => 96;
        public override int MaleHeightRange => 10;
        public override int MaleBaseWeight => 250;
        public override int MaleWeightRange => 50;
        public override int FemaleBaseHeight => 84;
        public override int FemaleHeightRange => 8;
        public override int FemaleBaseWeight => 225;
        public override int FemaleWeightRange => 40;
        public override int Infravision => 3;
        public override uint Choice => 0x0805;
        public override string Description => "Half-Trolls make up for their stupidity by being almost\npure muscle, as strong as creatures much larger than they.\nThey can't have their strength reduced, and as they grow\nstronger they can go into a berserk rage (at lvl 10),\nregenerate wounds (at lvl 15), and survive on less food\n(at lvl 15).";

        /// <summary>
        /// Half-Troll 22->23->62->63->64->65->66->End
        /// </summary>
        public override int Chart => 22;

        public override string RacialPowersDescription(int lvl) => lvl < 10 ? "berserk            (racial, unusable until level 10)" : "berserk            (racial, cost 12, WIS based)";
        public override bool HasRacialPowers => true;

        public override void UpdateRacialAbilities(int level, ItemCharacteristics itemCharacteristics)
        {
            itemCharacteristics.SustStr = true;
            if (level > 14)
            {
                itemCharacteristics.Regen = true;
                itemCharacteristics.SlowDigest = true;
            }
        }
        public override string CreateRandomName() => CreateRandomNameFromSyllables(new OrcishSyllables());

        public override string[]? SelfKnowledge(int level)
        {
            if (level > 9)
            {
                return new string[] { "You enter berserk fury (cost 12)." };
            }
            return null;
        }

        public override void CalcBonuses(SaveGame saveGame)
        {
            saveGame.Player.HasSustainStrength = true;
            if (saveGame.Player.Level > 14)
            {
                saveGame.Player.HasRegeneration = true;
                saveGame.Player.HasSlowDigestion = true;
            }
        }

        public override void UseRacialPower(SaveGame saveGame)
        {
            // Half-trolls can go berserk, which also heals them
            if (saveGame.CheckIfRacialPowerWorks(10, 12, Ability.Wisdom, saveGame.Player.ProfessionIndex == CharacterClass.Warrior ? 6 : 12))
            {
                saveGame.MsgPrint("RAAAGH!");
                saveGame.Player.SetTimedFear(0);
                saveGame.Player.SetTimedSuperheroism(saveGame.Player.TimedSuperheroism + 10 + Program.Rng.DieRoll(saveGame.Player.Level));
                saveGame.Player.RestoreHealth(30);
            }
        }
    }
}