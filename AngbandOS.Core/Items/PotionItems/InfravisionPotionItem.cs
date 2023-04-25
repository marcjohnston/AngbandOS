namespace AngbandOS.Core.Items
{
[Serializable]
    internal class InfravisionPotionItem : PotionItem
    {
        public InfravisionPotionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<PotionInfravision>()) { }
    }
}