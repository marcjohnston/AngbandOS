namespace AngbandOS.Core.Items
{
[Serializable]
    internal class GharneFragmentsChaosBookItem : ChaosBookItem
    {
        public GharneFragmentsChaosBookItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<ChaosBookGharneFragments>()) { }
    }
}