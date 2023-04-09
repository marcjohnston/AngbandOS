namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ResistancePotionItem : PotionItem
    {
        public ResistancePotionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<PotionResistance>()) { }
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
    }
}