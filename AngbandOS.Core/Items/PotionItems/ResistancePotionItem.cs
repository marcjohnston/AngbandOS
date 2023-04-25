namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ResistancePotionItem : PotionItem
    {
        public ResistancePotionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<PotionResistance>()) { }
    }
}