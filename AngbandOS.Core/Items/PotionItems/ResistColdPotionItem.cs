namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ResistColdPotionItem : PotionItem
    {
        public ResistColdPotionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<PotionResistCold>()) { }
    }
}