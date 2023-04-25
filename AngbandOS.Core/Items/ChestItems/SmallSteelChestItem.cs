namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SmallSteelChestItem : ChestItem
    {
        public SmallSteelChestItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<ChestSmallSteel>()) { }
    }
}