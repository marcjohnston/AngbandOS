namespace AngbandOS.Core.Items
{
[Serializable]
    internal class RestorationRodItem : RodItem
    {
        public RestorationRodItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RodRestoration>()) { }
    }
}