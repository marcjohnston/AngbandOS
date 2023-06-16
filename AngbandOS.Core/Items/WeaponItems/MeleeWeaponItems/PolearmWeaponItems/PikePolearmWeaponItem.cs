namespace AngbandOS.Core.Items;

[Serializable]
internal class PikePolearmWeaponItem : PolearmWeaponItem
{
    public PikePolearmWeaponItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<PolearmPike>()) { }
}