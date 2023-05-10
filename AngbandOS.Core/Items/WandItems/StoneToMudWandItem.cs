namespace AngbandOS.Core.Items
{
[Serializable]
    internal class StoneToMudWandItem : WandItem
    {
        public StoneToMudWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<StonetoMudWandItemFactory>()) { }
        protected override void ApplyMagic(int level, int power, Store? store)
        {
            TypeSpecificValue = Program.Rng.DieRoll(8) + 3;
        }
    }
}