namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SoftLeatherBootsItem : BootsItem
    {
        public SoftLeatherBootsItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<BootsSoftLeatherBoots>()) { }
    }
}