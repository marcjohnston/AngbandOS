namespace AngbandOS.Core.Items;

[Serializable]
internal class SleepPotionItem : PotionItem
{
    public SleepPotionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<SleepPotionItemFactory>()) { }
}