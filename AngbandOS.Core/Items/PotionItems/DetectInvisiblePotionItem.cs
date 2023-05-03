namespace AngbandOS.Core.Items
{
[Serializable]
    internal class DetectInvisiblePotionItem : PotionItem
    {
        public DetectInvisiblePotionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<DetectInvisiblePotionItemFactory>()) { }
    }
}