namespace AngbandOS.Core.Items
{
[Serializable]
    internal class PerceptionRodItem : RodItem
    {
        public PerceptionRodItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<RodPerception>()) { }
    }
}