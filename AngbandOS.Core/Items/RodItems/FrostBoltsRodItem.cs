namespace AngbandOS.Core.Items
{
[Serializable]
    internal class FrostBoltsRodItem : RodItem
    {
        public FrostBoltsRodItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<RodFrostBolts>()) { }
    }
}