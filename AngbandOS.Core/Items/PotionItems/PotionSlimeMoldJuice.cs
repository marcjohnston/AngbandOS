namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class PotionSlimeMoldJuice : PotionItemClass
    {
        private PotionSlimeMoldJuice(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

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
                    return (PotionItemClass)saveGame.SingletonRepository.ItemFactories.Get<PotionWater>();
                case 2:
                    return (PotionItemClass)saveGame.SingletonRepository.ItemFactories.Get<PotionAppleJuice>();
                case 3:
                    return (PotionItemClass)saveGame.SingletonRepository.ItemFactories.Get<PotionSlowness>();
                case 4:
                    return (PotionItemClass)saveGame.SingletonRepository.ItemFactories.Get<PotionSaltWater>();
                case 5:
                    return (PotionItemClass)saveGame.SingletonRepository.ItemFactories.Get<PotionPoison>();
                case 6:
                    return (PotionItemClass)saveGame.SingletonRepository.ItemFactories.Get<PotionBlindness>();
                case 7:
                    return (PotionItemClass)saveGame.SingletonRepository.ItemFactories.Get<PotionBooze>();
                case 8:
                    return (PotionItemClass)saveGame.SingletonRepository.ItemFactories.Get<PotionSleep>();
                case 9:
                    return (PotionItemClass)saveGame.SingletonRepository.ItemFactories.Get<PotionInfravision>();
                case 10:
                    return (PotionItemClass)saveGame.SingletonRepository.ItemFactories.Get<PotionDetectInvisible>();
                case 11:
                    return (PotionItemClass)saveGame.SingletonRepository.ItemFactories.Get<PotionSlowPoison>();
                case 12:
                    return (PotionItemClass)saveGame.SingletonRepository.ItemFactories.Get<PotionNeutralizePoison>();
                case 13:
                    return (PotionItemClass)saveGame.SingletonRepository.ItemFactories.Get<PotionBoldness>();
                case 14:
                    return (PotionItemClass)saveGame.SingletonRepository.ItemFactories.Get<PotionSpeed>();
                case 15:
                    return (PotionItemClass)saveGame.SingletonRepository.ItemFactories.Get<PotionResistHeat>();
                case 16:
                    return (PotionItemClass)saveGame.SingletonRepository.ItemFactories.Get<PotionResistCold>();
                case 17:
                    return (PotionItemClass)saveGame.SingletonRepository.ItemFactories.Get<PotionHeroism>();
                case 18:
                    return (PotionItemClass)saveGame.SingletonRepository.ItemFactories.Get<PotionBerserkStrength>();
                case 19:
                    return (PotionItemClass)saveGame.SingletonRepository.ItemFactories.Get<PotionCureLightWounds>();
                case 20:
                    return (PotionItemClass)saveGame.SingletonRepository.ItemFactories.Get<PotionCureSeriousWounds>();
                case 21:
                    return (PotionItemClass)saveGame.SingletonRepository.ItemFactories.Get<PotionCureCriticalWounds>();
                case 22:
                    return (PotionItemClass)saveGame.SingletonRepository.ItemFactories.Get<PotionHealing>();
                case 23:
                    return (PotionItemClass)saveGame.SingletonRepository.ItemFactories.Get<PotionSpecialHealing>();
                case 24:
                    return (PotionItemClass)saveGame.SingletonRepository.ItemFactories.Get<PotionLife>();
                case 25:
                    return (PotionItemClass)saveGame.SingletonRepository.ItemFactories.Get<PotionRestoreMana>();
                case 26:
                    return (PotionItemClass)saveGame.SingletonRepository.ItemFactories.Get<PotionRestoreLifeLevels>();
                case 27:
                    return (PotionItemClass)saveGame.SingletonRepository.ItemFactories.Get<PotionRestoreStrength>();
                case 28:
                    return (PotionItemClass)saveGame.SingletonRepository.ItemFactories.Get<PotionRestoreIntelligence>();
                case 29:
                    return (PotionItemClass)saveGame.SingletonRepository.ItemFactories.Get<PotionRestoreWisdom>();
                case 30:
                    return (PotionItemClass)saveGame.SingletonRepository.ItemFactories.Get<PotionRestoreDexterity>();
                case 31:
                    return (PotionItemClass)saveGame.SingletonRepository.ItemFactories.Get<PotionRestoreConstitution>();
                case 32:
                    return (PotionItemClass)saveGame.SingletonRepository.ItemFactories.Get<PotionRestoreCharisma>();
                case 33:
                    return (PotionItemClass)saveGame.SingletonRepository.ItemFactories.Get<PotionStrength>();
                case 34:
                    return (PotionItemClass)saveGame.SingletonRepository.ItemFactories.Get<PotionIntelligence>();
                case 35:
                    return (PotionItemClass)saveGame.SingletonRepository.ItemFactories.Get<PotionWisdom>();
                case 36:
                    return (PotionItemClass)saveGame.SingletonRepository.ItemFactories.Get<PotionDexterity>();
                case 37:
                    return (PotionItemClass)saveGame.SingletonRepository.ItemFactories.Get<PotionConstitution>();
                case 38:
                    return (PotionItemClass)saveGame.SingletonRepository.ItemFactories.Get<PotionCharisma>();
                case 39:
                    return (PotionItemClass)saveGame.SingletonRepository.ItemFactories.Get<PotionAugmentation>();
                case 40:
                    return (PotionItemClass)saveGame.SingletonRepository.ItemFactories.Get<PotionEnlightenment>();
                case 41:
                    return (PotionItemClass)saveGame.SingletonRepository.ItemFactories.Get<PotionSpecialEnlightenment>();
                case 42:
                    return (PotionItemClass)saveGame.SingletonRepository.ItemFactories.Get<PotionSelfKnowledge>();
                case 43:
                    return (PotionItemClass)saveGame.SingletonRepository.ItemFactories.Get<PotionExperience>();
                case 44:
                    return (PotionItemClass)saveGame.SingletonRepository.ItemFactories.Get<PotionResistance>();
                case 45:
                    return (PotionItemClass)saveGame.SingletonRepository.ItemFactories.Get<PotionCuring>();
                case 46:
                    return (PotionItemClass)saveGame.SingletonRepository.ItemFactories.Get<PotionInvulnerability>();
                case 47:
                    return (PotionItemClass)saveGame.SingletonRepository.ItemFactories.Get<PotionNewLife>();
                default:
                    throw new Exception("Invalid random potion chosen.");
            }
        }
        public override Item CreateItem() => new SlimeMoldJuicePotionItem(SaveGame);
    }
}
