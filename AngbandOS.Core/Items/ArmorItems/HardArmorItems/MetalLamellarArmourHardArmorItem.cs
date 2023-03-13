namespace AngbandOS.Core.Items
{
[Serializable]
    internal class MetalLamellarArmourHardArmorItem : HardArmorItem
    {
        public MetalLamellarArmourHardArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<HardArmorMetalLamellarArmour>()) { }
    }
}