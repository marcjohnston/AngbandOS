namespace AngbandOS.Core.Items
{
[Serializable]
    internal class DeVermisMysteriisCorporealBookItem : CorporealBookItem
    {
        public DeVermisMysteriisCorporealBookItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<CorporealBookDeVermisMysteriis>()) { }
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
    }
}