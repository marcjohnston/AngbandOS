namespace AngbandOS.Core.Items
{
[Serializable]
    internal class CurePoisonMushroomItem : MushroomItem
    {
        public CurePoisonMushroomItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<MushroomCurePoison>()) { }
    }
}