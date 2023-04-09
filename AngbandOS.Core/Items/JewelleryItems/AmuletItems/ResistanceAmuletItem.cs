namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ResistanceAmuletItem : AmuletItem
    {
        public ResistanceAmuletItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<AmuletResistance>()) { }
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
        public override bool ResAcid => true;
        public override bool ResCold => true;
        public override bool ResElec => true;
        public override bool ResFire => true;
    }
}