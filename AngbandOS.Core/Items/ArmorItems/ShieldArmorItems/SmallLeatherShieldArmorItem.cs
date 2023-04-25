namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SmallLeatherShieldArmorItem : ShieldArmorItem
    {
        public SmallLeatherShieldArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<ShieldSmallLeatherShield>()) { }
    }
}