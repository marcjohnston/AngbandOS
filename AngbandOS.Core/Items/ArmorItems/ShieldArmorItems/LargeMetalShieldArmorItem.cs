namespace AngbandOS.Core.Items
{
[Serializable]
    internal class LargeMetalShieldArmorItem : ShieldArmorItem
    {
        public LargeMetalShieldArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<ShieldLargeMetalShield>()) { }
    }
}