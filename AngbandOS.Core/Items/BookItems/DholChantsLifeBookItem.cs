namespace AngbandOS.Core.Items
{
[Serializable]
    internal class DholChantsLifeBookItem : LifeBookItem
    {
        public DholChantsLifeBookItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<LifeBookDholChants>()) { }
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
    }
}