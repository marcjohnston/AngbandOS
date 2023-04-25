namespace AngbandOS.Core.Items
{
[Serializable]
    internal class TwoHandedSwordWeaponItem : SwordWeaponItem
    {
        public TwoHandedSwordWeaponItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<SwordTwoHandedSword>()) { }
    }
}