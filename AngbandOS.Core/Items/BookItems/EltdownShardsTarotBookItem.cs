namespace AngbandOS.Core.Items
{
[Serializable]
    internal class EltdownShardsTarotBookItem : TarotBookItem
    {
        public EltdownShardsTarotBookItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<TarotBookEltdownShards>()) { }
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
    }
}