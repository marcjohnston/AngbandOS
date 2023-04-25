namespace AngbandOS.Core.Items
{
[Serializable]
    internal class LightRodItem : RodItem
    {
        public LightRodItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<RodLight>()) { }
    }
}