namespace AngbandOS.Core.Items
{
[Serializable]
    internal class WhiteDragonScaleMailArmorItem : DragonScaleMailArmorItem
    {
        public WhiteDragonScaleMailArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<WhiteDragonScaleMailArmorItemFactory>()) { }
    }
}