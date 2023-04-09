namespace AngbandOS.Core.Items
{
[Serializable]
    internal class CeleanoFragmentTarotBookItem : TarotBookItem
    {
        public CeleanoFragmentTarotBookItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<TarotBookCeleanoFragments>()) { }
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
    }
}