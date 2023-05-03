namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ResistHeatPotionItem : PotionItem
    {
        public ResistHeatPotionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<ResistHeatPotionItemFactory>()) { }
    }
}