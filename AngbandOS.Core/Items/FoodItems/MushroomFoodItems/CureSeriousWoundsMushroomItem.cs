namespace AngbandOS.Core.Items
{
[Serializable]
    internal class CureSeriousWoundsMushroomItem : MushroomItem
    {
        public CureSeriousWoundsMushroomItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<MushroomCureSeriousWounds>()) { }
    }
}