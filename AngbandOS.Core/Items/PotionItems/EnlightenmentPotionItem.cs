namespace AngbandOS.Core.Items
{
[Serializable]
    internal class EnlightenmentPotionItem : PotionItem
    {
        public EnlightenmentPotionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<PotionEnlightenment>()) { }
    }
}