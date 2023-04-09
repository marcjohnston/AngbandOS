namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ResistAcidAmuletItem : AmuletItem
    {
        public ResistAcidAmuletItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<AmuletResistAcid>()) { }
        public override bool EasyKnow => true;
        public override bool IgnoreAcid => true;
        public override bool ResAcid => true;
    }
}