namespace AngbandOS.Core.Items
{
[Serializable]
    internal class NewLifePotionItem : PotionItem
    {
        public NewLifePotionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<PotionNewLife>()) { }
    }
}