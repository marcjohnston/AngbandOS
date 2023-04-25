namespace AngbandOS.Core.Items
{
[Serializable]
    internal class HalberdPolearmWeaponItem : PolearmWeaponItem
    {
        public HalberdPolearmWeaponItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<PolearmHalberd>()) { }
    }
}