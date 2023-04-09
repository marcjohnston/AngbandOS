namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ResistanceAmuletItem : AmuletItem
    {
        public ResistanceAmuletItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<AmuletResistance>()) { }
    }
}