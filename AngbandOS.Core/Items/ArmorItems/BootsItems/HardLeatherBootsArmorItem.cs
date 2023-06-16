namespace AngbandOS.Core.Items
{
[Serializable]
    internal class HardLeatherBootsItem : BootsArmorItem
    {
        public HardLeatherBootsItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<HardLeatherBootsItemFactory>()) { }
    }
}