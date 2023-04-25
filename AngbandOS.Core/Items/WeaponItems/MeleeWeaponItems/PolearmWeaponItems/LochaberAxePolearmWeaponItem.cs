namespace AngbandOS.Core.Items
{
[Serializable]
    internal class LochaberAxePolearmWeaponItem : PolearmWeaponItem
    {
        public LochaberAxePolearmWeaponItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<PolearmLochaberAxe>()) { }
    }
}