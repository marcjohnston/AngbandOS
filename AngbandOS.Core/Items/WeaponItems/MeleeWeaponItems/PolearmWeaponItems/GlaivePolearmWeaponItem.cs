namespace AngbandOS.Core.Items;

[Serializable]
internal class GlaivePolearmWeaponItem : PolearmWeaponItem
{
    public GlaivePolearmWeaponItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<PolearmGlaive>()) { }
}