namespace AngbandOS.Core.Items
{
[Serializable]
    internal class IronSpikeItem : SpikeItem
    {
        public IronSpikeItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<SpikeIronSpike>()) { }
    }
}