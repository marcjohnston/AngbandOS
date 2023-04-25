namespace AngbandOS.Core.Items
{
[Serializable]
    internal class MetalBrigandineArmourHardArmorItem : HardArmorItem
    {
        public MetalBrigandineArmourHardArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<HardArmorMetalBrigandineArmour>()) { }
    }
}