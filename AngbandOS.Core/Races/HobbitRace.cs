namespace AngbandOS.Core.Races
{
    [Serializable]
    internal class HobbitRace : Race
    {
        private HobbitRace(SaveGame saveGame) : base(saveGame) { }
        public override string Title => "Hobbit";
        public override int[] AbilityBonus => new int[] { -2, 2, 1, 3, 2, 1 };
        public override int BaseDisarmBonus => 15;
        public override int BaseDeviceBonus => 18;
        public override int BaseSaveBonus => 18;
        public override int BaseStealthBonus => 5;
        public override int BaseSearchBonus => 12;
        public override int BaseSearchFrequency => 15;
        public override int BaseMeleeAttackBonus => -10;
        public override int BaseRangedAttackBonus => 20;
        public override int HitDieBonus => 7;
        public override int ExperienceFactor => 110;
        public override int BaseAge => 21;
        public override int AgeRange => 12;
        public override int MaleBaseHeight => 36;
        public override int MaleHeightRange => 3;
        public override int MaleBaseWeight => 60;
        public override int MaleWeightRange => 3;
        public override int FemaleBaseHeight => 33;
        public override int FemaleHeightRange => 3;
        public override int FemaleBaseWeight => 50;
        public override int FemaleWeightRange => 3;
        public override int Infravision => 4;
        public override uint Choice => 0xBC0B;
        public override string Description => "Hobbits are small and surprisingly dextrous given their\npropensity for plumpness. They make excellent burglars\nand are adept at spell casting too. Hobbits can't have\ntheir dexterity reduced, and they can learn to put together\nnourishing meals from the barest scraps (at lvl 15).";

        /// <summary>
        /// Hobbit 10->11->3->50->51->52->53->End
        /// </summary>
        public override int Chart => 10;

        public override string RacialPowersDescription(int lvl) => lvl < 15 ? "create food        (racial, unusable until level 15)" : "create food        (racial, cost 10, INT based)";
        public override bool HasRacialPowers => true;

        public override void UpdateRacialAbilities(int level, ItemCharacteristics itemCharacteristics)
        {
            itemCharacteristics.SustDex = true;
        }
        public override string CreateRandomName() => CreateRandomNameFromSyllables(new HobbitSyllables());

        public override string[]? SelfKnowledge(int level)
        {
            if (level > 14)
            {
                return new string[] { "You can produce food (cost 10)." };
            }
            return null;
        }

        public override void CalcBonuses(SaveGame saveGame)
        {
            saveGame.Player.HasSustainDexterity = true;
        }

        public override void UseRacialPower(SaveGame saveGame)
        {
            // Hobbits can cook food
            if (saveGame.CheckIfRacialPowerWorks(15, 10, Ability.Intelligence, 10))
            {
                ItemFactory foodItemClass = saveGame.SingletonRepository.ItemFactories.Get<RationFoodItemFactory>();
                Item item = foodItemClass.CreateItem();
                saveGame.Level.DropNear(item, -1, saveGame.Player.MapY, saveGame.Player.MapX);
                saveGame.MsgPrint("You cook some food.");
            }
        }
    }
}