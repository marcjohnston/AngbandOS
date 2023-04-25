namespace AngbandOS.Core.Items
{
[Serializable]
    internal class HardLeatherBootsItem : BootsItem
    {
        public HardLeatherBootsItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<BootsHardLeatherBoots>()) { }
    }
}