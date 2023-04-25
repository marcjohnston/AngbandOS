namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SpearPolearmWeaponItem : PolearmWeaponItem
    {
        public SpearPolearmWeaponItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<PolearmSpear>()) { }
    }
}