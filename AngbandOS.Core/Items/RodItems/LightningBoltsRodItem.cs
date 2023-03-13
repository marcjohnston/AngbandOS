namespace AngbandOS.Core.Items
{
[Serializable]
    internal class LightningBoltsRodItem : RodItem
    {
        public LightningBoltsRodItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RodLightningBolts>()) { }
    }
}