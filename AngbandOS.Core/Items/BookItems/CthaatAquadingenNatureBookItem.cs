namespace AngbandOS.Core.Items
{
[Serializable]
    internal class CthaatAquadingenNatureBookItem : NatureBookItem
    {
        public CthaatAquadingenNatureBookItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<NatureBookCthaatAquadingen>()) { }
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
    }
}