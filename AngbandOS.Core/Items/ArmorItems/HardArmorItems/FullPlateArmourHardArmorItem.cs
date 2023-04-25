namespace AngbandOS.Core.Items
{
[Serializable]
    internal class FullPlateArmourHardArmorItem : HardArmorItem
    {
        public FullPlateArmourHardArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<HardArmorFullPlateArmour>()) { }
    }
}