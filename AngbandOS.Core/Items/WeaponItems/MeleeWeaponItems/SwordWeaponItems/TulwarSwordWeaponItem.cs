namespace AngbandOS.Core.Items
{
[Serializable]
    internal class TulwarSwordWeaponItem : SwordWeaponItem
    {
        public TulwarSwordWeaponItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<SwordTulwar>()) { }
    }
}