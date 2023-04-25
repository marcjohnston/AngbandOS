namespace AngbandOS.Core.Items
{
[Serializable]
    internal class MetalShodBootsItem : BootsItem
    {
        public MetalShodBootsItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<BootsMetalShodBoots>()) { }
    }
}