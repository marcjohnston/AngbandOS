namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SoftLeatherArmourSoftArmorItem : SoftArmorItem
    {
        public SoftLeatherArmourSoftArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<SoftArmorSoftLeatherArmour>()) { }
    }
}