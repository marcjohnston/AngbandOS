namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ParalysisMushroomItem : MushroomItem
    {
        public ParalysisMushroomItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<MushroomParalysis>()) { }
    }
}