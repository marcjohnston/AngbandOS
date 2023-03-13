namespace AngbandOS.Core.Items
{
[Serializable]
    internal class DragonShieldArmorItem : ShieldArmorItem
    {
        public DragonShieldArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<ShieldDragonShield>()) { }
    }
}