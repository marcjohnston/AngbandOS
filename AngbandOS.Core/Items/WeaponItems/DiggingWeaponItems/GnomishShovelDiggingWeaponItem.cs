namespace AngbandOS.Core.Items
{
[Serializable]
    internal class GnomishShovelDiggingWeaponItem : DiggingWeaponItem
    {
        public GnomishShovelDiggingWeaponItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<DiggingGnomishShovel>()) { }
    }
}