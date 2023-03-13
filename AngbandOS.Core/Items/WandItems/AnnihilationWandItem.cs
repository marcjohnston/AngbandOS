namespace AngbandOS.Core.Items
{
[Serializable]
    internal class AnnihilationWandItem : WandItem
    {
        public AnnihilationWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<WandAnnihilation>()) { }
    }
}