namespace AngbandOS.Core.Items
{
[Serializable]
    internal class JewelEncrustedCrownArmorItem : CrownArmorItem
    {
        public JewelEncrustedCrownArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<CrownJewelEncrusted>()) { }
    }
}