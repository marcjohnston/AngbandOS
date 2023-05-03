namespace AngbandOS.Core.Items
{
[Serializable]
    internal class DetonationsPotionItem : PotionItem
    {
        public DetonationsPotionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<DetonationsPotionItemFactory>()) { }
    }
}