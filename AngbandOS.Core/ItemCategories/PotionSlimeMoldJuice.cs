using AngbandOS.Core.ItemClasses;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class PotionSlimeMoldJuice : PotionItemClass
    {
        public PotionSlimeMoldJuice(SaveGame saveGame) : base(saveGame) { }

        public override char Character => '!';
        public override string Name => "Slime Mold Juice";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 2;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Slime Mold Juice";
        public override int Pval => 400;
        public override int? SubCategory => (int?)PotionType.SlimeMold;
        public override int Weight => 4;
        public override bool Quaff(SaveGame saveGame)
        {
            // Slime mold juice has a random effect (calling this function again recusively)
            saveGame.MsgPrint("That tastes awful.");
            PotionItemClass potion = RandomPotion(saveGame);
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
        private PotionItemClass RandomPotion(SaveGame saveGame)
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
                    return new PotionWater(saveGame);
                case 2:
                    return new PotionAppleJuice(saveGame);
                case 3:
                    return new PotionSlowness(saveGame);
                case 4:
                    return new PotionSaltWater(saveGame);
                case 5:
                    return new PotionPoison(saveGame);
                case 6:
                    return new PotionBlindness(saveGame);
                case 7:
                    return new PotionBooze(saveGame);
                case 8:
                    return new PotionSleep(saveGame);
                case 9:
                    return new PotionInfravision(saveGame);
                case 10:
                    return new PotionDetectInvisible(saveGame);
                case 11:
                    return new PotionSlowPoison(saveGame);
                case 12:
                    return new PotionNeutralizePoison(saveGame);
                case 13:
                    return new PotionBoldness(saveGame);
                case 14:
                    return new PotionSpeed(saveGame);
                case 15:
                    return new PotionResistHeat(saveGame);
                case 16:
                    return new PotionResistCold(saveGame);
                case 17:
                    return new PotionHeroism(saveGame);
                case 18:
                    return new PotionBerserkStrength(saveGame);
                case 19:
                    return new PotionCureLightWounds(saveGame);
                case 20:
                    return new PotionCureSeriousWounds(saveGame);
                case 21:
                    return new PotionCureCriticalWounds(saveGame);
                case 22:
                    return new PotionHealing(saveGame);
                case 23:
                    return new PotionSpecialHealing(saveGame);
                case 24:
                    return new PotionLife(saveGame);
                case 25:
                    return new PotionRestoreMana(saveGame);
                case 26:
                    return new PotionRestoreLifeLevels(saveGame);
                case 27:
                    return new PotionRestoreStrength(saveGame);
                case 28:
                    return new PotionRestoreIntelligence(saveGame);
                case 29:
                    return new PotionRestoreWisdom(saveGame);
                case 30:
                    return new PotionRestoreDexterity(saveGame);
                case 31:
                    return new PotionRestoreConstitution(saveGame);
                case 32:
                    return new PotionRestoreCharisma(saveGame);
                case 33:
                    return new PotionStrength(saveGame);
                case 34:
                    return new PotionIntelligence(saveGame);
                case 35:
                    return new PotionWisdom(saveGame);
                case 36:
                    return new PotionDexterity(saveGame);
                case 37:
                    return new PotionConstitution(saveGame);
                case 38:
                    return new PotionCharisma(saveGame);
                case 39:
                    return new PotionAugmentation(saveGame);
                case 40:
                    return new PotionEnlightenment(saveGame);
                case 41:
                    return new PotionSpecialEnlightenment(saveGame);
                case 42:
                    return new PotionSelfKnowledge(saveGame);
                case 43:
                    return new PotionExperience(saveGame);
                case 44:
                    return new PotionResistance(saveGame);
                case 45:
                    return new PotionCuring(saveGame);
                case 46:
                    return new PotionInvulnerability(saveGame);
                case 47:
                    return new PotionNewLife(saveGame);
                default:
                    throw new Exception("Invalid random potion chosen.");
            }
        }
    }
}
