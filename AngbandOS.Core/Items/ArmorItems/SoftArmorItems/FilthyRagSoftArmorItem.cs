namespace AngbandOS.Core.Items
{
[Serializable]
    internal class FilthyRagSoftArmorItem : SoftArmorItem
    {
        public FilthyRagSoftArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<SoftArmorFilthyRag>()) { }
    }
}