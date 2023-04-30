namespace AngbandOS.Core.Items
{
[Serializable]
    internal class PowerDragonScaleMailArmorItem : DragonScaleMailArmorItem
    {
        public PowerDragonScaleMailArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<PowerDragonScaleMailArmorItemFactory>()) { }
    }
}