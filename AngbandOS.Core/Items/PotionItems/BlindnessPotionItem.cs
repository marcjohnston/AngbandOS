namespace AngbandOS.Core.Items;

[Serializable]
internal class BlindnessPotionItem : PotionItem
{
    public BlindnessPotionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<BlindnessPotionItemFactory>()) { }
}