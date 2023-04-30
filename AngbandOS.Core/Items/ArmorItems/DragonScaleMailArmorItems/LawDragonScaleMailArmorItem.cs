namespace AngbandOS.Core.Items
{
[Serializable]
    internal class LawDragonScaleMailArmorItem : DragonScaleMailArmorItem
    {
        public LawDragonScaleMailArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<LawDragonScaleMailArmorItemFactory>()) { }
    }
}