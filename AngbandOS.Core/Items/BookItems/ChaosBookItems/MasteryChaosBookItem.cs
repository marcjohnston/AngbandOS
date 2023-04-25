namespace AngbandOS.Core.Items
{
[Serializable]
    internal class MasteryChaosBookItem : ChaosBookItem
    {
        public MasteryChaosBookItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<ChaosBookChaosMastery>()) { }
    }
}