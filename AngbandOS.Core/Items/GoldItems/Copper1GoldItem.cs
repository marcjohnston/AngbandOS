namespace AngbandOS.Core.Items
{
[Serializable]
    internal class Copper1GoldItem : GoldItem
    {
        public Copper1GoldItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<GoldCopper1>()) { }
    }
}