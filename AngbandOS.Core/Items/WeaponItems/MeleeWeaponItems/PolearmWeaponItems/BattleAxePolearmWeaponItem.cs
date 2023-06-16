namespace AngbandOS.Core.Items;

[Serializable]
internal class BattleAxePolearmWeaponItem : PolearmWeaponItem
{
    public BattleAxePolearmWeaponItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<PolearmBattleAxe>()) { }
}