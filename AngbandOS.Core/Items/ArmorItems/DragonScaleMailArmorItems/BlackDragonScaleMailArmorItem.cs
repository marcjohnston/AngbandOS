namespace AngbandOS.Core.Items
{
[Serializable]
    internal class BlackDragonScaleMailArmorItem : DragonScaleMailArmorItem
    {
        public BlackDragonScaleMailArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<BlackDragonScaleMailArmorItemFactory>()) { }
    }
}