namespace AngbandOS.Core.Items
{
[Serializable]
    internal class EmptyBottle : BottleItem
    {
        public EmptyBottle(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<EmptyBottleItemFactory>()) { }
    }
}