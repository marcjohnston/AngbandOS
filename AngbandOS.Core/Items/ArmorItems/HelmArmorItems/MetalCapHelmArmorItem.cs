namespace AngbandOS.Core.Items;

[Serializable]
internal class MetalCapHelmArmorItem : HelmArmorItem
{
    public MetalCapHelmArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<HelmMetalCap>()) { }
}