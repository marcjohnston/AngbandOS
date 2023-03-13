namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SlimeMoldJuicePotionItem : PotionItem
    {
        public SlimeMoldJuicePotionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<PotionSlimeMoldJuice>()) { }
    }
}