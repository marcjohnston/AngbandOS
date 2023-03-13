namespace AngbandOS.Core.Items
{
[Serializable]
    internal class RestoreStrengthMushroomItem : MushroomItem
    {
        public RestoreStrengthMushroomItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<MushroomRestoreStrength>()) { }
    }
}