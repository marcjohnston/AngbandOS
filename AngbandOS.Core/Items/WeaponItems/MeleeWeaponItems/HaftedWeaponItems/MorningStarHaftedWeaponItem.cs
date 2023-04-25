namespace AngbandOS.Core.Items
{
[Serializable]
    internal class MorningStarHaftedWeaponItem : HaftedWeaponItem
    {
        public MorningStarHaftedWeaponItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<HaftedMorningStar>()) { }
    }
}