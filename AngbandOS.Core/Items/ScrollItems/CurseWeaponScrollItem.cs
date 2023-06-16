namespace AngbandOS.Core.Items;

[Serializable]
internal class CurseWeaponScrollItem : ScrollItem
{
    public CurseWeaponScrollItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<ScrollCurseWeapon>()) { }
}