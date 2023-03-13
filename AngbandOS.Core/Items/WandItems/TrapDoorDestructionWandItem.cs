namespace AngbandOS.Core.Items
{
[Serializable]
    internal class TrapDoorDestructionWandItem : WandItem
    {
        public TrapDoorDestructionWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<WandTrapDoorDestruction>()) { }
    }
}