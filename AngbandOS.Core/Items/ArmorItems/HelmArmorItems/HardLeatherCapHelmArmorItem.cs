namespace AngbandOS.Core.Items
{
[Serializable]
    internal class HardLeatherCapHelmArmorItem : HelmArmorItem
    {
        public HardLeatherCapHelmArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<HelmHardLeatherCap>()) { }
    }
}