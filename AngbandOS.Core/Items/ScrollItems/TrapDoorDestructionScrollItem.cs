namespace AngbandOS.Core.Items
{
[Serializable]
    internal class TrapDoorDestructionScrollItem : ScrollItem
    {
        public TrapDoorDestructionScrollItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<ScrollTrapDoorDestruction>()) { }
    }
}