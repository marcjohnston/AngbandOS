namespace AngbandOS.Core.Items
{
[Serializable]
    internal class MaceHaftedWeaponItem : HaftedWeaponItem
    {
        public MaceHaftedWeaponItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<HaftedMace>()) { }
    }
}