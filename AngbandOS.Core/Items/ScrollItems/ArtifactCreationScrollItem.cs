namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ArtifactCreationScrollItem : ScrollItem
    {
        public ArtifactCreationScrollItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<ScrollArtifactCreation>()) { }
    }
}