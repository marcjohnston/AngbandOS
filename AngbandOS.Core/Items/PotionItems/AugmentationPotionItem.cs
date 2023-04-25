namespace AngbandOS.Core.Items
{
[Serializable]
    internal class AugmentationPotionItem : PotionItem
    {
        public AugmentationPotionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<PotionAugmentation>()) { }
    }
}