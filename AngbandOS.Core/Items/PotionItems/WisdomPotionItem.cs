namespace AngbandOS.Core.Items
{
[Serializable]
    internal class WisdomPotionItem : PotionItem
    {
        public WisdomPotionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<PotionWisdom>()) { }
    }
}