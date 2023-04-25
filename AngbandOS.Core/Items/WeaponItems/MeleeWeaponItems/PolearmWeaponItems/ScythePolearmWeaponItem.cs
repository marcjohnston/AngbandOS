namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ScythePolearmWeaponItem : PolearmWeaponItem
    {
        public ScythePolearmWeaponItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<PolearmScythe>()) { }
    }
}