using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class PotionSlimeMoldJuice : PotionItemCategory
    {
        public override char Character => '!';
        public override string Name => "Slime Mold Juice";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 2;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Slime Mold Juice";
        public override int Pval => 400;
        public override int? SubCategory => (int)PotionType.SlimeMold;
        public override int Weight => 4;
        public override bool Quaff(SaveGame saveGame)
        {
            // Slime mold juice has a random effect (calling this function again recusively)
            saveGame.MsgPrint("That tastes awful.");
            PotionItemCategory potion = RandomPotion();
            potion.Quaff(saveGame);
            return true;
        }
        public override bool Smash(SaveGame saveGame, int who, int y, int x)
        {
            return true;
        }

        /// <summary>
        /// Pick a random potion to use from a selection that won't kill us
        /// </summary>
        /// <returns> The item sub-category of the potion to use </returns>
        private PotionItemCategory RandomPotion()
        {
            // The following potions are not selected as random.  SlimeMold is the potion causing the random.
            //Death = 23,
            //DecCha = 21,
            //DecCon = 20,
            //DecDex = 19,
            //DecInt = 17,
            //DecStr = 16,
            //DecWis = 18,
            //LoseMemories = 13,
            //Ruination = 15,
            //SlimeMold = 2,

            switch (Program.Rng.DieRoll(48))
            {
                case 1:
                    return new PotionWater();
                case 2:
                    return new PotionAppleJuice();
                case 3:
                    return new PotionSlowness();
                case 4:
                    return new PotionSaltWater();
                case 5:
                    return new PotionPoison();
                case 6:
                    return new PotionBlindness();
                case 7:
                    return new PotionBooze();
                case 8:
                    return new PotionSleep();
                case 9:
                    return new PotionInfravision();
                case 10:
                    return new PotionDetectInvisible();
                case 11:
                    return new PotionSlowPoison();
                case 12:
                    return new PotionNeutralizePoison();
                case 13:
                    return new PotionBoldness();
                case 14:
                    return new PotionSpeed();
                case 15:
                    return new PotionResistHeat();
                case 16:
                    return new PotionResistCold();
                case 17:
                    return new PotionHeroism();
                case 18:
                    return new PotionBerserkStrength();
                case 19:
                    return new PotionCureLightWounds();
                case 20:
                    return new PotionCureSeriousWounds();
                case 21:
                    return new PotionCureCriticalWounds();
                case 22:
                    return new PotionHealing();
                case 23:
                    return new PotionSpecialHealing();
                case 24:
                    return new PotionLife();
                case 25:
                    return new PotionRestoreMana();
                case 26:
                    return new PotionRestoreLifeLevels();
                case 27:
                    return new PotionRestoreStrength();
                case 28:
                    return new PotionRestoreIntelligence();
                case 29:
                    return new PotionRestoreWisdom();
                case 30:
                    return new PotionRestoreDexterity();
                case 31:
                    return new PotionRestoreConstitution();
                case 32:
                    return new PotionRestoreCharisma();
                case 33:
                    return new PotionStrength();
                case 34:
                    return new PotionIntelligence();
                case 35:
                    return new PotionWisdom();
                case 36:
                    return new PotionDexterity();
                case 37:
                    return new PotionConstitution();
                case 38:
                    return new PotionCharisma();
                case 39:
                    return new PotionAugmentation();
                case 40:
                    return new PotionEnlightenment();
                case 41:
                    return new PotionSpecialEnlightenment();
                case 42:
                    return new PotionSelfKnowledge();
                case 43:
                    return new PotionExperience();
                case 44:
                    return new PotionResistance();
                case 45:
                    return new PotionCuring();
                case 46:
                    return new PotionInvulnerability();
                case 47:
                    return new PotionNewLife();
                default:
                    throw new Exception("Invalid random potion chosen.");
            }
        }
    }
}
