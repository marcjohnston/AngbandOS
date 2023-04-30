namespace AngbandOS.Core.Items
{
[Serializable]
    internal class BlueDragonScaleMailArmorItem : DragonScaleMailArmorItem
    {
        public BlueDragonScaleMailArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<BlueDragonScaleMailArmorItemFactory>()) { }
    }
}