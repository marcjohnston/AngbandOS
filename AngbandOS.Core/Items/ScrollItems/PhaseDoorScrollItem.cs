namespace AngbandOS.Core.Items
{
[Serializable]
    internal class PhaseDoorScrollItem : ScrollItem
    {
        public PhaseDoorScrollItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<ScrollPhaseDoor>()) { }
    }
}