namespace AngbandOS.Core.Items
{
[Serializable]
    internal class RestoreConstitutionMushroomItem : MushroomItem
    {
        public RestoreConstitutionMushroomItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<MushroomRestoreConstitution>()) { }
    }
}