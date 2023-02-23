namespace AngbandOS.Core.Commands
{
    /// <summary>
    /// Equip an item
    /// </summary>
    [Serializable]
    internal class EquipInGameCommand : InGameCommand
    {
        private EquipInGameCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'e';

        public override bool Execute()
        {
            SaveGame.DoCmdEquip();
            return false;
        }
    }
}
