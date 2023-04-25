namespace AngbandOS.Core.Items
{
[Serializable]
    internal class DrainLifeRodItem : RodItem
    {
        public DrainLifeRodItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<RodDrainLife>()) { }
    }
}