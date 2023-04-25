namespace AngbandOS.Core.Items
{
[Serializable]
    internal class MainGaucheSwordWeaponItem : SwordWeaponItem
    {
        public MainGaucheSwordWeaponItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<SwordMainGauche>()) { }
    }
}