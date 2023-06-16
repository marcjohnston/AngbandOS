namespace AngbandOS.Core.Items
{
[Serializable]
    internal class LordlyProtectionRingItem : RingItem
    {
        public LordlyProtectionRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<LordlyProtectionRingItemFactory>()) { }
        protected override void ApplyMagic(int level, int power, Store? store)
        {
            IArtifactBias artifactBias = null;
            do
            {
                ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(20) + 18);
            } while (Program.Rng.DieRoll(4) == 1);
            BonusArmorClass = 10 + Program.Rng.DieRoll(5) + GetBonusValue(10, level);
            if (SaveGame.Level != null)
            {
                SaveGame.Level.TreasureRating += 5;
            }
        }
    }
}