namespace AngbandOS.Core.Items
{
[Serializable]
    internal class NeutralizePoisonPotionItem : PotionItem
    {
        public NeutralizePoisonPotionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<PotionNeutralizePoison>()) { }
    }
}