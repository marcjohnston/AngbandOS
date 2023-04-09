namespace AngbandOS.Core.Items
{
[Serializable]
    internal class LiberIvonisSorceryBookItem : SorceryBookItem
    {
        public LiberIvonisSorceryBookItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<SorceryBookLiberIvonis>()) { }
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
    }
}