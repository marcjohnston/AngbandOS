namespace AngbandOS.Core.Items
{
[Serializable]
    internal class TrapCreationScrollItem : ScrollItem
    {
        public TrapCreationScrollItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<ScrollTrapCreation>()) { }
    }
}