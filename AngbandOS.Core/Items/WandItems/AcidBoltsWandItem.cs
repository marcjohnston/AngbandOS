namespace AngbandOS.Core.Items
{
[Serializable]
    internal class AcidBoltsWandItem : WandItem
    {
        public AcidBoltsWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<WandAcidBolts>()) { }
    }
}