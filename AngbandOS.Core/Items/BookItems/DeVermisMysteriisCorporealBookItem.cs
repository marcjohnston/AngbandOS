namespace AngbandOS.Core.Items
{
[Serializable]
    internal class DeVermisMysteriisCorporealBookItem : CorporealBookItem
    {
        public DeVermisMysteriisCorporealBookItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<CorporealBookDeVermisMysteriis>()) { }
    }
}