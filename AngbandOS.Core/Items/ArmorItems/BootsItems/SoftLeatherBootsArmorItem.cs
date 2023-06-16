namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SoftLeatherBootsArmorItem : BootsArmorItem
    {
        public SoftLeatherBootsArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<SoftLeatherBootsArmorItemFactory>()) { }
    }
}