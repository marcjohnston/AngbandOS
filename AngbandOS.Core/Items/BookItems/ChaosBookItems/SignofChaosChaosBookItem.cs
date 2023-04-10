namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SignofChaosChaosBookItem : ChaosBookItem
    {
        public SignofChaosChaosBookItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<ChaosBookSignofChaos>()) { }
    }
}