namespace AngbandOS.Core.Items
{
[Serializable]
    internal class UnaussprechlichenKultenSorceryBookItem : SorceryBookItem
    {
        public UnaussprechlichenKultenSorceryBookItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<SorceryBookUnaussprechlichenKulten>()) { }
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
    }
}