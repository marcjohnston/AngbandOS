namespace AngbandOS.Core.Items
{
[Serializable]
    internal class DisarmingRodItem : RodItem
    {
        public DisarmingRodItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RodDisarming>()) { }
    }
}