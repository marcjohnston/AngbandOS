namespace AngbandOS.Core.Items
{
[Serializable]
    internal class LucerneHammerHaftedWeaponItem : HaftedWeaponItem
    {
        public LucerneHammerHaftedWeaponItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<HaftedLucerneHammer>()) { }
    }
}