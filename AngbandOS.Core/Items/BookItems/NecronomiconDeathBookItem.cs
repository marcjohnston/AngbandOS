namespace AngbandOS.Core.Items
{
[Serializable]
    internal class NecronomiconDeathBookItem : DeathBookItem
    {
        public NecronomiconDeathBookItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<DeathBookNecronomicon>()) { }
    }
}