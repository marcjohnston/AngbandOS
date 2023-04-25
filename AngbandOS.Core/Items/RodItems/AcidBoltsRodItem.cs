namespace AngbandOS.Core.Items
{
    [Serializable]
    internal class AcidBoltsRodItem : RodItem
    {
        public AcidBoltsRodItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<RodAcidBolts>()) { }
    }
}