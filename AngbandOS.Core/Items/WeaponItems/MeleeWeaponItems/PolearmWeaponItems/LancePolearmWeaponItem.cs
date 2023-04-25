namespace AngbandOS.Core.Items
{
[Serializable]
    internal class LancePolearmWeaponItem : PolearmWeaponItem
    {
        public LancePolearmWeaponItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<PolearmLance>()) { }
    }
}