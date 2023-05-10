namespace AngbandOS.Core.Items
{
[Serializable]
    internal class TeleportOtherWandItem : WandItem
    {
        public TeleportOtherWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<TeleportOtherWandItemFactory>()) { }
        protected override void ApplyMagic(int level, int power, Store? store)
        {
            TypeSpecificValue = Program.Rng.DieRoll(5) + 6;
        }
    }
}