namespace AngbandOS.Core.Items
{
[Serializable]
    internal class RestoreCharismaPotionItem : PotionItem
    {
        public RestoreCharismaPotionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<PotionRestoreCharisma>()) { }
    }
}