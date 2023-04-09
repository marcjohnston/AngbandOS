namespace AngbandOS.Core.Items
{
[Serializable]
    internal class TheBookofAzathothChaosBookItem : ChaosBookItem
    {
        public TheBookofAzathothChaosBookItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<ChaosBookTheBookofAzathoth>()) { }
    }
}