namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SpecialEnlightenmentPotionItem : PotionItem
    {
        public SpecialEnlightenmentPotionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<PotionSpecialEnlightenment>()) { }
    }
}