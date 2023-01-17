namespace AngbandOS.Commands
{
    /// <summary>
    /// Equip an item
    /// </summary>
    [Serializable]
    internal class EquipCommand : Command
    {
        private EquipCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'e';

        public override bool Execute()
        {
            SaveGame.DoCmdEquip();
            return false;
        }
    }
}
