namespace AngbandOS.Core.Items
{
[Serializable]
    internal class IocainePotionItem : PotionItem
    {
        public IocainePotionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<PotionIocaine>()) { }
    }
}