namespace AngbandOS.Core.Items
{
[Serializable]
    internal class UnhealthMushroomItem : MushroomItem
    {
        public UnhealthMushroomItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<MushroomUnhealth>()) { }
    }
}