namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SelfKnowledgePotionItem : PotionItem
    {
        public SelfKnowledgePotionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<PotionSelfKnowledge>()) { }
    }
}