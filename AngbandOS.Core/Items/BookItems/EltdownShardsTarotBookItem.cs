namespace AngbandOS.Core.Items
{
[Serializable]
    internal class EltdownShardsTarotBookItem : TarotBookItem
    {
        public EltdownShardsTarotBookItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<TarotBookEltdownShards>()) { }
    }
}