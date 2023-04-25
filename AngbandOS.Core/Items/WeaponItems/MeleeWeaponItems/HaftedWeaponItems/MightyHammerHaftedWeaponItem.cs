namespace AngbandOS.Core.Items
{
[Serializable]
    internal class MightyHammerHaftedWeaponItem : HaftedWeaponItem
    {
        public MightyHammerHaftedWeaponItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<HaftedMightyHammer>()) { }
    }
}