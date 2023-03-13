namespace AngbandOS.Core.Items
{
[Serializable]
    internal class InfravisionPotionItem : PotionItem
    {
        public InfravisionPotionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<PotionInfravision>()) { }
    }
}