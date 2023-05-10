namespace AngbandOS.Core.Items
{
[Serializable]
    internal class StinkingCloudWandItem : WandItem
    {
        public StinkingCloudWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<StinkingCloudWandItemFactory>()) { }
        protected override void ApplyMagic(int level, int power, Store? store)
        {
            TypeSpecificValue = Program.Rng.DieRoll(8) + 6;
        }
    }
}