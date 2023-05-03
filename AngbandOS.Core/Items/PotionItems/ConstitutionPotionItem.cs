namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ConstitutionPotionItem : PotionItem
    {
        public ConstitutionPotionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<ConstitutionPotionItemFactory>()) { }
    }
}