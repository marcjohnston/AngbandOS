namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ExperiencePotionItem : PotionItem
    {
        public ExperiencePotionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<PotionExperience>()) { }
    }
}